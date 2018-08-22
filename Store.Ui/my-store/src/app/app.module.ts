import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { API_BASE_URL, ProductServiceProxy } from '../shared/service-proxies/service-proxies';
import { AppConsts } from '../shared/AppConsts';
import { HttpClientModule } from '@angular/common/http';

export function getRemoteServiceBaseUrl(): string {
  return AppConsts.remoteServiceBaseUrl;
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    ProductServiceProxy,
    { provide: API_BASE_URL, useFactory: getRemoteServiceBaseUrl }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
