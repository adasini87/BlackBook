using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BlackBookAPITesting
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public int warning_count { get; set; }
        [DataMember]
        public int error_count { get; set; }

        [DataMember]
        public List<Type> message_list { get; set; }

    }
    [DataContract]
    public class WarningCount
    {


    }


    [DataContract]
    public class Type
    {
        [DataMember]
        public string type { get; set; }

    }



    [DataContract]
    public class InputParameters
    {


    }

    [DataContract]
    public class EffectiveParameters
    {


    }

    [DataContract]
    public class Listings
    {
        [DataMember]
        public string account { get; set; }
        [DataMember]
        public int tierCode { get; set; }
        [DataMember]
        public string tierDescription { get; set; }
        [DataMember]
        public string tierPoints { get; set; }
        [DataMember]
        public long cmpPoints { get; set; }
        [DataMember]
        public string tierDisplayMessage { get; set; }
        [DataMember]
        public string[] tierDisplayMessageArgs { get; set; }

    }


}
