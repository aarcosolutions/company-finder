import { Component, Output, EventEmitter } from '@angular/core';
import { ICompany } from './ICompany'
import { CompanyService } from './company.service'

@Component({
    moduleId: module.id,
    selector: "company-search",
    templateUrl: "./companySearch.component.html"
})

export class CompanySearchComponent {
    keyword: string = "";
    companies: ICompany[];
    errorMessage: string;
    @Output() searchResultCompleted: EventEmitter<ICompany[]> = new EventEmitter<ICompany[]>();

    constructor(private _service: CompanyService) {
    }

    search(searchTerm: string) {
        this._service.getCompanies(this.keyword)
            .subscribe(
            companies => this.companies = companies,
            error => this.errorMessage = <any>error,
            () => { this.searchResultCompleted.emit(this.companies) }
            );
    }
}