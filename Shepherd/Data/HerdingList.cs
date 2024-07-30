using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shepherd.Data {
    [BsonIgnoreExtraElements]
    public class HerdingList {
        [BsonElement("Id")]
        public ObjectIDGenerator _id {get;set;}

    }
}