import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TweetWebsocketComponent } from './tweet-websocket/tweet-websocket.component';
import { DictatorComponent } from './dictator/dictator.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CreateDictatorComponent } from './create-dictator/create-dictator.component';



@NgModule({
  declarations: [
    AppComponent,
    TweetWebsocketComponent,
    DictatorComponent,
    CreateDictatorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
