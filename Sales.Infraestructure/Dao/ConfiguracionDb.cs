using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class ConfiguracionDb : IConfiguracionDb
    {

        private readonly List<Configuracion> _configuraciones;

        public bool Exists(string id)
        {
            _ = int.TryParse(id, out int outId);

            return this._configuraciones.Exists(u => u.Id == outId);
        }

        public List<Configuracion> GetAll()
        {
            return this._configuraciones.Where(vd => !vd.Eliminado).ToList();
        }

        public Configuracion GetById(int Id)
        {
            return this._configuraciones.Single(vd => vd.Id == Id);
        }

        public DataResult Save(Configuracion entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Id.ToString()))
                    throw new ConfiguracionException("La configuracion ya se encuentra registrada.");

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
            }

            return result;
        }

        public void Update(Configuracion entity)
        {
            this._configuraciones.Add(entity);
        }

    }
}
