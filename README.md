# KidsBooks API

## Overview
The KidsBooks API provides endpoints for user authentication, including registration and login. It uses JWT for secure authentication.

## API Documentation
git clone <repository-url>
cd <repository-directory>
File: Childrens_Books/appsettings.json
{
  "Jwt": {
    "Key": "Your_Secret_Key_Here_That_Is_At_Least_32_Characters_Long",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=<server>;Database=<database>;User=<user>;Password=<password>;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
**File: Childrens_Books/appsettings.json**
{
  "Jwt": {
    "Key": "Your_Secret_Key_Here_That_Is_At_Least_32_Characters_Long",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=<server>;Database=<database>;User=<user>;Password=<password>;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
Build the Project
1.	Open the project in Visual Studio 2022.
2.	Build the project to restore dependencies:
Run the Project
1.	Run the project using IIS Express or your preferred method:
Access the API
1.	The API will be available at https://localhost:<port>/api/auth.
2.	You can use tools like Postman or curl to test the API endpoints.

**Register Register:**
curl -X POST https://localhost:<port>/api/auth/register -H "Content-Type: application/json" -d '{
  "username": "yaser",
  "password": "yourpassword",
  "email": "yaser@example.com"
}'
Response:
{
  "message": "User registered successfully"
}
Login:
curl -X POST https://localhost:<port>/api/auth/login -H "Content-Type: application/json" -d '{
  "userName": "yaser",
  "password": "yourpassword"
}'
Response:
{
  "token": "your_jwt_token"
}












