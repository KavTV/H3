import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TweetWebsocketComponent } from './tweet-websocket.component';

describe('TweetWebsocketComponent', () => {
  let component: TweetWebsocketComponent;
  let fixture: ComponentFixture<TweetWebsocketComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TweetWebsocketComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TweetWebsocketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
