using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoleServis.MVVM.Models;

public partial class StavkaUsluga:IResource
{
    public int UslugaIdUsluga { get; set; }

    public int Kolicina { get; set; }

    public decimal CijenaKomad { get; set; }

    public decimal CijenaUkupno { get; set; }

    public string RadnikOsobaKorisnickoIme { get; set; } = null!;

    public int RacunIdRacun { get; set; }

    public virtual Racun RacunIdRacunNavigation { get; set; } = null!;

    public virtual Usluga UslugaIdUslugaNavigation { get; set; } = null!;

    [NotMapped]
    public string Naziv { get; set; }
}
