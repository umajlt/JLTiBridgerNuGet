using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JLTiBridgerNuGet
{
    
    public class Faultstring
    {
        [JsonProperty("@lang")]
        public string Lang { get; set; }
        public string TEXT { get; set; }
    }

    public class ServiceFault
    {
        public string Message { get; set; }
        public string Type { get; set; }
    }

    public class Detail
    {
        public ServiceFault ServiceFault { get; set; }
    }

    public class Fault
    {
        public string faultcode { get; set; }
        public Faultstring faultstring { get; set; }
        public Detail detail { get; set; }
    }

    public class SanctionFault: SanctionResult
    {
        public Fault Fault { get; set; }
    }


}
