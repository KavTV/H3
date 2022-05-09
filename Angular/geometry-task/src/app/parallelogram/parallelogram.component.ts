import { Component, OnInit } from '@angular/core';
import { Parallelogram } from '../classes/parallelogram';

@Component({
  selector: 'app-parallelogram',
  templateUrl: './parallelogram.component.html',
  styleUrls: ['./parallelogram.component.css']
})
export class ParallelogramComponent implements OnInit {

  parallelogram: Parallelogram = new Parallelogram();
  area: number = 0;
  peremiter: number = 0;

  sideA: number = 0;
  sideB: number = 0;
  height: number = 0;

  constructor() {
  }

  ngOnInit(): void {
  }

  //WHEN INPUT IS CHANGED, CALCULATE THE AREA AND PEREMITER
  sideChanged(){
    this.parallelogram.sideA = this.sideA;
    this.parallelogram.sideB = this.sideB;
    this.parallelogram.height = this.height;
    this.area = this.parallelogram.calculateArea();
    this.peremiter = this.parallelogram.calculatePerimeter();
  }
}
