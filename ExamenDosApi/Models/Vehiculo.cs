using System;
using System.Collections.Generic;

namespace ExamenDosApi.Models;

public partial class Vehiculo
{
    public string Placa { get; set; } = null!;

    public string TipoVehiculo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<Infraccion> Infraccions { get; set; } = new List<Infraccion>();
}
