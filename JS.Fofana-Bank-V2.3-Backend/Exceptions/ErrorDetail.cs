using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.Fofana_Bank_V2._3_Backend.Exceptions
{
    public class ErrorDetail
    {
        public int status { get; set; }
        public string message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
