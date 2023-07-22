-- Create Table Assignments(
-- Id TEXT PRIMARY KEY DEFAULT (UUID()),
-- Assignee TEXT NOT NULL CHECK(length(Assignee) <= 255),
-- DueDate TEXT NOT NULL,
-- Description TEXT NOT NULL Check(length(Description) <= 500),
-- PercentComplete NUMERIC NOT NULL CHECK(PercentComplete == ROUND(PercentComplete, 2)),
-- IsPriority INTEGER NOT NULL);

-- Insert Into Assignments(Id, Assignee, DueDate, Description, PercentComplete, IsPriority)
-- Values(UUID(), 'Matt Riddle', '2023-09-01', 'Test Description', 0, 1);

--DROP Table Assignments;

select * from Assignments;