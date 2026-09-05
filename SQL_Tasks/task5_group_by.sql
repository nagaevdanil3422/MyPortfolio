use MyPortfolioDB;

select c.CourseName, Avg(e.Grade) as AverageGrade
from Enrollments e 
join Courses c on e.CourseID = c.CourseID
where e.Grade is not null
Group by c.CourseName;

select CourseName, Count(e.StudentID) as CountStudent
from Enrollments e
join Courses c on e.CourseID = c.CourseID
group by c.CourseName;

select s.FirstName, s.LastName, e.Grade, c.CourseName
from Enrollments e 
join Students s on e.StudentID = s.StudentID
join Courses c on e.CourseID = c.CourseID
where e.Grade = (select Max(grade) from Enrollments)
