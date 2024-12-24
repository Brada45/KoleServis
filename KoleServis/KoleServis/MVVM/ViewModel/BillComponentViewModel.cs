using KoleServis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace KoleServis.MVVM.ViewModel
{
    class BillComponentViewModel
    {

        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public byte[] Slika { get; set; }
        public int MaxKolicina { get; set; }

        public int Kolicina { get; set; }
        public int idKategorija { get; set; }

        public double UkupnaCijena { get; set; }

    }
}
