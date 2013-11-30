using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace ps.dmv.common.Validation
{
    /// <summary>
    /// ValidationProvider
    /// </summary>
    public class ValidationProvider : IValidationProvider
    {
        /// <summary>
        /// Validates the specified object to validate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <returns></returns>
        public ValidationResults Validate<T>(T objectToValidate)
        {
            ValidationFactory.SetDefaultConfigurationValidatorFactory(new SystemConfigurationSource(false));

            Validator<T> validator = ValidationFactory.CreateValidator<T>();

            ValidationResults results = new ValidationResults();

            if (objectToValidate != null)
            {
                results = validator.Validate(objectToValidate);
            }
            else
            {
                results = new ValidationResults();
                results.AddResult(new ValidationResult("Input data object is null.", null, String.Empty, String.Empty, null));
            }

            return results;
        }
    }
}
