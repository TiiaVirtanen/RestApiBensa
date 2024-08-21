using System;
using System.Collections.Generic;

namespace RestApiBensas.Models;

public partial class Ajoneuvot
{
    public int AjoneuvoId { get; set; }

    public string Rekisterinumero { get; set; } = null!;

    public string? Merkki { get; set; }

    public string? Malli { get; set; }

    public byte[]? Kuva { get; set; }

    public int? KäyttäjäId { get; set; }

    public virtual Käyttäjät? Käyttäjä { get; set; }

    public virtual ICollection<Tankkau> Tankkaus { get; set; } = new List<Tankkau>();
}
