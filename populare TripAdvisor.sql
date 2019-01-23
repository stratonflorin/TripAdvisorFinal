use TripAdvisor

SET IDENTITY_INSERT dbo.Tari ON
INSERT INTO Tari(TaraID, Nume) 
VALUES			(1, 'Romania'	),
			    (2, 'Ungaria'	),
				(3, 'Polonia'	),
				(4, 'Rusia'		),
				(5, 'Bulgaria'	),
				(6, 'Italia'    )
SET IDENTITY_INSERT dbo.Tari OFF
			

SET IDENTITY_INSERT dbo.Orase ON
INSERT INTO Orase ( OrasID, Nume, TaraId)
VALUES			  ( 11, 'Bucharest',	1),
				  ( 12, 'Sighisoara',	1),
				  ( 13, 'Cluj Napoca',	1),
				  ( 14, 'Bistrita',		1),
				  ( 15, 'Constanta',	1),
				  ( 16, 'Iasi',			1),
				  ( 21, 'Budapest',	2),
				  ( 22, 'Debrecen',		2),
				  ( 23, 'Miskolc',		2),
				  ( 31, 'Cracovia',		3),
				  ( 32, 'Warsaw',		3),
				  ( 33, 'Poznan',		3),
				  ( 41, 'Moscow',		4),
				  ( 42, 'Sankt Petersburg',		4),
				  ( 43, 'Novosibirsk',		4),
				  ( 51, 'Sofia',		5),
				  ( 52, 'Varna',        5),
				  ( 61, 'Rome',         6),
				  ( 62, 'Milan',       6),
				  ( 63, 'Venice',      6),
				  ( 64, 'Florence',     6)
SET IDENTITY_INSERT dbo.Orase OFF

SET IDENTITY_INSERT dbo.Restaurante ON
INSERT INTO Restaurante(RestaurantID, OrasID, Nume, NumarTelefon, Adresa, Program)
VALUES                 (121, 12, 'House Georgius Krauss',	'0763 986 132',         'Batalionului nr.11',                        'Deschis Luni-Sambata intre orele 08:30-22:30, Duminica intre orele 10:30-23:30'),
					   (122, 12, 'Casa cu Cerb',			'0274 512 789',         'Strada Scolii, nr. 1',						 'Deschis zilnic intre orele 10:30-23:30'),
					   (611, 61, 'Ristorante Pizzeria Pasquino', '+39 06 689 3043', 'Pizzeria Pasquino 1, Rome Italy',			 'Deschs zilnic intre orele 09:00-21:00'),
					   (641, 64, 'Essenziale',               '+39 02 367 0987',      'Piazza di Cestello 3R, 50124, Florence, Italy','Deschis zilnic intre orele 09:00-20:30')
insert into Restaurante(RestaurantID,OrasID,Nume,NumarTelefon,Adresa,Program,Poza)
SELECT '113','11','Vivo burgers','0777777777','Strada Soarelui 139',' Deschis zilnic intre orele 10:30-02:00',BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\restaurant.jpg', SINGLE_BLOB )as Poza
insert into Restaurante(RestaurantID,OrasID,Nume,NumarTelefon,Adresa,Program,Poza)
SELECT '111','11','Hanul Berarilor','0755 243 938','Str. Poenaru Bordea, nr. 2','Deschis zilnic intre orele 10:30-02:00',BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\hanul_berarilor.jpg', SINGLE_BLOB )as Poza
insert into Restaurante(RestaurantID,OrasID,Nume,NumarTelefon,Adresa,Program,Poza)
SELECT '112','11','La Terazza','0724 317 047','Str. Dr. Carol Davila, nr. 56A(Cotroceni)','Deschis zilnic intre orele 09:00-01:00',BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\la_terazza.jpg', SINGLE_BLOB )as Poza
SET IDENTITY_INSERT dbo.Restaurante OFF

SET IDENTITY_INSERT dbo.Preparate ON
INSERT INTO Preparate(PreparatID, Denumire,Poza)
Select  '1', 'Pizza', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\pizza.jpg', SINGLE_BLOB )as Poza
INSERT INTO Preparate(PreparatID, Denumire,Poza)
Select  '2', 'Burgers', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\burger.jpg', SINGLE_BLOB )as Poza
INSERT INTO Preparate(PreparatID, Denumire,Poza)
Select  '3', 'Spaghetti', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\paste.jpg', SINGLE_BLOB )as Poza
INSERT INTO Preparate(PreparatID, Denumire,Poza)
Select  '4', 'Fish', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\peste.jpg', SINGLE_BLOB )as Poza
INSERT INTO Preparate(PreparatID, Denumire,Poza)
Select  '5', 'Traditional', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\traditional.jpeg', SINGLE_BLOB )as Poza
SET IDENTITY_INSERT dbo.Preparate OFF


INSERT INTO Meniu(RestaurantID, PreparatID)
VALUES (111,1),(111,5),(111,3),(113,1),(113,2),(112,4),(112,5)


SET IDENTITY_INSERT dbo.Utilizatori ON
INSERT INTO Utilizatori(UserID, Nume, Prenume, Parola, NrTelefon, Email)
SELECT '4', 'Daia', 'Marius', '123', '0768443372', 'test@gmail.com'
INSERT INTO Utilizatori(UserID, Nume, Prenume, Parola, NrTelefon, Email, Poza)
SELECT '1','Timis','Diana','123','0733705260','diana.timis97@gmail.com', BulkColumn FROM OPENROWSET(BULK 'F:\TripAdvisor\Poze\diana.jpg', SINGLE_BLOB ) as Poza 
INSERT INTO Utilizatori(UserID, Nume, Prenume, Parola, NrTelefon, Email, Poza)
SELECT '2', 'Mota', 'Alexandra', '123', '0768543672', 'mota.alexandra@gmail.com', BulkColumn FROM OPENROWSET(BULK 'F:\TripAdvisor\Poze\alexandra.jpg', SINGLE_BLOB) as Poza
INSERT INTO Utilizatori(UserID, Nume, Prenume, Parola, NrTelefon, Email, Poza)
SELECT '3', 'Daia', 'Marius', '123', '0768543372', 'daia.marius@gmail.com', BulkColumn FROM OPENROWSET(BULK 'F:\TripAdvisor\Poze\sica.jpg', SINGLE_BLOB) as Poza
INSERT INTO Utilizatori(UserID, Nume, Prenume, Parola, NrTelefon, Email, Poza)
SELECT '5', 'Straton', 'Florin', '123', '0741906155', 'straton.florin@gmail.com', BulkColumn FROM OPENROWSET(BULK 'F:\TripAdvisor\Poze\florin.jpg', SINGLE_BLOB) as Poza
SET IDENTITY_INSERT dbo.Utilizatori OFF


SET IDENTITY_INSERT dbo.RecenziiRestaurante ON
INSERT INTO RecenziiRestaurante(RecenzieID, UserID, RestaurantID, Stele, Pret, Comentarii)
VALUES    (1, 1, 122, 4, 4, 'A fost foarte buna mancarea si personalul amabil.' ),
          (2, 1, 111, 3, 3, 'Pe masura asteptarilor'							 ),
		  (3, 2, 641, 3, 2, 'Destul de bine'									 ),
		  (4,2,111,4,3,'Mancarea foarte buna,preturi cam mari')
SET IDENTITY_INSERT dbo.RecenziiRestaurante OFF


INSERT INTO PozeRestaurante(RestaurantID, UserID,  Poza)
SELECT '111','1', BulkColumn FROM OPENROWSET(BULK 'F:\TripAdvisor\Poze\hanulberarilor.jpg', SINGLE_BLOB ) as Poza

INSERT INTO PozeRestaurante(RestaurantID, UserID,  Poza)
SELECT '122', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\casacucerb.png', SINGLE_BLOB )as Poza

INSERT INTO PozeRestaurante(RestaurantID, UserID,  Poza)
SELECT '641', '3', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\essenziale.png', SINGLE_BLOB )as Poza

INSERT INTO PozeRestaurante(RestaurantID, UserID,  Poza)
SELECT '112', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\laterrazza.png', SINGLE_BLOB )as Poza

INSERT INTO PozeRestaurante(RestaurantID, UserID,  Poza)
SELECT '113', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\restaurant1.jpg', SINGLE_BLOB )as Poza

INSERT INTO PozeRestaurante(RestaurantID, UserID,  Poza)
SELECT '113', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\restaurant2.jpg', SINGLE_BLOB )as Poza

SET IDENTITY_INSERT dbo.Cazare ON
INSERT INTO Cazare(CazareId, OrasID, Nume, Stele, NrTelefon, Email, Adresa, Poza)
SELECT '11', '11', 'Intercontinental', 5, '00 1 877-859-5095', 'hotel.intercontinental@gmail.com','Bulevardul Balcescu Nicolae 4 Bulevardul Nicolae Bălcescu 4, București 010051, Romania +40 21 310 2020, Bucharest 010051 Romania',BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinental.png', SINGLE_BLOB )as Poza 

INSERT INTO Cazare(CazareId, OrasID, Nume, Stele, NrTelefon, Email, Adresa, Poza)
SELECT '12', '11', 'Grand Hotel Continental', 4, '0758 692 589', 'grand.hotel@gmail.com','Calea Victoriei 56, Bucharest 010083, Romania',  BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinental.png', SINGLE_BLOB )as Poza 
SET IDENTITY_INSERT dbo.Cazare OFF

INSERT INTO PozeHotel(CazareId, UtilizatorID, Poza)
SELECT '12', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinentalUtilizator2.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeHotel(CazareId, UtilizatorID, Poza)
SELECT '12', '3', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinentalUtilizator3.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeHotel(CazareId, UtilizatorID, Poza)
SELECT '11', '1', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinentalUtilizator1.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeHotel(CazareId, UtilizatorID, Poza)
SELECT '11', '1', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinentalUtilizator11.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeHotel(CazareId, UtilizatorID, Poza)
SELECT '11', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinentalUtilizator2.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeHotel(CazareId, UtilizatorID, Poza)
SELECT '11', '3', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinentalUtilizator3.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeHotel(CazareId, UtilizatorID, Poza)
SELECT '12', '1', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinentalUtilizator1.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeHotel(CazareId, UtilizatorID, Poza)
SELECT '12', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinentalUtilizator2.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeHotel(CazareId, UtilizatorID, Poza)
SELECT '12', '3', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinentalUtilizator3.png', SINGLE_BLOB )as Poza 

SET IDENTITY_INSERT dbo.RecenziiHoteluri ON
INSERT INTO RecenziiHoteluri(RecenzieID, UserID, CazareID, Stele, Pret, Comentarii)
VALUES  (1, 1, 11, 4, 350, 'I stayed at the hotel for three nights. The staff is very helpful and friendly and would like to specially mention Kathrine at the reception and Paula at the guest relations. It is a pleasure interacting with them.The rooms are 
 huge and well furnished but a little dated since the hotel has been constructed many years ago. The breakfast spread is huge and enough even for vegetarians like us. The location of the hotel is also very good. All in all its a good option to stay in Bucharest.I am particularly thrilled with them
 because they more than made up my dissatisfaction by making my stay at intercontinental sofia outstanding. So thankyou to Paula!0'),
         (2, 1, 12, 3, 480, 'The best place to stay if you are visiting Bucharest. Everybody treated us like king and queen. They made our stay there a memorable one. Everyrhing was just perfect!!!! Pleasant and helpful staff, very clean rooms, rich breakfast, excellent location.'),
		 (3, 2, 11, 2, 270, 'We were three couples last weekend and the hotel was of the highest standard. Excellent breakfast and the clerks were very courteous and I wanted to especially mention Alejandro. I had a minor complaint and immediately received compensation.')
SET IDENTITY_INSERT dbo.RecenziiHoteluri OFF

SET IDENTITY_INSERT dbo.CategoriiObiective ON
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '1', 'Architectural Buildigs', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire,Poza)
Select  '2', 'City Tours', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\citytours.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '3', 'Things To Do', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '4', 'Fun & Games', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '5', 'Food Tours', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '6', 'Outdoor Activities', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '7', 'Water & Amusement Parks', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '8', 'Shopping Malls', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\shoppingmalls.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '9', 'Sights & Landmarks', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '10', 'Food & Drink', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '11', 'Nature & Parks', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '12', 'Adults-only Shows', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '13', 'Shopping', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\noimage.jpg', SINGLE_BLOB )as Poza
INSERT INTO CategoriiObiective(CategorieID, Denumire, Poza)
Select  '14', 'Day Trips', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\daytrips.jpg', SINGLE_BLOB )as Poza
SET IDENTITY_INSERT dbo.CategoriiObiective OFF


SET IDENTITY_INSERT dbo.Obiective ON
INSERT INTO Obiective(ObiectivID, Denumire, Locatie, OrasID, CategorieID, Poza)
Select  '21', 'Communism Tour of Bucharest','Bucharest', 11, 2, BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\comunismtour.jpg', SINGLE_BLOB )as Poza
INSERT INTO Obiective(ObiectivID, Denumire, Locatie, OrasID, CategorieID, Poza)
Select  '22', 'Half Day Tour in Bucharest', 'Bucharest', 11, 2, BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\halfdaytour.jpg', SINGLE_BLOB )as Poza
INSERT INTO Obiective(ObiectivID, Denumire, Locatie, OrasID, CategorieID, Poza)
Select  '23', 'Darkside Tour of Bucharest', 'Bucharest', 11, 2, BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\darksidetour.jpg', SINGLE_BLOB )as Poza
INSERT INTO Obiective(ObiectivID, Denumire, Locatie, OrasID, CategorieID, Poza)
Select  '141', 'Transylvania and Dracula s Castle Full Day Tour ', 'Transylvania', 11, 14, BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\draculacastle.jpg', SINGLE_BLOB )as Poza
INSERT INTO Obiective(ObiectivID, Denumire, Locatie, OrasID, CategorieID, Poza)
Select  '142', 'Three Castles in Transylvania Private Day Trip from Bucharest', 'Transylvania', 11, 14, BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\threecastles.jpg', SINGLE_BLOB )as Poza
INSERT INTO Obiective(ObiectivID, Denumire, Locatie, OrasID, CategorieID, Poza)
Select  '131', 'Plaza Mall', 'Bucharest',11, 8, BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\plazamall.jpg', SINGLE_BLOB )as Poza
INSERT INTO Obiective(ObiectivID, Denumire, Locatie, OrasID, CategorieID, Poza)
Select  '132', 'Promanada Mall','Bucharest', 11, 8, BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\promenadamall.jpg', SINGLE_BLOB )as Poza
SET IDENTITY_INSERT dbo.Obiective OFF


INSERT INTO PozeActivitati(obiectivID, UtilizatorID, Poza)
SELECT '21', '1', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\TourOfCommunism1.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeActivitati(obiectivID, UtilizatorID, Poza)
SELECT '21', '1', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\TourOfCommunism2.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeActivitati(obiectivID, UtilizatorID, Poza)
SELECT '21', '1', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\TourOfCommunism3.png', SINGLE_BLOB )as Poza
 
INSERT INTO PozeActivitati(obiectivID, UtilizatorID, Poza)
SELECT '21', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\TourOfCommunism4.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeActivitati(obiectivID, UtilizatorID, Poza)
SELECT '22', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\HalfDayTour.png', SINGLE_BLOB )as Poza 

INSERT INTO PozeActivitati(obiectivID, UtilizatorID, Poza)
SELECT '141', '2', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\CastleFullDayTour.png', SINGLE_BLOB )as Poza 

SET IDENTITY_INSERT dbo.RecenziiActivitati ON
INSERT INTO RecenziiActivitati(RecenzieID, UserID, ObiectivID, Stele, Comentarii)
VALUES  (1, 1, 21, 5, 'I learned SO much and gained a true appreciation for Bucharest!
Must-do for your visit to Bucharest and this tour was the best part of my visit. I felt like I was living Bucharest s history and watching it unfold in front of my eyes, and I understood the city so much more after the tour.'),
         (2, 3, 21, 5, 'Fully enjoyed Love our guide, Claudia, not only attentive to our questions, we also had good sharing about old days and the post-communist life in Romania'),
		 (3, 2, 22, 4, 'Great taste of Bucharest Our group of four really enjoyed the tour and loved our tour guide, Daniel. He was very pleasant and informative! '),
         (4, 3, 22, 5 , 'Fantastic tour Fantastic tour! The guide was friendly and knowledgeable, telling lots of stories and answering all questions. Daniel was a great guide. Tour covers all major sites and gives you a good idea of the area. I found it perfect as a solo traveler. ')
SET IDENTITY_INSERT dbo.RecenziiActivitati OFF

SET IDENTITY_INSERT dbo.Camere ON
--INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte)
--VALUES            (1, 11, 1, 250),
--                  (2, 11, 1, 280),
--				  (3, 11, 2, 250),
--				  (4, 11, 2, 200),
--				  (5, 11, 2, 180),
--				  (6, 11, 3, 300),
--				  (7, 12, 1, 275),
--				  (8, 12, 1, 300), 
--				  (9, 12, 2, 290), 
--				  (10, 12, 2, 296),
--				  (11, 12, 3, 300),
--				  (12, 12, 2, 350), 
--				  (13, 12, 2, 320), 
--				  (14, 12, 3, 300),
--				  (15, 12, 2, 270),
--				  (16, 12, 2, 280)


--SET IDENTITY_INSERT dbo.Camere OFF

SET IDENTITY_INSERT dbo.Rezervari OFF
INSERT INTO Rezervari(UserID, CameraID, DataCheckin, DataCheckout)
VALUES (1, 1, '2019-02-20 22:00' , '2019-02-22 10:00' ),
       (1, 12, '2019-03-01 17:45', '2019-03-04 11:00' ),
	   (2, 13, '2019-04-02 18:30', '2019-04-03 12:00' ),
	   (3, 10, '2019-04-02 17:20', '2019-04-04 08:00' ),
	   (3, 1, '2019-02-23 12:00',  '2019-02-24 07:30' )
SET IDENTITY_INSERT dbo.Rezervari OFF

SET IDENTITY_INSERT dbo.Camere ON
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '1', '11', '1', '250', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinental1pat.jpg', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '2', '11', '1', '280', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinental1pat2.jpg', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '3', '11', '1', '200', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinental1pat3.jpg', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '4', '11', '3', '360', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinental3pat.jpg', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '5', '11', '2', '300', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinental2pat.jpg', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '6', '11', '2', '290', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\intercontinental2pat1.jpg', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '10', '12', '1', '269', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinental1pat.png', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '17', '12', '2', '400', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinental2pat.png', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '11', '12', '2', '248', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinental2pat1.png', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '12', '12', '1', '369', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinental1pat1.png', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '13', '12', '3', '290', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinental3pat.png', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '14', '12', '1', '376', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinental1pat2.png', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '15', '12', '2', '299', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinental2pat3.png', SINGLE_BLOB) as Poza
INSERT INTO Camere( CameraID, CazareID, NumarPaturi, PretPerNoapte, Poza)
Select '16', '12', '1', '399', BulkColumn FROM OPENROWSET (BULK 'F:\TripAdvisor\Poze\grandhotelcontinental1pat3.png', SINGLE_BLOB) as Poza
SET IDENTITY_INSERT dbo.Camere OFF