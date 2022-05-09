import { Component, OnInit } from '@angular/core';
import { Trapez } from '../classes/trapez';

@Component({
  selector: 'app-trapez',
  templateUrl: './trapez.component.html',
  styleUrls: ['./trapez.component.css']
})
export class TrapezComponent implements OnInit {

  trapez: Trapez = new Trapez();
  area: number = 0;
  peremiter: number = 0;

  sideA: number = 0;
  sideB: number = 0;
  sideC: number = 0;
  sideD: number = 0;
  height: number = 0;

  constructor() {
  }

  ngOnInit(): void {
  }

  //WHEN INPUT IS CHANGED, CALCULATE THE AREA AND PEREMITER
  sideChanged(){
    this.trapez.sideA = this.sideA;
    this.trapez.sideB = this.sideB;
    this.trapez.height = this.height;
    this.trapez.sideC = this.sideC;
    this.trapez.sideD = this.sideD;
    this.area = this.trapez.calculateArea();
    this.peremiter = this.trapez.calculatePerimeter();
  }

}
