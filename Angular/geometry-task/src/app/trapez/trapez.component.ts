import { Component, OnInit } from '@angular/core';
import { Trapez } from '../classes/trapez';

@Component({
  selector: 'app-trapez',
  templateUrl: './trapez.component.html',
  styleUrls: ['./trapez.component.css']
})
export class TrapezComponent implements OnInit {

  trapez: Trapez = new Trapez();

  constructor() {
  }

  ngOnInit(): void {
  }

  //WHEN INPUT IS CHANGED, CALCULATE THE AREA AND PEREMITER
  //Removed since i can just use the method as interpolation in html
  // sideChanged(){
  //   this.area = this.trapez.calculateArea();
  //   this.peremiter = this.trapez.calculatePerimeter();
  // }

}
