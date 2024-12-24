using System;
using System.Collections.Generic;

namespace KoleServis.MVVM.Models;

public partial class Kategorija
{
    public int IdKategorija { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Dio> Dios { get; set; } = new List<Dio>();
}
