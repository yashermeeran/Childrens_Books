# KidsBooks API

## Overview
The KidsBooks API provides endpoints for user authentication, including registration and login. It uses JWT for secure authentication.

## API Documentation

### AuthController

1. **Register**
   - **Endpoint:** `POST /api/auth/register`
   - **Description:** Registers a new user.
   - **Request Body:**
 {
   "username": "string",
   "password": "string",
   "email": "string"
 }
 
