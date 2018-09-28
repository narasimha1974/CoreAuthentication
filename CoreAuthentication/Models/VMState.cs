using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAuthentication.Models
{
    public class VMState
    {        
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
        public List<SelectListItem> Countries{ get; set; }

    }
}
