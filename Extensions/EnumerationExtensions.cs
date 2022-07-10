using BitheroesBot.Helper;
using System;

namespace BitheroesBot.Extensions
{
    public static class EnumerationExtensions
    {
        public static T Add<T>(this System.Enum type, T value)
        {
            return InvocationHelper.ExecuteWithIgnoreException<T>(() =>
            {
                return (T)(object)(((int)(object)type | (int)(object)value));
            });
        }

        //public static string DescriptionAttr<T>(this T source)
        //{
        //    FieldInfo fi = source.GetType().GetField(source.ToString());

        //    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
        //        typeof(DescriptionAttribute), false);

        //    if (attributes != null && attributes.Length > 0)
        //    {
        //        return attributes[0].Description;
        //    }
        //    else
        //    {
        //        return source.ToString();
        //    }
        //}

        public static bool Has<T>(this System.Enum type, T value)
        {
            return InvocationHelper.ExecuteWithIgnoreException<bool>(() =>
            {
                return (((int)(object)type & (int)(object)value) == (int)(object)value);
            }
                                                                     ,
                () =>
                {
                    return false;
                });
        }



        public static bool Is<T>(this System.Enum type, T value)
        {
            try
            {
                return (int)(object)type == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        public static T Remove<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type & ~(int)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not remove value from enumerated type '{0}'.",
                        typeof(T).Name), ex);
            }
        }

        public static EnumType ToEnum<EnumType>(this String enumValue) where EnumType : struct
        {
            EnumType myreturn;
            if (System.Enum.TryParse<EnumType>(enumValue, out myreturn))
            {
                return myreturn;
            }
            return default(EnumType);
        }

        public static String ToStringFromEnum(this System.Enum eff)
        {
            return System.Enum.GetName(eff.GetType(), eff);
        }
    }
}
