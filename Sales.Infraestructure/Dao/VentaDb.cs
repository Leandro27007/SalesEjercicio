using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class VentaDb : IVentaDb
    {

        private readonly List<Venta> ventas;

        public bool Exists(string numeroVenta)
        {
            return this.ventas.Exists(vd => vd.NumeroVenta == numeroVenta);
        }

        public List<Venta> GetAll()
        {
            return this.ventas.Where(vd => !vd.Eliminado).ToList();
        }

        public Venta GetById(int ventaId)
        {
            return this.ventas.Single(vd => vd.Id == ventaId);
        }

        public DataResult Save(Venta venta)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(venta.NumeroVenta))
                    throw new VentaException("La venta ya se encuentra registrada.");
                
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
            }

            return result;
        }

        public void Update(Venta venta)
        {
            this.ventas.Add(venta);
        }
    }
}
