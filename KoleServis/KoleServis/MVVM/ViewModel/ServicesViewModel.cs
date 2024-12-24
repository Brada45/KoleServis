using Google.Protobuf.Compiler;
using KoleServis.Core;
using KoleServis.MVVM.Models;
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
        public ObservableCollection<Usluga> _items { get; set; }
        private int greatestID=0;
        public INavigationService _navigation;
        private Base64Service _Base64Service;
        private FindService _FindService;
        private Usluga _selectedItem;
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
        public ObservableCollection<Usluga> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
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
        private string _title;
        private decimal _price;

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
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }

        public ServicesViewModel()
        {
            Items = new ObservableCollection<Usluga>();
            _FindService = new FindService();
            _Base64Service = new Base64Service();
            AddCommand = new RelayCommand(o => AddItem(), o => SelectedItem == null);
            DeleteCommand = new RelayCommand(o => DeleteItem(), o => SelectedItem != null);
            UpdateCommand = new RelayCommand(o => UpdateItem(), o => SelectedItem != null);
            ClearCommand = new RelayCommand(o => ClearItem(), o => true);
            GetItems();

        }

        private void AddItem()
        {
            Usluga tmp = new Usluga {IdUsluga=greatestID+1, Cijena = Price, Naziv = Title,RadnjaIdRadnja="1",MenadzerOsobaKorisnickoIme="KoleMenadzer",Obrisano=0 };
            Items.Add(tmp);
            using (var context = new HcitableContext())
            {
                context.Uslugas.Add(tmp);
                context.SaveChanges();
            }
        }

        private void DeleteItem()
        {
            using (var context = new HcitableContext())
            {
                var item = context.Uslugas.FirstOrDefault(i => i.IdUsluga==SelectedItem.IdUsluga);
                if (item != null)
                {
                    item.Obrisano = 1;
                    context.SaveChanges();
                    Items.Remove(SelectedItem);
                    ClearItem();
                }
            }
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
                    }
                }

                // Forsiraj osvežavanje
                RefreshUIForCollection();

                ClearItem();
            }
        }
        private void RefreshUIForCollection()
        {
            var tempItems = Items.ToList();

            Items.Clear();

            foreach (var Item in tempItems)
            {
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
                    if(item.IdUsluga>greatestID)
                        greatestID = item.IdUsluga;
                    if (item.Obrisano == 0)
                        Items.Add(item);
                }
            }
        }

        private void OnSelecetedUslugaChanged()
        {

            Title= SelectedItem.Naziv;
            Price = SelectedItem.Cijena;

        }
    }
}
