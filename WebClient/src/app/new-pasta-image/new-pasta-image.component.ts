import { Component } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { PastaImagesService } from '../pasta-images.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PastaImageRequest } from '../model/pastaImageRequst.interface';

@Component({
  selector: 'app-new-pasta-image',
  templateUrl: './new-pasta-image.component.html',
  styleUrls: ['./new-pasta-image.component.css']
})
export class NewPastaImageComponent {
  imageSrc: SafeUrl | undefined;
  
  formPastaImage!: FormGroup;
  key: string = '';
  constructor(private servicePastaImage: PastaImagesService, private fb: FormBuilder, private sanitizer: DomSanitizer) {}

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.formPastaImage.patchValue({
        content: file
      });
      this.loadImage(file);
    }
  }

  loadImage(file: File | undefined) {
    if (file) {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.imageSrc = this.sanitizer.bypassSecurityTrustUrl(reader.result as string);
      };
    }
  }

  ngOnInit(): void {
    this.formPastaImage = this.fb.group({
      content: [null, Validators.required],
      date: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.formPastaImage.valid) {
      const formData = this.formPastaImage.value;
      const pastaImageRequest: PastaImageRequest = {
        image: formData.content,
        deleteDate: formData.date
      };
      this.servicePastaImage.addPastaImage(pastaImageRequest, null).subscribe((response: string) => {
        this.key = response;
      }, (error) => {
        console.error(error);
      });
    } else {
      console.log('Form is invalid');
    }
  }

  onDragOver(event: DragEvent) {
    event.preventDefault();
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    const file = event.dataTransfer?.files[0];
    this.loadImage(file);
    if (file) {
      this.formPastaImage.patchValue({
        content: file
      });
    }
  }
}
