using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Google.Protobuf.Compiler;
using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.Services;

namespace KoleServis.MVVM.ViewModel
{
    public class BillsViewModel:Core.ViewModel
    {
        public ObservableCollection<Racun> _bills { get; set; }
        public ObservableCollection<IResource> _resources { get; set; }
        private FindService _FindService;
        private Racun _selectedBill;
        public Racun SelectedBill
        {
            get { return _selectedBill ; }
            set
            {
                _selectedBill = value;
                OnPropertyChanged();
                OnSelecetedBillChanged();
            }
        }
        public ObservableCollection<IResource> Items
        {
            get => _resources;
            set
            {
                _resources = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        public ObservableCollection<Racun> Bills
        {
            get { return _bills; }
            set
            {
                _bills = value;
                OnPropertyChanged(nameof(Bills));
            }
        }

        public BillsViewModel(INavigationService navigation)
        {
            Bills=new ObservableCollection<Racun>();
            Items = new ObservableCollection<IResource>();
            _FindService = new FindService();
            GetBills();
        
        }

        private async Task GetBills()
        {
            await Task.Run(() =>
            {
                using (var context = new HcitableContext())
                {
                    var bills = context.Racuns.ToList();
                    _bills = new ObservableCollection<Racun>();

                    foreach (var bill in bills)
                    {
                        Kupac customer = _FindService.FindCustomer(bill.KupacIdKupac);
                        _bills.Add(new Racun
                        {
                            IdRacun = bill.IdRacun,
                            Customer = customer != null ? customer.Naziv : "",
                            Datum = bill.Datum,
                            Cijena = bill.Cijena
                        });
                    }
                }
            });
        }

        private void OnSelecetedBillChanged()
        {
            _resources.Clear();
            ObservableCollection<IResource> tmp=_FindService.FindItemOnBill(SelectedBill.IdRacun);
            
            foreach(StavkaDio item in tmp)
            {
               Dio itemName=_FindService.FindItem(item.DioIdDio);
                _resources.Add(new StavkaDio { Naziv=itemName.Naziv,CijenaKomad=item.CijenaKomad,Kolicina=item.Kolicina});
            }
            tmp=_FindService.FindServiceOnBill(SelectedBill.IdRacun);
            foreach (StavkaUsluga item in tmp)
            {
                Usluga itemName = _FindService.FindServices(item.UslugaIdUsluga);
                _resources.Add(new StavkaUsluga { Naziv = itemName.Naziv, CijenaKomad = item.CijenaKomad, Kolicina = item.Kolicina });
            }

        }
    }
}
