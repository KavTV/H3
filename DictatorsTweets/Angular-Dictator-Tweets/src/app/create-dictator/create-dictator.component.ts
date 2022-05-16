import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, Validators } from '@angular/forms';
import { Dictator } from '../interfaces/dictator';

@Component({
  selector: 'app-create-dictator',
  templateUrl: './create-dictator.component.html',
  styleUrls: ['./create-dictator.component.css']
})
export class CreateDictatorComponent implements OnInit {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  dictatorForm = this.fb.group({
    name: ['', Validators.required],
    description: ['', [Validators.required, Validators.minLength(5)]],
  })

  updateDictatorForm = this.fb.group({
    name: ['', Validators.required],
    newName:['', Validators.required],
    description: ['', [Validators.required, Validators.minLength(5)]],
  })


  ngOnInit(): void {

  }

  onSubmit() {
    let newDictator: Dictator = {} as Dictator;
    newDictator.name = this.dictatorForm.get('name')?.value;
    newDictator.description = this.dictatorForm.get('description')?.value;

    //send a post request to api, for creation
    this.http.post<Dictator>("https://localhost:44323/api/Dictator?dictatorName=jenfffs&Description=hej", {
      name: newDictator.name,
      description: newDictator.description,
      twitterKey: ""
    }).subscribe((data: Dictator) =>
      console.log(data)
    )
  }

  onPatch(){
    this.http.patch<Dictator>("https://localhost:44323/api/Dictator?dictatorName=jenfffs&Description=hej",{
      dictatorName: this.updateDictatorForm.get('name')?.value,
      newDicName: this.updateDictatorForm.get('newName')?.value,
      newDesc: this.updateDictatorForm.get('description')?.value

    }).subscribe(data =>
    console.log(data)
    )
  }

}
