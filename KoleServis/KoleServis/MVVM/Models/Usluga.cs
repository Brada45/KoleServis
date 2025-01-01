using System;
using System.Collections.Generic;

namespace KoleServis.MVVM.Models;

public partial class Usluga
{
    public int IdUsluga { get; set; }

    public string Naziv { get; set; } = null!;

    public string RadnjaIdRadnja { get; set; } = null!;

    public decimal Cijena { get; set; }

    public string MenadzerOsobaKorisnickoIme { get; set; } = null!;

    public sbyte? Obrisano { get; set; }

    public virtual Radnja RadnjaIdRadnjaNavigation { get; set; } = null!;

    public virtual ICollection<StavkaUsluga> StavkaUslugas { get; set; } = new List<StavkaUsluga>();
}
