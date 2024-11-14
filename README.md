# DreamyCommerce

E-commerce single-page application built with ASP.NET WebAPI (.NET 8), Angular 18 and SQLite. PrimeNG and PrimeFlex for UI components.

## Features

- User authentication with JWT using ASP.NET Identity
- Role-based access control for both client and server-side
- CRUD operations for managing users, products, categories, products, etc.
- Server-side pagination and sorting
- Server-side filtering using expression trees to build dynamic queries based on query string parameters
- Image upload

## Installation

Prerequisites:
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js v20.15.1 or newer](https://nodejs.org/en/download/package-manager)

1. Clone the repository
2. Install ASP.NET dependencies  
   Inside root solution directory, run:

   ```bash
   dotnet restore
   ```
3. Run migrations  
   Inside the root solution directory, run:

   ```bash
   dotnet ef database update --project DataAccess --startup-project API
   ```
4. Install Angular dependencies  
   Inside the `AngularUI` directory, run:

   ```bash
   npm install
   ```
## Usage

1. Start the API  
   Inside the root solution directory, run:

   ```bash
   dotnet run --project API
   ```

2. Start the Angular app  
    Inside the `AngularUI` directory, run:
    
    ```bash
    ng serve
    ```




