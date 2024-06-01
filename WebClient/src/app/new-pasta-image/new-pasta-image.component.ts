import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { PastaImagesService } from '../pasta-images.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PastaImageRequest } from '../model/pastaImageRequst.interface';

@Component({
  selector: 'app-new-pasta-image',
  templateUrl: './new-pasta-image.component.html',
  styleUrls: ['./new-pasta-image.component.css']
})
export class NewPastaImageComponent implements OnInit  {
  imageSrc: SafeUrl | undefined;
  key: string = '';
  formPastaImage: FormGroup;

  constructor(
    private servicePastaImage: PastaImagesService, 
    private fb: FormBuilder, 
    private sanitizer: DomSanitizer
  ) {
    this.formPastaImage = this.fb.group({
      content: [null, Validators.required],
      date: ['', Validators.required]
    });
  }
  
  ngOnInit(): void {}

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
      
      const file: File = formData.content;
      const reader = new FileReader();
  
      reader.onload = () => {
        const arrayBuffer: ArrayBuffer | null = reader.result as ArrayBuffer;
        if (arrayBuffer) {
          const byteArray = new Uint8Array(arrayBuffer);
          const pastaImageRequest: PastaImageRequest = {
            image: byteArray.toString(),
            deleteDate: formData.date
          };
          console.log(pastaImageRequest);
          
          this.servicePastaImage.addPastaImage(pastaImageRequest, 0).subscribe({
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
