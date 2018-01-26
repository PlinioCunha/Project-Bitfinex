using Domain.Core.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IServiceUsuario
    {
        Task Gravar(Usuario model);
        Task<Usuario> DetalhePorEmail(string email);
    }
}
