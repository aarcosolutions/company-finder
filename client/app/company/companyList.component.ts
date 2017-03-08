import {Component} from '@angular/core'
import {ICompany} from './ICompany'
@Component({
    moduleId        :   module.id,
    selector        :   "company-list",
    templateUrl     :   "./companyList.component.html"
    // providers       :   [ CompanySearchService ]
})

export class CompanyListComponent {
    companies : ICompany[]
    onSearchResultCompleted(companies: ICompany[]): void{
        this.companies = companies;
    }
}