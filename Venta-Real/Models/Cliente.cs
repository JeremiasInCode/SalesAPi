﻿using System;
using System.Collections.Generic;

namespace Venta_Real.Models;

public partial class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
