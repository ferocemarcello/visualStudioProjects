using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServerService
{
    [DataContract]
    public class Genre
    {
        [DataMember]
        public string Name { get; set; }
        public Genre(string genreName)
        {
            Name = genreName;
        }

        public static Genre ConvertJsonToGenre()
        {
            throw new NotImplementedException();
        }
    }
}