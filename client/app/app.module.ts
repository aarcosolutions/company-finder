import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms'
import {HttpModule} from '@angular/http'
import { AppComponent } from './app.component';
import {CompanyListComponent} from './company/companyList.component';
import {CompanySearchComponent} from './company/companySearch.component';

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule],
    declarations: [AppComponent, CompanyListComponent, CompanySearchComponent],
    bootstrap: [AppComponent]
})

export class AppModule { }