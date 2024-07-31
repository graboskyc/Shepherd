using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Shepherd.Data {
    [BsonIgnoreExtraElements]
    public class HerdingList {
        [BsonElement("_id")]
        public ObjectId Id {get;set;}  = ObjectId.GenerateNewId();

        [BsonElement("name")]
        public string Name {get;set;}
        [BsonElement("description")]
        public string Description {get;set;}
        [BsonElement("location")]
        public string Location {get;set;}

        [BsonElement("ownedBy")]
        public string OwnedBy {get;set;}

        [BsonElement("createdDT")]
        public DateTime CreatedDate {get;set;} = DateTime.Now;
        [BsonElement("modifiedDT")]
        public DateTime ModifiedDT {get;set;} = DateTime.Now;

        [BsonElement("eventDT")]
        public DateTime EventDT {get;set;} = DateTime.Now.AddDays(7);

        [BsonElement("isPublished")]
        public bool IsPublished {get;set;} = false;

        [BsonElement("slots")]
        public List<HerdingListSlot> Slots {get;set;} = new List<HerdingListSlot>();
    }
}