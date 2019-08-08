import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Treasure } from './treasure/treasure.component';
import { TreasureService } from './resolve.service';


const routes: Routes = [
  { path: 'treasure', component: Treasure, resolve: TreasureService },
  { path: '', component: Treasure },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
