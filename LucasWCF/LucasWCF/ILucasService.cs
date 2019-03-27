using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LucasWCF
{
    [ServiceContract]
    public interface ILucasService
    {

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CreateLucas")]
        string CreateLucas(Lucas lucas);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetLucas")]
        List<Lucas> GetLucas();
    }


    [DataContract]
    public class Lucas
    {
        public ObjectId Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
