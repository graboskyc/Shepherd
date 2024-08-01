using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Shepherd.Data {
    public class CSVDownload {
        
        public string SlotName {get;set;} = "";
        
        public string Quantity {get;set;} = "";

        public string SignupName {get;set;} = "";
        public string SignupEmail {get;set;} = "";

    }
}