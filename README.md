# University IT Service Request System

A role-based web application for managing technical support requests in a university environment.

## About the Project

I built this project to apply what I learned in C#, ASP.NET Core MVC, databases, authentication, and role-based authorization.

The system provides an organized way for university users to report technical issues and follow their requests until they are resolved. It includes two user roles, Requester and Technician, with different permissions based on their responsibilities.

## User Roles

### Requester

A requester can:

- Create an account using a full name, email, and password
- Sign in and sign out securely
- Submit a technical support request
- Add their department and contact number
- View only the requests connected to their account
- Search and filter their requests
- View request details, priority, and current status

A requester cannot edit, delete, or manage the priority and status of a request.

### Technician

A technician or administrator can:

- View all submitted requests
- Search and filter requests
- Review requester and contact information
- Change request priority and status
- Edit and delete requests
- View dashboard statistics

## Main Features

- Public welcome and landing pages
- User registration and secure authentication
- Full-name user profiles
- Role-based authorization
- Request ownership and access control
- Create, read, update, and delete operations
- Optional office or mobile contact number
- Search and status filtering
- Priority and status management
- Dashboard statistics
- Input validation
- Responsive user interface
- SQLite database integration
- Entity Framework Core migrations

## Request Workflow

Each new request starts with **Medium** priority and **New** status.

The technician can change the priority to **Low**, **Medium**, or **High** and update the status to **New**, **In Progress**, or **Completed**.

Requesters can follow the progress of their requests from the dashboard but cannot change their priority or status.

## Technologies Used

- C#
- .NET 10
- ASP.NET Core MVC
- ASP.NET Core Identity
- Entity Framework Core
- SQLite
- Razor Pages
- Bootstrap
- HTML, CSS, and JavaScript
- Visual Studio Code
- Git and GitHub

## Project Structure

The project follows the MVC design pattern:

- **Model:** Represents the application data and validation rules
- **View:** Displays the pages, forms, dashboard, and request details
- **Controller:** Handles user actions, authorization, and database operations

Entity Framework Core is used for database access and migrations.

## Security

I used ASP.NET Core Identity for registration, authentication, password hashing, user management, and roles.

Each request is linked to the account that created it. Requesters can access only their own requests, while management actions are restricted to the Technician role.

The administrator account details are stored locally using .NET User Secrets and are not included in the GitHub repository.

## Validation

The application validates required fields, email addresses, passwords, contact numbers, and maximum field lengths before saving information to the database.

Validation is applied in the user interface and on the server.

## How to Run

### 1. Clone the repository

```bash
git clone https://github.com/maldanyowi/university-service-desk.git
cd university-service-desk
```

### 2. Restore the packages

```bash
dotnet restore
```

### 3. Configure the administrator account

```bash
dotnet user-secrets set "TechnicianAccount:Email" "technician@example.com"
dotnet user-secrets set "TechnicianAccount:Password" "YourSecurePassword"
```

### 4. Apply the database migrations

```bash
dotnet ef database update
```

### 5. Run the application

```bash
dotnet run --urls "http://localhost:5200"
```

Then open:

```text
http://localhost:5200
```

## Current Scope

The current version covers the main workflow for submitting and managing technical support requests.

The Forgot Password and Resend Email Confirmation pages are included and styled, but an external email provider has not been connected yet.

The application currently runs locally using SQLite.

## Future Improvements

I plan to continue developing the project by adding:

- A RESTful Web API for integration with other systems
- Microsoft SQL Server for a production environment
- Clean Architecture to separate the application layers
- Request assignment, technician notes, and update history
- Email notifications and secure file attachments
- Real-time status updates using SignalR
- Audit logging and additional security controls
- Unit and integration tests
- Docker and a CI/CD pipeline
- Deployment to Microsoft Azure with monitoring and backups

## What I Learned

Through this project, I practiced:

- Building an ASP.NET Core MVC application
- Applying the MVC design pattern
- Using Entity Framework Core and database migrations
- Implementing authentication, roles, and authorization
- Building CRUD operations and form validation
- Connecting records to user accounts
- Restricting access based on ownership and roles
- Designing a responsive user interface
- Debugging application, database, and authorization issues
- Managing source code using Git and GitHub

## Developer

Developed by **Marwah Al Danyowi**.