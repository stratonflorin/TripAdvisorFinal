
/*in caz de drop*/
USE master;
GO
ALTER DATABASE TripAdvisor
SET SINGLE_USER 
WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE TripAdvisor
--create prima oara
Create database TripAdvisor
--pe urma tabelele
use [TripAdvisor]
GO
Create table Utilizatori
(
UserID int primary key identity(1000,1),
Nume varchar(255) not null,
Prenume varchar(255) not null,
Parola varchar(255) not null,
NrTelefon varchar(255) unique,
Email varchar(255) unique not null,
Poza image
)
Create table Tari
(
TaraID int primary key identity(1000,1),
Nume varchar(255) unique not null,
)

Create table Orase
(
OrasID int primary key identity(1000,1),
Nume varchar(255) not null unique,
TaraID int foreign key references Tari(TaraID) not null,
)

Create table Cazare
(
CazareID int primary key identity(1000,1),
OrasID int foreign key references Orase(OrasID) not null,
Nume varchar(255) not null,
Adresa varchar(5000),
Stele int not null,
NrTelefon varchar(255) unique,
Email varchar(255) unique,
Poza image
)

Create table CategoriiObiective
(
CategorieID int primary key identity(1000,1),
Denumire varchar(255) unique not null,
Poza image not null
)

Create table Preparate
(
PreparatID int primary key identity(1000,1),
Denumire varchar(255) unique not null,
Poza image not null
)
Create table Restaurante
(
RestaurantID int primary key identity(1000,1),
OrasID int foreign key references Orase(OrasID) not null,
Nume varchar(255) not null,
NumarTelefon varchar(255) not null,
Adresa varchar(255) not null,
Program varchar(255),
Poza image
)
Create table Meniu
(
RestaurantID int foreign key references Restaurante(RestaurantID) not null,
PreparatID int foreign key references Preparate(PreparatID) not null,
CONSTRAINT pk_Meniu PRIMARY KEY (RestaurantID,PreparatID)
)
Create table Obiective
(
ObiectivID int primary key identity(1000,1),
Denumire varchar(255) not null,
Locatie varchar(255) not null,
OrasID int foreign key references Orase(OrasID) not null,
CategorieID int foreign key references CategoriiObiective(CategorieID) not null,
Poza image
)
Create table PozeRestaurante
(
RestaurantID int foreign key references Restaurante(RestaurantID) not null,
UserID int foreign key references Utilizatori(UserID) not null,
Poza image not null,
Data datetime default CURRENT_TIMESTAMP
)
Create table Camere
(
CameraID int primary key identity(1000,1),
CazareID int foreign key references Cazare(CazareID) not null,
Adresa varchar(5000),
NumarPaturi int not null,
PretPerNoapte int not null,
Poza image
)
Create table Rezervari
(
UserID int foreign key references Utilizatori(UserID) not null,
CameraID int foreign key references Camere(CameraID) not null,
DataCheckin datetime not null,
DataCheckout datetime not null,
DataRezervarii datetime not null default CURRENT_TIMESTAMP
)
Create table PozeHotel
(
CazareID int foreign key references Cazare(CazareID) not null,
UtilizatorID int foreign key references Utilizatori(UserID) not null,
Poza image not null,
Data datetime not null default CURRENT_TIMESTAMP
)
Create table PozeActivitati
(
ObiectivID int foreign key references Obiective(ObiectivID) not null,
UtilizatorID int foreign key references Utilizatori(UserID) not null,
Poza image not null,
Data datetime not null default CURRENT_TIMESTAMP
)
Create table RecenziiHoteluri
(
RecenzieID int primary key identity(1000,1),
UserID int foreign key references Utilizatori(UserID) not null,
CazareID int foreign key references Cazare(CazareID) not null,
Stele int not null,
Pret int not null,
Data datetime not null default CURRENT_TIMESTAMP,
Comentarii varchar(5000)
)
Create table RecenziiRestaurante
(
RecenzieID int primary key identity(1000,1),
UserID int foreign key references Utilizatori(UserID) not null,
RestaurantID int foreign key references Restaurante(RestaurantID) not null,
Stele int not null,
Pret int not null,
Comentarii varchar(5000),
Data datetime not null default CURRENT_TIMESTAMP
)
Create table RecenziiActivitati
(
RecenzieID int primary key identity(1000,1),
UserID int foreign key references Utilizatori(UserID) not null,
ObiectivID int foreign key references Obiective(ObiectivID) not null,
Stele int not null,
Comentarii varchar(5000),
Data datetime not null default CURRENT_TIMESTAMP
)


