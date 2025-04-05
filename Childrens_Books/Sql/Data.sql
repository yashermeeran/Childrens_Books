CREATE DATABASE kids_books;
use kids_books;


CREATE SCHEMA IF NOT EXISTS Kids_books;
USE Kids_books;


CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(255) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE Books (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    Category VARCHAR(255) NOT NULL,
    CoverImageUrl VARCHAR(255),
    Description TEXT
);


CREATE TABLE BookPages (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    BookId INT NOT NULL,
    PageNumber INT NOT NULL,
    Text TEXT NOT NULL,
    ImageUrl VARCHAR(255) NULL,
    FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
);

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
('The Great Adventure', 'John Doe', 'Fiction', https://picsum.photos/seed/book1/300/450, 'An exciting journey through uncharted lands.'),
('Exploring the Universe', 'Jane Smith', 'Science', 'https://picsum.photos/seed/book2/300/450', 'A deep dive into the mysteries of space.'),
('The World War Chronicles', 'Alan Turing', 'History', 'https://picsum.photos/seed/book3/300/450', 'A detailed account of historical wars.'),
('Magical Realms', 'Emma Watson', 'Fantasy', 'https://picsum.photos/seed/book4/300/450', 'A tale of magic, wizards, and mythical creatures.'),
('Artificial Intelligence', 'Elon Gates', 'Technology', 'https://picsum.photos/seed/book5/300/450', 'Lily was a little girl who loved to paint. One day, she found an old paintbrush in her grandmother’s attic. It had golden bristles that shimmered in the light. As soon as she touched it, the brush started to glow!

"Wow!" Lily whispered. She dipped the brush into her paint and made a tiny bluebird on the canvas. Suddenly, the bluebird flapped its wings and flew away!

Her eyes widened. "Did that just... come to life xcited, Lily painted a small orange cat. The cat blinked its bright green eyes and jumped off the page, purring loudly.

"This is amazing!" Lily laughed. She painted a garden full of flowers, and soon, the air was filled with the sweet scent of blossoms.

But then, she had an idea. "What if I paint something really special?"

With a careful hand, she painted a magical door. As soon as she finished, the door creaked open, and a voice whispered, "Step inside if you dare..."

What would Lily find behind the door.');

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
