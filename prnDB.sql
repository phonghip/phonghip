create database taskManagement;
use taskManagement;

-- Create User Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(10) NOT NULL -- Member or Leader
);

-- Create Task Table
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    DueDate DATE,
    CompletionStatus BIT DEFAULT 0, -- 0 for incomplete, 1 for completed
    UserID INT NULL,
    CONSTRAINT FK_Tasks_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Comments (
    CommentID INT PRIMARY KEY IDENTITY,
    TaskID INT NOT NULL,
	UserID INT NOT NULL,
    CommentText NVARCHAR(MAX) NOT NULL,
	CommentDate Date not null,
    CONSTRAINT FK_Comments_Tasks FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID),
    CONSTRAINT FK_Comments_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
