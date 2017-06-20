using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SharePointApi
{
    [DataContract]
    public class SpList : SpObject
    {
        [DataMember(Name = "Title")]
        public string Title { get; set; }
        [DataMember(Name = "ItemCount")]
        public int ItemCount { get; set; }
    }
}
