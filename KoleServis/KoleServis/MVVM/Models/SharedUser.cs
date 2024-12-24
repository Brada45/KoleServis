using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KoleServis.MVVM.Models
{
    public static class SharedUser
    {
        public static Osoba CurrentPerson { get; set; }
        public static Tema Theme { get; set; }
        public static Jezik Language { get; set; }
    }
}
