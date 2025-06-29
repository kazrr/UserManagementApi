# User Management API

## Overview
The User Management API is a RESTful service that allows for the management of user data. It provides endpoints for creating, retrieving, updating, and deleting users, along with input validation and error handling features.

## Features
- User creation, retrieval, updating, and deletion
- Input validation for user data
- Global exception handling for improved error management

## Project Structure
```
UserManagementApi
├── Controllers
│   └── UsersController.cs       # Manages user-related API endpoints
├── Middleware
│   └── ExceptionHandlingMiddleware.cs # Handles exceptions globally
├── Models
│   └── User.cs                  # Represents the user entity
├── Services
│   └── UserService.cs           # Contains business logic for user management
├── Validators
│   └── UserValidator.cs         # Validates user input
├── Program.cs                   # Entry point of the application
└── UserManagementApi.csproj     # Project file containing metadata and dependencies
```

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd UserManagementApi
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```
4. Run the application:
   ```
   dotnet run
   ```

## API Usage
### Endpoints
- **POST /users**: Create a new user
- **GET /users/{id}**: Retrieve a user by ID
- **PUT /users/{id}**: Update an existing user
- **DELETE /users/{id}**: Delete a user by ID

### Error Handling
The API includes global exception handling to return appropriate error responses for unhandled exceptions and non-existent users.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License.