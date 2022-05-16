import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';
import { DictatorService } from './dictator.service';
import { Dictator } from './interfaces/dictator';
import { TwitterMessage } from './interfaces/twitter-message';

@Injectable({
  providedIn: 'root'
})
export class TweetService {
  myWebSocket: WebSocketSubject<TwitterMessage> = webSocket('ws://127.0.0.1:7890/tweet');

  constructor(private dictatorService: DictatorService) {

    //Subscribe to the websocket, and send the tweet to the correct dictator
    this.myWebSocket.asObservable().subscribe((data) => {
      next:
      dictatorService.dictatorObservable.subscribe((dicData: Dictator[]) => {
        dicData.forEach(dic => {

          if (data != null && dic.twitterKey == data.Client) {

            console.log("TWEET DATA", data.Client);
            if(dic.tweets == null){
              dic.tweets = new BehaviorSubject<TwitterMessage[]>([] as TwitterMessage[]);
            }            
            
            let newTweetList: TwitterMessage[] = dic.tweets.getValue();
            newTweetList.push(data);
            dic.tweets.next(newTweetList);
          }
        })
      });

    });

  }

  getTweets() {


  }
}
