using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class RolMenuDb : IRolMenuDb
    {
        private readonly List<RolMenu> _roles;

        public bool Exists(string id)
        {
            _ = int.TryParse(id, out int outId);

            return this._roles.Exists(u => u.Id == outId);
        }

        public List<RolMenu> GetAll()
        {
            return this._roles.Where(vd => !vd.Eliminado).ToList();
        }

        public RolMenu GetById(int Id)
        {
            return this._roles.Single(vd => vd.Id == Id);
        }

        public DataResult Save(RolMenu entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Id.ToString()))
                    throw new RolMenuException("El rol menu ya se encuentra registrada.");

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
            }

            return result;
        }

        public void Update(RolMenu entity)
        {
            this._roles.Add(entity);
        }
    }
}
