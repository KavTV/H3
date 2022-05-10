import { Component, OnInit } from '@angular/core';
import { Shape } from '../classes/shape';

@Component({
  selector: 'app-square',
  templateUrl: './square.component.html',
  styleUrls: ['./square.component.css']
})
export class SquareComponent implements OnInit  {

  shape: Shape = new Shape();

  constructor() {
  }

  ngOnInit(): void {
  }
  

}
