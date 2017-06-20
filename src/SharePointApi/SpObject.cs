using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SharePointApi
{
    [DataContract]
    public class SpObject
    {
        [DataMember(Name = "__metadata")]
        public MetaData MetaData { get; set; }
    }

    [DataContract]
    public class MetaData
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    [DataContract]
    public class SpUrl : SpObject
    {
        [DataMember(Name = "Description")]
        public string Description { get; set; }
        [DataMember(Name = "Url")]
        public string Url { get; set; }
    }
}
