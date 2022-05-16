import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DictatorComponent } from './dictator/dictator.component';
import { TweetWebsocketComponent } from './tweet-websocket/tweet-websocket.component';

const routes: Routes = [
  { path: '', component: TweetWebsocketComponent },
  { path: 'dictator/:id', component: DictatorComponent },
  { path: '**',
    redirectTo: '/red',
    pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
