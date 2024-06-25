import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PastaTextsService } from '../pasta-texts.service';
import { PastaTextRequest } from '../model/pastaTextRequst.interface';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-new-pasta-text',
  templateUrl: './new-pasta-text.component.html',
  styleUrls: ['./new-pasta-text.component.css'],
  providers: [DatePipe]
})
export class NewPastaTextComponent implements OnInit {
  formPastaText!: FormGroup;
  key: string = '';
  minDate: string;

  constructor(
    private fb: FormBuilder,
    private servicePastaText: PastaTextsService,
    private datePipe: DatePipe
  ) { 
    const now = new Date();
    this.minDate = this.datePipe.transform(now, 'yyyy-MM-ddTHH:mm') || '';
  }

  ngOnInit(): void {
    this.formPastaText = this.fb.group({
      content: ['', Validators.required],
      date: [this.minDate, Validators.required]
    });
  }
  
  onSubmit(): void {
    if (this.formPastaText.valid) {
      const formData = this.formPastaText.value;

      const dateObject = new Date(formData.date);
      if (isNaN(dateObject.getTime())) {
        console.error('Invalid date format');
        return;
      }
      
      const pastaTextRequest: PastaTextRequest = {
        content: formData.content,
        deleteDate: dateObject
      };
      console.log(formData.date);
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
