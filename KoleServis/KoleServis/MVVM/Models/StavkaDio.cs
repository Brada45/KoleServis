using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoleServis.MVVM.Models;

public partial class StavkaDio:IResource
{
    public int Kolicina { get; set; }

    public int DioIdDio { get; set; }

    public decimal CijenaKomad { get; set; }

    public decimal CijenaUkupno { get; set; }

    public int RacunIdRacun { get; set; }

    public virtual Dio DioIdDioNavigation { get; set; } = null!;

    public virtual Racun RacunIdRacunNavigation { get; set; } = null!;

    [NotMapped]
    public virtual string Naziv { get; set; } = string.Empty;
}
