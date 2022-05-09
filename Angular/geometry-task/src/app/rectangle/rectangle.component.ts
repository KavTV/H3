import { Component, OnInit } from '@angular/core';
import { Rectangle } from '../classes/rectangle';

@Component({
  selector: 'app-rectangle',
  templateUrl: './rectangle.component.html',
  styleUrls: ['./rectangle.component.css']
})
export class RectangleComponent implements OnInit {

  rectangle: Rectangle = new Rectangle();
  area: number = 0;
  peremiter: number = 0;

  sideA: number = 0;
  sideB: number = 0;

  constructor() {
  }

  ngOnInit(): void {
  }

  //WHEN INPUT IS CHANGED, CALCULATE THE AREA AND PEREMITER
  sideChanged(){
    this.rectangle.sideA = this.sideA;
    this.rectangle.sideB = this.sideB;
    this.area = this.rectangle.calculateArea();
    this.peremiter = this.rectangle.calculatePerimeter();
  }

}
