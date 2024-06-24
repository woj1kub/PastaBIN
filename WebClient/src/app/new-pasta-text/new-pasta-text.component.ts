import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PastaTextsService } from '../pasta-texts.service';
import { PastaTextRequest } from '../model/pastaTextRequst.interface';

@Component({
  selector: 'app-new-pasta-text',
  templateUrl: './new-pasta-text.component.html',
  styleUrls: ['./new-pasta-text.component.css']
})
export class NewPastaTextComponent implements OnInit {
  formPastaText!: FormGroup;
  key: string = '';

  constructor(private fb: FormBuilder, private servicePastaText: PastaTextsService) { }

  ngOnInit(): void {
    this.formPastaText = this.fb.group({
      content: ['', Validators.required],
      date: ['', Validators.required]
    });
  }
  
  onSubmit(): void {
    if (this.formPastaText.valid) {
      const formData = this.formPastaText.value;
      const pastaTextRequest: PastaTextRequest = {
        content: formData.content,
        deleteDate: formData.date
      };
      this.servicePastaText.addPastaText(pastaTextRequest).subscribe({
        next: (Key: any) => {
          this.key = Key.key;
        },
        error: (error) => {
          console.error(error);
        }
      });            
    } else {
      console.log('Form is invalid');
    }
  }
}
