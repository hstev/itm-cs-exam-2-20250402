using System;
using System.Collections.Generic;

namespace ExamenDosApi.Models;

public partial class Infraccion
{
    public int IdFotoMulta { get; set; }

    public string PlacaVehiculo { get; set; } = null!;

    public DateTime FechaInfraccion { get; set; }

    public string TipoInfraccion { get; set; } = null!;

    public virtual ICollection<FotoInfraccion> FotoInfraccions { get; set; } = new List<FotoInfraccion>();

    public virtual Vehiculo PlacaVehiculoNavigation { get; set; } = null!;
}
