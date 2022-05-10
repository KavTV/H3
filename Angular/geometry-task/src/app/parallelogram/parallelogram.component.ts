import { Component, OnInit } from '@angular/core';
import { Parallelogram } from '../classes/parallelogram';

@Component({
  selector: 'app-parallelogram',
  templateUrl: './parallelogram.component.html',
  styleUrls: ['./parallelogram.component.css']
})
export class ParallelogramComponent implements OnInit {

  parallelogram: Parallelogram = new Parallelogram();

  constructor() {
  }

  ngOnInit(): void {
  }

}
