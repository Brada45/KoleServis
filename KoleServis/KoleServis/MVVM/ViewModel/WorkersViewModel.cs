using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.Services;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoleServis.MVVM.ViewModel
{
    public class WorkersViewModel:Core.ViewModel
    {

        public ObservableCollection<Osoba> _persons { get; set; }
        public INavigationService _navigation;
        private Base64Service _Base64Service;
        private FindService _FindService;
        private Osoba _selectedPerson;
        public Osoba SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
                if(SelectedPerson != null)
                    OnSelecetedOsobaChanged();
            }
        }
        public ObservableCollection<Osoba> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }
        private string _username;
        private string _name;
        private string _surname;
        private string _password;
        private string _confirmPassword;
        private bool _editUsername;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }
        public bool EditUsername
        {
            get => _editUsername;
            set
            {
                _editUsername = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }

        public WorkersViewModel()
        {
            Persons = new ObservableCollection<Osoba>();
            _FindService = new FindService();
            _Base64Service=new Base64Service();
            EditUsername = true;
            AddCommand = new RelayCommand(o => AddPerson(), o => SelectedPerson == null);
            DeleteCommand = new RelayCommand(o => DeletePerson(), o => SelectedPerson != null);
            UpdateCommand = new RelayCommand(o => UpdatePerson(), o => SelectedPerson != null);
            ClearCommand=new RelayCommand(o=>ClearPerson(),o=> true);
            GetPersons();
            
        }

        private void AddPerson()
        {
            Osoba person = null;
            string tmpPassword = _Base64Service.ConvertPassword(Password);
            string tmpConfirm=_Base64Service.ConvertPassword(ConfirmPassword);
            if (tmpPassword.Equals(tmpConfirm) && !Username.Equals("") && !Surname.Equals("") && !Name.Equals(""))
            {
                 person= new Osoba { KorisnickoIme = Username, Ime = Name, Prezime = Surname, Sifra = tmpPassword, TipIdTip = 1, TemaIdTema = 1, JezikIdJezik = 1, Obrisan = 0 };
            }
            if (person != null)
            {
                _persons.Add(person);
                using (var context = new HcitableContext())
                {
                    context.Osobas.Add(person);
                    context.SaveChanges();
                }
            }

        }

        private void DeletePerson()
        {
            using (var context = new HcitableContext())
            {
                var user = context.Osobas.FirstOrDefault(u => u.KorisnickoIme.Equals(SelectedPerson.KorisnickoIme));
                if (user!=null)
                {
                    user.Obrisan = 1;
                    context.SaveChanges();
                    Persons.Remove(SelectedPerson);
                    ClearPerson();
                }
            }
        }
        private void UpdatePerson()
        {
            if (SelectedPerson != null)
            {
                SelectedPerson.Ime = Name;
                SelectedPerson.Prezime = Surname;

                using (var context = new HcitableContext())
                {
                    var user = context.Osobas.FirstOrDefault(u => u.KorisnickoIme.Equals(SelectedPerson.KorisnickoIme));
                    if (user != null)
                    {
                        user.Ime = Name;
                        user.Prezime = Surname;
                        context.SaveChanges();
                    }
                }

                RefreshUIForCollection();

                ClearPerson();
            }
        }
        private void RefreshUIForCollection()
        {
            var tempPersons = Persons.ToList();

            Persons.Clear();

            foreach (var person in tempPersons)
            {
                Persons.Add(person);
            }
        }



        private void ClearPerson()
        {
            SelectedPerson = null;
            Username=string.Empty;
            Name=string.Empty;
            Surname=string.Empty;
            Password=string.Empty;
            ConfirmPassword = string.Empty;
            EditUsername = true;
        }

        private void GetPersons()
        {
            using (var context = new HcitableContext())
            {
                var persons = context.Osobas.ToList();
                _persons = new ObservableCollection<Osoba>();

                foreach (var person in persons)
                {
                    if (person.TipIdTip == 1 && person.Obrisan==0)
                        Persons.Add(person);
                }
            }
        }

        private void OnSelecetedOsobaChanged()
        {
            
            Username = SelectedPerson.KorisnickoIme;
            Name = SelectedPerson.Ime;
            Surname = SelectedPerson.Prezime ;
            Password = "";
            ConfirmPassword = "";
            EditUsername = false;

        }


    }
}
