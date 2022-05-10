import { Component, OnInit } from '@angular/core';
import { Tweet } from '../tweet';
import { TweetsService } from '../tweets.service';

@Component({
  selector: 'app-tweets',
  templateUrl: './tweets.component.html',
  styleUrls: ['./tweets.component.css']
})
export class TweetsComponent implements OnInit {



  twat: Tweet[];
  constructor(tService: TweetsService) {
       this.twat = tService.tweets;
       console.log(this.twat.length);
   }

  ngOnInit() {
  }

  isAngryTweet(text: string) : boolean{
    //In every tweet where an ! is shown, the tweet is considered angry
    return text.search('!') != -1
  }

  isHappyTweet(text: string): boolean{
    return text.search('God') != -1 || text.search("happy") != -1;
  }

}
