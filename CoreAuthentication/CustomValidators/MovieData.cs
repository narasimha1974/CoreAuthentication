using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAuthentication.CustomValidators
{

    public class EMailRoundTrip
    {
        [Remote(action: "VerifyEmail", controller: "Movie")]
        public string Email { get; set; }
    }
    public enum Genre
    {
        Classic=10,
        Jamesbond=11
    };

    [ClassicMovie(1960)]   
    public class Movie
    {
        public int Id { get; set; }

        [Remote(action: "VerifyEmail", controller: "Movie")]
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
    }
    public class ClassicMovieAttribute : ValidationAttribute, IClientModelValidator
    {
        private int _year;

        public ClassicMovieAttribute(int year)
        {
            _year = year;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-classicmovie", GetErrorMessage());

            var year = _year.ToString(CultureInfo.InvariantCulture);
            MergeAttribute(context.Attributes, "data-val-classicmovie-year", year);
        }
        bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;

            if ((movie.Genre == Genre.Classic) && (movie.ReleaseDate.Year > _year))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;
            if ((movie.Genre == Genre.Classic) && (movie.ReleaseDate.Year > _year))
            {
                yield return new ValidationResult(
                    $"IENUMERABLE Classic movies must have a release year earlier than {_year}.",
                    new[] { "ReleaseDate" });
            }
        }
        private string GetErrorMessage()
        {
            return $"Classic movies must have a release year earlier than {_year}.";
        }
    }
}
