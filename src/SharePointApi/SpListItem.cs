using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SharePointApi
{
    [DataContract]
    public class SpListItem : SpObject
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "SFLink")]
        public SpUrl SfLink { get; set; }
    }
}
