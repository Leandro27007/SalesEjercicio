
using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class ProductoDb : IProductoDb
    {
        private readonly List<Producto> _Productos;

        public bool Exists(string id)
        {
            _ = int.TryParse(id, out int outId);

            return this._Productos.Exists(u => u.Id == outId);
        }

        public List<Producto> GetAll()
        {
            return this._Productos.Where(vd => !vd.Eliminado).ToList();
        }

        public Producto GetById(int Id)
        {
            return this._Productos.Single(vd => vd.Id == Id);
        }

        public DataResult Save(Producto entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Id.ToString()))
                    throw new ProductoException("El producto ya se encuentra registrada.");

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
            }

            return result;
        }

        public void Update(Producto entity)
        {
            this._Productos.Add(entity);
        }
    }
}
