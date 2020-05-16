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

## Database Configuration
This solution is configured to use a Microsoft sql database by default. 

If you would like to use In Memory, there is a key to be updated in **WebApi/appsettings.{ENVIRONMENT}.json** as follows:

```json
  "UseInMemoryDatabase": true,
```
(This ensures that all users will be able to run the solution without needing to set up additional infrastructure)

Verify that the **DbConnection** connection details within **appsettings.{ENVIRONMENT}.json** points to a valid SQL Server instance. 

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

## Getting Started
The easiest way to get started is to install Docker in your computer and:

1. Navigate to root folder
   - Run the command `docker-compose run -d` << this will setup the environment using Microsoft Sql Server
   - Run the command `docker-compose -f docker-compose-in-mem.yml up -d` << this will setup the environment using in memory database
2. Docker compose will download all necessary components and, after all...
3. Just access http://localhost:8080 to check if it's working fine

## Testing
You can check all API endpoints at http://localhost:8080/swagger. Thanks [Swagger](https://github.com/swagger-api)

There is a file **simple-api.postman_collection.json** containing all possible consuming api endpoint, with data, for using with Postman v7.24.0.

A initial user to authenticate is provider under the following credentials email: admin@domain.com and password: 123

Most of api endpoints requires a token authentication (supplied by http://localhost:5000/user/auth endpoint). Add this token in you header request (see postman file for more details).
