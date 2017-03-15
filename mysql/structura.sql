drop database if exists tema2;
create database tema2;
use tema2;

create table Course(
	id int(6) not null AUTO_INCREMENT,
	name varchar(45),
	teacher varchar(45),
	studyYear int(4),
	adresa varchar(120),
	primary key (id)
);

create table Student(
	id int(6) not null AUTO_INCREMENT,
	birthdate date,
	email varchar(255),
	address varchar(255),
	primary key (id)
);

create table CS(
	studentID int(6),
	courseID int(6),
	constraint student_c foreign key (studentID) references Student(id),
	constraint course_c  foreign key (courseID)  references Course(id)
);