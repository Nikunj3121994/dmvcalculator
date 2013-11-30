using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace ps.dmv.common.Exceptions
{
    /// <summary>
    /// BusinessValidationException
    /// </summary>
    [Serializable]
    public class BusinessValidationException : BusinessException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException"/> class.
        /// </summary>
        /// <param name="validationResultList">The validation result list.</param>
        public BusinessValidationException(ValidationResults validationResultList) : base(BusinessExceptionEnum.Validation, String.Empty)
        {
            this.ValidationResultList = validationResultList;
        }

        /// <summary>
        /// Gets or sets the validation result list.
        /// </summary>
        /// <value>
        /// The validation result list.
        /// </value>
        public ValidationResults ValidationResultList { get; set; }
    }
}
