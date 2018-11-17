using System;
using System.Collections.Generic;

namespace CoreAuthentication.EntityModels
{
    public partial class BrideOrGroom
    {
        public int Id { get; set; }
        public DateTime? Dob { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public bool? BrideOneGroomZero { get; set; }
    }
}
