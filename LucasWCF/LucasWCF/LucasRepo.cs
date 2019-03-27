using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LucasWCF
{
    public class LucasRepo
    {
        private readonly IMongoCollection<Lucas> collectionLucas;

        public LucasRepo()
        {
            string conexaoMongoDB = ConfigurationManager.ConnectionStrings["LucasDB"].ConnectionString;
            var cliente = new MongoClient(conexaoMongoDB);
            collectionLucas = cliente.GetDatabase("lucasdatabase").GetCollection<Lucas>("lucascollection");
        }

        public List<Lucas> Get()
        {
            return collectionLucas.Find(lucas => true).ToList();
        }
    }
}