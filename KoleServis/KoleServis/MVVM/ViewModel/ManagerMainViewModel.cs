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
    public class ManagerMainViewModel:Core.ViewModel
    {
        
        public INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                    _navigation = value; 
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

        private string _ime;
        public String Ime
        {
            get => _ime;
            set
            {
                _ime = value;
                OnPropertyChanged(nameof(Ime));
            }
        }

        private string _letter;
        public String Letter
        {
            get=> _letter;
            set
            {
                _letter = value;
                OnPropertyChanged(nameof(Letter));
            }
        }

        private Osoba Person { get; set; }

        public RelayCommand NavigateToBillsCommand { get; set; }
        public RelayCommand NavigateToSettingsViewCommand { get; set; }
        public RelayCommand NavigateToWorkersViewCommand { get; set; }
        public RelayCommand NavigateToServicesViewCommand { get; set; }
        public RelayCommand NavigateToItemsViewCommand {  get; set; }
        public RelayCommand ChangeLanguageCommand { get; }

        private ChangeFontService _changeFontService;
        private ChangeBoldItalicService _changeBoldItalicService;
        private ChangeColorService _changeColorService;
        private FindService _findService;


        public ManagerMainViewModel(INavigationService navigation)
        {
            
             Navigation = navigation;
            _changeFontService= new ChangeFontService();
            _changeBoldItalicService= new ChangeBoldItalicService();
            _changeColorService= new ChangeColorService();
            _findService= new FindService();
            Person = SharedUser.CurrentPerson;

            _ime=Person.Ime+" "+Person.Prezime;
            _letter = Person.Ime[0].ToString() + Person.Prezime[0].ToString();
            Tema tema=_findService.findTheme(Person.TemaIdTema);
            if (tema != null)
            {
                SharedUser.Theme = tema;
                _changeBoldItalicService.ChangeBold(tema.Bold.ToString().Equals("0") ? "normal":"bold");
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

            NavigateToBillsCommand = new RelayCommand(o => { Navigation.NavigateTo<BillsViewModel>(true); }, o => true);
            NavigateToSettingsViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(true); }, o => true);
            NavigateToWorkersViewCommand = new RelayCommand(o => { Navigation.NavigateTo<WorkersViewModel>(true); }, o => true);
            NavigateToServicesViewCommand = new RelayCommand(o => { Navigation.NavigateTo<ServicesViewModel>(true); }, o => true);
            NavigateToItemsViewCommand=new RelayCommand(o => { Navigation.NavigateTo<ItemsViewModel>(true); }, o => true);
            ChangeLanguageCommand=new RelayCommand(execute=>ChangeLanguageService.ChangeLanguage(IsToggled),o=>true);
        }
    }
}
