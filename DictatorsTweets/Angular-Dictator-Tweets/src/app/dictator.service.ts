import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Dictator } from './interfaces/dictator';

@Injectable({
  providedIn: 'root'
})
export class DictatorService {

  dictatorObservable: BehaviorSubject<Dictator> = new BehaviorSubject<Dictator>({} as Dictator)

  constructor(private http: HttpClient) {
    this.http.get<Dictator>("https://localhost:44323/api/Dictator").subscribe((data: Dictator) =>
      {
        this.dictatorObservable.next(data);
      }
    
    )
  }
}
