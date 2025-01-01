using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoleServis.MVVM.Models;

public partial class Kupac
{
    public int IdKupac { get; set; }

    public string Naziv { get; set; } = null!;

    public int? Rabat { get; set; }

    public virtual ICollection<Racun> Racuns { get; set; } = new List<Racun>();
}


