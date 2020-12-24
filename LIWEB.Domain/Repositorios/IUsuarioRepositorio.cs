using LIWEB.Domain.Entidades;
using System.Threading.Tasks;

namespace LIWEB.Domain.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario> 
    {
        Task<Usuario> Autenticar(string email, string senha);        
        Task<bool> EmailExiste(string email);
    }
}