using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class UsuarioDb : IUsuarioDb
    {

        private readonly List<Usuario> _users;

        public bool Exists(string correo)
        {
            return this._users.Exists(u => u.Correo == correo);
        }

        public List<Usuario> GetAll()
        {
            return this._users.Where(vd => !vd.Eliminado).ToList();
        }

        public Usuario GetById(int Id)
        {
            return this._users.Single(vd => vd.Id == Id);
        }

        public DataResult Save(Usuario entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Correo))
                    throw new UsuarioDbExceptions("El usuario ya se encuentra registrada.");

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
            }

            return result;
        }

        public void Update(Usuario entity)
        {
            this._users.Add(entity);
        }
    }
}
