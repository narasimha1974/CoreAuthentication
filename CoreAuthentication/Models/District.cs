using System;
using System.Collections.Generic;

namespace CoreAuthentication.Models
{
    public partial class District
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StateId { get; set; }
        public string CountryId { get; set; }
    }
}
