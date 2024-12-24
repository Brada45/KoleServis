using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.MVVM.View;
using KoleServis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Globalization;
using System.Runtime.Versioning;

namespace KoleServis.MVVM.ViewModel
{
    public class LoginViewModel:Core.ViewModel
    {
        public INavigationService _navigation;
        public Base64Service _base64Service;

        public RelayCommand LoginCommand { get; }
        public RelayCommand ChangeLanguageCommand {  get; }
        public ChangeLanguageService _changeLanguageService;

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
        private string _password;
        private string _warrning;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
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
        public string WarrningColor
        {
            get => _warrning;
            set
            {
                _warrning = value;
                OnPropertyChanged();
            }
        }
        private bool _isToggled;
        public bool IsToggled
        {
            get => _isToggled;
            set
            {
                _isToggled = value;
                OnPropertyChanged(nameof(IsToggled));
            }
        }

        public LoginViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            _warrning = "white";
            _changeLanguageService = new ChangeLanguageService();
            IServiceCollection services = new ServiceCollection();
            LoginCommand = new RelayCommand( execute => LoginCheck(),canExecute => true );
            ChangeLanguageCommand = new RelayCommand(execute => ChangeLanguageService.ChangeLanguage(IsToggled), canExecute => true);
            _base64Service = new Base64Service();
        }

        private void LoginCheck()
        {

            string passBase64=_base64Service.ConvertPassword(Password);
            Boolean found = false;
            Osoba person = null;
            using (var context =new HcitableContext())
            {
                var korisnici=context.Osobas.ToList();
                
                foreach (var korisnik in korisnici)
                {
                   if(passBase64.Equals(korisnik.Sifra) && Username.Equals(korisnik.KorisnickoIme)){
                        found = true; 
                        person= korisnik;
                        break;
                   }
                }
            }
            if (found)
            {
                if (person.TipIdTip == 1)
                {
                    SharedUser.CurrentPerson = person;
                    Navigation.NavigateTo<WorkerMainViewModel>(false);
                }else
                {
                    SharedUser.CurrentPerson=person;
                    Navigation.NavigateTo<ManagerMainViewModel>(false);

                }
            }
            else
            {
                Username = "";
                WarrningColor = "red";
            }

        }

        







    }
}
