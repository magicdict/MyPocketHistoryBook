import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TreasurePageListComponent } from './treasure/TreasurePageList.component';
import { ITreasureResolver, IEventResolver, IPersonageResolver } from './resolve.service';
import { EventPageListComponent } from './treasure/EventPageList.component';
import { PersonagePageListComponent } from './treasure/PersonagePageList.component';


const routes: Routes = [
  { path: 'treasure', component: TreasurePageListComponent, resolve: { treasure: ITreasureResolver } },
  { path: 'event', component: EventPageListComponent, resolve: { event: IEventResolver } },
  { path: 'personage', component: PersonagePageListComponent, resolve: { personage: IPersonageResolver } },
  { path: '', redirectTo: 'treasure', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
