using System;
using System.Collections.Generic;

namespace KoleServis.MVVM.Models;

public partial class Dio:IResource  
{
    public int IdDio { get; set; }

    public string Naziv { get; set; } = null!;

    public string RadnjaIdRadnja { get; set; } = null!;

    public decimal Cijena { get; set; }

    public int Kolicina { get; set; }

    public byte[]? Slika { get; set; }

    public int KategorijaIdKategorija { get; set; }

    public sbyte? Obrisano { get; set; }

    public virtual Kategorija KategorijaIdKategorijaNavigation { get; set; } = null!;

    public virtual Radnja RadnjaIdRadnjaNavigation { get; set; } = null!;

    public virtual ICollection<StavkaDio> StavkaDios { get; set; } = new List<StavkaDio>();
}
