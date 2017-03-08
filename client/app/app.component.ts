import {Component} from'@angular/core'
import {CompanyService} from './company/company.service'

@Component({

    selector: 'app',
    templateUrl:'./app/app.component.html',
    providers : [CompanyService],
    styleUrls: ['./app/app.component.css']
})

export class AppComponent{
    pageTitle : string = "Company finder";


}