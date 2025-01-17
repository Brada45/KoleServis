using Google.Protobuf.Compiler;
using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.MVVM.View;
using KoleServis.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KoleServis.MVVM.ViewModel
{
    public class ServicesViewModel:Core.ViewModel
    {

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }


        public ObservableCollection<Usluga> OriginalItems { get; set; }
        public ObservableCollection<Usluga> _items { get; set; }


        public INavigationService _navigation;
        public ConfirmWindowViewModel confirmWindowViewModel;
        private Base64Service _Base64Service;
        private FindService _FindService;
        private Usluga _selectedItem;
        private string _title;
        private decimal _price;
        private string _searchItem;


        public ObservableCollection<Usluga> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        public Usluga SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                    OnSelecetedUslugaChanged();
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
        public string SearchItem
        {
            get => _searchItem;
            set
            {
                _searchItem = value;
                OnPropertyChanged();
            }
        }


        public ServicesViewModel()
        {
            OriginalItems = new ObservableCollection<Usluga>();
            _FindService = new FindService();
            _Base64Service = new Base64Service();
            AddCommand = new RelayCommand(o => AddItem(), o => SelectedItem == null);
            DeleteCommand = new RelayCommand(o => DeleteItem(), o => SelectedItem != null);
            UpdateCommand = new RelayCommand(o => UpdateItem(), o => SelectedItem != null);
            ClearCommand = new RelayCommand(o => ClearItem(), o => true);
            SearchCommand = new RelayCommand(o => Search(), o => true);
            GetItems();
            Items = new ObservableCollection<Usluga>(OriginalItems);
            confirmWindowViewModel= new ConfirmWindowViewModel();

        }

        public void UpdateList()
        {
            Items.Clear();
            foreach (var item in OriginalItems)
            {
                Items.Add(item);
            }
        }

        private void AddItem()
        {
            confirmWindowViewModel.Result = (confirmed) =>
            {
                if (confirmed)
                {
                    if (!Price.Equals("") && !Title.Equals(""))
                    {
                        Usluga tmp = new Usluga { Cijena = Price, Naziv = Title, RadnjaIdRadnja = "1", MenadzerOsobaKorisnickoIme = SharedUser.CurrentPerson.KorisnickoIme, Obrisano = 0 };
                        OriginalItems.Add(tmp);
                        using (var context = new HcitableContext())
                        {
                            context.Uslugas.Add(tmp);
                            context.SaveChanges();
                        }
                        UpdateList();
                        var succes = new SuccessfulAction();
                        succes.ShowDialog();
                    }
                    else
                    {
                        var unsuccess = new UnseccessfulAction();
                        unsuccess.ShowDialog();
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
                        var item = context.Uslugas.FirstOrDefault(i => i.IdUsluga == SelectedItem.IdUsluga);
                        if (item != null)
                        {
                            item.Obrisano = 1;
                            context.SaveChanges();
                            OriginalItems.Remove(SelectedItem);
                            ClearItem();
                            var success=new SuccessfulAction();
                            success.ShowDialog();
                        }
                        else
                        {
                            var unsuccess=new UnseccessfulAction();
                            unsuccess.ShowDialog();
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
                SelectedItem.Cijena = Price;

                using (var context = new HcitableContext())
                {
                    var item = context.Uslugas.FirstOrDefault(i => i.IdUsluga==SelectedItem.IdUsluga);
                    if (item != null)
                    {
                        item.Naziv = Title;
                        item.Cijena = Price;
                        context.SaveChanges();
                        var success = new SuccessfulAction();
                        success.ShowDialog();
                    }
                    else
                    {
                        var unsuccess = new UnseccessfulAction();
                        unsuccess.ShowDialog();
                    }
                }

                RefreshUIForCollection();

                ClearItem();
            }
        }
        private void RefreshUIForCollection()
        {
            var tempItems = Items.ToList();

            Items.Clear();
            OriginalItems.Clear();
            foreach (var Item in tempItems)
            {
                OriginalItems.Add(Item);
                Items.Add(Item);
            }
        }



        private void ClearItem()
        {
            SelectedItem = null; 
            Title= string.Empty;
            Price = (decimal)0.0;
        }

        private void GetItems()
        {
            using (var context = new HcitableContext())
            {
                var items = context.Uslugas.ToList();

                foreach (var item in items)
                {
                    if (item.Obrisano == 0)
                        OriginalItems.Add(item);
                }
            }
        }

        private void OnSelecetedUslugaChanged()
        {

            Title= SelectedItem.Naziv;
            Price = SelectedItem.Cijena;

        }

        private void Search()
        {
            if (SearchItem != null && !SearchItem.Equals(""))
            {
                var filteredList = OriginalItems
                    .Where(service => service.Naziv.Contains(SearchItem, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                Items.Clear();
                if (filteredList.Count == 0)
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDialog();
                }
                else
                {
                    foreach (var dio in filteredList)
                        Items.Add(dio);
                }

            }
            else
            {
                Items.Clear();
                foreach (var dio in OriginalItems)
                    Items.Add(dio);
            }
        }
    }
}
