using MongoDB.Driver;
using System.Threading.Tasks;
using LIWEB.Domain.Entidades;
using LIWEB.Domain.Repositorios;

namespace LIWEB.RepositorioMongoDb
{
    public class RepositorioUsuario : MongoRepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public RepositorioUsuario(IMongoDatabase mongoDatabase) : base(mongoDatabase, nameof(Usuario))
        {
            
        }

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            var filtro = Filtro.Eq(u => u.Email, email);
            filtro &= Filtro.Eq(usuario => usuario.Senha, senha);

            var registros = await Colecao.FindAsync(filtro);

            return registros.FirstOrDefault();
        }

        public async Task<bool> EmailExiste(string email)
        {
            var filtro = Filtro.Eq(u => u.Email, email);

            var registros = await Colecao.FindAsync(filtro);

            return registros.Any();
        }
    }
}