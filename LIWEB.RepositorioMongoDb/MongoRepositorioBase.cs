using System;
using System.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;
using LIWEB.Domain.Entidades;
using LIWEB.Domain.Repositorios;

namespace LIWEB.RepositorioMongoDb
{
    public abstract class MongoRepositorioBase<T> //: IRepositorio<T> where T : Entidade
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

        //public async Task<T> Alterar(T entidade)
        //{
        //    await Colecao.FindOneAndReplaceAsync(x => x.Id == entidade.Id, entidade);
        //    return entidade;
        //}

        //public async Task Excluir(Guid id)
        //{
        //    var filtro = Builders<T>.Filter.Eq(c => c.Id, id);
        //    await Colecao.DeleteOneAsync(filtro);
        //}

        //public async Task<T> Inserir(T entidade)
        //{
        //    await Colecao.InsertOneAsync(entidade);
        //    return entidade;
        //}

        //public async Task<T> ObterPorId(Guid id)
        //{
        //    var filtro = Builders<T>.Filter.Eq(e => e.Id, id);
        //    var retorno = await Colecao.FindAsync(filtro);
        //    return retorno.FirstOrDefault();
        //}
    }
}