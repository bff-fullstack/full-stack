import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CrudComponent } from './crud/crud.component';
import { RestService } from './shared/rest.service';
import { HttpModule } from '@angular/http';
import {Safe} from './crud/safe-html.pipe';

@NgModule({
  declarations: [
    AppComponent,
    CrudComponent,
    Safe  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [RestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
