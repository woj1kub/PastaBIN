import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { PastaImagesService } from '../pasta-images.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PastaImageRequest } from '../model/pastaImageRequst.interface';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-new-pasta-image',
  templateUrl: './new-pasta-image.component.html',
  styleUrls: ['./new-pasta-image.component.css'],
  providers: [DatePipe]
})
export class NewPastaImageComponent {
  imageSrc: SafeUrl | undefined;
  key: string = '';
  formPastaImage: FormGroup;
  minDate: string;

  constructor(
    private servicePastaImage: PastaImagesService, 
    private fb: FormBuilder, 
    private sanitizer: DomSanitizer,
    private datePipe: DatePipe

  ) {
    const now = new Date();
    this.minDate = this.datePipe.transform(now, 'yyyy-MM-ddTHH:mm') || '';

    this.formPastaImage = this.fb.group({
      content: [null, Validators.required],
      date: [this.minDate, Validators.required]
    });
  }
  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.formPastaImage.patchValue({
        content: file
      });
      this.loadImage(file);
    }
  }

  loadImage(file: File) {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.imageSrc = this.sanitizer.bypassSecurityTrustUrl(reader.result as string);
    };
  }
  
  onSubmit(): void {
    if (this.formPastaImage.valid) {
      const formData = this.formPastaImage.value;
      
      const dateObject = new Date(formData.date);
      if (isNaN(dateObject.getTime())) {
        console.error('Invalid date format');
        return;
      }
      const file: File = formData.content;
      const reader = new FileReader();
  
      reader.onload = () => {
        const arrayBuffer: ArrayBuffer | null = reader.result as ArrayBuffer;
        if (arrayBuffer) {
          const byteArray = new Uint8Array(arrayBuffer);
          const pastaImageRequest: PastaImageRequest = {
            image: byteArray.toString(),
            deleteDate: dateObject
          };
          console.log(pastaImageRequest);
          
          this.servicePastaImage.addPastaImage(pastaImageRequest).subscribe({
            next: (Key: any) => {
              this.key = Key.key;
            },
            error: (error) => {
              console.error(error);
            }
          });
        } else {
          console.error("Błąd odczytu pliku");
        }
      };
  
      reader.readAsArrayBuffer(file);
    } else {
      console.log('Formularz jest niepoprawny');
    }
  }
  
  onDragOver(event: DragEvent) {
    event.preventDefault();
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    const file = event.dataTransfer?.files[0];
    if (file) {
      this.loadImage(file);
      this.formPastaImage.patchValue({
        content: file
      });
    }
  }
}
