import { Component, OnInit } from '@angular/core';
import { ITreasure } from '../interface/ITreasure';
import { ActivatedRoute } from '@angular/router';

@Component({
  templateUrl: 'TreasurePageList.component.html'
})
export class TreasurePageListComponent implements OnInit {
  constructor(private route: ActivatedRoute) {

  }
  treasurelist: ITreasure[] = [];
  ngOnInit(): void {
    this.route.data
      .subscribe((data: { treasure: ITreasure[] }) => {
        this.treasurelist = data.treasure;
        this.treasurelist.forEach(
          x => x.ImageName = escape(x.ImageName)
        );
      });
  }
}