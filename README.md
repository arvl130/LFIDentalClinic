# Patient Record System for LFI Dental Clinic using ASP.NET

## Database Setup

To setup the database for this project, create a database called `LFIDentalClinic`, and run the following SQL commands:

```sql
USE LFIDentalClinic;

CREATE TABLE [dbo].[Users] (
	[Username] NVARCHAR(50) NOT NULL PRIMARY KEY,
	[Password] NVARCHAR(100) NOT NULL
);

INSERT INTO [dbo].[Users] VALUES ('admin', 'admin');

CREATE TABLE [dbo].[Patients] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FullName NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	Gender NVARCHAR(10) NOT NULL,
	BirthDate NVARCHAR(10) NOT NULL,
	MaritalStatus NVARCHAR(10) NOT NULL,
	MobileNumber NVARCHAR(11) NOT NULL,
	TelephoneNumber NVARCHAR(11) NOT NULL,
	-- Dental History
	Palate BIT NOT NULL,
	BadBreath BIT NOT NULL,
	BleedingInMouth BIT NOT NULL,
	GumsColorChange BIT NOT NULL,
	LumpsInMouth BIT NOT NULL,
	TeethColorChange BIT NOT NULL,
	SensitiveTeeth BIT NOT NULL,
	ClickingSound BIT NOT NULL,
	PastDentalCareOrTreatments NVARCHAR(500) NOT NULL,
	-- Medical Chart
	HeartAilmentOrDisease NVARCHAR(500) NOT NULL,
	HospitalAdmission NVARCHAR(500) NOT NULL,
	SelfMedication NVARCHAR(500) NOT NULL,
	Allergies NVARCHAR(500) NOT NULL,
	Operation NVARCHAR(500) NOT NULL,
	TumorsOrGrowth NVARCHAR(500) NOT NULL,
	Diabetes BIT NOT NULL,
	Sinusitis BIT NOT NULL,
	BleedingGums BIT NOT NULL,
	Hypertension BIT NOT NULL,
	StomachDisease BIT NOT NULL,
	BloodDisease BIT NOT NULL,
	Headache BIT NOT NULL,
	LiverDisease BIT NOT NULL,
	Pregnant NVARCHAR(500) NOT NULL,
	Cold BIT NOT NULL,
	Kidney BIT NOT NULL,
	FamilyHistryOnAny NVARCHAR(500) NOT NULL,
);

CREATE TABLE [dbo].[DentalTreatments] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	PatientId INT NOT NULL FOREIGN KEY REFERENCES Patients(Id) ON DELETE CASCADE,
	CreatedDate NVARCHAR(10) NOT NULL,
	Service NVARCHAR(50) NOT NULL,
	ProcedureDetails NVARCHAR(3000) NOT NULL
);
```

## Login

The default login credentials are `admin` and `admin` for the username and password, respectively.
