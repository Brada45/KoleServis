using Google.Protobuf.Compiler;
using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.MVVM.View;
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

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand UpdateImageCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ClearCategoryCommand { get; set; }


        public ObservableCollection<ItemComponentViewModel> Dijelovi { get; set; }
        public ObservableCollection<string> _categories { get; set; }
        public ObservableCollection<ItemComponentViewModel> OriginalDijelovi { get; set; }
        public ConfirmWindowViewModel confirmWindowViewModel;
        private FindService _FindService { get; set; }
        public ItemComponentViewModel _selectedItem {  get; set; }
        private BitmapImage _base64Image;

        private string _searchItem;
        private bool _itemsChecked;
        private string _defaultImage { get; set; }
        private byte[] array { get; set; }
        private string _title;
        private decimal _price;
        private int _quantity;
        public string _selectedCategory { get; set; }



        public ObservableCollection<String> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public ItemComponentViewModel SelectedItem {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                OnSelectedItemChanged();
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
        public string SelectedCategory
        {
            get=> _selectedCategory;
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
        public string SearchItem
        {
            get => _searchItem;
            set
            {
                _searchItem = value;
                OnPropertyChanged(nameof(SearchItem));
            }
        }
        public string SelectedSearchCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedSearchCategory));
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


        public ItemsViewModel()
        {
            OriginalDijelovi = new ObservableCollection<ItemComponentViewModel>();
            Categories = new ObservableCollection<string>();
            AddCommand = new RelayCommand(o => AddItem(), o => SelectedItem == null);
            DeleteCommand = new RelayCommand(o => DeleteItem(), o => SelectedItem != null);
            UpdateCommand = new RelayCommand(o => UpdateItem(), o => SelectedItem != null);
            ClearCommand = new RelayCommand(o => ClearItem(), o => true);
            UpdateImageCommand=new RelayCommand(o=>UpdateImage(),o=>true);
            ClearCategoryCommand = new RelayCommand(execute => ClearCategory(), o => true);
            SearchCommand=new RelayCommand(o=>Search(),o=>true);
            confirmWindowViewModel = new ConfirmWindowViewModel();
            _FindService = new FindService();

            LoadDefaultImage();
            GetItems();
            Dijelovi = new ObservableCollection<ItemComponentViewModel>(OriginalDijelovi);
        }

        private void UpdateList()
        {
            Dijelovi.Clear();
            foreach(var item in OriginalDijelovi)
            {
                Dijelovi.Add(item);
            }
        }
        private void AddItem()
        {
            confirmWindowViewModel.Result = (confirmed) =>
            {
                if (confirmed)
                {
                    int cat = _FindService.FindIdCategory(SelectedCategory);
                    if (cat != 0)
                    {
                        if (!Title.Equals("") && !Price.Equals("") && !Quantity.Equals("")) {
                            Dio item = new Dio { Naziv = Title, Cijena = Price, Obrisano = 0, Kolicina = Quantity, RadnjaIdRadnja = "1", KategorijaIdKategorija = cat, Slika = ImageService.BitmapImageToByteArray(SelectedImage) };
                            using (var context = new HcitableContext())
                            {
                                context.Dios.Add(item);
                                context.SaveChanges();
                            }
                            OriginalDijelovi.Add(new ItemComponentViewModel { Id = item.IdDio, Naziv = item.Naziv, Cijena = item.Cijena.ToString(), Slika = item.Slika != null ? item.Slika : array, Kolicina = item.Kolicina, idKategorija = item.KategorijaIdKategorija });
                            UpdateList();
                            var success = new SuccessfulAction();
                            success.ShowDialog();
                        }
                        else
                        {
                            var unsucc=new UnseccessfulAction();
                            unsucc.ShowDialog();
                        }
                    }
                    else
                    {
                        var unsucc = new UnseccessfulAction();
                        unsucc.ShowDialog();
                    }
                }
            };
            var confirmWindow = new ConfirmWindow(confirmWindowViewModel.Result);
            confirmWindow.ShowDialog();
        }
        private void DeleteItem()
        {
            confirmWindowViewModel.Result = (confirmed) =>
            {
                if (confirmed)
                {
                    using (var context = new HcitableContext())
                    {
                        var item = context.Dios.FirstOrDefault(i => i.IdDio == SelectedItem.Id);
                        if (item != null)
                        {
                            item.Obrisano = 1;
                            context.SaveChanges();
                            OriginalDijelovi.Remove(SelectedItem);
                            ClearItem();
                            var success=new SuccessfulAction();
                            success.ShowDialog();
                        }
                    }
                    UpdateList();
                }
            };
            var confirmWindow = new ConfirmWindow(confirmWindowViewModel.Result);
            confirmWindow.ShowDialog();

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
                        var success=new SuccessfulAction();
                        success.ShowDialog();
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
            OriginalDijelovi.Clear();
            foreach (var item in tempItems)
            {
                OriginalDijelovi.Add(item);
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
            SelectedItem = null;
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
                        OriginalDijelovi.Add(new ItemComponentViewModel { Id = item.IdDio, Naziv = item.Naziv, Cijena = item.Cijena.ToString(), Slika = item.Slika!=null?item.Slika:array, Kolicina=item.Kolicina,idKategorija=item.KategorijaIdKategorija });
                    
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

        public void ClearCategory()
        {
            SelectedSearchCategory = null;
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
            if (SearchItem != null && !SearchItem.Equals("") && ItemsChecked == true && SelectedCategory != null && !SelectedCategory.Equals(""))
            {
                int idkat = GetIdKat(SelectedSearchCategory);
                var filteredList = OriginalDijelovi
                    .Where(dio => dio.Naziv.Contains(SearchItem, StringComparison.OrdinalIgnoreCase) && dio.idKategorija == idkat)
                    .ToList();
                SetDijelovi(filteredList);

            }
            else if (ItemsChecked == true && SelectedCategory != null && !SelectedCategory.Equals(""))
            {
                int idkat = GetIdKat(SelectedSearchCategory);
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
    }

   
}
