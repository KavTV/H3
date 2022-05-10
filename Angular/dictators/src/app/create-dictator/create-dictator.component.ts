import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Dictator } from '../classes/dictator';

@Component({
  selector: 'app-create-dictator',
  templateUrl: './create-dictator.component.html',
  styleUrls: ['./create-dictator.component.css']
})
export class CreateDictatorComponent implements OnInit {


  constructor(private fb: FormBuilder) { 
  }

  dictatorForm = this.fb.group({
    firstName: ['',Validators.required],
    lastName: ['',Validators.required],
    birthYear: ['',Validators.required],
    deathYear: ['',Validators.required],
    description: ['', [Validators.required, Validators.minLength(5)]],
  })

  dictatorList: Array<Dictator> = new Array<Dictator>();

  ngOnInit(): void {
  }

  onDelete(dic: Dictator){
    // this.dictatorList = this.dictatorList.filter(item => item != dic)
    let foundDic = this.dictatorList.findIndex(toFind => toFind == dic);
    this.dictatorList.splice(foundDic,1);
  }

  onSubmit(){
    console.log(this.dictatorForm.get('firstName')?.value)
    let newDictator = new Dictator();
    newDictator.FirstName = this.dictatorForm.get('firstName')?.value;
    newDictator.LastName = this.dictatorForm.get('lastName')?.value;
    newDictator.BirthYear = this.dictatorForm.get('birthYear')?.value;
    newDictator.DeathYear = this.dictatorForm.get('deathYear')?.value;
    newDictator.Description = this.dictatorForm.get('description')?.value;

    this.dictatorList.push(newDictator);
  }

}
