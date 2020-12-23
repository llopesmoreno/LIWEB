using LIWEB.Domain.Entidades;
using MongoDB.Bson.Serialization;

namespace LIWEB.RepositorioMongoDb.Mapeamento
{
    public abstract class MongoDbMap<T> //where T : Entidade
    {
        protected MongoDbMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                BsonClassMap.RegisterClassMap<T>(Map);
        }

        public abstract void Map(BsonClassMap<T> cm);
    }
}
