go 
use PostGrad_System
--1.a) Register to the website by using my name (First and last name), password, faculty, email, and address
go
Create Procedure StudentRegister
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@faculty varchar(20),
@Gucian bit,
@email varchar(50),
@address varchar(50)
as 
declare @id int
if @Gucian= 1
begin
	insert into PostGradUser(email,password) values(@email,@password)
	set @id= (select max(id) from PostGradUser)
	insert into GucianStudent(id,firstName,lastName,faculty,address)
		values(@id,
			@first_name,
			@last_name,
			@faculty,
			@address)
	
end
else 
begin
insert into PostGradUser(email,password) values(@email,@password)
set @id= (select max(id) from PostGradUser)
insert into NonGucianStudent(id,firstName,lastName,faculty,address)
	values(@id,
			@first_name,
			@last_name,
			@faculty,
			@address)	
end
go

--1.a) Register to the website by using my name (First and last name), password, faculty, email, and address
go
Create Procedure SupervisorRegister
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@faculty varchar(20),
@email varchar(50)
as
declare @id int
insert into PostGradUser(email,password) values(@email,@password)
set @id= (select max(id) from PostGradUser)
insert into Supervisor(id,name,faculty)
values(@id,
			@first_name +
			@last_name,
			@faculty)
go

--2.a) login using my username and password
go
Create function userLogin
(@ID int,
@password varchar(20))
returns bit
begin 
Declare @Success bit
if(exists(select id,password from PostGradUser where id=@ID and password= @password))
set @Success ='1'
else
set @Success ='0'
Return @Success
end
go

--2.b) add my mobile number(s)
go
create procedure addMobile 
	@ID int, 
	@mobile_number varchar(20)
as
	if (exists(Select id from GucianStudent where id=@ID))
		insert into GUCStudentPhoneNumber values(@ID,@mobile_number)
	else 
		insert into NonGUCStudentPhoneNumber values(@ID,@mobile_number)
go

--3.a) List all supervisors in the system.
go
create Procedure AdminListSup
as Select*from Supervisor;
go

--3.b) view the profile of any supervisor that contains all his/her information
go
create procedure AdminViewSupervisorProfile
	@supId int
as 
	Select* from PostGradUser PGU inner join Supervisor S on PGU.id=S.id
		where S.id=@supId
go

--3.c) List all Theses in the system.
go
create Procedure AdminViewAllTheses
as
	Select*from Thesis;
go

--3.d) List the number of on going theses.
go
create function AdminViewOnGoingTheses()
returns int
begin
declare @thesesCount int
set @thesesCount= (Select count(*) from Thesis where YEAR(CURRENT_TIMESTAMP)<Year(endDate))
return @thesesCount
end
go

--3.e) List all supervisors’ names currently supervising students, theses title, student name.
go
create procedure AdminViewStudentThesisBySupervisor
as	
Select S.name as 'Supervisor_name', Th.title as 'Thesis_Title',GS.firstName as 'Student_First_name', GS.lastName as 'Student_Last_name' from Supervisor S 
	inner join GUCianStudentRegisterThesis GSRT on S.id =GSRT.supid inner join Thesis Th on Th.serialNumber=GSRT.serial_no
	inner join GucianStudent GS on GSRT.sid=GS.id
	union Select S.name as 'Supervisor_name', Th.title as 'Thesis_Title',NGS.firstName as 'Student_First_name',NGS.lastName as 'Student_Last_name' from Supervisor S 
	inner join NonGUCianStudentRegisterThesis NGSRT on S.id =NGSRT.supid inner join Thesis Th on Th.serialNumber=NGSRT.serial_no
	inner join NonGucianStudent NGS on NGSRT.sid=NGS.id
go

--3.f) List nonGucians names, course code, and respective grade.
go
create procedure AdminListNonGucianCourse
	@courseID int
as
 Select NG.firstName,NG.lastName, C.code, NGTC.grade from NonGucianStudent NG inner join NonGucianStudentTakeCourse NGTC on NG.id=NGTC.sid inner join Course C on NGTC.cid=C.id
	where NGTC.cid=@courseID
go

--3.g) Update the number of thesis extension by 1.
go
create procedure AdminUpdateExtension
	@ThesisSerialNo int
as
	Update Thesis
	set noExtention=noExtention+1
	where Thesis.serialNumber=@ThesisSerialNo
go


--3.h) Issue a thesis payment.
go
create function AdminIssueThesisPayment(
	@ThesisSerialNo int, 
	@amount decimal, 
	@noOfInstallments int, 
	@fundPercentage decimal)
returns bit
begin
declare @Success bit
	if(exists(Select* from Payment P inner join Thesis Th on P.id=Th.payment_id
			where Th.serialNumber=@ThesisSerialNo and P.amount=@amount and P.no_Installments=@noOfInstallments and P.fundPercentage=@fundPercentage))
		set @Success ='1'
	else
		set @Success='0'
	return @Success
end
go

--3.i) view the profile of any student that contains all his/her information.
go
create proc AdminViewStudentProfile
@sid int
as
if(exists(select id from GucianStudent where @sid=id))
	select * 
	from GucianStudent GS inner join PostGradUser P on GS.id=P.id
	where @sid=GS.id

else if(exists(select id from NonGucianStudent where @sid=id))
	select * 
	from NonGucianStudent NS inner join PostGradUser P on NS.id=P.id
	where @sid=NS.id
go

--3.j) Issue installments as per the number of installments for a certain payment every six months starting from the entered date.
go
create proc AdminIssueInstallPayment
@paymentID int, 
@InstallStartDate date
as
Declare @amount decimal
set @amount=(select amount from Payment where id=@paymentID)
Declare @number int
set @number= (select no_Installments from Payment where id=@paymentID)
Declare @value decimal
set @value= @amount/@number
Declare @counter INT
Set @counter=1
Declare @date date
set @date=@InstallStartDate
while(@counter<=@number)
Begin
set @date=DATEADD(month,6,@date)
set @counter= @counter+1
insert into Installment(date,paymentId,amount) values (@date,@paymentID,@value)
end
go
--3.k) List the title(s) of accepted publication(s) per thesis.
go
create proc AdminListAcceptPublication
as
	select P.title,TP.serialNo
	from Thesis T INNER JOIN ThesisHasPublication TP on T.serialNumber=TP.serialNo INNER JOIN Publication P on P.id=TP.pubid
	group By TP.serialNo,P.title,P.accepted
	having P.accepted=1
go

--3.l) Add courses to students.
go
create proc AddCourse
@courseCode varchar(10),
@creditHrs int,
@fees decimal
as 
insert into Course(id,creditHours,fees) values(@courseCode,@creditHrs,@fees)
go

--3.l) link courses to students
go
create proc linkCourseStudent
@courseID int,
@studentID int
as 
insert into NonGucianStudentTakeCourse(cid,sid) values(@courseID,@studentID)
go

--3.l) Add courses' grade to students
go 
create proc addStudentCourseGrade
@courseID int,
@studentID int,
@grade decimal
as
update NonGucianStudentTakeCourse 
set grade=@grade
where sid=@studentID and cid=@courseID
go

--3.m) View examiners and supervisor(s) names attending a thesis defense taking place on a certain date.
go
create proc ViewExamSupDefense
@defenseDate datetime
as 
begin
if(exists(select * from Defense D inner join Thesis T on D.serialNumber=T.serialNumber inner join GUCianStudentRegisterThesis G on G.serial_no=T.serialNumber where @defenseDate=D.date))
	select S.name, E.name
	from Supervisor S inner join GUCianStudentRegisterThesis GSRT on S.id=GSRT.supid inner join Thesis T on GSRT.serial_no=T.serialNumber inner join Defense D on T.serialNumber=D.serialNumber inner join ExaminerEvaluateDefense EED on D.serialNumber=EED.serialNo inner join Examiner E on EED.examinerId=E.id
	where @defenseDate=D.date
else if(exists(select * from Defense D inner join Thesis T on D.serialNumber=T.serialNumber inner join NonGUCianStudentRegisterThesis NG on NG.serial_no=T.serialNumber where @defenseDate=D.date))
	select S.name, E.name
	from Supervisor S inner join NonGUCianStudentRegisterThesis NGSRT on S.id=NGSRT.supid inner join Thesis T on NGSRT.serial_no=T.serialNumber inner join Defense D on T.serialNumber=D.serialNumber inner join ExaminerEvaluateDefense EED on D.serialNumber=EED.serialNo inner join Examiner E on EED.examinerId=E.id
	where @defenseDate=D.date
else 
	  RAISERROR('Student Failed',16,1)
end
go

--4.a) Evaluate a student’s progress report, and give evaluation value 0 to 3.
go 
Create Proc EvaluateProgressReport
@supervisorID int, 
@thesisSerialNo int, 
@progressReportNo int, 
@evaluation int
as

Declare @GID int
Declare @NID int

set @GID=(select sid from GUCianStudentRegisterThesis where @thesisSerialNo=serial_no)
Set @NID=(select sid from NonGUCianStudentRegisterThesis where @thesisSerialNo=serial_no)
if(exists(select sid,no,thesisSerialNumber from GUCianProgressReport where @GID=sid and @progressReportNo=no and @thesisSerialNo=thesisSerialNumber))
if(@evaluation between 0 and 3)
	update GUCianProgressReport 
	set eval=@evaluation 
	where @supervisorID=supid and @thesisSerialNo=thesisSerialNumber and @progressReportNo=no and @GID=sid
else
begin
	raiserror('Invalid eval input',18,1)
end
else 
begin if(exists(select sid,no,thesisSerialNumber from NonGUCianProgressReport where @NID=sid and @progressReportNo=no and @thesisSerialNo=thesisSerialNumber))
if(@evaluation between 0 and 3)
update NonGUCianProgressReport 
	set eval=@evaluation 
	where @supervisorID=supid and @thesisSerialNo=thesisSerialNumber and @progressReportNo=no and @NID=sid
else
begin
	raiserror('Invalid eval input',18,2)
end
end
go


--4.b) View all my students’s names and years spent in the thesis.
go
create proc ViewSupStudentsYears
@supervisorID int
as
	select G.firstName,G.lastName,Th.years
	from GucianStudent G INNER JOIN GUCianStudentRegisterThesis Gt on G.id=Gt.sid INNER JOIN Thesis Th on Th.serialNumber=Gt.serial_no
	where @supervisorID= Gt.supid 
union
	select NG.firstName,NG.lastName, Th.years
	from NonGucianStudent NG INNER JOIN NonGUCianStudentRegisterThesis NGt on NG.id=NGt.sid INNER JOIN Thesis Th on Th.serialNumber=NGt.serial_no
	where @supervisorID= NGt.supid 
go

--4.c) View supervisor's personal information.
go
create proc SupViewProfile
@supervisorID int
as 
Select * 
from Supervisor S inner join PostGradUser P on S.id=P.id 
where S.id = @supervisorID
go

--4.c) Update supervisor's personal information.
go 
create proc UpdateSupProfile
@supervisorID int, 
@name varchar(20), 
@faculty varchar(20)
as
update Supervisor 
set name=@name,
	faculty=@faculty
where id=@supervisorID
go


--4.d) View all publications of a student.
go
create procedure  ViewAStudentPublications
@StudentID int
as
if(exists(select sid from GUCianProgressReport where @StudentID=sid))
select P.* from  GucianStudent GS inner join GUCianStudentRegisterThesis GST on GS.id=GST.sid inner join Thesis T on GST.serial_no=T.serialNumber inner join ThesisHasPublication TP on T.serialNumber=TP.serialNo inner join Publication P on TP.pubid=P.id
where GS.id = @StudentID
else if(exists(select sid from NonGUCianProgressReport where @StudentID=sid)) 
select P.* from  NonGucianStudent NGS inner join NonGUCianStudentRegisterThesis NGST on NGS.id=NGST.sid inner join Thesis T on NGST.serial_no=T.serialNumber inner join ThesisHasPublication TP on T.serialNumber=TP.serialNo inner join Publication P on TP.pubid=P.id
where NGS.id = @StudentID
go

--4.e) Add defense for a thesis for Gucian students
go
create proc AddDefenseGucian
@ThesisSerialNo int , 
@DefenseDate Datetime , 
@DefenseLocation varchar(15)
as
if(exists(select serial_no from GUCianStudentRegisterThesis where @ThesisSerialNo=serial_no))
    insert into Defense (serialNumber,date,location)values(@ThesisSerialNo,@DefenseDate,@DefenseLocation) 
go

--4.e) Add defense for a thesis for Nongucian students
go
create proc AddDefenseNonGucian
    @thesisSerialNo int,
    @defenseDate datetime,
    @defenseLocation varchar(15)
as
begin
    declare @ID int
    set @ID = (select sid from NonGUCianStudentRegisterThesis N where N.serial_no = @thesisSerialNo)

    if not exists ( select NG.* from NonGucianStudentTakeCourse NG where NG.sid = @ID and NG.grade <= 50) 
	begin

        insert into Defense (serialNumber, date, location) values (@thesisSerialNo, @defenseDate, @defenseLocation)

        update Thesis
        set defenseDate = @defenseDate
        where Thesis.serialNumber = @thesisSerialNo
    end
	else  
	begin
	raiserror('Student Failed',16,1)
	end
end
go

--4.f) Add examiner(s) for a defense.
go
Create Proc AddExaminer
@ThesisSerialNo int , 
@DefenseDate Datetime , 
@ExaminerName varchar(20), 
@National bit, 
@fieldOfWork varchar(20)
as 
declare @ID int
declare @IDF int
set @ID =(select max(id) from PostGradUser)
set @IDF= @ID+1
if exists(select serialNumber,date from Defense where @ThesisSerialNo=serialNumber and @DefenseDate=date)
set Identity_insert PostGradUser ON
insert into PostGradUser (id) values (@IDF)
set Identity_insert PostGradUser OFF
insert into Examiner values (@IDF,@ExaminerName,@fieldOfWork,@National) 
    insert into ExaminerEvaluateDefense (date,serialNo,examinerId)values (@DefenseDate,@ThesisSerialNo,@IDF)
go

--4.g)Cancel a Thesis if the evaluation of the last progress report is zero.
go
create proc CancelThesis 
@ThesisSerialNo int 
as
if exists (select * from GUCianProgressReport GP
where GP.thesisSerialNumber=@ThesisSerialNo AND GP.eval=0 AND
GP.date>(select max(GS.date) FROM GUCianProgressReport GS 
where GS.thesisSerialNumber=@ThesisSerialNo AND GP.no<>GS.no))
begin
delete from Thesis where
serialNumber=@ThesisSerialNo
end
else
begin
if exists (select * from NonGUCianProgressReport NGP
where NGP.thesisSerialNumber=@ThesisSerialNo AND NGP.eval=0 AND
NGP.date>(select MAX(NGS.date) from NonGUCianProgressReport NGS 
where NGS.thesisSerialNumber=@ThesisSerialNo AND NGP.no<>NGS.no))
begin
delete from Thesis where
serialNumber=@ThesisSerialNo
end
end
go

 --4.h) Add a grade for a thesis. 
go
create proc AddGrade
@ThesisSerialNo int,
@grade decimal
as
Update Thesis
set grade=@grade
where serialNumber=@ThesisSerialNo
go

--5.a) Add grade for a defense.
go
create proc AddDefenseGrade
@ThesisSerialNo int , 
@DefenseDate Datetime , 
@grade decimal
as
Update Defense
set grade=@grade
where serialNumber=@ThesisSerialNo and date=@DefenseDate
go

--5.b) Add comments for a defense.
go
create proc AddCommentsGrade
@ThesisSerialNo int , 
@DefenseDate Datetime , 
@comments varchar(300)
as
Update ExaminerEvaluateDefense
set comment=@comments
where serialNo=@ThesisSerialNo and date=@DefenseDate 
go

--6.a) View my profile that contains all my information.
go
create proc viewMyProfile
@studentId int
as
if (exists(select id from GucianStudent where id=@studentId))
    begin
    select * from GucianStudent G inner join PostGradUser Ps on G.id=Ps.id inner join GUCStudentPhoneNumber PM on G.id=PM.id where G.id=@studentId
    end
else 
begin
    select * from NonGucianStudent NG inner join PostGradUser Ps on NG.id=Ps.id inner join NonGUCStudentPhoneNumber NPM on NG.id=NPM.id where NG.id=@studentId
  end

--6.b) Edit my profile (change any of my personal information).
go
create proc editMyProfile
	@studentID int,
	@firstName varchar(10),
	@lastName varchar(10),
	@password varchar(10), 
	@email varchar(10), 
	@address varchar(10),
	@type varchar(10)
	as
if(exists(select id from GucianStudent where id=@studentID))
begin
	Begin Transaction

	update GucianStudent
		set	firstName=@firstName,
		lastName= @lastName,
		address=@address,
		type=@type 
	where id=@studentID
	update PostGradUser 
	set password=@password,
		email=@email
	where id=@studentID

	commit	
end
else
begin
	Begin Transaction
	update NonGucianStudent
		set	firstName=@firstName,
		lastName= @lastName,
		address=@address,
		type=@type 
	where id=@studentID
	update PostGradUser 
	set password=@password,
		email=@email
	where id=@studentID
	commit
end
go

--6.c) As a Gucian graduate, add my undergarduate ID.
go
create proc addUndergradID
	@studentID int,
	@undergradID varchar(10)
as
update GucianStudent set undergradID=@undergradID where id=@studentID
go

--6.d) As a nonGucian student, view my courses’ grades
go 	
create proc ViewCourseGrades
@studentID int
as
select grade from NonGucianStudentTakeCourse
where @studentID=sid
go

--6.e) View course payment installments
go
create proc ViewCousrePaymentsInstall
@studentID int
as 
select I.* , P.*
from NonGucianStudentPayForCourse NG inner join Installment I on NG.paymentNo=I.paymentId inner join Payment P on I.paymentId=P.id
where @studentID=NG.sid
go

--6.e) View Thesis payment installments
go
create proc ViewThesisPaymentsInstall
@studentID int
as 
if(exists(select sid from GUCianStudentRegisterThesis where sid=@studentID))
	select I.*,P.* 
	from Thesis T inner join GUCianStudentRegisterThesis GR on T.serialNumber=GR.serial_no inner join Payment P on T.payment_id=P.id inner join Installment I on P.id=I.paymentId
	where @studentID=GR.sid
else if(exists(select sid from NonGUCianStudentRegisterThesis where sid=@studentID))
	select I.*,P.* 
	from Thesis T inner join NonGUCianStudentRegisterThesis NGR on T.serialNumber=NGR.serial_no inner join Payment P on T.payment_id=P.id inner join Installment I on P.id=I.paymentId
	where @studentID=NGR.sid
go

--6.e) View upcoming payment installments
go 
Create proc ViewUpcomingInstallments
@studentID int
as
if(exists(select sid from GUCianStudentRegisterThesis where @studentID=sid))
select I.* ,P.*
from GUCianStudentRegisterThesis GS inner join Thesis T on GS.serial_no=T.serialNumber inner join Payment P on T.payment_id=P.id inner Join Installment I on P.id=I.paymentId
where I.date > CURRENT_TIMESTAMP and GS.sid=@studentID
else if(exists(select sid from NonGUCianStudentRegisterThesis where @studentID=sid))
select I.* ,P.*
from Installment I inner join Payment P on I.paymentId=P.id inner join NonGucianStudentPayForCourse NG on P.id=NG.paymentNo 
where I.date > CURRENT_TIMESTAMP and NG.sid=@studentID
union
select I.* ,P.*
from NonGUCianStudentRegisterThesis NGS inner join Thesis T on NGS.serial_no=T.serialNumber inner join Payment P on T.payment_id=P.id inner Join Installment I on P.id=I.paymentId
where I.date > CURRENT_TIMESTAMP and NGS.sid=@studentID
go

--6.e) View missed payment installments
go 
Create proc ViewMissedInstallments
@studentID int
as
if(exists(select sid from GUCianStudentRegisterThesis where @studentID=sid))
select I.* ,P.*
from GUCianStudentRegisterThesis GS inner join Thesis T on GS.serial_no=T.serialNumber inner join Payment P on T.payment_id=P.id inner Join Installment I on P.id=I.paymentId
where I.date < CURRENT_TIMESTAMP and GS.sid=@studentID
else if(exists(select sid from NonGUCianStudentRegisterThesis where @studentID=sid))
select I.* ,P.*
from Installment I inner join Payment P on I.paymentId=P.id inner join NonGucianStudentPayForCourse NG on P.id=NG.paymentNo 
where I.date < CURRENT_TIMESTAMP and NG.sid=@studentID
union
select I.* ,P.*
from NonGUCianStudentRegisterThesis NGS inner join Thesis T on NGS.serial_no=T.serialNumber inner join Payment P on T.payment_id=P.id inner Join Installment I on P.id=I.paymentId
where I.date < CURRENT_TIMESTAMP and NGS.sid=@studentID
go

--6.f) Add a progress report(s).
go
create proc AddProgressReport
@thesisSerialNo int, 
@progressReportDate date
as
Declare @NGID int
Declare @P int
declare @NGP int
declare @GID int
declare @PID int
declare @GPIDF int
declare @GSUP int
Declare @NSUP int

set @PID= (select max(no) from GUCianProgressReport)
Set @GPIDF = @PID +1
set @GID = (select sid from GUCianStudentRegisterThesis where @thesisSerialNo=serial_no)
set @P = (select max(no) from NonGUCianProgressReport)
set @PID=@P+1
set @NGID=(select sid from NonGUCianStudentRegisterThesis where @thesisSerialNo=serial_no)
Set @GSUP=(select supid from GUCianStudentRegisterThesis where @thesisSerialNo=serial_no)
set @NSUP=(select supid from NonGUCianStudentRegisterThesis where @thesisSerialNo=serial_no)

if(exists(select serial_no from GUCianStudentRegisterThesis where @thesisSerialNo=serial_no))
	insert into GUCianProgressReport (sid,no,thesisSerialNumber,date,supid) values (@GID,@GPIDF,@thesisSerialNo,@progressReportDate,@GSUP)
else if (exists(select serial_no from NonGUCianStudentRegisterThesis where @thesisSerialNo=serial_no))
	insert into NonGUCianProgressReport (sid,no,thesisSerialNumber,date,supid) values (@NGID,@PID,@thesisSerialNo,@progressReportDate,@NSUP)
go

--6.f) Fill progress report(s)
go
Create proc FillProgressReport
@thesisSerialNo int, 
@progressReportNo int, 
@state int, 
@description varchar(200)
as
Declare @GID int
Declare @NID int

set @GID=(select sid from GUCianStudentRegisterThesis where @thesisSerialNo=serial_no)
Set @NID=(select sid from NonGUCianStudentRegisterThesis where @thesisSerialNo=serial_no)

if(exists(select sid,no,thesisSerialNumber from GUCianProgressReport where @GID=sid and @progressReportNo=no and @thesisSerialNo=thesisSerialNumber))
	update GUCianProgressReport 
	set state=@state,
	description=@description
	where @GID=sid and @progressReportNo=no and @thesisSerialNo=thesisSerialNumber
else if(exists(select sid,no,thesisSerialNumber from NonGUCianProgressReport where @NID=sid and @progressReportNo=no and @thesisSerialNo=thesisSerialNumber))
	update NonGUCianProgressReport 
	set state=@state,
	description=@description
	where @NID=sid and @progressReportNo=no and @thesisSerialNo=thesisSerialNumber
go


--6.g) View my progress report(s) evaluations.
go
create proc ViewEvalProgressReport 
@thesisSerialNo int, 
@progressReportNo int
as
if (exists(select no,thesisSerialNumber from GUCianProgressReport where @thesisSerialNo=thesisSerialNumber and @progressReportNo=no))
	begin
	select eval from GUCianProgressReport where @thesisSerialNo=thesisSerialNumber and @progressReportNo=no
	end
else
	begin
		select eval from NonGUCianProgressReport where @thesisSerialNo=thesisSerialNumber and @progressReportNo=no
	end
go

--6.h) Add publication.
go
create proc addPublication
@title varchar(50), 
@pubDate datetime, 
@host varchar(50), 
@place varchar(50), 
@accepted bit
as
declare @ID int
set @ID=(select max(id) from Publication)+1
insert into Publication (id,title, date, host, place, accepted ) values (@ID,@title, @pubDate, @host, @place, @accepted)
go

--6.i) Link publication to my thesis.
go 
Create proc linkPubThesis
@PubID int, 
@thesisSerialNo int
as
if(exists(select id from Publication where @PubID=id))
if(exists(select serialNumber from Thesis where @thesisSerialNo=serialNumber))
insert into ThesisHasPublication values ( @thesisSerialNo,@PubID )
go