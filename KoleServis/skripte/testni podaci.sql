use hcitable;

SET SQL_SAFE_UPDATES=0;

DELETE FROM stavka_usluga;
DELETE FROM stavka_dio;
DELETE FROM racun;
DELETE FROM usluga;
DELETE FROM dio;
DELETE FROM kupac;
DELETE FROM kategorija;
DELETE FROM radnik;
DELETE FROM menadzer;
DELETE FROM radnja;
DELETE FROM osoba;
DELETE FROM tema;
DELETE FROM jezik;
DELETE FROM tip;

insert into tip(id_tip,naziv) values (1,'radnik');
insert into tip(id_tip,naziv) values (2,'menadzer');

insert into jezik(id_jezik,naziv) values (1,'srpski');
insert into jezik(id_jezik,naziv) values(2,'engleski');

insert into tema(id_tema,boja,font,italic,bold,velicina) values (1,'Orange','Arial',0,0,10);
insert into tema(id_tema,boja,font,italic,bold,velicina) values (2,'Blue','Times New Roman',0,1,10);
insert into tema(id_tema,boja,font,italic,bold,velicina) values (3,'Gray','Courier New',1,0,10);

insert into osoba(`Korisnicko ime`,ime,prezime,sifra,Tip_id_tip,Tema_id_tema,Jezik_id_jezik,Obrisan) values ('KoleMenadzer','Dragan','Kostic','S29sZW1lbmFkemVy',2,1,1,0);
insert into osoba(`Korisnicko ime`,ime,prezime,sifra,Tip_id_tip,Tema_id_tema,Jezik_id_jezik,Obrisan) values ('KoleMajstor','Dragan','Kostic','S29sZW1hanN0b3I=',1,1,1,0);

insert into radnja(id_radnja,naziv) values (1,'Kole Servis');

insert into menadzer(Radnja_id_radnja,`Osoba_Korisnicko ime`) values (1,'KoleMenadzer');

insert into radnik(Radnja_JIB,`Osoba_Korisnicko ime`) values(1,'KoleMajstor');

insert into kategorija(id_kategorija,naziv) values (1,'Filter ulja');
insert into kategorija(id_kategorija,naziv) values (2,'Filter vazduha');
insert into kategorija(id_kategorija,naziv) values (3,'Filter kabine');
insert into kategorija(id_kategorija,naziv) values (4,'Filter nafte');
insert into kategorija(id_kategorija,naziv) values (5,'Diskovi');
insert into kategorija(id_kategorija,naziv) values (6,'Plocice');
insert into kategorija(id_kategorija,naziv) values (7,'Ulje');

insert into kupac(id_kupac,naziv) values (1,'Stefanelo');
insert into kupac(id_kupac,naziv) values (2,'X Express');
insert into kupac(id_kupac,naziv) values (3,'Royal food');

insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (1,'Filter ulja Golf 4 1.4 16v',1,8,5,1,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (2,'Filter ulja Golf 5 1.6 TDI',1,9,8,1,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (3,'Filter vazduha Golf 5 19/2.0 TDI',1,13.5,10,2,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (4,'Filter vazduha BMW e60 3.0d',1,30,2,2,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (5,'Filter polena Pezo 206 98-03',1,18.60,2,3,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (6,'Filter polena Golf 7',1,23,12,3,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (7,'Filter goriva Golf 7 1.6/2.0 TDI kratki',1,70,3,4,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (8,'Filter nafte Audi A6 2.7/3.0 2004+',1,30,2,4,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (9,'Disk Golf 4 zadnji',1,45,7,5,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (10,'Disk Golf 7 zadnji',1,120,11,5,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (11,'Plocice prednje Golf 6 1.6 TDI',1,35,5,6,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (12,'Plocice Renault Espace IV ',1,38,5,6,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (13,'Ulje Castrol Edge Professional LL III 5w30 1l',1,20,17,7,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (14,'Ulje Castrol 5w30 4l',1,90,5,7,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (15,'Ulje Ople 5w30 5l',1,60,2,7,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (16,'Ulje Mobil Super 3000 5w40 5l',1,70,8,7,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (17,'Ulje ELF Evolution 900 5w40 5l',1,60,2,7,0);
insert into dio(id_dio,Naziv,Radnja_id_radnja,cijena,kolicina,Kategorija_id_kategorija,obrisano) values (18,'Ulje ELF Evolution 900 5w40 1l',1,15,9,7,0);

insert into usluga(id_usluga,Naziv,Radnja_id_radnja,cijena,`Menadzer_Osoba_Korisnicko ime`,obrisano) values(1,'Mali servis Golf 4',1,30,'KoleMenadzer',0);
insert into usluga(id_usluga,Naziv,Radnja_id_radnja,cijena,`Menadzer_Osoba_Korisnicko ime`,obrisano) values(2,'Zamjena prednjih plocica VW Passat 7',1,60,'KoleMenadzer',0);
INSERT INTO usluga (id_usluga, Naziv, Radnja_id_radnja, cijena,`Menadzer_Osoba_Korisnicko ime`,obrisano) VALUES (3, 'Veliki servis Golf 4', 1, 180, 'KoleMenadzer',0);
INSERT INTO usluga (id_usluga, Naziv, Radnja_id_radnja, cijena, `Menadzer_Osoba_Korisnicko ime`,obrisano) VALUES (4, 'Zamjena ulja - Audi A4', 1, 20, 'KoleMenadzer',0);
INSERT INTO usluga (id_usluga, Naziv, Radnja_id_radnja, cijena, `Menadzer_Osoba_Korisnicko ime`,obrisano) VALUES (5, 'Punjenje klime 100g', 1, 5, 'KoleMenadzer',0);
INSERT INTO usluga (id_usluga, Naziv, Radnja_id_radnja, cijena, `Menadzer_Osoba_Korisnicko ime`,obrisano) VALUES (6, 'Zamjena amortizera Volvo v50', 1, 40, 'KoleMenadzer',0);
INSERT INTO usluga (id_usluga, Naziv, Radnja_id_radnja, cijena, `Menadzer_Osoba_Korisnicko ime`,obrisano) VALUES (7, 'Dijagnostika auta 1h', 1, 20, 'KoleMenadzer',0);

insert into racun(id_racun,cijena,datum,`Radnik_Osoba_Korisnicko ime`,Radnja_id_radnja) values(1,50,'2024-12-05 14:30:00','KoleMajstor',1);
insert into racun(id_racun,cijena,datum,`Radnik_Osoba_Korisnicko ime`,Radnja_id_radnja) values(2,120,'2024-12-02 11:28:00','KoleMajstor',1);
insert into racun(id_racun,cijena,datum,Kupac_id_kupac,`Radnik_Osoba_Korisnicko ime`,Radnja_id_radnja) values(3,180,'2024-11-28 14:30:00',1,'KoleMajstor',1);

insert into stavka_dio(kolicina,Dio_id_dio,`cijena komad`,`cijena ukupno`,Racun_id_racun) values (1,14,90,90,2);

insert into stavka_usluga(Usluga_id_usluga,kolicina,`cijena komad`,`cijena ukupno`,`Radnik_Osoba_Korisnicko ime`,Racun_id_racun) values(5,6,5,30,'KoleMajstor',1);
insert into stavka_usluga(Usluga_id_usluga,kolicina,`cijena komad`,`cijena ukupno`,`Radnik_Osoba_Korisnicko ime`,Racun_id_racun) values(7,1,20,20,'KoleMajstor',1);
insert into stavka_usluga(Usluga_id_usluga,kolicina,`cijena komad`,`cijena ukupno`,`Radnik_Osoba_Korisnicko ime`,Racun_id_racun) values(1,1,30,30,'KoleMajstor',2);
insert into stavka_usluga(Usluga_id_usluga,kolicina,`cijena komad`,`cijena ukupno`,`Radnik_Osoba_Korisnicko ime`,Racun_id_racun) values(4,1,180,180,'KoleMajstor',3);

