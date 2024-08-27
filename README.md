# Project Documentation for DeveloperAssignment

## Table of Contents

*   [1\. Project Overview](#1-project-overview)
*   [2\. Technologies Used](#2-technologies-used)
*   [3\. Installation and Setup](#3-installation-and-setup)
*   [4\. Database Configuration](#4-database-configuration)
*   [5\. Application Structure](#5-application-structure)
*   [6\. Entity Framework and Database Migrations](#6-entity-framework-and-database-migrations)
*   [7\. Usage Instructions](#7-usage-instructions)
*   [8\. Error Handling and Resiliency](#8-error-handling-and-resiliency)
*   [9\. Testing and Validation](#9-testing-and-validation)
*   [10\. Conclusion](#10-conclusion)
*   [11\. Contact Information](#11-contact-information)

## 1\. Project Overview

The **DeveloperAssignment** project is a robust ASP.NET Core MVC application designed to manage data within multiple SQL Server databases. This solution provides functionality for basic CRUD operations on a `Children` entity and includes the ability to compare data across two identically structured databases.

## 2\. Technologies Used

*   **.NET Core 8.0**
*   **ASP.NET Core MVC**
*   **Entity Framework Core**
*   **SQL Server Express (LocalDB)**
*   **Razor Views**
*   **C#**

## 3\. Installation and Setup

### Prerequisites

Ensure that the following are installed on your development machine:

*   **.NET 8.0 SDK**
*   **Visual Studio 2022** (or later) with ASP.NET and web development workload
*   **SQL Server Express (LocalDB)**
*   **SQL Server Management Studio (SSMS)**

### Clone the Repository

```
git clone <repository-url>
cd DeveloperAssignment
```

### Configure the Project

Open the project in Visual Studio. Ensure that the `ChildrenDB.mdf`, `DatabaseA.mdf`, and `DatabaseB.mdf` files are located in the `Data` directory.

## 4\. Database Configuration

The application utilizes three databases:

*   **ChildrenDB.mdf**: Main database for CRUD operations on the `Children` entity.
*   **DatabaseA.mdf**: Used for comparison operations.
*   **DatabaseB.mdf**: Used for comparison operations.

The connection strings for these databases are defined in `appsettings.json`:

```
"ConnectionStrings": {
    "ChildrenDB": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Data\\ChildrenDB.mdf;Integrated Security=True;",
    "DatabaseA": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Data\\DatabaseA.mdf;Integrated Security=True;",
    "DatabaseB": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Data\\DatabaseB.mdf;Integrated Security=True;"
}
```

## 5\. Application Structure

The project follows a standard MVC architecture:

*   **Controllers**:
    *   `ChildrenController`: Manages CRUD operations for the `Children` entity.
    *   `DatabaseController`: Handles database comparison between `DatabaseA` and `DatabaseB`.
*   **Models**:
    *   `Child`: Represents the `Children` entity.
    *   `ChildrenContext`: `DbContext` for `ChildrenDB`.
    *   `DatabaseAContext` and `DatabaseBContext`: `DbContext` for comparison databases.
*   **Views**:
    *   Razor views for `Index`, `Details`, `Create`, `Edit`, and `Delete` actions.
*   **Migrations**:
    *   Includes database migrations to create and seed initial data in the `Children` tables.

## 6\. Entity Framework and Database Migrations

To handle database schema changes and seed initial data, the project uses Entity Framework Core migrations.

### Applying Migrations

To apply migrations and update the database:

1.  Open the **Package Manager Console** in Visual Studio.
2.  Run the following commands:

```
Add-Migration InitialMigration -Context ChildrenContext
Update-Database -Context ChildrenContext

Add-Migration InitialMigrationA -Context DatabaseAContext
Update-Database -Context DatabaseAContext

Add-Migration InitialMigrationB -Context DatabaseBContext
Update-Database -Context DatabaseBContext
```

These commands will create the necessary tables and seed data in `ChildrenDB`, `DatabaseA`, and `DatabaseB`.

## 7\. Usage Instructions

### Accessing the Application

*   **List All Children**: `/Children/Index`
*   **Create a New Child**: `/Children/Create`
*   **Edit a Child**: `/Children/Edit/{id}`
*   **Delete a Child**: `/Children/Delete/{id}`
*   **View Child Details**: `/Children/Details/{id}`
*   **Compare Databases**: `/Database/CompareTables`

### Example Workflow

1.  **Start the application** from Visual Studio.
2.  **Navigate** to `/Children/Index` to view all children.
3.  **Use the CRUD operations** to manage the `Children` entity.
4.  **Navigate to `/Database/CompareTables`** to compare data between `DatabaseA` and `DatabaseB`.

## 8\. Error Handling and Resiliency

The application is designed to handle transient errors that may occur during database operations. This is achieved using the `EnableRetryOnFailure` method in the `DbContext` configuration.

### Example:

```
options.UseSqlServer(builder.Configuration.GetConnectionString("ChildrenDB"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    });
```

## 9\. Testing and Validation

The application has been tested for:

*   **Basic CRUD operations**: All basic operations (Create, Read, Update, Delete) on the `Children` entity work as expected.
*   **Database Comparison**: The comparison logic between `DatabaseA` and `DatabaseB` has been validated to accurately reflect differences.

## 10\. Conclusion

This project demonstrates a robust solution for managing data within multiple SQL Server databases. The use of Entity Framework Core allows for smooth database interactions, and the architecture is scalable and maintainable.

## 11\. Contact Information

For further inquiries, assistance, or custom development services, please contact:

*   **Developer Name**: Jamal Hamilton

- - -

Thank you for choosing our services. We look forward to working with you on future projects.
