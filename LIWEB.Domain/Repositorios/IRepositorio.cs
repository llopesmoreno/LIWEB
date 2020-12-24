using System.Threading.Tasks;

namespace LIWEB.Domain.Repositorios
{
    public interface IRepositorio<T>
    {
        Task<T> Inserir(T entidade);
    }
}