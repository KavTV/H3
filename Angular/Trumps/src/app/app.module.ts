import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { TweetsComponent } from './tweets/tweets.component';
import { TextReplacerPipe } from './text-replacer.pipe';

@NgModule({
  declarations: [
    AppComponent,
    TweetsComponent,
    TextReplacerPipe
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
