using System;
using System.Collections.Generic;

namespace KoleServis.MVVM.Models;

public partial class Tema
{
    public int IdTema { get; set; }

    public string Boja { get; set; } = null!;

    public string Font { get; set; } = null!;

    public sbyte Italic { get; set; }

    public sbyte Bold { get; set; }

    public int Velicina { get; set; }

    public virtual ICollection<Osoba> Osobas { get; set; } = new List<Osoba>();
}
