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

        //[DataMember]
       // public List<EffectiveParameters> effective_parameters { get; set; }

        [DataMember]
        public List<Listings1> listings { get; set; }

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
    public class Listings1
    {
        [DataMember]
        public int msrp { get; set; }


    }

    public class Listing1
    {
        [DataMember]
        public int msrp1 { get; set; }


    }

}
