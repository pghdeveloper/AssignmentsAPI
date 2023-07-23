-- Create Table Assignments(
-- Id INTEGER PRIMARY KEY AUTOINCREMENT,
-- ExternalId TEXT NOT NULL,
-- Assignee TEXT NOT NULL CHECK(length(Assignee) <= 255),
-- DueDate TEXT NOT NULL,
-- Description TEXT NOT NULL Check(length(Description) <= 500),
-- PercentComplete NUMERIC NULL CHECK(PercentComplete == ROUND(PercentComplete, 2)),
-- IsPriority INTEGER NULL);

-- Insert Into Assignments(ExternalId, Assignee, DueDate, Description, PercentComplete, IsPriority)
-- Values('e173bd80-897e-4599-ab1b-c07bf1fd3fbb', 'Matt Riddle', '2023-09-01', 'Test Description', 56.76, 1);
-- 
-- Insert Into Assignments(ExternalId, Assignee, DueDate, Description)
-- Values('37f57b66-9da9-4e13-8e1d-0285df56acdc', 'John Cena', '2023-09-01', 'Test Description');

--DROP Table Assignments;

--select * from Assignments;