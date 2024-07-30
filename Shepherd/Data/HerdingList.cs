using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shepherd.Data {
    [BsonIgnoreExtraElements]
    public class HerdingList {
        [BsonElement("_id")]
        public ObjectId Id {get;set;}

        [BsonElement("name")]
        public string Name {get;set;}

        [BsonElement("ownedBy")]
        public string OwnedBy {get;set;}


    }
}