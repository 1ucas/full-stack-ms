using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFLucasBanco;
using System.Configuration;

namespace WCF.OrderReader
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

        public void Insert(Lucas input)
        {
            collectionLucas.InsertOne(input);
        }
    }
}
