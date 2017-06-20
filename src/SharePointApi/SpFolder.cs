using System.Runtime.Serialization;

namespace SharePointApi
{
    [DataContract]
    public class SpFolder : SpObject
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "ServerRelativeUrl")]
        public string ServerRelativeUrl { get; set; }
        [DataMember(Name = "ItemCount")]
        public int ItemCount { get; set; }
    }
}
