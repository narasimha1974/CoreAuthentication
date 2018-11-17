using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoreAuthentication.CustomValidators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class NoThatInThisAttribute : ValidationAttribute, IClientModelValidator
    {
        string otherPropertyName;

        public NoThatInThisAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-nothatinthis", GetErrorMessage());

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
        private string GetErrorMessage()
        {
            return otherPropertyName+ "should not be same as this value";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                // Using reflection we can get a reference to the other date property, in this example the project start date
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                // Let's check that otherProperty is of type DateTime as we expect it to be

                if (otherPropertyInfo == null)
                {
                    validationResult = new ValidationResult(ErrorMessageString);
                    validationResult.ErrorMessage = "Blanks not allowed in "+this.otherPropertyName;
                    return validationResult;
                }
                if(((EmailInfo)validationContext.ObjectInstance).Name==null)
                {
                    validationResult = new ValidationResult(ErrorMessageString);
                    validationResult.ErrorMessage = "Blanks not allowed in Name";
                    return validationResult;
                }
                if (otherPropertyInfo.PropertyType.Name == "String")
                {
                   
                    string toValidate = value.ToString();
                    
                    string referenceProperty = (string)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                    if (toValidate.IndexOf(referenceProperty)!=-1)
                    {

                        validationResult = new ValidationResult(ErrorMessageString);
                        validationResult.ErrorMessage = "ding dong dong !!!!";
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occurred while validating the property.");
                }
            }
            catch (Exception ex)
            {
                // Do stuff, i.e. log the exception
                // Let it go through the upper levels, something bad happened
                throw ex;
            }

            return validationResult;
        }
    }
}