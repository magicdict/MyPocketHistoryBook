import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

//组件
import { AppComponent } from './app.component/app.component';
import { TreasurePageListComponent } from './treasure/TreasurePageList.component';
import { EventPageListComponent } from './treasure/EventPageList.component';
import { PersonagePageListComponent } from './treasure/PersonagePageList.component';
import { TreasureEditComponent } from './treasure/TreasureEdit.component';

//Third party component
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';


//服务
import { CommonFunction } from './common';
import { ITreasureResolver, IEventResolver, IPersonageResolver } from './resolve.service';


@NgModule({
  declarations: [
    AppComponent,
    TreasurePageListComponent,
    EventPageListComponent,
    PersonagePageListComponent,
    TreasureEditComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule,
    DialogModule
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
