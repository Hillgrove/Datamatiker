begin transaction

--create database ImdbBasics
--go

use ImdbBasics

create table TitleType (
	TitleTypeID int identity(1,1),
	Name varchar(20) not null unique,

	constraint PK_TitleType primary key clustered (TitleTypeID asc)
);

create table Title (
	Tconst varchar(10),
	TitleTypeID int not null,
	PrimaryTitle nvarchar(255) not null,
	OriginalTitle nvarchar(255) not null,
	IsAdult bit not null,
	StartYear smallint null,
	EndYear smallint null,
	RuntimeMinutes int null,

	constraint PK_Title primary key clustered (Tconst asc), --non clustered instead due to searches being on title mostly?
	constraint FK_Title_TitleType foreign key (TitleTypeID)
		references TitleType(TitleTypeID),
	constraint CHK_EndYear_Valid check
	(
		EndYear is null or StartYear <= EndYear
	)
);

create table Genre (
	GenreID int identity(1,1),
	Name varchar(20) not null unique,

	constraint PK_Genre primary key clustered (GenreID asc)
);

create table TitleGenre (
	Tconst varchar(10) not null,
	GenreID int not null,
	
	constraint PK_TitleGenre primary key clustered (Tconst, GenreID asc),
	constraint FK_TitleGenre_Title foreign key (Tconst)
		references Title(Tconst)
		on delete cascade,
	constraint FK_TitleGenre_Genre foreign key (GenreID)
		references Genre(GenreID)
);

rollback