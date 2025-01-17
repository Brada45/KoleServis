using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using KoleServis.MVVM.View;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Controls;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;
using System.Windows.Documents;
using System.Windows.Media;
using System.Globalization;


namespace KoleServis.MVVM.ViewModel
{
    class CreateBillViewModel:Core.ViewModel
    {

        public RelayCommand ClearCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand IncreaseCommand { get; set; }
        public RelayCommand PreviewCommand { get; set; }
        public RelayCommand DecreaseCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand PrintCommand { get; set; }
        public ObservableCollection<ItemComponentViewModel> Dijelovi { get; set; }
        public ObservableCollection<ItemComponentViewModel> OriginalDijelovi { get; set; }
        public ObservableCollection<ItemComponentViewModel> ItemsBill { get; set; }
        private ObservableCollection<Kupac> _customers;
        public ObservableCollection<string> _categories { get; set; }


        private FindService _FindService { get; set; }
        public ItemComponentViewModel _selectedItem { get; set; }
        public ItemComponentViewModel _selectedItemBill { get; set; }
        private BitmapImage _base64Image;
        private Kupac _selectedCustomer;
        private DateTime? _selectedDate;
        private DateTime? _selectedTime;
        private Racun billTmp;
        private Osoba osoba { get; set; }
        public ConfirmWindowViewModel confirmWindowViewModel;

        private bool _itemsChecked;
        public string _selectedCategory { get; set; }
        private string _title;
        private decimal _price;
        private int _quantity;
        private double _priceOver;
        private string _defaultImage { get; set; }
        private byte[] array { get; set; }
        private string _defaultImageMechanic { get; set; }
        private byte[] arrayMechanic { get; set; }
        private string _searchItem;
        private string _number;
        private string _customerName;


        public ObservableCollection<String> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public ObservableCollection<Kupac> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public bool ItemsChecked
        {
            get => _itemsChecked;
            set
            {
                if (_itemsChecked != value)
                {
                    _itemsChecked = value;
                    OnPropertyChanged(nameof(ItemsChecked));
                }
            }
        }

        public ItemComponentViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                AddToBill();
            }
        }

        public ItemComponentViewModel SelectedItemBill
        {
            get => _selectedItemBill;
            set
            {
                _selectedItemBill = value;
                OnPropertyChanged(nameof(SelectedItemBill));
            }
        }

        public BitmapImage SelectedImage
        {
            get => _base64Image;
            set
            {
                _base64Image = value;
                OnPropertyChanged(nameof(SelectedImage));
            }
        }
        public Kupac SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
                CustomerChanged();
            }
        }
        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime? SelectedTime
        {
            get => _selectedTime;
            set
            {
                _selectedTime = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
        public double PriceOver
        {
            get=>_priceOver;
            set
            {
                _priceOver = value;
                OnPropertyChanged();
            }
        }
        

        public string SearchItem
        {
            get => _searchItem;
            set
            {
                _searchItem = value;
                OnPropertyChanged();
            }
        }
        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }

        public string Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }
       


        public CreateBillViewModel()
        {
            OriginalDijelovi = new ObservableCollection<ItemComponentViewModel>();
            Categories = new ObservableCollection<string>();
            ItemsBill = new ObservableCollection<ItemComponentViewModel>();
            Customers=new ObservableCollection<Kupac>();


            ClearCommand = new RelayCommand(execute => ClearCategory(), o => true);
            SearchCommand = new RelayCommand(execute => Search(), o => true);
            IncreaseCommand = new RelayCommand(execute=>Increase(), o => true);
            DecreaseCommand = new RelayCommand(execute=>Decrease(), o => true);
            DeleteCommand=new RelayCommand(execute=>Delete(), o => true);
            PreviewCommand=new RelayCommand(execute=>Preview(), o => true);

            ItemsChecked = false;
            LoadDefaultImage();
            LoadDefaultImageMechanic();
            GetItems();
            GetServices();
            Dijelovi = new ObservableCollection<ItemComponentViewModel>(OriginalDijelovi);
            _FindService = new FindService();
            Customers=_FindService.FindAllCustomer();

            osoba = SharedUser.CurrentPerson;

            CreateCommand=new RelayCommand(execute=>Create(), o => true);
            PrintCommand=new RelayCommand(execute=>Print(), o => true);
            confirmWindowViewModel = new ConfirmWindowViewModel();

        }
        public void Create()
        {
            confirmWindowViewModel.Result = (confirmed) =>
            {
                if (confirmed)
                {
                    Racun racun = null;
                    if (ItemsBill.Count() != 0 && !SelectedDate.ToString().Equals("") && !SelectedTime.ToString().Equals(""))
                    {
                        string dateTimeString = SelectedDate?.ToString("yyyy-MM-dd") + " " + SelectedTime?.ToString(@"hh\:mm\:ss");
                        DateTime.TryParseExact(
                            dateTimeString,
                            "yyyy-MM-dd HH:mm:ss", 
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out DateTime result);
                        racun = new Racun { Cijena = (Decimal)PriceOver, Datum = result, KupacIdKupac = SelectedCustomer != null ? SelectedCustomer.IdKupac : null, RadnikOsobaKorisnickoIme = osoba.KorisnickoIme, RadnjaIdRadnja = 1.ToString() };
                        billTmp = racun;
                    }
                    if (racun != null)
                    {
                        using (var context = new HcitableContext())
                        {
                            context.Racuns.Add(racun);
                            context.SaveChanges();
                            SaveItems(racun);
                        }
                        var succes = new SuccessfulAction();
                        succes.ShowDialog();
                    }
                }
            };
            var confirmWindow = new ConfirmWindow(confirmWindowViewModel.Result);
            confirmWindow.ShowDialog();
        }

        public void SaveItems(Racun racun)
        {
            using (var context = new HcitableContext())
            {
                foreach (ItemComponentViewModel items in ItemsBill)
                {
                    if (items.IsDio == true)
                    {
                        StavkaDio item = new StavkaDio { Kolicina = items.Kolicina, DioIdDio = items.Id, CijenaKomad = Decimal.Parse(items.Cijena), CijenaUkupno = (Decimal)items.UkupnaCijena, RacunIdRacun = racun.IdRacun };
                        context.StavkaDios.Add(item);
                        context.SaveChanges();
                    }
                    else if (items.IsDio == false)
                    {
                        StavkaUsluga service = new StavkaUsluga { UslugaIdUsluga = items.Id, Kolicina = items.Kolicina, CijenaKomad = Decimal.Parse(items.Cijena), CijenaUkupno = (Decimal)items.UkupnaCijena, RadnikOsobaKorisnickoIme = "KoleMajstor", RacunIdRacun = racun.IdRacun };
                        context.StavkaUslugas.Add(service);
                        context.SaveChanges();
                    }
                }
            }
        }

        public void Print()
        {
            string dateTimeString = SelectedDate?.ToString("dd.MM.yyyy");
            FlowDocument flowDocument = new PrintService().CreateFlowDocument(ItemsBill,CustomerName,billTmp,Number,dateTimeString,PriceOver.ToString("F2"));

            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                IDocumentPaginatorSource paginatorSource = flowDocument;

                printDialog.PrintDocument(paginatorSource.DocumentPaginator, "Štampanje računa");
            }
        }

        public void Preview()
        {
            string dateTimeString = SelectedDate?.ToString("dd.MM.yyyy");
            FlowDocument flowDocument = new PrintService().CreateFlowDocument(ItemsBill, CustomerName, billTmp, Number, dateTimeString, PriceOver.ToString("F2"));

            var documentWindow = new DocumentViewewWindow();
            documentWindow.SetDocument(flowDocument);
            documentWindow.ShowDialog();
        }


        public void ChangeItemsChecked()
        {
            ItemsChecked = ItemsChecked==true?false:true;
        }
        public void ClearCategory()
        {
            SelectedCategory = null;
        }

        public void RefreshPrice()
        {
            double tmp=0.0;
            foreach (var item in ItemsBill)
            {
                tmp+= Double.Parse(item.Cijena) * item.Kolicina;
            }
            PriceOver=tmp;
        }

        public void Increase()
        {

            if (SelectedItemBill!=null && SelectedItemBill.Kolicina < SelectedItemBill.MaxKolicina)
            {
                SelectedItemBill.Kolicina += 1;
                SelectedItemBill.UkupnaCijena = Double.Parse(SelectedItemBill.Cijena) * SelectedItemBill.Kolicina;
            }
            RefreshPrice();
            RefreshUIForCollection();
        }

        public void Decrease()
        {
            if (SelectedItemBill != null && SelectedItemBill.Kolicina > 1)
            {
                SelectedItemBill.Kolicina -= 1;
                SelectedItemBill.UkupnaCijena = Double.Parse(SelectedItemBill.Cijena) * SelectedItemBill.Kolicina;

            }
            RefreshPrice();

            RefreshUIForCollection();
        }

        public void Delete()
        {
            if (SelectedItemBill != null)
            {
                 ItemsBill.Remove(SelectedItemBill);
            }
            RefreshPrice();

        }
        private void RefreshUIForCollection()
        {
            var tempItemsBill = ItemsBill.ToList();

            ItemsBill.Clear();

            foreach (var item in tempItemsBill)
            {
                ItemsBill.Add(item);
            }
        }
        public void SetDijelovi(List<ItemComponentViewModel> filteredList)
        {
            Dijelovi.Clear();
            if (filteredList.Count == 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDialog();
            }
            else
            {
                foreach (var dio in filteredList)
                    Dijelovi.Add(dio);
            }
        }
        public void Search()
        {
            
            if (SearchItem!=null && !SearchItem.Equals("") && ItemsChecked==true && SelectedCategory!=null && !SelectedCategory.Equals(""))
            {
                int idkat = GetIdKat(SelectedCategory);
                var filteredList = OriginalDijelovi
                    .Where(dio => dio.Naziv.Contains(SearchItem, StringComparison.OrdinalIgnoreCase) && dio.idKategorija==idkat)
                    .ToList();
                SetDijelovi(filteredList);
                
            }
            else if (ItemsChecked == true && SelectedCategory != null && !SelectedCategory.Equals(""))
            {
                int idkat = GetIdKat(SelectedCategory);
                var filteredList = OriginalDijelovi
                    .Where(dio => dio.idKategorija == idkat)
                    .ToList();

                SetDijelovi(filteredList);

            }
            else if (SearchItem != null && !SearchItem.Equals(""))
            {
                var filteredList = OriginalDijelovi
                    .Where(dio => dio.Naziv.Contains(SearchItem, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                SetDijelovi(filteredList);

            }
            else
            {
                Dijelovi.Clear();
                foreach (var dio in OriginalDijelovi)
                    Dijelovi.Add(dio);
            }
        }

        private int GetIdKat(string naziv)
        {
            using (var context = new HcitableContext())
            {
                var trazeniZapis = context.Kategorijas.FirstOrDefault(x => x.Naziv.Equals(naziv));
                if (trazeniZapis != null)
                {
                    return trazeniZapis.IdKategorija;
                }
                else
                {
                    return 0;
                }
            }

        }

        private void AddToBill()
        {
            if (SelectedItem != null)
            {

                ItemComponentViewModel _item = new ItemComponentViewModel { Naziv = SelectedItem.Naziv, Id = SelectedItem.Id, IsDio = SelectedItem.IsDio, Cijena = SelectedItem.Cijena, Kolicina = 1, UkupnaCijena = Math.Round(Double.Parse(SelectedItem.Cijena), 2), MaxKolicina = SelectedItem.idKategorija != 0 ? SelectedItem.Kolicina : int.MaxValue };
                if (!ItemsBill.Contains(_item))
                    ItemsBill.Add(_item);
                RefreshPrice();
            }


        }
        private void LoadDefaultImage()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("Resources/appsettings.json")
           .Build();

            _defaultImage = configuration["Images:DefaultImage"];
            array = Convert.FromBase64String(_defaultImage);
        }
        private void LoadDefaultImageMechanic()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("Resources/appsettings.json")
           .Build();

            _defaultImageMechanic = configuration["Images:MechanicImage"];
            arrayMechanic = Convert.FromBase64String(_defaultImageMechanic);
        }

        public void GetItems()
        {
            using (var context = new HcitableContext())
            {
                var items = context.Dios.ToList();
                GetCategories();
                foreach (var item in items)
                {
                    if (item.Obrisano == 0 && item.Kolicina>=1)
                        OriginalDijelovi.Add(new ItemComponentViewModel { Id = item.IdDio, Naziv = item.Naziv, Cijena = item.Cijena.ToString(), Slika = item.Slika != null ? item.Slika : array, Kolicina = item.Kolicina, idKategorija = item.KategorijaIdKategorija });

                }
            }
        }

        public void GetServices()
        {
            using(var context = new HcitableContext())
            {
                var items = context.Uslugas.ToList();
                foreach (var item in items)
                {
                    if (item.Obrisano == 0)
                        OriginalDijelovi.Add(new ItemComponentViewModel { Id = item.IdUsluga, Naziv = item.Naziv,IsDio=false, Cijena = item.Cijena.ToString(), Slika = arrayMechanic, idKategorija=0 });

                }
            }
        }

        public void GetCategories()
        {
            using (var context = new HcitableContext())
            {
                var categories = context.Kategorijas.ToList();
                foreach (var category in categories)
                {
                    Categories.Add(category.Naziv);
                }
            }
        }
        public void CustomerChanged()
        {
            CustomerName = SelectedCustomer.Naziv;
        }
    }
}
