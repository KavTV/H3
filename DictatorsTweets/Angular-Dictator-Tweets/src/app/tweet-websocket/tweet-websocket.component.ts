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
export class TweetWebsocketComponent implements OnInit {

  constructor(private http: HttpClient, public dicService: DictatorService, private tweetService: TweetService) {
  }

  ngOnInit(): void {
  }

}
