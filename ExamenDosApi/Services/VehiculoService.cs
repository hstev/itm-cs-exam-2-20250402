using ExamenDosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenDosApi.Services
{
    public class VehiculoService
    {

        //public <List<Vehiculo>> GetVehiculos()
        //{
        //    using (var context = new DbexamenContext())
        //    {
        //        return context.Vehiculos.ToList();
        //    }
        //}

        //public Vehiculo GetVehiculo(string id)
        //{
        //    using (var context = new DbexamenContext())
        //    {
        //        return context.Vehiculos.Find(id);
        //    }
        //}

        //public void PutVehiculo(string id, Vehiculo vehiculo)
        //{
        //    using (var context = new DbexamenContext())
        //    {
        //        if (id != vehiculo.Placa)
        //        {
        //            return BadRequest();
        //        }
        //        context.Entry(vehiculo).State = EntityState.Modified;
        //        try
        //        {
        //            context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            throw;
        //        }
        //    }
        //}
    }
}
