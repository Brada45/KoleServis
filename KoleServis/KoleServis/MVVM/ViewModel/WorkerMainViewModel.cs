using Google.Protobuf.Compiler;
using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KoleServis.MVVM.ViewModel
{
    class WorkerMainViewModel:Core.ViewModel
    {


        public RelayCommand NavigateToBillsCommand { get; set; }
        public RelayCommand NavigateToSettingsViewCommand { get; set; }
       
        
        
        public INavigationService _navigation;
        private ChangeFontService _changeFontService;
        private ChangeBoldItalicService _changeBoldItalicService;
        private ChangeColorService _changeColorService;
        private FindService _findService;
        private Osoba Person { get; set; }


        private string _ime;
        private bool _isToggled;
        private string _letter;
        public bool IsCreateBillButonEnabled { get; set; } = false;
        public bool IsSettingsButtonEnabled { get; set; } = true;
        public bool IsToggled
        {
            get => _isToggled;
            set
            {
                _isToggled = value;
                OnPropertyChanged(nameof(IsToggled));
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

        public string Ime
        {
            get => _ime;
            set
            {
                _ime = value;
                OnPropertyChanged(nameof(Ime));
            }
        }

        public string Letter
        {
            get => _letter;
            set
            {
                _letter = value;
                OnPropertyChanged(nameof(Letter));
            }
        }


        public WorkerMainViewModel(INavigationService navigation) {
            Navigation = navigation;
            _changeFontService = new ChangeFontService();
            _changeBoldItalicService = new ChangeBoldItalicService();
            _changeColorService = new ChangeColorService();
            _findService = new FindService();
            Person = SharedUser.CurrentPerson;

            _ime = Person.Ime + " " + Person.Prezime;
            _letter = Person.Ime[0].ToString() + Person.Prezime[0].ToString();
            Tema tema = _findService.findTheme(Person.TemaIdTema);
            if (tema != null)
            {
                SharedUser.Theme = tema;
                _changeBoldItalicService.ChangeBold(tema.Bold.ToString().Equals("0") ? "normal" : "bold");
                _changeBoldItalicService.ChangeItalic(tema.Italic.ToString().Equals("0") ? "normal" : "italic");
                if (Person.JezikIdJezik == 1)
                {
                    IsToggled = true;
                    SharedUser.Language = new Jezik { IdJezik = 1, Naziv = "Srpski" };
                }
                else
                {
                    SharedUser.Language = new Jezik { IdJezik = 2, Naziv = "English" };

                    IsToggled = false;
                }
                ChangeLanguageService.ChangeLanguage(IsToggled);
                _changeColorService.ChangeThemeColor(tema.Boja);
                ChangeFontService.ChangeFont(tema.Font);
            }
            NavigateToBillsCommand = new RelayCommand(o => { Navigation.NavigateTo<CreateBillViewModel>(true); SetButtonStates("Bills"); }, o => true);
            NavigateToSettingsViewCommand=new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(true); SetButtonStates("Settings"); }, o => true);
            Navigation.NavigateTo<CreateBillViewModel>(true);

        }
        private void SetButtonStates(string pressedButton)
        {
            IsCreateBillButonEnabled = pressedButton != "Bills";
            IsSettingsButtonEnabled = pressedButton != "Settings";

            OnPropertyChanged(nameof(IsCreateBillButonEnabled));
            OnPropertyChanged(nameof(IsSettingsButtonEnabled));
        }
    }
}
