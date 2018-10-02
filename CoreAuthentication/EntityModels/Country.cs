using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreAuthentication.Models
{
    public partial class Country
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(2, ErrorMessage = "Name cannot be longer than 2 characters.")]
        public string Name { get; set; }
    }
}
