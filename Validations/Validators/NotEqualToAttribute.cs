using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Validations.Validators
{
    public class NotEqualToAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _dependentProperty;
        //private readonly string _errorMessage;

        public NotEqualToAttribute(string dependentProperty) //, string errorMessage)
        {
            _dependentProperty = dependentProperty;
            //_errorMessage = errorMessage;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var clientValidationRule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "notequalto"
            };
            clientValidationRule.ValidationParameters.Add("dependentproperty", _dependentProperty);
            yield return clientValidationRule;

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_dependentProperty);
            if (propertyInfo != null)
            {
                var dependentValue = propertyInfo.GetValue(validationContext.ObjectInstance) as string;
                if (!string.IsNullOrEmpty(dependentValue) &&
                    value.ToString().Equals(dependentValue, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}