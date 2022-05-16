import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DictatorService } from '../dictator.service';
import { Dictator } from '../interfaces/dictator';

@Component({
  selector: 'app-dictator',
  templateUrl: './dictator.component.html',
  styleUrls: ['./dictator.component.css']
})
export class DictatorComponent implements OnInit {

  dictator: Dictator = {} as Dictator;
  routeId: string | null = "";

  constructor(public dicService: DictatorService, private router: Router, private route: ActivatedRoute) {
    //Get the id from parameter
    this.route.paramMap.subscribe(params => {
      this.routeId = params.get("id");
    })

    dicService.dictatorObservable.subscribe((dic: Dictator[]) => {
      //Get the information for the specific dictator requested in parameters
      let foundDic = dic.find(x => x.twitterKey == this.routeId);
      if(foundDic != undefined || foundDic != null){
        this.dictator = foundDic;
      }
    })
   }


  ngOnInit(): void {

  }


}
