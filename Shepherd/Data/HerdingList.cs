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
        [BsonElement("endSignupsDT")]
        public DateTime EndSignupsDT {get;set;} = DateTime.Now.AddDays(7);

        [BsonElement("isPublished")]
        public bool IsPublished {get;set;} = false;

        [BsonElement("slots")]
        public List<HerdingListSlot> Slots {get;set;} = new List<HerdingListSlot>();

        public List<CSVDownload> AsCSV {get {
            List<CSVDownload> csv = new List<CSVDownload>();
            foreach(var slot in Slots) {
                int i = 0;
                while(i < slot.Quantity) {
                    
                    CSVDownload suAsCSV = new CSVDownload();

                    if(slot.SignUps.ElementAtOrDefault(i) != null) {
                        suAsCSV.SlotName = slot.Name;
                        suAsCSV.Quantity = (i+1).ToString() + " of "+slot.Quantity.ToString();
                        suAsCSV.SignupName = slot.SignUps[i].WhoName;
                        suAsCSV.SignupEmail = slot.SignUps[i].WhoEmail;
                    } else {
                        suAsCSV.SlotName = slot.Name;
                        suAsCSV.Quantity = (i+1).ToString() + "/"+slot.Quantity.ToString();
                    }
                    csv.Add(suAsCSV);
                    i = i + 1;
                }
            }
            return csv;
        }}
    }
}