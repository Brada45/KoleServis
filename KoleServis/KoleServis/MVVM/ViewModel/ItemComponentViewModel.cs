using KoleServis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace KoleServis.MVVM.ViewModel
{
    public class ItemComponentViewModel
    {
        public int Id { get; set; } 
        public string Naziv { get; set; }
        public string Cijena { get; set; }
        public byte[] Slika { get; set; }
        public int Kolicina { get; set; }
        public int MaxKolicina { get; set; }
        public int idKategorija {  get; set; }  
        public double UkupnaCijena {  get; set; }
        public bool IsDio { get; set; } = true;


        public int TargetWidth { get; set; } =200; // Primer širine
        public int TargetHeight { get; set; } =200; // Primer visine

        public BitmapImage SlikaBitmap => ImageService.ByteArrayToImage(Slika, TargetWidth, TargetHeight);
    }
}
