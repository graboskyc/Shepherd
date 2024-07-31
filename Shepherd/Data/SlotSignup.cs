using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Shepherd.Data {
    [BsonIgnoreExtraElements]
    public class SlotSignup {

        [BsonElement("whoId")]
        public string WhoId {get;set;} = "";
        
        [BsonElement("whoName")]
        public string WhoName {get;set;} = "";
        [BsonElement("whoEmail")]
        public string WhoEmail {get;set;} = "";
        [BsonElement("when")]
        public DateTime When {get;set;} = DateTime.Now;
    }
}