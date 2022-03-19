-- Creating Hospital management database
create database HMS_System

-- Using HMS Database
use HMS_System

/*		***Creating Tables***     */

-- Doctors Detail
create table Doctors
(Doctor_ID int primary key, 
Doctor_Name varchar(50), 
Doctor_Contact varchar(20), 
Doctor_CNIC varchar(20), 
Doctor_Address varchar(50), 
Doctor_Qualification varchar(20))

select * from Doctors

-- Nurses Detail
create table Nurses
(Nurse_ID int primary key, 
Nurse_Name varchar(50), 
Nurse_Contact varchar(20), 
Nurse_CNIC varchar(20), 
Nurse_Address varchar(50))

select * from Nurses

-- Receptionist Detail
create table Receptionist
(Receptionist_ID int primary key, 
Receptionist_Name varchar(50), 
Receptionist_Contact varchar(20), 
Receptionist_CNIC varchar(20), 
Receptionist_Address varchar(50))

select * from Receptionist

-- Patient Detail
create table Patient
(Patient_ID int primary key, 
Patient_Name varchar(50), 
Patient_Contact varchar(20), 
Patient_CNIC varchar(20), 
Patient_Address varchar(50), 
Patient_Age int, 
Patient_Gender varchar(20), 
Doctor_ID int foreign key references Doctors(Doctor_ID))

select * from Patient

-- Medicines Detail
create table Medicines
(Medicines_ID int primary key, 
Medicines_Name varchar(50), 
Medicines_Quality int, 
Medicines_Price int)

select * from Medicines

-- Appointment Detail
create table Appointment
(Appointment_Day int, 
Appointment_Month int, 
Appointment_Year int, 
Appointment_Time int, 
Appointment_Meridiem varchar(3),
Patient_ID int foreign key references Patient(Patient_ID),
Doctor_ID int foreign key references Doctors(Doctor_ID))

select * from Appointment

-- CheckUp Detail
create table CheckUp
(Medicine_Duration int,
Disease_Description varchar(200),
Patient_ID int foreign key references Patient(Patient_ID),
Doctor_ID int foreign key references Doctors(Doctor_ID),
Medicines_ID int foreign key references Medicines(Medicines_ID))

select * from CheckUp

--Laboratory Detail
create table Laboratory
(Test_ID int primary key,
Test_Name varchar(50),
Test_Date varchar(10),
Result_Date varchar(10),
Patient_ID int foreign key references Patient(Patient_ID))

select * from Laboratory

--Pharmacy Detail
create table Pharmacy
(Medicine_Bill int,
Patient_ID int foreign key references Patient(Patient_ID),
Medicines_ID int foreign key references Medicines(Medicines_ID))

select * from Pharmacy

--Bill Detail
create table Bill
(Bill_Date varchar(20),
Bill_Time varchar(10),
Bill_Description varchar(50),
Bill_Amount int,
Patient_ID int foreign key references Patient(Patient_ID))

select * from Bill
