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

INSERT INTO Users (Username, PasswordHash, Email) VALUES
('john_doe', 'hashed_password_1', 'john@example.com'),
('jane_smith', 'hashed_password_2', 'jane@example.com'),
('alex_brown', 'hashed_password_3', 'alex@example.com');

INSERT INTO Books (Title, Author, Category, CoverImageUrl, Description) VALUES
('The Great Adventure', 'John Doe', 'Fiction', 'https://example.com/adventure.jpg', 'An exciting journey through uncharted lands.'),
('Exploring the Universe', 'Jane Smith', 'Science', 'https://example.com/universe.jpg', 'A deep dive into the mysteries of space.'),
('The World War Chronicles', 'Alan Turing', 'History', 'https://example.com/wwchronicles.jpg', 'A detailed account of historical wars.'),
('Magical Realms', 'Emma Watson', 'Fantasy', 'https://example.com/magicrealms.jpg', 'A tale of magic, wizards, and mythical creatures.'),
('Artificial Intelligence Today', 'Elon Gates', 'Technology', 'https://example.com/ai_today.jpg', 'The impact of AI on modern society.');

INSERT INTO BookPages (BookId, PageNumber, Text, ImageUrl) VALUES
(1, 1, 'Once upon a time in a land far away...', 'https://example.com/adventure_page1.jpg'),
(1, 2, 'The journey continues through the mystical forests...', NULL),
(2, 1, 'The universe is vast and full of mysteries...', 'https://example.com/universe_page1.jpg'),
(3, 1, 'World War I started in 1914 and changed history forever...', NULL),
(4, 1, 'In a world filled with magic and wonder...', 'https://example.com/magicrealms_page1.jpg');

INSERT INTO Bookmarks (UserId, BookId, PageNumber) VALUES
(1, 1, 2),
(1, 3, 1),
(2, 2, 1),
(3, 4, 1),
(3, 5, 1);
