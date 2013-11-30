using Microsoft.Practices.EnterpriseLibrary.Validation;
using ps.dmv.common.Core;
using ps.dmv.common.Exceptions;
using ps.dmv.common.Validation;

namespace ps.dmv.domain.application.Core
{
    /// <summary>
    /// ManagerBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ManagerBase<T>
    {
        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ps.dmv.common.Exceptions.BusinessValidationException"></exception>
        protected void Validate(T entity)
        {
            IValidationProvider validator = ServiceLocator.Instance.Resolve<IValidationProvider>();

            ValidationResults validationResults = new ValidationResults();

            ValidationResults validationResultsEntity = validator.Validate(entity);
            validationResults.AddAllResults(validationResultsEntity);

            ValidationResults validationResultsSpecial = ValidateSpecial(entity);
            validationResults.AddAllResults(validationResultsSpecial);

            if (!validationResults.IsValid)
            {
                throw new BusinessValidationException(validationResults);
            }
        }

        /// <summary>
        /// Validates the special.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        protected virtual ValidationResults ValidateSpecial(T entity)
        {
            return new ValidationResults();
        }
    }
}
