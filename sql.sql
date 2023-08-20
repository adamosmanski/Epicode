USE [Epicode]


CREATE TABLE Employee (
    [ID] INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR(255),
    [TeamID] INT,
    [PositionID] INT,
    [VacationPackageID] INT,
    FOREIGN KEY ([TeamID]) REFERENCES Team([ID]),
    FOREIGN KEY ([VacationPackageID]) REFERENCES VacationPackage([ID])
);

CREATE TABLE Vacations (
    [ID] INT IDENTITY(1, 1) PRIMARY KEY,
    [DateSince] DATETIME,
    [DateUntil] DATETIME,
    [NumberOfHours] INT,
    [IsPartialVacation] INT,
    [EmployeeID] INT,
    FOREIGN KEY ([EmployeeID]) REFERENCES Employee([ID])
);



INSERT INTO Team ([Name]) VALUES ('Zespó³ 1'), ('Zespó³ 2'), ('Zespó³ 3');

INSERT INTO VacationPackage ([Name], [GrantedDays], [Year])
VALUES 
    ('Package 1', 5, 2019),
    ('Package 2', 10, 2020),
    ('Package 3', 15, 2021),
    ('Package 4', 20, 2022),
	('Package 5', 25, 2023);

INSERT INTO Employee ([Name], [TeamID], [VacationPackageID])
VALUES 
    ('.Net Developer', 1, 1),
	('.Net Developer', 1, 1),
	('.Net Developer', 1, 2),
	('.Net Developer', 1, 2),
    ('Java Developer', 2, 2),
    ('Backend Developer', 3, 3);



INSERT INTO Vacations ([DateSince], [DateUntil], [NumberOfHours], [IsPartialVacation], [EmployeeID])
VALUES 
    ('2023-08-01', '2023-08-05', 40, 0, 1),
	('2023-08-01', '2023-08-05', 40, 0, 1),
    ('2023-08-10', '2023-08-15', 30, 1, 2),
    ('2023-09-01', '2023-09-10', 50, 0, 3);


