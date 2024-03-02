using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class CategoriaDb : ICategoriaDb
    {
        private readonly List<Categoria> _categorias;

        public bool Exists(string id)
        {
            _ = int.TryParse(id, out int outId);

            return this._categorias.Exists(u => u.Id == outId);
        }

        public List<Categoria> GetAll()
        {
            return this._categorias.Where(vd => !vd.Eliminado).ToList();
        }

        public Categoria GetById(int Id)
        {
            return this._categorias.Single(vd => vd.Id == Id);
        }

        public DataResult Save(Categoria entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Id.ToString()))
                    throw new CategoriaException("la categoria ya se encuentra registrada.");

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
            }

            return result;
        }

        public void Update(Categoria entity)
        {
            this._categorias.Add(entity);
        }
    }
}
