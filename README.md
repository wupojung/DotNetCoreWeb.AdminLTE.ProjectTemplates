# AdminLTE Starter Kit for ASP.NET Core
This is a projects for dotNet Core Web Applications with modern Admin UI (based on [AdminLTE](https://adminlte.io))
## 1. Getting Started
You can copy from NuGet or GitHub
![Imgur](https://i.imgur.com/BeiRH6J.png)

## 2. Prerequisites
You mut install the software 
* [.Net 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* IDEs (choose one)
  * [Rider](https://www.jetbrains.com/rider/)
  * [VS Code](https://code.visualstudio.com/)
  * [VS Community](https://visualstudio.microsoft.com/zh-hant/vs/community/)

## 3. Installing
### 3.1 Installing from .NET Core CLI 
### 3.2 Installing from GitHub repository
You can clone source code from GitHub
```shell
git clone https://github.com/wupojung/DotNetCoreWeb.AdminLTE.ProjectTemplates.git
```
## 4. Templates Settings
All configuration settings contains in **appsettings.json**.
### 4.1 Database
* PostgreSQL
```shell
dotnet add package Npgsql --version 8.0.1
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.11
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design --version 1.1.0
```
Login DB
```shell
psql -U postgres
```
Create Database,Usernmae
```shell
postgres=# create database adminlte;
postgres=# create user adminlte with encrypted password '12345678';
postgres=# grant all privileges on database adminlte to adminlte;
postgres=# GRANT ALL ON DATABASE adminlte TO adminlte;
postgres=# ALTER DATABASE adminlte OWNER TO adminlte;
```

```shell
dotnet tool install --global dotnet-ef --version 6.0.26
dotnet ef migrations add InitialUser
dotnet ef database update
```

## 5. Including List 
* [AdminLTE 3.2.0](https://adminlte.io/themes/v3/) UI
* [Asp.Versioning.Mvc](https://www.nuget.org/packages/Asp.Versioning.Mvc.ApiExplorer)  api versioning 
* [Autofac](https://www.nuget.org/packages/Autofac)  IoC container

## 6. Sample 
### 6.1 Api Versioning 
This function based on [aspnet-api-versioning](https://github.com/dotnet/aspnet-api-versioning).
The setting is on the **Program.cs**
You can find two **EchoController** on the Controllers\APIs  

## Authors
## License
This project is licensed under the MIT License. 
## Acknowledgments
* [Abdullah Almasaeed](https://adminlte.io/about) for great [AdminLTE](https://adminlte.io) Template project.
* [Leonid Shishkin](https://github.com/leonex) for great [AdminLTE-Starter-Kit](https://github.com/dotnet-express/AdminLTE-Starter-Kit) Template project.
## Ref
* [WebApi Multi Versioning](https://dotblogs.com.tw/yc421206/2022/03/13/support_multiple_versions_of_asp_net_core_web_api#google_vignette)