using System;
using MongoDB.Bson.Serialization;

namespace LIWEB.RepositorioMongoDb.Util
{
    public class DateTimeSerializer : MongoDB.Bson.Serialization.Serializers.DateTimeSerializer
    {
        public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var obj = base.Deserialize(context, args);
            return new DateTime(obj.Ticks, DateTimeKind.Unspecified);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
        {
            var utcValue = new DateTime(value.Ticks, DateTimeKind.Unspecified);
            base.Serialize(context, args, utcValue);
        }
    }
}