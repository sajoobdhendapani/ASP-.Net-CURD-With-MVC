Create procedure InsertStudentDetails
@Name nvarchar(50),@DOB datetime2(7),@AGE int,@Gender nvarchar,@MobileNumber bigint,@Email nvarchar(50),@subject nvarchar(50)
as
begin
insert into StudentDetail values(@Name,@DOB,@AGE,@Gender,@MobileNumber,@Email,@subject)
end
exec InsertStudentDetails 'madan','12/02/2004',18,'m',7766554388,'madan@gmail.com','commers'
drop procedure InsertStudentDetails
select * from StudentDetail

create procedure UpdateStudentDetail
@StudentId bigint,@Name nvarchar(50),@DOB datetime2(7),@AGE int,@Gender nvarchar,@MobileNumber bigint,@Email nvarchar(50),@subject nvarchar(50)
as
begin
update StudentDetail set name=@name,DOB=@DOB,AGE=@AGE,Gender=@Gender,MoblieNumber=@MobileNumber,Email=@Email,Subject=@subject where StudentId=@StudentId
end
exec UpdateStudentDetail 1 ,'madan','12/16/2001',18,'f',998853429,'Madan@gmail.com','computer'
drop procedure UpdateStudentDetail

create procedure ReadallRecords
as
begin
select * from StudentDetail
end
exec ReadallRecords 

create procedure DeleteStudentDetails
(@studentId bigint)
as
begin
delete from StudentDetail where StudentId=@studentId
end
exec DeleteStudentDetails 1
 
