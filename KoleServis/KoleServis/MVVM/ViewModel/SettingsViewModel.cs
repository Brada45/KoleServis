using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.Services;
using MaterialDesignThemes.Wpf;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoleServis.MVVM.ViewModel
{
    public class RadioItem
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class SettingsViewModel: Core.ViewModel
    {


        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }


        private ObservableCollection<RadioItem> _backupRadioItems;
        private ObservableCollection<RadioItem> _backupRadioFonts;
        private ObservableCollection<RadioItem> _backupRadioLanguage;
        private ObservableCollection<RadioItem> _radioItems;
        private ObservableCollection<RadioItem> _radioFonts;
        private ObservableCollection<RadioItem> _radioLanguage;


        private FindService _findService;
        private RadioItem _selectedRadioItem;
        private RadioItem _selectedRadioFont;
        private Osoba person;
        private Base64Service _base64Service;

        private string _name;
        private string _surname;
        private string _password;
        private string _confirmPassword;
        private bool _boldChecked;
        private bool _italicChecked;

        public ObservableCollection<RadioItem> RadioItems
        {
            get => _radioItems;
            set
            {
                _radioItems = value;
                OnPropertyChanged(nameof(RadioItems));
            }
        }
        public ObservableCollection<RadioItem> RadioFonts
        {
            get => _radioFonts;
            set
            {
                _radioItems = value;
                OnPropertyChanged(nameof(RadioFonts));
            }
        }
        public ObservableCollection<RadioItem> RadioLanguage
        {
            get => _radioLanguage;
            set
            {
                _radioLanguage = value;
                OnPropertyChanged(nameof(RadioItems));
            }
        }
        public RadioItem SelectedRadioItem
        {
            get=>_selectedRadioItem;
            set
            {
                _selectedRadioItem = value;
                OnPropertyChanged(nameof(SelectedRadioItem));
            }
        }
        public RadioItem SelectedRadioFont
        {
            get => _selectedRadioFont;
            set
            {
                _selectedRadioItem = value;
                OnPropertyChanged(nameof(SelectedRadioFont));
            }
        }

        public bool BoldChecked
        {
            get => _boldChecked;
            set
            {
                _boldChecked = value;
                OnPropertyChanged(nameof(BoldChecked));
            }
        }
        public bool ItalicChecked
        {
            get => _italicChecked;
            set
            {
                _italicChecked = value;
                OnPropertyChanged(nameof(ItalicChecked));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ConfirmPassword {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public SettingsViewModel()
        {
            _findService = new FindService();
            Tema theme=SharedUser.Theme;
            Jezik lang = SharedUser.Language;
            person= SharedUser.CurrentPerson;
            _base64Service = new Base64Service();

            _radioItems = new ObservableCollection<RadioItem>(
                _findService.GetColor().Select(color => new RadioItem { Name = color, IsChecked = false })
            );
            _radioFonts = new ObservableCollection<RadioItem>(
                _findService.GetFonts().Select(font => new RadioItem { Name = font, IsChecked = false })
            );
            _radioLanguage = new ObservableCollection<RadioItem>(
                _findService.GetLanguages().Select(lang => new RadioItem{ Name=lang, IsChecked=false})    
            );

            _backupRadioItems = new ObservableCollection<RadioItem>(
                _radioItems.Select(item => new RadioItem { Name = item.Name, IsChecked = item.IsChecked })
            );
            _backupRadioFonts = new ObservableCollection<RadioItem>(
                _radioFonts.Select(item => new RadioItem { Name = item.Name, IsChecked = item.IsChecked })
            );
            _backupRadioLanguage = new ObservableCollection<RadioItem>(
                _radioLanguage.Select(item => new RadioItem { Name = item.Name, IsChecked = item.IsChecked })
            );
            SetDefaultCheckedItem(theme);
            SetDefaultCheckedFont(theme);
            SetDefaultCheckedLanguage(lang);
            if (theme.Bold.ToString().Equals("0"))
            {
                BoldChecked = false; 
            }
            else 
                BoldChecked = true;
            if (theme.Italic.ToString().Equals("0"))
            {
                ItalicChecked = false;
            }
            else
                ItalicChecked = true;
            SetBoldItalic(BoldChecked, ItalicChecked);
            Name = person.Ime;
            Surname = person.Prezime;
            Password = _base64Service.ConvertBase64(person.Sifra);
            ConfirmPassword = Password;
            UpdateCommand = new RelayCommand(o => Update(), o => true);
            ClearCommand = new RelayCommand(o => Clear(theme,lang), o => true);

        }

        public void Update() { 
            if(!Password.Equals("") && !ConfirmPassword.Equals("") && Password.Equals(ConfirmPassword))
            {
                string color=GetSelectedRadioItem().Name;
                string font = GetSelectedRadioFont().Name;
                string language = GetSelectedRadioLanguage().Name;
                bool bold = BoldChecked;
                bool italic = ItalicChecked;
                bool serbian = false;
                if (language.Equals("Srpski"))
                {
                    serbian = true;
                    ChangeLanguageService.ChangeLanguage(true);
                }
                else
                {
                    ChangeLanguageService.ChangeLanguage(false);
                }
                Tema theme = new Tema { Boja = color, Font = font, Bold = (sbyte)(bold?1:0), Italic = (sbyte)(italic?1:0), Velicina=10 };
                int idTheme=_findService.CheckAndAddTheme(theme);
                using (var context = new HcitableContext())
                {
                    var user = context.Osobas.FirstOrDefault(u => u.KorisnickoIme.Equals(person.KorisnickoIme));
                    if (user != null)
                    {
                        user.Ime = Name;
                        user.Prezime = Surname;
                        user.Sifra = _base64Service.ConvertPassword(Password);
                        user.TemaIdTema = idTheme;
                        user.JezikIdJezik = serbian ? 1 : 2;
                        SharedUser.CurrentPerson = user;
                        context.SaveChanges();
                    }
                }
                new ChangeBoldItalicService().ChangeItalic(italic == true ? "italic" : "normal");
                new ChangeBoldItalicService().ChangeBold(bold == true ? "bold" : "normal");
                new ChangeColorService().ChangeThemeColor(color.ToLower());
                ChangeFontService.ChangeFont(font);


            }
        }

        public void Clear(Tema theme, Jezik lang)
        {
            Name = person.Ime;
            Surname = person.Prezime;
            Password = _base64Service.ConvertBase64(person.Sifra);
            ConfirmPassword = Password;
            _radioFonts.Clear();
            foreach (var item in _backupRadioFonts)
            {
                _radioFonts.Add(item);  
            }

            _radioItems.Clear();
            foreach (var item in _backupRadioItems)
            {
                _radioItems.Add(item); 
            }

            _radioLanguage.Clear();
            foreach (var item in _backupRadioLanguage)
            {
                _radioLanguage.Add(item);
            }

            SetDefaultCheckedItem(theme);
            SetDefaultCheckedFont(theme);
            SetDefaultCheckedLanguage(lang);
            BoldChecked = theme.Bold.ToString().Equals("0")?false : true;
            ItalicChecked = theme.Italic.ToString().Equals("0") ? false : true;


        }
        public RadioItem GetSelectedRadioItem()
        {
            return _radioItems.FirstOrDefault(item => item.IsChecked);
        }

        public void SetBoldItalic(bool bold,bool italic)
        {
            BoldChecked = bold;
            ItalicChecked = italic;
        }

        private void SetDefaultCheckedItem(Tema theme)
        {
            var itemToCheck = _radioItems.FirstOrDefault(item => item.Name == theme.Boja);
            if (itemToCheck != null)
            {
                itemToCheck.IsChecked = true;
            }
        }
        public RadioItem GetSelectedRadioFont()
        {
            return _radioFonts.FirstOrDefault(item => item.IsChecked);
        }

        private void SetDefaultCheckedFont(Tema theme)
        {
            var itemToCheck = _radioFonts.FirstOrDefault(item => item.Name == theme.Font);
            if (itemToCheck != null)
            {
                itemToCheck.IsChecked = true;
            }
        }
        public RadioItem GetSelectedRadioLanguage()
        {
            return _radioLanguage.FirstOrDefault(item => item.IsChecked);
        }

        private void SetDefaultCheckedLanguage(Jezik lang)
        {
            var itemToCheck = _radioLanguage.FirstOrDefault(item => item.Name ==lang.Naziv);
            if (itemToCheck != null)
            {
                itemToCheck.IsChecked = true;
            }
        }

    }
}
