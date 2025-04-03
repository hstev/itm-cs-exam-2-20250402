using System;
using System.Collections.Generic;

namespace ExamenDosApi.Models;

public partial class FotoInfraccion
{
    public int IdFoto { get; set; }

    public string NombreFoto { get; set; } = null!;

    public int IdInfraccion { get; set; }

    public virtual Infraccion IdInfraccionNavigation { get; set; } = null!;
}
