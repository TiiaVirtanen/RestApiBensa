using System;
using System.Collections.Generic;

namespace RestApiBensas.Models;

public partial class Käyttäjät
{
    public int KäyttäjäId { get; set; }

    public string Sähköposti { get; set; } = null!;

    public string Salasana { get; set; } = null!;

    public string? Etunimi { get; set; }

    public string? Sukunimi { get; set; }

    public virtual ICollection<Ajoneuvot> Ajoneuvots { get; set; } = new List<Ajoneuvot>();
}
