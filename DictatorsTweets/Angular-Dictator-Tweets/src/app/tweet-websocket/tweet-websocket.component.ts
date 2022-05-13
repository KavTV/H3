import { Component, Injectable, OnInit } from '@angular/core';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket'
import { TwitterMessage } from '../interfaces/twitter-message';
import { HttpClient } from '@angular/common/http'
import { Dictator } from '../interfaces/dictator';
import { TweetService } from '../tweet.service';
import { DictatorService } from '../dictator.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-tweet-websocket',
  templateUrl: './tweet-websocket.component.html',
  styleUrls: ['./tweet-websocket.component.css']
})
@Injectable()
export class TweetWebsocketComponent implements OnInit {


  constructor(private http: HttpClient, public dicService: DictatorService, private tweetService: TweetService) {

  }

  ngOnInit(): void {
    // this.dicService.dictatorObservable.subscribe((data: Dictator) => {
    //   next:

    // })
    // this.http.get<Dictator>("https://localhost:44323/api/Dictator").subscribe(data =>
    //   console.log(data)
    // )
    // this.http.post<Dictator>("https://localhost:44323/api/Dictator?dictatorName=jenfffs&Description=hej","").subscribe(data =>
    // console.log(data)
    // )
  }

}
