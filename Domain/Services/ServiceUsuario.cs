using Domain.Core.Interfaces.Data;
using Domain.Core.Models;
using Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Domain.Services
{

    public class ServiceUsuario: IServiceUsuario
    {
        private readonly IDataUsuario _repository;
        public ServiceUsuario(IDataUsuario repository)
        {
            this._repository = repository;
        }

        public async Task Gravar(Usuario model)
        {
            await _repository.Gravar(model);            
        }

        public Task<Usuario> DetalhePorEmail(string email) =>_repository.DetalhePorEmail(email);
        
    }
}
