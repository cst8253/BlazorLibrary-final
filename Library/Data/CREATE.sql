-- Create the Books table
DROP TABLE Loans;
DROP TABLE Books;
DROP TABLE Members;

CREATE TABLE Books
(
    BookID        INTEGER PRIMARY KEY,
    Title         TEXT NOT NULL,
    Author        TEXT NOT NULL,
    Genre         TEXT,
    PublishedYear INTEGER
);

-- Create the Members table
CREATE TABLE Members
(
    MemberID            INTEGER PRIMARY KEY,
    Name                TEXT NOT NULL,
    Email               TEXT UNIQUE,
    MembershipStartDate DATE
);

-- Create the Loans table
CREATE TABLE Loans
(
    LoanID     INTEGER PRIMARY KEY,
    BookID     INTEGER NOT NULL,
    MemberID   INTEGER NOT NULL,
    LoanDate   DATE    NOT NULL,
    ReturnDate DATE,
    FOREIGN KEY (BookID) REFERENCES Books (BookID),
    FOREIGN KEY (MemberID) REFERENCES Members (MemberID)
);

-- Insert data into the Books table
INSERT INTO Books (BookID, Title, Author, Genre, PublishedYear)
VALUES (1, 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 1960),
       (2, '1984', 'George Orwell', 'Dystopian', 1949),
       (3, 'The Great Gatsby', 'F. Scott Fitzgerald', 'Classic', 1925),
       (4, 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', 1951),
       (5, 'Moby Dick', 'Herman Melville', 'Adventure', 1851),
       (6, 'Pride and Prejudice', 'Jane Austen', 'Romance', 1813),
       (7, 'The Hobbit', 'J.R.R. Tolkien', 'Fantasy', 1937),
       (8, 'War and Peace', 'Leo Tolstoy', 'Historical', 1869),
       (9, 'Brave New World', 'Aldous Huxley', 'Dystopian', 1932),
       (10, 'Crime and Punishment', 'Fyodor Dostoevsky', 'Classic', 1866),
       (11, 'Jane Eyre', 'Charlotte Brontë', 'Gothic', 1847),
       (12, 'The Odyssey', 'Homer', 'Epic Poetry', -800),
       (13, 'A Tale of Two Cities', 'Charles Dickens', 'Historical', 1859),
       (14, 'Animal Farm', 'George Orwell', 'Political Satire', 1945),
       (15, 'The Count of Monte Cristo', 'Alexandre Dumas', 'Adventure', 1844);

-- Insert data into the Members table
INSERT INTO Members (MemberID, Name, Email, MembershipStartDate)
VALUES (1, 'Alice Johnson', 'alice.johnson@example.com', '2023-01-10'),
       (2, 'Bob Smith', 'bob.smith@example.com', '2022-05-15'),
       (3, 'Cathy Brown', 'cathy.brown@example.com', '2021-11-20'),
       (4, 'David Lee', 'david.lee@example.com', '2023-03-05'),
       (5, 'Emma Davis', 'emma.davis@example.com', '2022-08-30');

-- Insert data into the Loans table
INSERT INTO Loans (LoanID, BookID, MemberID, LoanDate, ReturnDate)
VALUES (1, 1, 1, '2025-03-01', '2025-03-04'),
       (2, 2, 2, '2025-03-01', '2025-03-05'),
       (3, 3, 3, '2025-03-02', '2025-03-09'),
       (4, 4, 4, '2025-03-02', '2025-03-09'),
       (5, 5, 5, '2025-03-04', '2025-03-09'),
       (6, 6, 1, '2025-03-04', '2025-03-11'),
       (7, 7, 2, '2025-03-04', '2025-03-11'),
       (8, 8, 3, '2025-03-06', '2025-03-14'),
       (9, 9, 4, '2025-03-06', '2025-03-14'),
       (10, 1, 5, '2025-03-09', '2025-03-15'),
       (11, 2, 1, '2025-03-11', '2025-03-15'),
       (12, 3, 2, '2025-03-11', '2025-03-15'),
       (13, 4, 3, '2025-03-15', '2025-03-19'),
       (14, 5, 4, '2025-03-16', '2025-03-22'),
       (15, 1, 5, '2025-03-18', '2025-03-24'),
       (16, 2, 1, '2025-03-18', NULL),
       (17, 3, 2, '2025-03-18', NULL),
       (18, 4, 3, '2025-03-19', NULL),
       (19, 5, 4, '2025-03-22', NULL),
       (20, 6, 5, '2025-03-23', NULL);
