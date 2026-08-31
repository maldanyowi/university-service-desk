# University IT Service Request System

A web-based application for managing and tracking technical support requests in a university environment.

## Project Overview

I developed this project to demonstrate how technical support requests can be recorded, organized, and tracked through a simple web application.

The system allows users to create service requests, assign priorities, update request statuses, view request details, and delete requests. It also includes a dashboard that displays request statistics.

## Features

- Create new service requests
- View all requests
- View request details
- Edit existing requests
- Delete requests
- Track request priority
- Track request status
- Dashboard with request statistics
- Input validation
- Responsive user interface

## Technologies Used

- C#
- .NET 10
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Bootstrap
- HTML and CSS
- Visual Studio Code
- Git

## Architecture

The project follows the MVC design pattern:

- **Model:** Represents service request data and validation rules.
- **View:** Displays the user interface.
- **Controller:** Handles user actions and communicates with the database.

## Database

The application uses SQLite with Entity Framework Core. Database changes are managed through EF Core Migrations.

## CRUD Operations

The application supports:

- **Create:** Add a new request
- **Read:** View requests and details
- **Update:** Edit request information and status
- **Delete:** Remove a request

## How to Run

1. Clone the repository.
2. Open the project folder.
3. Restore the required packages:

```bash
dotnet restore