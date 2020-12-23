using System;
using LIWEB.Domain.Entidades;
using System.Threading.Tasks;

namespace LIWEB.Domain.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {
        Task<T> Inserir(T entidade);
        Task<T> Alterar(T entidade);
        Task Excluir(Guid id);
        Task<T> ObterPorId(Guid id);        
    }
}