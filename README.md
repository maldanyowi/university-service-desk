# University IT Service Request System

A role-based web application for managing and tracking technical support requests in a university environment.

## Project Overview

I developed this project to demonstrate how university IT service requests can be submitted, organized, and tracked securely.

The system separates regular requesters from IT technicians using ASP.NET Core Identity and role-based authorization.

## User Roles

### Requester

- Register and log in
- Create service requests
- View only their own requests
- View request details
- Cannot change priority or status
- Cannot edit or delete requests

### Technician

- Log in using a technician account
- View all service requests
- Change request priority and status
- Edit and delete requests

## Features

- User registration
- Secure login and logout
- Role-based authorization
- Request ownership
- CRUD operations
- Priority and status tracking
- Dashboard statistics
- Input validation
- Responsive Bootstrap interface

## Technologies Used

- C#
- .NET 10
- ASP.NET Core MVC
- ASP.NET Core Identity
- Entity Framework Core
- SQLite
- Bootstrap
- HTML and CSS
- Visual Studio Code
- Git and GitHub

## Architecture

The project follows the MVC design pattern:

- **Model:** Represents request data and validation rules
- **View:** Displays the user interface
- **Controller:** Handles requests, authorization, and database operations

## Security

ASP.NET Core Identity is used for authentication, password hashing, user management, roles, and authorization.

The application contains two roles:

- `Requester`
- `Technician`

Technician credentials are stored locally using .NET User Secrets and are not committed to GitHub.

## How to Run

1. Restore packages:

```bash
dotnet restore
```

2. Configure a local technician account:

```bash
dotnet user-secrets set "TechnicianAccount:Email" "technician@example.com"
dotnet user-secrets set "TechnicianAccount:Password" "YourSecurePassword"
```

3. Create the database:

```bash
dotnet ef database update
```

4. Run the application:

```bash
dotnet run
```

## Developer

Developed by Marwah