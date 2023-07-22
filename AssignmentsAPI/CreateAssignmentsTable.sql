-- Create Table Assignments(
-- Id TEXT PRIMARY KEY DEFAULT (UUID()),
-- Assignee TEXT NOT NULL CHECK(length(Assignee) <= 255),
-- DueDate TEXT NOT NULL,
-- Description TEXT NOT NULL Check(length(Description) <= 500),
-- PercentComplete NUMERIC NULL CHECK(PercentComplete == ROUND(PercentComplete, 2)),
-- IsPriority INTEGER NULL);

-- Insert Into Assignments(Id, Assignee, DueDate, Description, PercentComplete, IsPriority)
-- Values(UUID(), 'Matt Riddle', '2023-09-01', 'Test Description', 56.76, 1);
-- Insert Into Assignments(Id, Assignee, DueDate, Description)
-- Values(UUID(), 'John Cena', '2023-09-01', 'Test Description');

--DROP Table Assignments;

--select * from Assignments;