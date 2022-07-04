# About
This is a sample REST API project built with .Net Core 6 and PostgreSQL using Entity Framework Core 6 code-first approach.

# Requirements:

1. You must use a .Net Core / .Net Framework technology of your preference to build the service.
2. A REST API must be built. The following guide is recommended for resource naming: https://www.restapitutorial.com/lessons/restfulresourcenaming.html
3. A CustomerOrder consists of Customer (Name and Address) and Product (Barcode, Description, Quantity, Price) information.
4. A CustomerOrder may contain number of Products but must contain only one Customer information.
5. The client that is consuming the API must be able to save a CustomerOrder via an endpoint.
6. The client that is consuming the API must be able to delete a CustomerOrder via an endpoint.
7. The client that is consuming the API must be able to change a CustomerOrder via an endpoint. The client may change the product’s quantity or add new product or remove a product from the CustomerOrder completely. Or a Customer may revise his/her address for the CustomerOrder.
8. The security is not important for this project. But you are welcome to implement one.
9. For the persistence layer, you must use any database like MSSql/Mysql/Postgresql/etc. You are free to use any ORM (EntityFramework) or microORM (Dapper etc.) tool of your preference, or you can use native solutions like ADO.Net.
10. You are not expected to implement an end to end logging mechanism. But you are welcome to add one.
11. Finally, you must document your API. You can use library like Swagger, or document it by a text/Word file.

# Running the project
1. Clone this repository.
2. Update postgresql connection string, which can be found in src/AktifTech.CustomerOrderRestApi.API/appsettings.json file.
3. Update nlog.config file to write text logs to desired path.
4. Run `dotnet run` command or, hit `F5` key on the keyboard.

> DB migrations will be applied automatically to your local postgresql database you provide in appsettings.json file.

# Usage

API endpoints can be used directly on swagger ui after running the project. Sample postman collection to create real data is also provided, [click here](/postman/AktifTech.CustomerOrderRestApi.API.postman_collection.json) to download it.

# Libraries and frameworks used
* [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.6)
* [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/6.0.5)
* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/13.0.1)
* [AutoMapper.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/11.0.0)
* [NLog](https://www.nuget.org/packages/NLog/5.0.1)
* [NLog.Web.AspNetCore](https://www.nuget.org/packages/NLog.Web.AspNetCore/5.0.0)