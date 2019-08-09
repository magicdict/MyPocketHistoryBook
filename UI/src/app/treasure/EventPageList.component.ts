import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IEvent } from '../interface/IEvent';

@Component({
  templateUrl: 'EventPageList.component.html'
})
export class EventPageListComponent implements OnInit {
  constructor(private route: ActivatedRoute) {

  }
  eventlist: IEvent[] = []; 
  ngOnInit(): void {
    this.route.data
      .subscribe((data: { event: IEvent[] }) => {
        this.eventlist = data.event;
        this.eventlist.forEach(
          x => x.ImageName = escape(x.ImageName)
        );
      });
  }
}
