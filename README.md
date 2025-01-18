## Uputstvo za upotrebu
### Uvod

  ***KoleServis*** je aplikacija namjenjena za automehaničarksu ranju, koja pored klasičnih usluga može da pruža i usluge prodaje dijelova. Prilikom paljenja aplikacije dolazi se na početnu stranicu za prijavu, gdje se unose korisnički kredencijali, a dalje se na osnovu njih otvara odgovarajući prozor u zavisnosti od tipa naloga. Dakle postoje dva tipa naloga:

### Tipovi naloga:
1)     Menadžer;

2)     Radnik;

   Aplikacija je pisana u programskom jeziku C# koristeći Windows Presentation Foundation(WPF) framework oslanjajući se na MVVM pristup i koristi relacionu bazu podataka na portu 3306 (MySQL) kao glavni način čuvanja podataka te Entity framework kao mehanizam za pristup podacima.
   ## Prijava na sistem
   Prilikom pokretanja aplikacije ovo je prvi prozor na koji se nailazi u kojem je neophodno da korisnik unese svoje kredencijale u vidu korisničkog imena i lozinke. Takođe korisnik može u zavisnosti od svojih potreba i da promjeni jezik same aplikacije. Aplikacije podržava dva jezika: srpski i engleski.
  ![image](https://github.com/user-attachments/assets/c0cb383d-df8e-4b11-a0bb-cf8968b22050)
    <p align=center>Forma za prijavu na sistem</p>
    Ukoliko se korisnik uspješno prijavio otvoriće mu se jedan od prozora, a ukoliko nije dobiće odgovarajuću poruku da korisničko ime ili lozinka nisu ispravni. Korisnik se moze prijaviti i pritiskom na dugme "Enter" pri čemu nije neophodno korištenje miša da se pritisne da dugme prijava.
    
    ## Menadžerska aplikacija
    Menadzer ima opcije da pregleda račune, vrši CRUD operacije nad radnicima, uslugama, dijelovima te mijenja postavke svog naloga. Pri prijavi na korisnicki nalog podrazumijevano je da se otovri prva stavka, tj. pregled računa.
    
    ### Pregled računa
    ![image](https://github.com/user-attachments/assets/5cb1cced-69a2-4900-9db8-3e7ec35d4bd0)
    <p align=center>Izgled prozora za pregled računa</p>
    Menadžer klikom na neki račun može da prikaže u desnom dijelu sve stavke koje se nalaze na tome računu.

    ### Pregled radnika

   ![image](https://github.com/user-attachments/assets/50876db8-6ed6-4235-b1c0-24bcd03adda2)
    <p align=center>Izgled prozora za pregled ažuriranje radnika</p>
    
    ![image](https://github.com/user-attachments/assets/1441b744-7683-4279-a8ca-7051f1772b15)
    <p align=center>Izgled prozora za pregled kreiranje radnika</p>

    Menadžer može da vrši CRUD operacije nad radnikom, pri čemu ako se vrši ažuriranje korisničko ime se ne može promijeniti (primarni ključ u bazi podataka) kao i lozinka. Takođe ako nije odabran niti jedan radnik nije moguće pritisnuti na dugme ažuriraj i obriši.

    ### Pregled usluga

    ![image](https://github.com/user-attachments/assets/57a2e6c8-06ca-4fa8-925a-369cc0a11970)
    <p align=center>Izgled prozora za pregled i ažuriranje usluge</p>

    ![image](https://github.com/user-attachments/assets/48bce6ee-4731-4c6c-824a-e5c2dc9fcbd0)
    <p align=center>Izgled prozora za pregled usluga pri uključenom filteru</p>

   ![image](https://github.com/user-attachments/assets/571dc016-817c-4461-8b3e-af106ab06cca)
    <p align=center>Izgled prozora za kreiranje usluge</p>

    Kao i u prethodom slučaju menadžer može da vrši CRUD operacije nad uslugama. Takodje ima i opciju za filtriranje usluga radi lakšeg pronalaženja željene usluge. Prilikom promjene cijene napravljen je "regex pattern" da se ne može unijeti ništa drugo sem brojeva u to polje.

    ### Pregled dijelova

    ![image](https://github.com/user-attachments/assets/28689d8b-f48a-4564-9a0d-e7c1f971e35f)
    <p align=center>Izgled prozora za pregled i ažuriranje dijelova</p>

    ![image](https://github.com/user-attachments/assets/f5a1b890-a3aa-47ea-806c-e61c201d40f5)
    <p align=center>Izgled prozora za filtriranje i ažuriranje dijelova</p>

   ![image](https://github.com/user-attachments/assets/c3e5ea21-6d4c-46a6-a77c-ce76d2f9e53f)
   <p align=center>Ne postoji dio koji odgovara datim parametrima</p>
   
    ![image](https://github.com/user-attachments/assets/0f062610-2cd6-4b3d-bcae-50a218a8825e)
    <p align=center>Izgled prozora za kreiranje novog dijela</p>

    Slično kao i kod usluga menadžer može da vrši gotovo identične akcije. Razlika je u tom što kod filtriranja može da pored naziva odabere i kategoriju po kojoj hoće da filtrira dijelove. Takođe je i razlika što dijelovi za razliku od usluga imaju sliku pa može da odabere odgovarajuću. Ukoliko ne odabere biće prikazana podrazumijevana slika. Slike se u bazi čuvaju u Base64 formatu. Takođe opet je onemogućen unos drugih karaktera gdje se očekuju brojevi.

   ### Pregled podešavanja

   ![image](https://github.com/user-attachments/assets/d8b5f69f-4fa6-4bf6-bee8-f2e122f4b0b8)
    <p align=center>Izgled prozora za izmjenu vlastitog naloga</p>

   Na ovom prozoru se nalaze sve izmjenljive karakteristike neke osobe. Nakon odabira željenih postavki neophodno je da korisnik procesuira želju klikom na dugme ažuriraj, a ukoliko ne želi da promjeni opcije uvijek može da ih poništi prije nego ih je sačuvao.

   ## Klijentska aplikacija

   Nakon prijave kao klijent korisniku se otvara ovakav prozor pri cemu je podrazumijevan prozor za kreiranje računa. 

  ### Pregled kreiranja računa

  ![image](https://github.com/user-attachments/assets/a5374ee7-586a-4e2d-94fc-395e317d7140)
    <p align=center>Izgled prozora za kreiranje računa</p>

  Početni izgled za kreiranje računa. U lijevo dijelu se nalaze stavke u vidu dijelova i usluga koje korisnik klikom odabire i dodaje na račun. U desnom dijelu prozora se nalazi lista odabranih stavki, prikaz ukupne cijene svih stavki, broj računa (ukoliko je specifičan broj pri kopiranju), odabir klijenta kojem se izadje račun (ne mora se odabrati), te odabir datuma i vremena.
  Takođe postoje tri dugmeta: prvo za kreiranje računa, drugo za štampanje (skida pdf na računar koji se potom može štampati) i pregled fakture. Postoji i opcija za filtriranje radi lakšeg pronalaska željene stavke.
  Kada odabere neku stavku korisnik ima opciju da u koloni količina klikom na dugme "plus" ili "minus" povećava smanjuje količinu do željene, pri čemu kod dijelova količina ne može ići preko maksimalne u bazi a ni ispod 1. Kod usluga je maksimalna vrijednost beskonačno. Za svaku stavku na kraju postoji simbolično kanta koji ima svrhu brisanja iste sa računa.

  ![image](https://github.com/user-attachments/assets/ac240fb2-d7a5-4c83-9f7e-b22c8756464d)
    <p align=center>Izgled prozora nakon odabira par stavki koje su dodane na račun</p>

  ![image](https://github.com/user-attachments/assets/17de191d-f422-4272-bb85-62e2d882bb38)
    <p align=center>Izgled prozora nakon odabira par stavki i filtera za dodavanje još</p>

  ![image](https://github.com/user-attachments/assets/e38f979d-4aa3-48d0-a6be-2156bd8feb77)
  <p align=center>Izgled prozora za pregled fakture</p>

  ### Pregled podešavanja

  ![image](https://github.com/user-attachments/assets/15f330a0-0234-47e5-9326-65a6556386d4)
  <p align=center>Izgled prozora za podesavanje naloga</p>

  Ovaj prozor je identičan kao kod menadžerskog naloga.

  
  
  


    
