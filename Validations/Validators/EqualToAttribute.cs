using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Validations.Validators
{
    public class EqualToAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _dependentProperty;

        public EqualToAttribute(string dependentProperty)
        {
            _dependentProperty = dependentProperty;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var clientValidationRule = new ModelClientValidationEqualToRule(ErrorMessage, _dependentProperty);
            clientValidationRule.ValidationParameters.Add("dependentproperty", _dependentProperty);
            yield return clientValidationRule;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectInstance.GetType().GetProperty(_dependentProperty);
            if (propertyInfo != null)
            {
                var dependentValue = propertyInfo.GetValue(validationContext.ObjectInstance) as string;
                if (!string.IsNullOrEmpty(dependentValue) && value.ToString().Equals(dependentValue, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}