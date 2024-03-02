using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class NumeroCorrelativoDb : INumeroCorrelativoDb
    {
        private readonly List<NumeroCorrelativo> _numeroCorrelativo;

        public bool Exists(string id)
        {
            _ = int.TryParse(id, out int outId);

            return this._numeroCorrelativo.Exists(u => u.Id == outId);
        }

        public List<NumeroCorrelativo> GetAll()
        {
            return this._numeroCorrelativo.Where(vd => !vd.Eliminado).ToList();
        }

        public NumeroCorrelativo GetById(int Id)
        {
            return this._numeroCorrelativo.Single(vd => vd.Id == Id);
        }

        public DataResult Save(NumeroCorrelativo entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Id.ToString()))
                    throw new NumeroCorrelatividadException("El numero Correlativo ya se encuentra registrada.");

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
            }

            return result;
        }

        public void Update(NumeroCorrelativo entity)
        {
            this._numeroCorrelativo.Add(entity);
        }
    }
}
