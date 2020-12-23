using LIWEB.Domain.Entidades;
using MongoDB.Bson.Serialization;

namespace LIWEB.RepositorioMongoDb.Mapeamento
{
    public class UsuarioMapeamento : MongoDbMap<Usuario>
    {
        public UsuarioMapeamento() : base()
        {

        }

        public override void Map(BsonClassMap<Usuario> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(x => x.Id);
            cm.SetIgnoreExtraElements(true);
        }
    }
}