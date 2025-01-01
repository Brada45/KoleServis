using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoleServis.MVVM.Models;

public partial class Racun
{
    public int IdRacun { get; set; }

    public decimal Cijena { get; set; }

    public int? KupacIdKupac { get; set; }

    public DateTime Datum { get; set; }

    public string RadnikOsobaKorisnickoIme { get; set; } = null!;

    public string RadnjaIdRadnja { get; set; } = null!;

    public virtual Kupac? KupacIdKupacNavigation { get; set; }

    public virtual Radnja RadnjaIdRadnjaNavigation { get; set; } = null!;

    public virtual ICollection<StavkaDio> StavkaDios { get; set; } = new List<StavkaDio>();

    public virtual ICollection<StavkaUsluga> StavkaUslugas { get; set; } = new List<StavkaUsluga>();

    [NotMapped]
    public string Customer {  get; set; }
}
