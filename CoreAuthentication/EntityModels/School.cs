using System;
using System.Collections.Generic;

namespace CoreAuthentication.Models
{
    public partial class School
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Pin { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; }
        public string StateId { get; set; }
        public string CountryId { get; set; }
        public string PhonesGroupId { get; set; }
        public string EmailsGroupId { get; set; }
        public string FaxsGroupId { get; set; }
        public string WebSitesGroupId { get; set; }
    }
}
