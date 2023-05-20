import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/internal/Subject';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  private lastPageTitle = '';
  private pageTitleSubject = new Subject<string>();
  pageTitle = this.pageTitleSubject.asObservable();

  constructor() { }

  setPageTitle(title: string) {
    if (this.lastPageTitle == title) return;

    this.pageTitleSubject.next(title);
    this.lastPageTitle = title;
  }
}
