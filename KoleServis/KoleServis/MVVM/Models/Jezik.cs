using System;
using System.Collections.Generic;

namespace KoleServis.MVVM.Models;

public partial class Jezik
{
    public int IdJezik { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Osoba> Osobas { get; set; } = new List<Osoba>();
}
