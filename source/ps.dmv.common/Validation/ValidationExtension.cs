using System;
using System.Linq.Expressions;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace ps.dmv.common.Validation
{
    /// <summary>
    /// ValidationExtension
    /// </summary>
    public static class ValidationExtension
    {
        /// <summary>
        /// Adds the result.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="validationResults">The validation results.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        public static void AddResult<TModel>(this ValidationResults validationResults, Expression<Func<TModel, object>> expression, string message, string tag = null)
        {
            validationResults.AddResult(new ValidationResult(message, null, expression.Body.Type.Name, tag ?? String.Empty, null));
        }
    }
}
