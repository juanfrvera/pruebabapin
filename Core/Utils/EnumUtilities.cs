using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

namespace Core.Utils
{
    public static class EnumUtilities
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static IList<T> GetValues<T>()
        {
          return GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static IList<object> GetValues(Type enumType)
        {
          if (!enumType.IsEnum)
            throw new ArgumentException("Type '" + enumType.Name + "' is not an enum.");

          List<object> values = new List<object>();

          var fields = from field in enumType.GetFields()
                       where field.IsLiteral
                       select field;

          foreach (FieldInfo field in fields)
          {
            object value = field.GetValue(enumType);
            values.Add(value);
          }

          return values;
        }

        public static IList<string> GetNames<T>()
        {
          return GetNames(typeof(T));
        }

        public static IList<string> GetNames(Type enumType)
        {
          if (!enumType.IsEnum)
            throw new ArgumentException("Type '" + enumType.Name + "' is not an enum.");

          List<string> values = new List<string>();

          var fields = from field in enumType.GetFields()
                       where field.IsLiteral
                       select field;

          foreach (FieldInfo field in fields)
          {
            values.Add(field.Name);
          }

          return values;
        }


        /// <summary>
        /// Gets the maximum valid value of an Enum type. Flags enums are ORed.
        /// </summary>
        /// <typeparam name="TEnumType">The type of the returned value. Must be assignable from the enum's underlying value type.</typeparam>
        /// <param name="enumType">The enum type to get the maximum value for.</param>
        /// <returns></returns>
        public static TEnumType GetMaximumValue<TEnumType>(Type enumType) where TEnumType : IConvertible, IComparable<TEnumType>
        {
          if (enumType == null)
            throw new ArgumentNullException("enumType");

          Type enumUnderlyingType = Enum.GetUnderlyingType(enumType);

          if (!typeof(TEnumType).IsAssignableFrom(enumUnderlyingType))
            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "TEnumType is not assignable from the enum's underlying type of {0}.", enumUnderlyingType.Name));

          ulong maximumValue = 0;
          IList<object> enumValues = GetValues(enumType);

          if (enumType.IsDefined(typeof(FlagsAttribute), false))
          {
            foreach (TEnumType value in enumValues)
            {
              maximumValue = maximumValue | value.ToUInt64(CultureInfo.InvariantCulture);
            }
          }
          else
          {
            foreach (TEnumType value in enumValues)
            {
              ulong tempValue = value.ToUInt64(CultureInfo.InvariantCulture);

              // maximumValue is smaller than the enum value
              if (maximumValue.CompareTo(tempValue) == -1)
                maximumValue = tempValue;
            }
          }

          return (TEnumType)Convert.ChangeType(maximumValue, typeof(TEnumType), CultureInfo.InvariantCulture);
        }
  }
}