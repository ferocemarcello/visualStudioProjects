using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MainService.svc or MainService.svc.cs at the Solution Explorer and start debugging.
    public class MainService : IMainService
    {
        private static IMongoClient client;
        private static IMongoDatabase db;
        public MainService()
        {
            client = new MongoClient("mongodb://admin:admin@127.0.0.1:27017");
            db = client.GetDatabase("musicDb");
        }
        public void DoWork()
        {
        }
        public List<Genre> GetAllGenres()
        {
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Genre");
            var docs = collection.AsQueryable();
            List<Genre> glist = new List<Genre>();
            foreach (var x in docs)
            {
                Genre g = Converter.ConvertBsonDocumentToGenre(x);
                glist.Add(g);
            }
            return glist;
        }

        public string GetRandomString()
        {
            return "I am the server";
        }
    }
}
