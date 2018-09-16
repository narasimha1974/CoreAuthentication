using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryHelper.Models
{
    public class City
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DistrinctId { get; set; }
        public string StateId { get; set; }
        public string CountryId { get; set; }
    }
    public class District
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string StateId { get; set; }
        public string CountryId { get; set; }
    }
    public class State
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
    }
    public class Country
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

}
