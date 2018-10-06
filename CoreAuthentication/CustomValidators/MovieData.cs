using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAuthentication.CustomValidators
{


    public enum Genre
    {
        Classic=0,
        Jamesbond=1
    };

    public class MovieVM
    {
        public Movie Movie { get; set; }
        public IEnumerable<SelectListItem> MovieLst { get; set; }

        public static IEnumerable<SelectListItem> getMoviesAsSelectListItems()
        {
            List<SelectListItem> movies = new List<SelectListItem>();

            movies.Add(new SelectListItem() { Text = "Classic", Value = "Classic", Selected =  false });
            movies.Add(new SelectListItem() { Text = "Jamesbond", Value = "Jamesbond", Selected = false });

            return movies;
        }
    }
    [ClassicMovie(1960)]   
    public class Movie
    {
        public int Id { get; set; }
        
        [Remote(action: "VerifyEmail", controller: "Movie" )]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [ClassicMovie(1960)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public bool Preorder { get; set; }

        [DisplayName("Start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("Estimated end date")]
        [DataType(DataType.Date)]
        [DateGreaterThan("StartDate", "tring tring !!!! from client validation")]
        public DateTime EndDate { get; set; }
    }   
}

