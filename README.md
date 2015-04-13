# README #

This project contains the a ASP.Net WebApi 2.x boilder plate by [Mike Stokes](http://mikestokes.co).

### Summary ###

* Visual Studio 2012+ Solution
* Version 0.4
* Build all and required NuGet packages will be installed

### Installation ***

1. Clone this repository locally (or fork it and commit back)
2. Open the solution in Visual Studio
3. Re-build all to force Nuget to download required packages.
4. Run the Boilerplate project OR run the tests in the Tests project.

### Calling the APIs ###

1. The demo is set to run on localhost port 54563 (set in the projects properties->web tab).
2. When the app runs you can use a REST client like Postman (for Chrome) to call the API:

- GET http://localhost:54563/api/v1/bom/1111

- POST  http://localhost:54563/api/v1/bom

Headers

```
Content-Type: application/json
Accept: application/json
```

Body

```
{  "firstName": "Mike",  "lastName": "Stokes"}
```

You should receive back an echo of the input object.

### How to run tests ###

* Tests can simply be run using the Microsoft Unit Testing tools from the command line or from within Visual Studio - using Test Explorer.

### Deployment ###

* IIS 7.5 >
* Integrated Pipeline
* .NET Framework 4.5 >
* App_Data folder permissions for logging


