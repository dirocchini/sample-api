# Sample Api
![.NET Core](https://github.com/dirocchini/sample-api/workflows/.NET%20Core/badge.svg) 
[![Build Status](https://rocchini.visualstudio.com/SampleApi/_apis/build/status/dirocchini.sample-api?branchName=master)](https://rocchini.visualstudio.com/SampleApi/_build/latest?definitionId=1&branchName=master)

<br/>

This is a sample api using ASP.NET Core 3.1, CQRS with MediatR, Microsoft Sql Server or In Memory and a lot of fun things like swagger and JWT, following the principles of Clean Architecture. 

## Technologies
* .NET Core 3.1
* Entity Framework Core 3.1
* MediatR
* AutoMapper
* FluentValidation
* Swagger
* xUnit, Moq, Expected Objects, Bogus

## Getting Started
The easiest way to get started is to install Docker in your computer and:

1. Navigate to root folder
2. Run the command `docker-compose run -d`
3. It will download all necessary components and, after all...
4. Just access http://localhost:8080 to check if it's working fine

### Database Configuration
This solution is configured to use a in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you would like to use SQL Server, you will need to update **WebApi/appsettings.{ENVIRONMENT}.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DbConnection** connection details within **appsettings.{ENVIRONMENT}.json** points to a valid SQL Server instance. 

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

If you use docker you don't need to change any configuration in sql server settings

### Testing
You can check all API endpoints at http://localhost:8080/swagger. Thanks [Swagger](https://github.com/swagger-api)

There is a file **simple-api.postman_collection.json** containing all possible consuming api endpoint, with data, for using with Postman v7.24.0.
