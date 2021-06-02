Create Database EmployeePortal_Ganesh
Go

Create Table employee
(
emp_id int not null Primary key,
first_name Char( 50) not null,
last_name Char(50) not null,
gender Char(2) not null,
dob	date  not null,
pan_num	char(15),
aadhaar_num	char(15),
mobile_num	char(15)  not null,
email_id char(150)   not null,
office_mail	char(150)  not null,
permanent_address text,
present_address	text,
blood_group	char(5),
profile_pict char(200) Null,
doj	date  not null,
emp_level Int   not null,
post_name char(30)  not null,
basic_pay Int   not null,
house_allowance	Int   not null
)
GO

Create Table employment_history
(
id int Not null Primary Key,
emp_id int Not null FOREIGN KEY REFERENCES employee(emp_id),
organization_name int Not null,
from_date date  Not null,
until_date	date  Not null,
[location] char(30) Not null,
country text null,
post char(30) Not null,
skill_used	text Null
)
Go


ALTER TABLE employment_history
ALTER column organization_name varchar(50)



--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(1,10000,'ABC Pvt Ltd','01/05/2018','05/05/2021','Pune','India','Project Manager','.NET')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(2,10000,'XYZ nfotech','01/12/2016','01/04/2018','Kolkata','India','Team Lader','.NET')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(3,10000,'ABS Software','10/07/2013','01/06/2016','Newyork','USA','Senior App Developer','.NET')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(4,10000,'OOO Systems','01/01/2011','01/07/2013','Tokyo','Japan','Software Developer','.NET')


--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(5,10001,'ABC Pvt Ltd','01/05/2018','05/05/2021','Pune','India','Project Manager','Java')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(6,10001,'XYZ nfotech','01/12/2016','01/04/2018','Kolkata','India','Team Lader','Java')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(7,10001,'ABS Software','10/07/2013','01/06/2016','Newyork','USA','Senior App Developer','Java')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(8,10001,'OOO Systems','01/01/2011','01/07/2013','Tokyo','Japan','Software Developer','Java')

--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(9,10002,'ABC Pvt Ltd','01/05/2018','05/05/2021','Pune','India','Project Manager','.NET')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(10,10002,'XYZ nfotech','01/12/2016','01/04/2018','Kolkata','India','Team Lader','.NET')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(11,10002,'ABS Software','10/07/2013','01/06/2016','Newyork','USA','Senior App Developer','.NET')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(12,10002,'OOO Systems','01/01/2011','01/07/2013','Tokyo','Japan','Software Developer','.NET')


--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(13,10003,'ABC Pvt Ltd','01/05/2018','05/05/2021','Pune','India','Project Manager','Java')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(14,10003,'XYZ nfotech','01/12/2016','01/04/2018','Kolkata','India','Team Lader','Java')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(15,10003,'ABS Software','10/07/2013','01/06/2016','Newyork','USA','Senior App Developer','Java')
--insert into employment_history(id,emp_id,organization_name,from_date,until_date,location,country,post,skill_used)
--Values(16,10003,'OOO Systems','01/01/2011','01/07/2013','Tokyo','Japan','Software Developer','Java')