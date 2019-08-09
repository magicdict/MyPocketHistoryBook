import { Component, OnInit, ViewChild } from '@angular/core';
import { ITreasure } from '../interface/ITreasure';
import { ActivatedRoute } from '@angular/router';
import { TreasureEditComponent } from './TreasureEdit.component';

@Component({
  templateUrl: 'TreasurePageList.component.html'
})
export class TreasurePageListComponent implements OnInit {
  constructor(private route: ActivatedRoute) {

  }

  @ViewChild(TreasureEditComponent, { static: true })
  private editor: TreasureEditComponent;

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
