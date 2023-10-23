

CREATE TABLE Person (
    UserID int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
    EmailAddress varchar(255),
    Age int
);

CREATE TABLE Course (
    CourseID int IDENTITY(1,1) PRIMARY KEY,
    CourseName varchar(255),
	BatchID int
);

CREATE TABLE Batch(
    BatchID int IDENTITY(1,1) PRIMARY KEY,
    BatchName varchar(255)
);

CREATE TABLE AuthorizedPersonRole(
    RoleID int IDENTITY(1,1) PRIMARY KEY,
    RoleName varchar(255)
);