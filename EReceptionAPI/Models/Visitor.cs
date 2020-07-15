using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EReceptionAPI.Models
{
    public class Visitor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public string Gender { get; set; }

        public string Purpose { get; set; }
        public string Address { get; set; }
        public string ToMeet { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
    }
}