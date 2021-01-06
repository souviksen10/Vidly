# Vidly

[![Travis](https://img.shields.io/travis/rust-lang/rust.svg)]()

This is a web application for a video rental store called Vidly. There are three links in the navigation bar: New Rental, Customers and Movies.
* Customers: This page shows the list of customers of Vidly in a table. The table has pagination, sorting and searching. If we delete a customer, we get a bootstrap dialogue box for confirmation. We can also add a new customer. While adding a customer we have to choose a membership type. If the customer wants to go in a monthly, quarterly or annual membership type then they have to be at least 18 years old. Otherwise, we get a validation error.
* Movies: This page shows the list of movies present in Vidly database in a table. It is similar to customers. The table has pagination, sorting and searching. We can delete a movie or add a new movie.
* New Rental: When a customer comes to the counter, we use this page to add all the movies they are going to rent. But as we are renting out movies this application keeps a track on the availability of the movies.

#### Authorization
The user has to login first to use this application. A user can login via their Facebook account or create a new account in the Vidly app.
There are two roles:
* **Staff member**: They can add a new customer and add movies the customer is going to rent in the New Rental page. But they get a read-only view of the list of movies. They cannot add update or delete a movie.
* **Admin**: Apart from the privileges of a staff member an admin can add update or delete a movie.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine.

### Prerequisites

The following must be installed in your computer
* .NET Framework 4.7.2

### To run the project

* Open `Vidly.sln` file using Visual Studio.
* Give the solution a build.
* Set your *db connection string* in **web.config**
* In package manager console execute the command `update-database` to setup the database. 
* Select `Ctrl-F5` to run the app in non-debug mode.
* To access the application as an **admin**, use the following credentials:
```
Email: admin@vidly.com,
Password: Admin123#
```
* To access the application as a **staff member**, use the following credentials:
```
Email: guest@vidly.com,
Password: Guest123#
```
* All new users created will have role as staff member.


## Technologies
* C#
* .NET Framework 4.7.2
* ASP.NET MVC 5.2.7
* ASP.NET Web API 5.2.7
* Entity Framework 6.4.0
* jQuery 3.3.1 for client-side development.
* Bootstrap 3.4.1
* SQL Server 2016
* ASP.NET Identity 2.2.2 for authentication and authorization
* [AutoMapper](http://automapper.org/) 4.1.1 for mapping DTOs with domain class objects.
* [jquery.datatables](https://datatables.net/) 1.10.11 for creating tables that have built in support for pagination searching and sorting.
* [jQuery.Validation](https://www.nuget.org/packages/jquery.validation) 1.17.0 for implementing client-side validation.
* [toastr](https://www.npmjs.com/package/toastr) 2.1.1 for displaying toast notifications.
* [Bootbox](http://bootboxjs.com/) 4.3.0 for creating Bootstrap dialogue boxes.
* [Elmah](https://elmah.github.io/) 1.2.2 for logging unhandled exceptions.
* [Glimpse](https://github.com/glimpse/glimpse) 1.8.6 for getting real time diagnostics and insights into the app.
* [Twitter.Typeahead](https://twitter.github.io/typeahead.js/) 0.11.1 for adding autocompletion to the textboxes.
