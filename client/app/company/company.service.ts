import {Injectable} from '@angular/core';
import {Http, Response} from '@angular/http';
import {ICompany} from './ICompany';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/do'
import 'rxjs/add/operator/catch'

@Injectable()
export class CompanyService{

    private _companySearchUrl = 'http://companysearchapi.azurewebsites.net/api/search/'
    constructor(private _http : Http){

    }

    getCompanies(keyword : string) : Observable<ICompany[]>{
        return  this._http.get(this._companySearchUrl + keyword)
                            .map((response : Response) => <ICompany[]>response.json())
                            .do(data=> console.log('ALL : ' + JSON.stringify(data)))
                            .catch(this.handlerError);
    }

    private handlerError(error : Response)
    {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}