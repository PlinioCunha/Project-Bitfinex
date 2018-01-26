using Domain.Core.Interfaces.Data;
using Domain.Core.Models;
using Infra.Data.Interfaces.MongoDB;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace Domain.Core.Data
{
    public class DataUsuario : IDataUsuario
    {
        private readonly IMongoRepository<Usuario> _repository;
        public DataUsuario(IMongoRepository<Usuario> repository)
        {
            this._repository = repository;
        }

        public async Task Gravar(Usuario model)
        {
            var item = _repository.FindAsync(a => a.guid == model.guid);
            if (item.Result == null)
                await _repository.InsertAsync(model);
            else
                await _repository.UpdateAsync(model, (a => a.guid == model.guid));
        }

        public Task<Usuario> DetalhePorEmail(string email)
        {
            return _repository.Query().Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
        }

    }
}
