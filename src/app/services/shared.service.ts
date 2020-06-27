import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private sub = new Subject();
  subj$ = this.sub.asObservable();

  send(value: any) {
    this.sub.next(value);
  }

}
