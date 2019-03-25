using System.Runtime.Serialization;

namespace WCFLucasBanco
{
    [DataContract]
    public class Lucas
    {
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
    }
}
