import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DictatorService } from '../dictator.service';
import { Dictator } from '../interfaces/dictator';
import { TweetService } from '../tweet.service';

@Component({
  selector: 'app-dictator',
  templateUrl: './dictator.component.html',
  styleUrls: ['./dictator.component.css']
})
export class DictatorComponent implements OnInit {

  dictator: Dictator | null = null;
  routeId: string | null = "";

  constructor(public dicService: DictatorService, private tweetService: TweetService,
    private router: Router, private route: ActivatedRoute,
    private fb: FormBuilder, private http: HttpClient) {
    //Get the id from parameter
    this.route.paramMap.subscribe(params => {
      this.routeId = params.get("id");
    })

    dicService.dictatorObservable$.subscribe((dic: Dictator[]) => {
      //Get the information for the specific dictator requested in parameters
      let foundDic = dic.find(x => x.twitterKey == this.routeId);
      if (foundDic != undefined || foundDic != null) {
        this.dictator = foundDic;
      }

    })
  }

  updateDictatorForm = this.fb.group({
    name: ['', Validators.required],
    description: ['', [Validators.required, Validators.minLength(5)]],
  })

  ngOnInit(): void {
  }

  onPatch() {
    this.http.patch<Dictator>("https://localhost:44323/api/Dictator?id=" + this.routeId, {
      name: this.updateDictatorForm.get('name')?.value,
      description: this.updateDictatorForm.get('description')?.value,
      twitterKey: ""

    }).subscribe(data => {
      //Get the current list, and update the dictator to the new one without deleting tweets
      let updatedDictators = this.dicService.dictatorObservable$.getValue();
      let upDic = updatedDictators.find(x => x.twitterKey == data.twitterKey);
      if (upDic) {
        upDic.name = data.name;
        upDic.description = data.description;

        this.dicService.dictatorObservable$.next(updatedDictators);
      }
    }
    )
  }

  onDelete() {
    // Delete the dictator and update list this will only run if dictator is deleted, or it returns 404
    this.http.delete<boolean>("https://localhost:44323/api/Dictator?id=" + this.routeId).subscribe(data => {
      let updatedDictators = this.dicService.dictatorObservable$.getValue();
      let upDic = updatedDictators.find(x => x.twitterKey == this.routeId);

      if (upDic) {
        updatedDictators.splice(updatedDictators.indexOf(upDic, 0), 1)
        this.dicService.dictatorObservable$.next(updatedDictators);
        this.dictator = null;
        //Send user back to mainpage since there is no data to show
        this.router.navigate([''])
      }
    }
    )
  }


}
