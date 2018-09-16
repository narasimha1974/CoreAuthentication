using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAuthentication.Models
{
    public class StudentAddress
    {
        [Key]
        public string ID { get; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string GurdianName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PIN { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; }
        public string StateId { get; set; }
        public string CountryId { get; set; }
        public string PhonesGroupId { get; set; }
        public string EmailsGroupId { get; set; }
        public string FaxsGroupId { get; set; }
        public string WebSitesGroupId { get; set; }
        public DateTime DOB { get; set; }
    }

}
