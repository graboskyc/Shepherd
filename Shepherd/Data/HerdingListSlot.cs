using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Shepherd.Data {
    [BsonIgnoreExtraElements]
    public class HerdingListSlot {
        [BsonElement("_id")]
        public ObjectId Id {get;set;} = ObjectId.GenerateNewId();

        [BsonElement("name")]
        public string Name {get;set;}
        
        [BsonElement("qty")]
        public int Quantity {get;set;} = 1;

        [BsonElement("signups")]
        public List<SlotSignup> SignUps {get;set;} = new List<SlotSignup>();

    }
}