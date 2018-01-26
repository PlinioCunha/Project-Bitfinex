using Domain.Core.Models;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Data
{
    public interface IDataUsuario
    {
        Task Gravar(Usuario model);
        Task<Usuario> DetalhePorEmail(string email);
    }
}
