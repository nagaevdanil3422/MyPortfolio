

Use MyPortfolioDB;

-->Таблица Студенты 
create table Students (
StudentID int primary key identity(1,1),
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Age int,
Email Nvarchar(100) Unique
);

--> Таблица Курсы 
create table Courses (
CourseID int primary key identity(1,1),
CourseName nvarchar(100) not null,
Credits int check(Credits > 0)
);

--> Таблица Записи на курсы 
create table Enrollments (
EnrollmentID int primary key Identity(1, 1),
StudentId int foreign key references Students(StudentID),
CourseID int foreign key references Courses(CourseID),
EnrollmentDate DATe default getdate(),
Grade decimal(3,1) check (Grade >= 0 and Grade <=100)
);
