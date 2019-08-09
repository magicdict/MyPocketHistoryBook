import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPersonage } from '../interface/IPersonage';

@Component({
  templateUrl: 'PersonagePageList.component.html'
}) 
export class PersonagePageListComponent implements OnInit {
  constructor(private route: ActivatedRoute) {

  }
  personagelist: IPersonage[] = []; 
  ngOnInit(): void {
    this.route.data
      .subscribe((data: { personage: IPersonage[] }) => {
        this.personagelist = data.personage;
        this.personagelist.forEach(
          x => x.ImageName = escape(x.ImageName)
        );
      });
  }
}
