## Uputstvo za upotrebu
### Uvod

  ***KoleServis*** je aplikacija namjenjena za automehaničarksu ranju, koja pored klasičnih usluga može da pruža i usluge prodaje dijelova. Prilikom paljenja aplikacije dolazi se na početnu stranicu za prijavu, gdje se unose korisnički kredencijali, a dalje se na osnovu njih otvara odgovarajući prozor u zavisnosti od tipa naloga. Dakle postoje dva tipa naloga:

### Tipovi naloga:
1)     Menadžer;

2)     Radnik;

   Aplikacija je pisana u programskom jeziku C# koristeći Windows Presentation Foundation(WPF) framework oslanjajući se na MVVM pristup i koristi relacionu bazu podataka na portu 3306 (MySQL) kao glavni način čuvanja podataka te Entity framework kao mehanizam za pristup podacima.
   ## Prijava na sistem
   Prilikom pokretanja aplikacije ovo je prvi prozor na koji se nailazi u kojem je neophodno da korisnik unese svoje kredencijale u vidu korisničkog imena i lozinke. Takođe korisnik može u zavisnosti od svojih potreba i da promjeni jezik same aplikacije. Aplikacije podržava dva jezika: srpski i engleski.
   ![image](https://github.com/user-attachments/assets/d6c39023-c433-4cca-a9cd-7a1cdee4ecae)
    <p align=center>Forma za prijavu na sistem</p>
    Ukoliko se korisnik uspješno prijavio otvoriće mu se jedan od prozora, a ukoliko nije dobiće odgovarajuću poruku da korisničko ime ili lozinka nisu ispravni. Korisnik se moze prijaviti i pritiskom na dugme "Enter" pri čemu nije neophodno korištenje miša da se pritisne da dugme prijava.
    
    ## Menadžerska aplikacija
    Menadzer ima opcije da pregleda račune, vrši CRUD operacije nad radnicima, uslugama, dijelovima te mijenja postavke svog naloga. Pri prijavi na korisnicki nalog podrazumijevano je da se otovri prva stavka, tj. pregled računa.
    
    ### Pregled računa
    ![image](https://github.com/user-attachments/assets/b64dbddb-e2a3-4a5c-a913-3670ba0650ab)
    <p align=center>Izgled prozora za pregled računa</p>
    Menadžer klikom na neki račun može da prikaže u desnom dijelu sve stavke koje se nalaze na tome računu.

    ### Pregled radnika

   ![image](https://github.com/user-attachments/assets/7dd7f3d4-4f4d-4085-a390-95866eaf252b)
    <p align=center>Izgled prozora za pregled ažuriranje radnika</p>
    
    ![image](https://github.com/user-attachments/assets/94c78f46-517f-4855-a5d7-13ab14f19241)
    <p align=center>Izgled prozora za pregled kreiranje radnika</p>

    Menadžer može da vrši CRUD operacije nad radnikom, pri čemu ako se vrši ažuriranje korisničko ime se ne može promijeniti (primarni ključ u bazi podataka) kao i lozinka. Takođe ako nije odabran niti jedan radnik nije moguće pritisnuti na dugme ažuriraj i obriši.

    ### Pregled usluga

    ![image](https://github.com/user-attachments/assets/700ca0ad-a201-46f7-b70e-1476b70a065e)
    <p align=center>Izgled prozora za pregled i ažuriranje usluge</p>

    ![image](https://github.com/user-attachments/assets/0b96e078-cda2-44f9-a7dd-0b4103b06842)
    <p align=center>Izgled prozora za pregled usluga pri uključenom filteru</p>

    ![image](https://github.com/user-attachments/assets/c314f86a-8344-4533-807b-4958938e44b1)
    <p align=center>Izgled prozora za kreiranje usluge</p>

    Kao i u prethodom slučaju menadžer može da vrši CRUD operacije nad uslugama. Takodje ima i opciju za filtriranje usluga radi lakšeg pronalaženja željene usluge. Prilikom promjene cijene napravljen je "regex pattern" da se ne može unijeti ništa drugo sem brojeva u to polje.

    ### Pregled dijelova

     ![image](https://github.com/user-attachments/assets/ba130ce5-cdfe-4bf7-8c3f-453eaeff0c02)
    <p align=center>Izgled prozora za pregled i ažuriranje dijelova</p>

    ![image](https://github.com/user-attachments/assets/4f6e408e-ede2-4336-ae17-7152055c0e9d)
    <p align=center>Izgled prozora za filtriranje i ažuriranje dijelova</p>

    ![image](https://github.com/user-attachments/assets/a7487bae-62e2-4e9c-bc21-8e4825e7b48a)
    <p align=center>Izgled prozora za kreiranje novog dijela</p>

    Slično kao i kod usluga menadžer može da vrši gotovo identične akcije. Razlika je u tom što kod filtriranja može da pored naziva odabere i kategoriju po kojoj hoće da filtrira dijelove. Takođe je i razlika što dijelovi za razliku od usluga imaju sliku pa može da odabere odgovarajuću. Ukoliko ne odabere biće prikazana podrazumijevana slika. Slike se u bazi čuvaju u Base64 formatu. Takođe opet je onemogućen unos drugih karaktera gdje se očekuju brojevi.

   ### Pregled podešavanja

   ![image](https://github.com/user-attachments/assets/8596111d-0d34-4e64-b374-8de5c5e52aca)
    <p align=center>Izgled prozora za izmjenu vlastitog naloga</p>

   Na ovom prozoru se nalaze sve izmjenljive karakteristike neke osobe. Nakon odabira željenih postavki neophodno je da korisnik procesuira želju klikom na dugme ažuriraj, a ukoliko ne želi da promjeni opcije uvijek može da ih poništi prije nego ih je sačuvao.

   ## Klijentska aplikacija

   Nakon prijave kao klijent korisniku se otvara ovakav prozor pri cemu je podrazumijevan prozor za kreiranje računa. 

  ### Pregled kreiranja računa

  ![image](https://github.com/user-attachments/assets/78c057c9-0262-4d1f-8bc7-b3868761a7df)
    <p align=center>Izgled prozora za kreiranje računa</p>

  Početni izgled za kreiranje računa. U lijevo dijelu se nalaze stavke u vidu dijelova i usluga koje korisnik klikom odabire i dodaje na račun. U desnom dijelu prozora se nalazi lista odabranih stavki, prikaz ukupne cijene svih stavki, broj računa (ukoliko je specifičan broj pri kopiranju), odabir klijenta kojem se izadje račun (ne mora se odabrati), te odabir datuma i vremena.
  Takođe postoje tri dugmeta: prvo za kreiranje računa, drugo za štampanje (skida pdf na računar koji se potom može štampati) i pregled fakture. Postoji i opcija za filtriranje radi lakšeg pronalaska željene stavke.
  Kada odabere neku stavku korisnik ima opciju da u koloni količina klikom na dugme "plus" ili "minus" povećava smanjuje količinu do željene, pri čemu kod dijelova količina ne može ići preko maksimalne u bazi a ni ispod 1. Kod usluga je maksimalna vrijednost beskonačno. Za svaku stavku na kraju postoji simbolično kanta koji ima svrhu brisanja iste sa računa.

  ![image](https://github.com/user-attachments/assets/2400e527-3e99-4071-beb6-346a858586ee)
    <p align=center>Izgled prozora nakon odabira par stavki koje su dodane na račun</p>

  ![image](https://github.com/user-attachments/assets/c646be59-6519-4ec4-b7b1-b9d6087e305c)
    <p align=center>Izgled prozora nakon odabira par stavki i filtera za dodavanje još</p>

  ![image](https://github.com/user-attachments/assets/e38f979d-4aa3-48d0-a6be-2156bd8feb77)
  <p align=center>Izgled prozora za pregled fakture</p>

  ### Pregled podešavanja

  ![image](https://github.com/user-attachments/assets/d8b60899-19ff-4083-b029-8e982212e023)
  <p align=center>Izgled prozora za podesavanje naloga</p>

  Ovaj prozor je identičan kao kod menadžerskog naloga.

  
  
  


    
