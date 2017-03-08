# Company Finder

The best way to learn a technology is to get your hands dirty. Hence I started developing Company Finder. The purpose of this application is to retrieve information about limited companies which are based in United Kingdom. I have implemented this application using:

* [Angular2] (https://angular.io/)
* [ASP.NET Core] (https://docs.microsoft.com/en-us/aspnet/core/)
* [TypeScript] (https://www.typescriptlang.org/)
* [Company House API] (https://developer.companieshouse.gov.uk/api/docs/index/gettingStarted.html)


The application design is very simple. I have tried to explain it in the following diagram:

![high-level-desigh](https://github.com/aarcosolutions/company-finder/blob/master/diagrams/highlevel-design.jpg)

The website consist of three angular components and a service which retrieve data from CompanyFinder Api. Following diagram will give you an idea of the angular components

![angular-component-interaction](https://github.com/aarcosolutions/company-finder/blob/master/diagrams/angular-component-interaction.jpg)

I have hosted this application in Azure. You can see the demo site at [Company Finder](http://companysearch.azurewebsites.net/)

---

##Steps on how to configure the code locally?

First you will need to clone this repository
> git clone https://github.com/aarcosolutions/company-finder.git
