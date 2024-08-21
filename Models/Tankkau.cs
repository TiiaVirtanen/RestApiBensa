using System;
using System.Collections.Generic;

namespace RestApiBensas.Models;

public partial class Tankkau
{
    public int TankkausId { get; set; }

    public int AjoneuvoId { get; set; }

    public int? Ajokilometrit { get; set; }

    public decimal? Litraa { get; set; }

    public decimal? Euroa { get; set; }

    public DateOnly? Päivämäärä { get; set; }

    public virtual Ajoneuvot Ajoneuvo { get; set; } = null!;
}
