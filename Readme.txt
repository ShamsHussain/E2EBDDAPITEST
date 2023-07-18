----------------------------------------------------
Behavioral-Driven Development API Framework 
----------------------------------------------------
C# quickstart project for automation that covers Rest Based API testing and assertions including status codes along with 
response body assertion. It is capable and improved framework to automate end-to-end business workflows on service level. 

Concept Included:
----------------

1. Dependancy Injection
2. Parallel Test runs
3. Token Authentication 
4. Fluent Assertion
5. User Secrets
6. Shared Step Definitions
7. Common Business Class
8. Common Utility Classes

Tools and Packages: 
-------------------
Faker.Net (2.0.154) - Generate Fake Data 
FluentAssertions (6.10.0)
Microsoft.Extensions.Configuration (7.0.0)
Microsoft.Extenstions.Configuration.Abbstractions (7.0.0)
Microsoft.Extenstions.Configuration.Binder (7.0.4)
Microsoft.Extenstions.Configuration.EnvironmentVariables (7.0.0)
Microsoft.Extenstions.Configuration.FileExtensions (7.0.0)
Microsoft.Extenstions.Configuration.Json (7.0.0)
Microsoft.Extenstions.Configuration.UserSecrets (7.0.0)
Microsoft.Extenstions.DependencyInjection (7.0.0)
Microsoft.Extenstions.Options.ConfigurationExtensions (7.0.0)
Microsoft.NET.Test.Sdk (17.4.1)
Newtonsoft.Json.Schema (3.0.14)
RestSharp (109.0.1)
SolidToken.SpecFlow.DependancyInjection (3.9.3)
SpecFlow.Plus.LivingDocPlugin (3.9.57)
SpecFlow.xUnit (3.9.74)
xunit (2.4.2)
xunit.runner.visualstudio (2.4.5)

Requirements: 
-------------
In Order to utilise this project you need to update and have latest above nuget packages

Usage: 
-----
The porject has following structure and purpose description

- Configuration 
-- AuthConfig: Contains Auth level config Geter Seter  
-- SpecFlowConfig: Contains Service level Geter Seter

- Core 
-- BusinessUtilsAPI: Class contian the common methods for API Automaiton - GET PUT POST DELETE CallRequest
-- ContentHelpers: Class contains methods to deserialize response and handle null values in serializeObject

- Helpers
-- Constants: enum Class contains constants used in the project
-- CreatePayload: Class contains method to create payload for the desired service
-- Helper: Class contains common utility methods
-- JsonTokenAuthorization: Class Contians method for authorization
-- RequestandResponse: Class Contains method to Request services and assert Response

- Models: Contains data model or Property  classes for Feature Payload and Response  
-- Feature
-- Payload
-- Response

- Tests: 
-- Features 
-- Stap Definitions

- appsettings.json 
- startUp: Manageing Dependencies


