using System.Runtime.Serialization;

namespace SharePointApi
{
    [DataContract]
    public class SpFile : SpObject
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "ServerRelativeUrl")]
        public string ServerRelativeUrl { get; set; }
    }
}
