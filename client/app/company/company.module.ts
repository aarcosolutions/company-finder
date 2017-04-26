import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'
import { HttpModule } from '@angular/http'
import { CompanyListComponent } from './companyList.component';
import { CompanySearchComponent } from './companySearch.component';
import { CompanyService } from './company.service'

@NgModule({
    declarations: [
        CompanyListComponent,
        CompanySearchComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    providers: [
        CompanyService
    ],
    exports: [
        CompanyListComponent,
        CompanySearchComponent
    ]
})
export class CompanyModule { }