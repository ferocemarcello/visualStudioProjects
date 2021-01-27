using System;
using MongoDB.Bson;
using System.Collections.Generic;

namespace ServerService
{
    public class Converter
    {
        public static Genre ConvertBsonDocumentToGenre(BsonDocument x)
        {
            IEnumerator<BsonValue> e= x.Values.GetEnumerator();
            e.MoveNext(); e.MoveNext();
            return new Genre(e.Current.AsString);
        }
    }
}