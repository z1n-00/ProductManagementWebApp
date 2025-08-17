## Product Management Web Application
      A simple ASP.NET Core web application for managing products with CRUD operations, built using Dapper and SQL Server. The project demonstrates clean architecture principles,    responsive UI, logging, and pagination.

### Features
      View Products: Display a list of products with pagination and a responsive table.
      Add Product: Add new products with name, price, and automatically tracked creation date.
      Edit Product: Update existing product details with modification tracking.
      Delete Product: Preview and delete products safely.
      Responsive Design: Uses Bootstrap 5 and icons for better UI/UX.
      Database: SQL Server with Dapper for data access.
      Pagination: Easily browse through large lists of products.

### Project Structure
      ProductManagementWebApp/
      ├─ ProductManagement.Application/   # Application layer (interfaces, services)
      ├─ ProductManagement.Domain/        # Domain entities and interfaces
      ├─ ProductManagement.Infrastructure/ # Dapper context, repository implementations
      ├─ ProductManagementWebApp/        # ASP.NET Core MVC web project (controllers, views)

### Screenshots

Product List
<img width="1301" height="713" alt="Screenshot (1728)" src="https://github.com/user-attachments/assets/d129a3bb-1d18-4b83-aeb8-230308e1c3c8" />

Create Product
<img width="1293" height="727" alt="Screenshot (1729)" src="https://github.com/user-attachments/assets/78b1cca8-e3d2-4b75-b4aa-61e28a51ca63" />

Update Prouduct
<img width="1279" height="715" alt="Screenshot (1730)" src="https://github.com/user-attachments/assets/649c7aab-764b-4d7a-98d8-5da840d09a4e" />

Delete Product
<img width="1303" height="721" alt="Screenshot (1731)" src="https://github.com/user-attachments/assets/69c5094d-e1e6-4107-adb5-b8aeefad3815" />

### Technologies
      ASP.NET Core 8
      Dapper ORM
      SQL Server
      Bootstrap 5
      Visual Studio / VS Code

## Getting Started

### 1. Clone the repository:
      git clone https://github.com/z1n-00/ProductManagementWebApp.git
      cd ProductManagementWebApp

### 2. Configure the SQL Server connection in appsettings.json:
      "ConnectionStrings": {
          "DefaultConnection": "Server=YOUR_SERVER;Database=ProductManagement;User=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
      }

### 3. Run query in the SQL Server
      CREATE DATABASE ProductManagement;
      GO
      USE ProductManagement;
      GO
      CREATE TABLE Products (
          Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
          Name NVARCHAR(100) NOT NULL,
          Price DECIMAL(18,2) NOT NULL,
          CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
          CreatedBy NVARCHAR(100) NULL,
          ModifiedDate DATETIME2 NULL,
          ModifiedBy NVARCHAR(100) NULL
      );

### 4. Run the project:
      dotnet run --project ProductManagementWebApp.csproj

### 5. Navigate to in your browser.
      http://localhost:5082
