DBCC CHECKIDENT ('Trainer', NORESEED);
DBCC CHECKIDENT ('Member', RESEED, 3);

INSERT INTO [dbo].[Trainer] (Tname, Tage, Tgender, TphoneNumber)
VALUES 
('John Smith', 35, 'Male', '555-123-4567'),
('Emily Johnson', 28, 'Female', '555-987-6543'),
('David Lee', 42, 'Male', '555-456-7890');

INSERT INTO [dbo].[GymClass] (cTitle, cCategory, Tid, cFee)
VALUES 
('Yoga for Beginners', 'Yoga', 1, 50.00),
('Advanced Weight Training', 'Weight Training', 2, 75.00),
('Pilates Core Strength', 'Pilates', 3, 60.50);

select g.cTitle,g.cCategory,g.cFee,t.Tname from GymClass as g
join Trainer as t 
on t.Tid = g.Tid;

select Tid from Trainer where Tname='godfrey';