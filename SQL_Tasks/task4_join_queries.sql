use MyPortfolioDB;

select s.FirstName, s.LastName, c.CourseName
from Enrollments e
join Students s on e.StudentID = s.StudentID
join Courses c on e.CourseID = c.CourseID;

select s.FirstName, LastName, c.CourseName, Grade
from Enrollments e
join Students s on e.StudentID = s.StudentId
join Courses c on e.CourseID = c.CourseID;

SELECT s.FirstName, s.LastName, c.CourseName
FROM Students s
LEFT JOIN Enrollments e ON s.StudentID = e.StudentID
LEFT JOIN Courses c ON e.CourseID = c.CourseID;