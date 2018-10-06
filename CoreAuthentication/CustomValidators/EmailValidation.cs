using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAuthentication.CustomValidators
{
    public class EMailRoundTrip
    {
        [Remote(action: "VerifyEmail", controller: "Movie")]
        public string Email { get; set; }
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
