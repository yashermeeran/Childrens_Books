# KidsBooks API

## Overview
The KidsBooks API provides endpoints for user authentication, book management, and bookmarks functionality. It's built using ASP.NET Core with Entity Framework Core and JWT for secure authentication.

## Prerequisites
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (or other compatible database server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/)

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/yashermeeran/Childrens_Books.git
cd Childrens_Books
```

### 2. Install .NET Dependencies
Restore all the required NuGet packages:

```bash
dotnet restore
```

This will install all the dependencies specified in the project file, including:
- Microsoft.AspNetCore.Authentication.JwtBearer
- BCrypt.Net-Next
- Pomelo.EntityFrameworkCore.MySql
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore

### 3. Database Setup
1. Create a MySQL database using the provided SQL script:
```bash
mysql -u root -p < Childrens_Books/Sql/Data.sql
```
This script will:
- Create a new database named 'kids_books'
- Create necessary tables (Users, Books, BookPages, Bookmarks)
- Populate the database with sample data

### 4. Configure the Application
1. Update the connection string in `Childrens_Books/appsettings.json`:
```json
{
  "Jwt": {
    "Key": "Your_Secret_Key_Here_That_Is_At_Least_32_Characters_Long"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=kids_books;User=your_username;Password=your_password;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
> **Important**: Replace `your_username` and `your_password` with your MySQL credentials. Make sure to use a strong JWT key for production environments.

### 5. Build and Run the Project

#### Using Visual Studio:
1. Open the solution file `Kids_Book.sln` in Visual Studio 2022
2. Build the solution (Ctrl+Shift+B)
3. Run the project (F5 or press the "Run" button)

#### Using Command Line:
```bash
cd Childrens_Books
dotnet build
dotnet run
```

### 6. Explore the API
- The API will be available at `https://localhost:7147/` 
- Swagger UI is available at `https://localhost:7147/swagger` for exploring and testing the API endpoints

## API Endpoints

### Authentication

#### Register a new user:
- **URL**: `https://localhost:7147/api/Auth/register`
- **Method**: `POST`
- **Request Body**:
```json
{
  "username": "your_username",
  "password": "your_password",
  "email": "your_email@example.com"
}
```
- **Response**:
```json
{
  "message": "User registered successfully"
}
```

#### Login:
- **URL**: `https://localhost:7147/api/Auth/login`
- **Method**: `POST`
- **Request Body**:
```json
{
  "username": "your_username",
  "password": "your_password"
}
```
- **Response**:
```json
{
  "userId": "1",
  "token": "your_jwt_token"
}
```

### Books

#### Get All Books:
- **URL**: `https://localhost:7147/api/books`
- **Method**: `GET`
- **Response**:
```json
[
  {
    "id": 1,
    "title": "Book Title 1",
    "author": "Author Name",
    "category": "Fiction",
    "coverImageUrl": "https://example.com/cover1.jpg",
    "description": "Book description here"
  },
  {
    "id": 2,
    "title": "Book Title 2",
    "author": "Author Name",
    "category": "Science",
    "coverImageUrl": "https://example.com/cover2.jpg",
    "description": "Book description here"
  }
]
```

#### Get Book by ID:
- **URL**: `https://localhost:7147/api/books/{bookId}`
- **Method**: `GET`
- **Response**:
```json
{
  "id": 1,
  "title": "Book Title",
  "author": "Author Name",
  "category": "Fiction",
  "coverImageUrl": "https://example.com/cover.jpg",
  "description": "Book description here"
}
```

#### Get Book Content by Page:
- **URL**: `https://localhost:7147/api/books/{bookId}/content?page={pageNumber}`
- **Method**: `GET`
- **Response**:
```json
{
  "content": "Once upon a time",
  "bookId": "1",
  "pageNumber": "1",
  "totalPages": "4"
}
```

#### Get All Categories:
- **URL**: `https://localhost:7147/api/books/categories`
- **Method**: `GET`
- **Response**:
```json
[
  {
    "id": 1,
    "category": "Fiction"
  },
  {
    "id": 2,
    "category": "Science"
  }
]
```

#### Get Books by Category:
- **URL**: `https://localhost:7147/api/books/category?category={categoryName}`
- **Method**: `GET`
- **Response**:
```json
[
  {
    "id": 1,
    "title": "Book Title 1",
    "author": "Author Name",
    "category": "Fiction",
    "coverImageUrl": "https://example.com/cover1.jpg",
    "description": "Book description here"
  },
  {
    "id": 2,
    "title": "Book Title 2",
    "author": "Author Name",
    "category": "Fiction",
    "coverImageUrl": "https://example.com/cover2.jpg",
    "description": "Book description here"
  }
]
```

### Bookmarks

#### Get User Bookmarks:
- **URL**: `https://localhost:7147/api/bookmarks/user/{userId}`
- **Method**: `GET`
- **Response**:
```json
[
  {
    "id": 1,
    "userId": 3,
    "bookId": 1,
    "pageNumber": 1,
    "createdAt": "2025-03-21T19:25:10.623045Z",
    "book": {
      "id": 1,
      "title": "Book Title",
      "author": "Author Name",
      "category": "Fiction",
      "coverImageUrl": "https://example.com/cover.jpg",
      "description": "Book description here"
    }
  },
  {
    "id": 2,
    "userId": 3,
    "bookId": 2,
    "pageNumber": 1,
    "createdAt": "2025-03-21T19:25:10.623045Z",
    "book": {
      "id": 2,
      "title": "Book Title 2",
      "author": "Author Name",
      "category": "Science",
      "coverImageUrl": "https://example.com/cover2.jpg",
      "description": "Book description here"
    }
  }
]
```

#### Add Bookmark:
- **URL**: `https://localhost:7147/api/bookmarks`
- **Method**: `POST`
- **Request Body**:
```json
{
  "userId": 1,
  "bookId": 1,
  "pageNumber": 1
}
```
- **Response**:
```json
{
  "id": 1,
  "userId": 3,
  "bookId": 1,
  "pageNumber": 1,
  "createdAt": "2025-03-21T19:25:10.623045Z",
  "book": {
    "id": 1,
    "title": "Book Title",
    "author": "Author Name",
    "category": "Fiction",
    "coverImageUrl": "https://example.com/cover.jpg",
    "description": "Book description here"
  }
}
```

#### Delete Bookmark:
- **URL**: `https://localhost:7147/api/bookmarks/user/{bookmarkId}`
- **Method**: `DELETE`
- **Response**:
```json
{
  "message": "Bookmark deleted successfully"
}
```

## Project Structure
- **Controllers/** - API endpoints
- **Models/** - Data models
- **Data/** - Database context and configuration
- **Repositories/** - Data access logic
- **Sql/** - SQL scripts for database setup

## Dependencies
The project uses the following main packages:
- Microsoft.AspNetCore.Authentication.JwtBearer
- Pomelo.EntityFrameworkCore.MySql
- BCrypt.Net-Next
- Swashbuckle.AspNetCore (Swagger)
