using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.Fofana_Bank_V2._3_Backend.Models
{
    public class Account
    {
        public int id { get; set; }
        public string name { get; set; }
        public double amount { get; set; }
        public int user { get; set; }
        //public User user { get; set; }
    }
}
