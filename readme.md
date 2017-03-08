# Company Finder

The best way to learn a technology is to get your hands dirty. Hence I started developing Company Finder. The purpose of this application is to retrieve information about limited companies which are based in United Kingdom. I have implemented this application using:

* [Angular2] (https://angular.io/)
* [ASP.NET Core] (https://docs.microsoft.com/en-us/aspnet/core/)
* [TypeScript] (https://www.typescriptlang.org/)
* [Companies House API] (https://developer.companieshouse.gov.uk/api/docs/index/gettingStarted.html)


The application design is very simple. I have tried to explain it in the following diagram:

![high-level-desigh](https://github.com/aarcosolutions/company-finder/blob/master/diagrams/highlevel-design.jpg)

The website consist of three angular components and a service which retrieve data from CompanyFinder Api. Following diagram will give you an idea of the angular components

![angular-component-interaction](https://github.com/aarcosolutions/company-finder/blob/master/diagrams/angular-component-interaction.jpg)

I have hosted this application in Azure. You can see the demo site at [Company Finder](http://companysearch.azurewebsites.net/)

---

##Steps for configuring this code locally:

Software requirement:
* [nodejs - v7.7.1](https://nodejs.org/dist/v7.7.1/node-v7.7.1-x64.msi)
* [ASP.NET Core 1.1.1 SDK](https://go.microsoft.com/fwlink/?linkid=843448)
* Text Editor of your choice. I have used Visual Studio code and Visual Studion 2017 Professional

### Running Company Finder website:

Clone the repository locally. Open command prompt and navigate to "client" folder in the location where the repository is cloned.
Restore node dependencies by executing:
> npm install

Run the CompanyFinder website by executing:
> npm start

### Running Company Finder API:

Clone the repository locally. Open command prompt and navigate to "api" folder in the location where the repository is cloned.
Restore nuget packages:
> dotnet restore

Run the CompanyFinder API by executing:
> dotnet run

### Config changes:

* You will have to update the base url of CompanyFinder API. It is specified in **client/app/company/company.service.ts** file. Update the value of **_companySearchUrl** property.

* You will also have to udate the Companies House API key in the CompanyFinder API project. It is specified in **api/companyHouseConfig.json**. Update the value of **ApiKey** property. You will have to register with Companies House Developer Hub to obtain the API key.




