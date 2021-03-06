import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http'
import { AppComponent } from './app.component';
import { CompanyModule } from './company/company.module';

@NgModule({
    imports: [BrowserModule, HttpModule, CompanyModule],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})

export class AppModule { }