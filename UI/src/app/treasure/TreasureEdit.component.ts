import { Component, Output, EventEmitter } from '@angular/core';
import { ITreasure } from '../interface/ITreasure';

@Component({
  selector:"TreasureEdit",
  templateUrl: 'TreasureEdit.component.html'
})
export class TreasureEditComponent {
  constructor() {

  }
  @Output() pick: EventEmitter<any> = new EventEmitter();
  public display = false;
  treasure: ITreasure;

  CloseMe(){
    this.pick.emit(this.treasure);
    this.display = false;
  }
}
