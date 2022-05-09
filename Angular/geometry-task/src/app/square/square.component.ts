import { Component, OnInit } from '@angular/core';
import { Shape } from '../classes/shape';

@Component({
  selector: 'app-square',
  templateUrl: './square.component.html',
  styleUrls: ['./square.component.css']
})
export class SquareComponent implements OnInit  {

  shape: Shape = new Shape();
  area: number = 0;
  peremiter: number = 0;

  constructor() {
  }

  ngOnInit(): void {
  }

  sideChanged(){
    this.shape.sideA = 1
    this.area = this.shape.calculateArea()
  }

}
