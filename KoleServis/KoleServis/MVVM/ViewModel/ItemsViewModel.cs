using Google.Protobuf.Compiler;
using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace KoleServis.MVVM.ViewModel
{
    public class ItemsViewModel:Core.ViewModel
    {

        public ObservableCollection<ItemComponentViewModel> Dijelovi { get; set; }
        private FindService _FindService { get; set; }

        public ItemComponentViewModel _selectedItem {  get; set; }
        public ObservableCollection<string> _categories {  get; set; }

        public ItemComponentViewModel SelectedItem {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                OnSelectedItemChanged();
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
            get=> _selectedCategory;
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
        private string _defaultImage {  get; set; }
        private byte[] array {  get; set; }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand UpdateImageCommand { get; set; }

        public ItemsViewModel()
        {
            Dijelovi = new ObservableCollection<ItemComponentViewModel>();
            Categories = new ObservableCollection<string>();
            AddCommand = new RelayCommand(o => AddItem(), o => SelectedItem == null);
            DeleteCommand = new RelayCommand(o => DeleteItem(), o => SelectedItem != null);
            UpdateCommand = new RelayCommand(o => UpdateItem(), o => SelectedItem != null);
            ClearCommand = new RelayCommand(o => ClearItem(), o => true);
            UpdateImageCommand=new RelayCommand(o=>UpdateImage(),o=>true);
            _FindService = new FindService();

            LoadDefaultImage();
            GetItems();
        }
        private void AddItem()
        {
            int cat=_FindService.FindIdCategory(SelectedCategory);
            if (cat != 0) {
                Dio item = new Dio { Naziv = Title, Cijena = Price,Obrisano=0, Kolicina = Quantity,RadnjaIdRadnja="1", KategorijaIdKategorija = cat, Slika = ImageService.BitmapImageToByteArray(SelectedImage)};
                using (var context = new HcitableContext())
                {
                    context.Dios.Add(item);
                    context.SaveChanges();
                }
                Dijelovi.Add(new ItemComponentViewModel { Id = item.IdDio, Naziv = item.Naziv, Cijena = item.Cijena.ToString(), Slika = item.Slika != null ? item.Slika : array, Kolicina = item.Kolicina, idKategorija = item.KategorijaIdKategorija });
            }
        }
        private void DeleteItem()
        {
            using (var context = new HcitableContext())
            {
                var item = context.Dios.FirstOrDefault(i => i.IdDio==SelectedItem.Id);
                if (item != null)
                {
                    item.Obrisano = 1;
                    context.SaveChanges();
                    Dijelovi.Remove(SelectedItem);
                    ClearItem();
                }
            }

        }
        private void UpdateItem()
        {
            if (SelectedItem != null)
            {
                SelectedItem.Naziv = Title;
                SelectedItem.Cijena = Price.ToString();
                SelectedItem.Kolicina = Quantity;
                SelectedItem.Slika = ImageService.BitmapImageToByteArray(SelectedImage);

                using (var context = new HcitableContext())
                {
                    var item = context.Dios.FirstOrDefault(i=>i.IdDio==SelectedItem.Id);
                    if (item != null)
                    {
                        item.Naziv = Title;
                        item.Cijena = Price;
                        item.Kolicina = Quantity;
                        item.Slika=ImageService.BitmapImageToByteArray(SelectedImage);
                        context.SaveChanges();
                    }
                }

                RefreshUIForCollection();

                ClearItem();
            }
        }
        private void RefreshUIForCollection()
        {
            var tempItems = Dijelovi.ToList();

            Dijelovi.Clear();

            foreach (var item in tempItems)
            {
                Dijelovi.Add(item);
            }
        }
        private void ClearItem()
        {
            SelectedImage = null;
            Title=string.Empty;
            Price = 0;
            Quantity = 0;
            SelectedCategory=null;
            SelectedImage = null;
        }
        private void UpdateImage()
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Izaberite sliku",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                SelectedImage = ImageService.LoadImageFromFile(openFileDialog.FileName);
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
        public void GetItems()
        {
            using (var context = new HcitableContext())
            {
                var items = context.Dios.ToList();
                GetCategories();
                foreach (var item in items)
                {
                    if(item.Obrisano==0)
                        Dijelovi.Add(new ItemComponentViewModel { Id = item.IdDio, Naziv = item.Naziv, Cijena = item.Cijena.ToString(), Slika = item.Slika!=null?item.Slika:array, Kolicina=item.Kolicina,idKategorija=item.KategorijaIdKategorija });
                    
                }
            }
        }

        public void GetCategories()
        {
            using (var context = new HcitableContext())
            {
                var categories = context.Kategorijas.ToList();
                foreach(var category in categories)
                {
                    Categories.Add(category.Naziv);
                }
            }
        }

        public void OnSelectedItemChanged()
        {
            if (SelectedItem != null)
            {
                Title = SelectedItem.Naziv;
                Price = decimal.Parse(SelectedItem.Cijena);
                Quantity = SelectedItem.Kolicina;
                var tmpCat = _FindService.FindCategory(SelectedItem.idKategorija);
                SelectedCategory = tmpCat.Naziv;
                SelectedImage = ImageService.ByteArrayToImage(SelectedItem.Slika);
            }
        }
    }

   
}
