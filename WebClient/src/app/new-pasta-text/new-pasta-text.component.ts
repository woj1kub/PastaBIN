import { Component } from '@angular/core';
import { PastaTextsService } from '../pasta-texts.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PastaTextRequest } from '../model/pastaTextRequst.interface';

@Component({
  selector: 'app-new-pasta-text',
  templateUrl: './new-pasta-text.component.html',
  styleUrl: './new-pasta-text.component.css'
})
export class NewPastaTextComponent {

  formPastaText!: FormGroup;
  key!:string;
  constructor(private fb: FormBuilder, private servicePastaText:PastaTextsService) { }

  ngOnInit(): void {
    this.formPastaText = this.fb.group({
      content: ['', Validators.required],
      date: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.formPastaText.valid) {
      const formData = this.formPastaText.value;
      //console.log('Form data:', formData);
      const pastaTextRequest: PastaTextRequest = {
        content: formData.content,
        deleteDate: formData.date
      };
      this.servicePastaText.addPastaText(pastaTextRequest).subscribe((responce:string)=>{
        this.key=responce;
      },(error)=>{
        console.error(error)
      }
    );
      
    } else {
      console.log('Form is invalid');
    }
  }

}
