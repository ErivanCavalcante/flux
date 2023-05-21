import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { AppService } from '../../services/app.service.';

@Component({
  selector: 'app-host-page',
  templateUrl: './host-page.component.html',
  styleUrls: ['./host-page.component.scss']
})
export class HostPageComponent implements OnInit {
  currentPageTitle: string = '';

  constructor(private appService: AppService, private changeDetectorRef: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.appService.pageTitle.subscribe(title => {
      this.currentPageTitle = title;
    });

    this.changeDetectorRef.detectChanges();
  }
}
