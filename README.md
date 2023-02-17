# ASP-NET-PROJECT
### Furniture store

1. [Getting Started](#getting-started)

- [Tech Stack](#tech-stack)
- [Dependencies](#dependencies)
  
2. [Installation and configuration](#installation-and-configuration)

- [How to run the app](#how-to-run-the-app)
- [How to seed data](#how-to-seed-data)

3. [Accounts](#accounts)

4. [Connection string](#connection-string)

5. [Project overview](#project-overview)
- [Authorization](#authorization)
- [App overview with different roles](#app-overview-with-different-roles)


## Getting started
### Tech stack

ASP.NET Core 6.0

### Dependencies

- Visual Studio
- Microsoft SQL Server 

## Installation and configuration

### How to run the app
- Clone the repository from Github
- Open the project in Visual Studio
- To run the application, press the green button on top of the page

### How to seed data

In order to seed the data and users into the database, you have to create a migration.<br>
Move into the project directory and use below commands:

```bash
dotnet tool install --global dotnet-ef
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```
```bash
dotnet ef migrations add CompleteMigration
```
```bash
dotnet ef database update
```
It should create a migration, which will be applied to the database.

## Accounts

The migration will create 2 users with different privileages: 

**ADMIN**
- Login: admin@admin.com
- Password: Admin@111

**USER**
- Login: user@user.com
- Password: User@222

## Connection string

The connection string can be found in *appsetings.json* file. 

```bash
"ConnectionStrings": {
    "Application": "Data Source=.;Initial Catalog=Projekt; Integrated Security=True;Pooling=False"
 }
```

## Project overview
### Authorization
 **LOGIN**
 
 In the header of the page, there is a login button which redirect user to login page. On this page user can input their Email address and Password in order to log in.
 
![Login page](https://user-images.githubusercontent.com/47400438/219798272-3c21a0e7-ac59-4bfa-9320-57f8c747f168.png)

 **REGISTER**
 
 In the header of the page, there is a register button which redirect user to register page. In order to register, user need to input their Full Name, Email address and Password.
 After the user registers a new account, they can log into it on the login page.
 
 ![Register page](https://user-images.githubusercontent.com/47400438/219798572-6cff8695-f4e3-44a4-9a55-7ed74a13d9dc.png)

## App overview with different roles

### UNAUTHORIZED
When the user is unauthorized they have access to:

- displaying a list of furniture in the database 
![displaying the list of furnitures](https://user-images.githubusercontent.com/47400438/219799388-383a9dc9-935e-4b3a-9ad0-969a11651ed0.png)

- displaying single furtniture piece details.
![details of single furtniture](https://user-images.githubusercontent.com/47400438/219799428-b3db75d8-cb40-48ef-a635-fd694e1d255c.png)

### USER
When normal user is logged on top of unauthorized permissions they also have access to: 

- buying single furniture piece on furniture list 
![furniture-list-user](https://user-images.githubusercontent.com/47400438/219800199-2fbdc32d-c267-45f6-9ee1-49fe24810791.png)

- after they click buy, they recieve information that they succesfully bought the product
![buy-succesfull](https://user-images.githubusercontent.com/47400438/219800335-dac72380-b9ec-4785-85ff-faead779fd03.png)

### ADMIN
When admin is logged on top of unauthorized permissions they also have access to: 

- adding and updating furniture pieces from the furniture list page
![furniture-list-admin](https://user-images.githubusercontent.com/47400438/219800762-5e9005a1-334b-433a-afd1-040cf636438d.png)

- updating all data within the furniture piece such as name, production date, image, category (dropdown list), company (dropdown list), creator (dropdown list)
![furniture-update](https://user-images.githubusercontent.com/47400438/219800809-753d4c04-ecf3-4ab8-8676-df24d57b9b7f.png)

- adding a new furniture piece 
![furniture-update](https://user-images.githubusercontent.com/47400438/219801110-b306e2fa-b54f-445e-91fe-fe0dd3c6e299.png)

- displaying companies list with access to edit, show details, delete or add new
![companies-list](https://user-images.githubusercontent.com/47400438/219801426-00a75daf-9d9c-4cb4-a5d2-969400af6398.png)
![company-edit](https://user-images.githubusercontent.com/47400438/219801468-e1832cd6-e2d0-405f-b7fe-3798f0428f37.png)
![company-details](https://user-images.githubusercontent.com/47400438/219801492-db0aa993-ca59-40ff-82bf-84b7d0231cb7.png)
![company-delete](https://user-images.githubusercontent.com/47400438/219801538-f66cd11d-feff-4abb-b996-1e77c115d3d9.png)
![company-add](https://user-images.githubusercontent.com/47400438/219801577-fc5d2589-cad5-4295-bcaf-cfbf74f36be8.png)
- displaying categories and creators lists and performing similar CRUD operations such as on companies
![categories-list](https://user-images.githubusercontent.com/47400438/219801752-c079848c-0a56-457d-84b4-c56f80e43b64.png)
![creators-list](https://user-images.githubusercontent.com/47400438/219801784-6cd7036a-05af-4e81-9047-7cc08d7e52c5.png)
- showing users list
![users-list](https://user-images.githubusercontent.com/47400438/219801204-703c7fba-3702-42a0-aff0-04fcc1ff2951.png)









