use MyPortfolioDB;

select FirstName, LastName
from Students;

select * 
from Students where Age > 20;

select * 
from Courses where Credits > 3;

select *
from Students where Email is NULL;