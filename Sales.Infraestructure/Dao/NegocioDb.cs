using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class NegocioDb : INegocioDb
    {
        private readonly List<Negocio> _negocios;

        public bool Exists(string id)
        {
            _ = int.TryParse(id, out int outId);

            return this._negocios.Exists(u => u.Id == outId);
        }

        public List<Negocio> GetAll()
        {
            return this._negocios.Where(vd => !vd.Eliminado).ToList();
        }

        public Negocio GetById(int Id)
        {
            return this._negocios.Single(vd => vd.Id == Id);
        }

        public DataResult Save(Negocio entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Id.ToString()))
                    throw new NegocioException("El negocio ya se encuentra registrado.");

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
            }

            return result;
        }

        public void Update(Negocio entity)
        {
            this._negocios.Add(entity);
        }
    }
}
