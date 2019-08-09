import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component/app.component';
import { TreasurePageListComponent } from './treasure/TreasurePageList.component';
import { EventPageListComponent } from './treasure/EventPageList.component';

//Third party component
import { TableModule } from 'primeng/table';

//服务
import { CommonFunction } from './common';
import { ITreasureResolver, IEventResolver, IPersonageResolver } from './resolve.service';
import { PersonagePageListComponent } from './treasure/PersonagePageList.component';


@NgModule({
  declarations: [
    AppComponent,
    TreasurePageListComponent,
    EventPageListComponent,
    PersonagePageListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule
  ],
  providers: [
    CommonFunction,
    ITreasureResolver,
    IEventResolver,
    IPersonageResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
