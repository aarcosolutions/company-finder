"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var company_service_1 = require("./company.service");
var CompanySearchComponent = (function () {
    function CompanySearchComponent(_service) {
        this._service = _service;
        this.keyword = "";
        this.searchResultCompleted = new core_1.EventEmitter();
    }
    CompanySearchComponent.prototype.search = function (searchTerm) {
        var _this = this;
        this._service.getCompanies(this.keyword)
            .subscribe(function (companies) { return _this.companies = companies; }, function (error) { return _this.errorMessage = error; }, function () { _this.searchResultCompleted.emit(_this.companies); });
    };
    return CompanySearchComponent;
}());
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], CompanySearchComponent.prototype, "searchResultCompleted", void 0);
CompanySearchComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: "company-search",
        templateUrl: "./companySearch.component.html"
    }),
    __metadata("design:paramtypes", [company_service_1.CompanyService])
], CompanySearchComponent);
exports.CompanySearchComponent = CompanySearchComponent;
//# sourceMappingURL=companySearch.component.js.map