CREATE DATABASE kids_books;
use kids_books;
-- Database Schema and Table Creation

CREATE SCHEMA IF NOT EXISTS Kids_books;
USE Kids_books;

-- Users Table
CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(255) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL
);

-- Books Table
CREATE TABLE Books (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    Category VARCHAR(255) NOT NULL,
    CoverImageUrl VARCHAR(255),
    Description TEXT
);

-- BookPages Table (Related to Books)
CREATE TABLE BookPages (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    BookId INT NOT NULL,
    PageNumber INT NOT NULL,
    Text TEXT NOT NULL,
    ImageUrl VARCHAR(255) NULL,
    FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
);

-- Bookmarks Table (Related to Users and Books)
CREATE TABLE Bookmarks (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId INT NOT NULL,
    BookId INT NOT NULL,
    PageNumber INT NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
);
