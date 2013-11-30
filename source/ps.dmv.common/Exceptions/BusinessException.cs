using System;

namespace ps.dmv.common.Exceptions
{
    /// <summary>
    /// BusinessException
    /// </summary>
    [Serializable]
    public class BusinessException: Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        /// <param name="businessExceptionType">Type of the business exception.</param>
        /// <param name="message">The message.</param>
        public BusinessException(BusinessExceptionEnum businessExceptionType, string message) : base(message)
        {
            BusinessExceptionType = businessExceptionType;
        }

        /// <summary>
        /// Gets or sets the type of the business exception.
        /// </summary>
        /// <value>
        /// The type of the business exception.
        /// </value>
        public BusinessExceptionEnum BusinessExceptionType { get; set; }
    }
}
