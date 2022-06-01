Create database PostGrad_System
go

use PostGrad_Systemf
--User table
create table PostGradUser(
	id int primary key identity,
	email varchar(50),
	password varchar(20));

-- Admin table
create table Admin(
	id int primary key,
	Foreign key(id) references PostGradUser(id) on delete CASCADE on update CASCADE)

-- GucianStudent table
create table GucianStudent(
	id int primary key,
	firstName varchar(20),
	lastName varchar(20),
	type varchar(10),
	faculty varchar(20),
	address varchar(50),
	GPA decimal,
	undergradID int,
	Foreign key(id) references PostGradUser(id) on delete cascade on update Cascade);

-- NonGucianStudent table
create table NonGucianStudent(
	id int primary key,
	firstName varchar(20),
	lastName varchar(20),
	type varchar(10),
	faculty varchar(50),
	address varchar(20),
	GPA decimal,
	Foreign key(id) references PostGradUser(id) on delete CASCADE on update CASCADE);

-- GUCStudentPhoneNumber Relation Table
create table GUCStudentPhoneNumber (
	id int,
	phone varchar(20),
	Primary key(id,phone),
	Foreign key(id) references GucianStudent(id));

-- NonGUCStudentPhoneNumber Relation Table
create table NonGUCStudentPhoneNumber(
	id int,
	phone varchar(20),
	Primary key(id,phone),
	Foreign key(id) references NonGucianStudent(id) on delete CASCADE on update CASCADE);

--Course table
create table Course ( 
	id int primary key,
	fees decimal,
	creditHours int,
	code varchar(10)
)

--Supervisor Table
create table Supervisor (
	id int,
	name varchar(20),
	faculty varchar(20),
	primary key (id),
	Foreign key(id) references PostGradUser(id) on delete CASCADE on update CASCADE
)

--Payment Table 
create table Payment ( 
	id int primary key ,
	amount decimal,
	no_Installments int ,
	fundPercentage decimal
)


--Thesis Table
create table Thesis ( 
	serialNumber int primary key,
	field varchar(20),
	type varchar(10),
	title varchar(50),
	startDate datetime,
	endDate datetime,
	defenseDate datetime,
	years AS (year(endDate) - year(startDate)),
	grade decimal(7,3),
	payment_id int references Payment(id) on delete CASCADE on update CASCADE,
	noExtention int )

--Publication Table
create table Publication (
	id int primary key,
	title varchar(50),
	date datetime,
	place varchar(50),
	accepted bit,
	host varchar(50)
)

--Examinar Table 
create table Examiner (
	id int primary key,
	name varchar(20) ,
	fieldOfWork varchar(20) ,
	isNational bit,
	Foreign key(id) references PostGradUser(id) on delete CASCADE on update CASCADE)

--Defense Table
create table Defense (
	serialNumber int ,
	date datetime,
	location varchar(15),
	grade decimal,
	primary key (serialNumber,date),
	Foreign key (serialNumber) references Thesis(serialNumber) on delete CASCADE on update CASCADE
	)

--GUCian Progress Report Relational Table 
create table GUCianProgressReport(
	sid int,
	no int,
	date date,
	eval int,
	state int,
	thesisSerialNumber int,
	supid int,
	description varchar(200),
	primary key (sid,no),
	Foreign key (sid) references GucianStudent(id) on delete CASCADE on update CASCADE,
	Foreign key (thesisSerialNumber) references Thesis(serialNumber) on delete CASCADE on update CASCADE,
	Foreign key (supid) references Supervisor(id) on delete no action on update no action
	)

--NonGUCian Progress Report Relational Table 
create table NonGUCianProgressReport(
	sid int,
	no int,
	date date,
	eval int,
	state int,
	thesisSerialNumber int,
	supid int,
	description varchar(200),
	primary key (sid,no),
	Foreign key (sid) references NonGucianStudent(id) on delete CASCADE on update CASCADE,
	Foreign key (thesisSerialNumber) references Thesis(serialNumber) on delete CASCADE on update CASCADE,
	Foreign key (supid) references Supervisor(id) on delete no action on update no action
	)


--Installments Table
create table Installment(
	date date,
	paymentId int,
	amount decimal,
	done bit,
	Primary key(date, paymentId),
	Foreign key (paymentId) references Payment(id) on delete CASCADE on update CASCADE);

--NonGucianStudentPayForCourse Relation Table
create table NonGucianStudentPayForCourse(
	sid int,
	paymentNo int,
	cid int,
	primary key(sid, paymentNo, cid),
    Foreign key (sid) references NonGucianStudent(id) on delete CASCADE on update CASCADE,
    Foreign key (paymentNo) references Payment(id) on delete CASCADE on update CASCADE,
	Foreign key (cid) references Course(id) on delete CASCADE on update CASCADE);

--NonGucianStudentTakeCourse Relation Table
create table NonGucianStudentTakeCourse(
	sid int,
	cid int,
	grade decimal,
	Primary key (sid, cid),
	Foreign key (sid) references NonGucianStudent(id) on delete CASCADE on update CASCADE,
	Foreign key (cid) references Course(id)on delete CASCADE on update CASCADE);

--GUCianStudentRegisterThesis Relation Table
create table GUCianStudentRegisterThesis(
	sid int,
	supid int,
	serial_no int,
	Primary Key (sid, supid, serial_no),
	Foreign Key (sid) references GucianStudent(id) on delete CASCADE on update CASCADE,
	Foreign Key (supid) references Supervisor(id) on delete no action on update no action,
	Foreign Key (serial_no) references Thesis(serialNumber) on delete CASCADE on update CASCADE);

--NonGUCianStudentRegisterThesis Relation Table
create table NonGUCianStudentRegisterThesis(
	sid int,
	supid int,
	serial_no int,
	Primary Key (sid, supid, serial_no),
	Foreign Key (sid) references NonGucianStudent(id) on delete CASCADE on update CASCADE,
	Foreign Key (supid) references Supervisor(id) on delete no action on update no action,
	Foreign Key (serial_no) references Thesis(serialNumber) on delete CASCADE on update CASCADE);

--ExaminerEvaluateDefense Relation Table
create table ExaminerEvaluateDefense(
	date datetime,
	serialNo int,
	examinerId int,
	comment varchar(300),
	Primary key (date, serialNo, examinerId),
	Foreign key (serialNo, date) references Defense(serialNumber, date) on delete CASCADE on update CASCADE,
	Foreign key (examinerId) references Examiner(id) on delete CASCADE on update CASCADE);

--ThesisHasPublication Relation Table
create table ThesisHasPublication(
	serialNo int,
	pubid int,
	Primary key (serialNo, pubid),
	Foreign key (serialNo) references Thesis(serialNumber)on delete CASCADE on update CASCADE ,
	Foreign key (pubid) references Publication(id)on delete CASCADE on update CASCADE);