using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps.dmv.common.Helpers
{
    /// <summary>
    /// EnumHelper
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// Gets the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="enumValue">The enum value.</param>
        /// <returns></returns>
        public static TEnum GetEnumValue<TEnum>(string enumValue)
        {
            return (TEnum) Enum.Parse(typeof (TEnum), enumValue);
        }
    }
}
