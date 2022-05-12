import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';
import { DictatorService } from './dictator.service';
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
      dictatorService.dictatorObservable.forEach(element => {
        if (element.twitterKey == data.Client) {
          element.tweets.next(data);
        }
      });
    });
    
  }

  getTweets() {


  }
}
