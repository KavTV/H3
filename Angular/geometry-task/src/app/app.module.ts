import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SquareComponent } from './square/square.component';
import { RectangleComponent } from './rectangle/rectangle.component';
import { ParallelogramComponent } from './parallelogram/parallelogram.component';
import { TrapezComponent } from './trapez/trapez.component';

@NgModule({
  declarations: [
    AppComponent,
    SquareComponent,
    RectangleComponent,
    ParallelogramComponent,
    TrapezComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
