using System;
using System.Collections.Generic;

namespace CoreAuthentication.Models
{
    public partial class City
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DistrinctId { get; set; }
        public string StateId { get; set; }
        public string CountryId { get; set; }
    }
}
