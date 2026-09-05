
USE MyPortfolioDB;
GO

INSERT INTO Students (FirstName, LastName, Age, Email) VALUES
(N'Иван', N'Петров', 20, 'ivan@mail.ru'),
(N'Мария', N'Сидорова', 22, 'maria@mail.ru'),
(N'Алексей', N'Иванов', 19, NULL),
(N'Екатерина', N'Смирнова', 21, 'ekaterina@mail.ru');

-- Добавляем курсы
INSERT INTO Courses (CourseName, Credits) VALUES
(N'Математика', 4),
(N'Программирование на C#', 5),
(N'Базы данных', 3),
(N'Английский язык', 2);

-- Добавляем записи на курсы
INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate, Grade) VALUES
(1, 2, '2024-09-01', 85.5),
(1, 3, '2024-09-01', 90.0),
(2, 1, '2024-09-01', 75.0),
(2, 2, '2024-09-01', 92.5),
(3, 3, '2024-09-01', NULL),
(4, 2, '2024-09-01', 88.0),
(4, 4, '2024-09-01', 95.0);