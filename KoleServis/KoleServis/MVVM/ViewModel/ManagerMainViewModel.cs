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

        public RelayCommand NavigateToBillsCommand { get; set; }
        public RelayCommand NavigateToSettingsViewCommand { get; set; }
        public RelayCommand NavigateToWorkersViewCommand { get; set; }
        public RelayCommand NavigateToServicesViewCommand { get; set; }
        public RelayCommand NavigateToItemsViewCommand { get; set; }


        public INavigationService _navigation;
        private Osoba Person { get; set; }
        private ChangeFontService _changeFontService;
        private ChangeBoldItalicService _changeBoldItalicService;
        private ChangeColorService _changeColorService;
        private FindService _findService;


        public bool IsBillsButtonEnabled { get; set; } = false;
        public bool IsWorkersButtonEnabled { get; set; } = true;
        public bool IsServicesButtonEnabled { get; set; } = true;
        public bool IsItemsButtonEnabled { get; set; } = true;
        public bool IsSettingsButtonEnabled { get; set; } = true;
        private bool _isToggled;
        private string _ime;
        private string _selectedButton;
        private string _letter;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                    _navigation = value; 
                OnPropertyChanged();
            }
        }
        public bool IsToggled
        {
            get => _isToggled;
            set
            {
                _isToggled = value;
                OnPropertyChanged(nameof(IsToggled));
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
            get=> _letter;
            set
            {
                _letter = value;
                OnPropertyChanged(nameof(Letter));
            }
        }

        public string SelectedButton
        {
            get => _selectedButton;
            set
            {
                _selectedButton = value;
                OnPropertyChanged(nameof(SelectedButton));
            }
        }

        


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

            NavigateToBillsCommand = new RelayCommand(o =>
            {
                SetButtonStates("Bills");
                Navigation.NavigateTo<BillsViewModel>(true);
            }, o => true);

            NavigateToWorkersViewCommand = new RelayCommand(o =>
            {
                SetButtonStates("Workers");
                Navigation.NavigateTo<WorkersViewModel>(true);
            }, o => true);

            NavigateToServicesViewCommand = new RelayCommand(o =>
            {
                SetButtonStates("Services");
                Navigation.NavigateTo<ServicesViewModel>(true);
            }, o => true);

            NavigateToItemsViewCommand = new RelayCommand(o =>
            {
                SetButtonStates("Items");
                Navigation.NavigateTo<ItemsViewModel>(true);
            }, o => true);

            NavigateToSettingsViewCommand = new RelayCommand(o =>
            {
                SetButtonStates("Settings");
                Navigation.NavigateTo<SettingsViewModel>(true);
            }, o => true);

            Navigation.NavigateTo<BillsViewModel>(true);
        }
        private void SetButtonStates(string pressedButton)
        {
            IsBillsButtonEnabled = pressedButton != "Bills";
            IsWorkersButtonEnabled = pressedButton != "Workers";
            IsServicesButtonEnabled = pressedButton != "Services";
            IsItemsButtonEnabled = pressedButton != "Items";
            IsSettingsButtonEnabled = pressedButton != "Settings";

            OnPropertyChanged(nameof(IsBillsButtonEnabled));
            OnPropertyChanged(nameof(IsWorkersButtonEnabled));
            OnPropertyChanged(nameof(IsServicesButtonEnabled));
            OnPropertyChanged(nameof(IsItemsButtonEnabled));
            OnPropertyChanged(nameof(IsSettingsButtonEnabled));
        }

    }
}
