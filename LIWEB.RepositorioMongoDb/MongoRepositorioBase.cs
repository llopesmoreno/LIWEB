using MongoDB.Driver;
using System.Threading.Tasks;
using LIWEB.Domain.Repositorios;

namespace LIWEB.RepositorioMongoDb
{
    public abstract class MongoRepositorioBase<T> : IRepositorio<T>
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly MongoCollectionSettings _collectionSettings;
        private readonly string _nomeColecao;

        protected MongoRepositorioBase(IMongoDatabase mongoDatabase, string nomeColecao)
        {
            _collectionSettings = new MongoCollectionSettings();
            _mongoDatabase = mongoDatabase;
            _nomeColecao = nomeColecao;
        }

        protected IMongoCollection<T> Colecao => _mongoDatabase.GetCollection<T>(_nomeColecao, _collectionSettings);
        protected FilterDefinitionBuilder<T> Filtro => Builders<T>.Filter;

        public async Task<T> Inserir(T entidade)
        {
            await Colecao.InsertOneAsync(entidade);
            return entidade;
        }
    }
}