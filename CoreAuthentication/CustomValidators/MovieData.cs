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

    [NoNameInSubject]
    public class EmailInfo
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name needs at least 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        //[RegularExpression(@"^[&=+\w]+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$",
        //ErrorMessage = "Invalid Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Body { get; set; }
    }

    // model validation attribute
    [System.AttributeUsage(AttributeTargets.Class)]
    public class NoNameInSubjectAttribute : ValidationAttribute, IClientModelValidator
    {
        public NoNameInSubjectAttribute()
        {
            ErrorMessage = "Please do NOT put your name in the Subject";
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-nonameinsubject", ErrorMessage);
            
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

        public override bool IsValid(object value)
        {
            EmailInfo emailInfo = value as EmailInfo;

            if (emailInfo == null || string.IsNullOrEmpty(emailInfo.Name)
                || string.IsNullOrEmpty(emailInfo.Subject))
            {
                return true;
            }
            else
            {
                return (emailInfo.Subject.IndexOf(emailInfo.Name) < 0);
            }
        }
    }
}

