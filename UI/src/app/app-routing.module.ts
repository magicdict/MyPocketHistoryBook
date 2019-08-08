import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Treasure } from './treasure/treasure.component';
import { ITreasureResolver } from './resolve.service';


const routes: Routes = [
  {
    path: 'treasure', component: Treasure, resolve: {
      treasure: ITreasureResolver
    }
  },
  { path: '', redirectTo: 'treasure', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
