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

namespace KoleServis.MVVM.ViewModel
{
    class CreateBillViewModel:Core.ViewModel
    {
        public ObservableCollection<ItemComponentViewModel> Dijelovi { get; set; }
        public ObservableCollection<ItemComponentViewModel> OriginalDijelovi { get; set; }
        public ObservableCollection<ItemComponentViewModel> ItemsBill { get; set; }

        private FindService _FindService { get; set; }

        public ItemComponentViewModel _selectedItem { get; set; }
        public ItemComponentViewModel _selectedItemBill { get; set; }
        public ObservableCollection<string> _categories { get; set; }

        private bool _itemsChecked;

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



        public ObservableCollection<String> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public string _selectedCategory { get; set; }
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        private string _title;
        private decimal _price;
        private int _quantity;
        private BitmapImage _base64Image;
        public BitmapImage SelectedImage
        {
            get => _base64Image;
            set
            {
                _base64Image = value;
                OnPropertyChanged(nameof(SelectedImage));
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
        private double _priceOver;
        public double PriceOver
        {
            get=>_priceOver;
            set
            {
                _priceOver = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand ClearCommand {  get; set; }
        public RelayCommand SearchCommand { get; set; }

        public RelayCommand IncreaseCommand { get; set; }

        public RelayCommand DecreaseCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        private string _defaultImage { get; set; }
        private byte[] array { get; set; }
        private string _defaultImageMechanic { get; set; }
        private byte[] arrayMechanic { get; set; }

        private string _searchItem;

        private ObservableCollection<Kupac> _customers;
        private Kupac _selectedCustomer;
        public Kupac SelectedCustomer
        {
            get=> _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
                CustomerChanged();
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

        public string SearchItem
        {
            get => _searchItem;
            set
            {
                _searchItem = value;
                OnPropertyChanged();
                AddToBill();
            }
        }

        private DateTime? _selectedDate;
        private DateTime? _selectedTime;

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

        private string _customerName;
        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand PrintCommand { get; set; }
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

            ItemsChecked = false;
            LoadDefaultImage();
            LoadDefaultImageMechanic();
            GetItems();
            GetServices();
            Dijelovi = new ObservableCollection<ItemComponentViewModel>(OriginalDijelovi);
            _FindService = new FindService();
            Customers=_FindService.FindAllCustomer();

            CreateCommand=new RelayCommand(execute=>Create(), o => true);
            PrintCommand=new RelayCommand(execute=>Print(), o => true);

        }
        public void Create()
        {

        }

        public void Print()
        {

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
            MessageBox.Show(SelectedDate?.ToString("yyyy-MM-dd") + " " + SelectedTime?.ToString(@"hh\:mm\:ss"));

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

        public void Search()
        {
            if (string.IsNullOrEmpty(SearchItem))
            {
                Dijelovi.Clear();
                foreach (var dio in OriginalDijelovi)
                    Dijelovi.Add(dio);
            }
            else if (SearchItem!=null && !SearchItem.Equals("") && ItemsChecked==true && SelectedCategory!=null && !SelectedCategory.Equals(""))
            {
                int idkat = getIdKat(SelectedCategory);
                var filteredList = OriginalDijelovi
                    .Where(dio => dio.Naziv.Contains(SearchItem, StringComparison.OrdinalIgnoreCase) && dio.idKategorija==idkat)
                    .ToList();

                Dijelovi.Clear();
                foreach (var dio in filteredList)
                    Dijelovi.Add(dio);
            }
            else
            {
                var filteredList = OriginalDijelovi
                    .Where(dio => dio.Naziv.Contains(SearchItem, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                Dijelovi.Clear();
                foreach (var dio in filteredList)
                    Dijelovi.Add(dio);
            }
        }

        private int getIdKat(string naziv)
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
            
            ItemComponentViewModel _item=new ItemComponentViewModel{ Naziv = SelectedItem.Naziv, Cijena = SelectedItem.Cijena, Kolicina = 1, UkupnaCijena = Double.Parse(SelectedItem.Cijena), MaxKolicina=SelectedItem.idKategorija!=0?SelectedItem.Kolicina:int.MaxValue };
            ItemsBill.Add(_item);
            RefreshPrice();


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
                    if (item.Obrisano == 0)
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
                        OriginalDijelovi.Add(new ItemComponentViewModel { Id = item.IdUsluga, Naziv = item.Naziv, Cijena = item.Cijena.ToString(), Slika = arrayMechanic, idKategorija=0 });

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
