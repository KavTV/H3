import { Component, OnInit } from '@angular/core';
import { Rectangle } from '../classes/rectangle';

@Component({
  selector: 'app-rectangle',
  templateUrl: './rectangle.component.html',
  styleUrls: ['./rectangle.component.css']
})
export class RectangleComponent implements OnInit {

  rectangle: Rectangle = new Rectangle();

  constructor() {
  }

  ngOnInit(): void {
  }

}
