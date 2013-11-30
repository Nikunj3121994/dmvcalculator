using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace ps.dmv.common.Validation
{
    /// <summary>
    /// IValidationProvider
    /// </summary>
    public interface IValidationProvider
    {
        /// <summary>
        /// Validates the specified object to validate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <returns></returns>
        ValidationResults Validate<T>(T objectToValidate);
    }
}
