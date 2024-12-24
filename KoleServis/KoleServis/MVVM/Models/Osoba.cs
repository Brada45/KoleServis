using System;
using System.Collections.Generic;

namespace KoleServis.MVVM.Models;

public partial class Osoba
{
    public string KorisnickoIme { get; set; } = null!;

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string Sifra { get; set; } = null!;

    public int TipIdTip { get; set; }

    public int TemaIdTema { get; set; }

    public int JezikIdJezik { get; set; }

    public sbyte? Obrisan { get; set; }

    public virtual Jezik JezikIdJezikNavigation { get; set; } = null!;

    public virtual Tema TemaIdTemaNavigation { get; set; } = null!;

    public virtual Tip TipIdTipNavigation { get; set; } = null!;

    public virtual ICollection<Radnja> RadnjaIdRadnjas { get; set; } = new List<Radnja>();

    public virtual ICollection<Radnja> RadnjaJibs { get; set; } = new List<Radnja>();
}
