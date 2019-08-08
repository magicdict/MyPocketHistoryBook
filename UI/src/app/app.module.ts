import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component/app.component';
import { Treasure } from './treasure/treasure.component';

//Third party component
import { TableModule } from 'primeng/table';
import { CommonFunction } from './common';
import { ITreasureResolver } from './resolve.service';


@NgModule({
  declarations: [
    AppComponent,
    Treasure
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule
  ],
  providers: [
    CommonFunction,
    ITreasureResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
