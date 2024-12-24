using System;
using System.Collections.Generic;

namespace KoleServis.MVVM.Models;

public partial class Radnja
{
    public string IdRadnja { get; set; } = null!;

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Dio> Dios { get; set; } = new List<Dio>();

    public virtual ICollection<Racun> Racuns { get; set; } = new List<Racun>();

    public virtual ICollection<Usluga> Uslugas { get; set; } = new List<Usluga>();

    public virtual ICollection<Osoba> OsobaKorisnickoImes { get; set; } = new List<Osoba>();

    public virtual ICollection<Osoba> OsobaKorisnickoImesNavigation { get; set; } = new List<Osoba>();
}
