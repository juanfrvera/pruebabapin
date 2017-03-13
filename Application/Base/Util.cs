using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using System.Text; 

namespace UI.Web
{
    public class Util
    {
        internal static IQueryable<T> Ordenar<T>(IQueryable<T> resultado, string sortExpression, SortDirection sortDirection)
        {
            var param = Expression.Parameter(typeof(T), "tItem");
            Type type = Expression.Property(param, sortExpression).Type;

            switch (Expression.Property(param, sortExpression).Type.ToString())
            {
                case "System.Int32":
                    {
                        var expresion = Expression.Lambda<Func<T, Int32>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                case "System.Nullable`1[System.Int32]":
                    {
                        var expresion = Expression.Lambda<Func<T, Nullable<Int32>>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                case "System.Int16":
                    {
                        var expresion = Expression.Lambda<Func<T, Int16>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                case "System.Nullable`1[System.Int16]":
                    {
                        var expresion = Expression.Lambda<Func<T, Nullable<Int16>>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                case "System.Byte":
                    {
                        var expresion = Expression.Lambda<Func<T, Byte>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                case "System.Boolean":
                    {
                        var expresion = Expression.Lambda<Func<T, Boolean>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                case "System.DateTime":
                    {
                        var expresion = Expression.Lambda<Func<T, DateTime>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                case "System.Nullable`1[System.DateTime]":
                    {
                        var expresion = Expression.Lambda<Func<T, Nullable<DateTime>>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                case "System.Decimal":
                    {
                        var expresion = Expression.Lambda<Func<T, Decimal>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                case "System.Nullable`1[System.Decimal]":
                    {
                        var expresion = Expression.Lambda<Func<T, Nullable<Decimal>>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
                default:
                    {
                        var expresion = Expression.Lambda<Func<T, Object>>(Expression.Property(param, sortExpression), param);
                        if (sortDirection == SortDirection.Ascending)
                            resultado = resultado.OrderBy(expresion);
                        else
                            resultado = resultado.OrderByDescending(expresion);
                    }
                    break;
            }



            return resultado;

        }

        // Fields
        internal const char DeviceFilterSeparator = ':';
        private static char[] invalidFileNameChars = new char[] { '/', '\\', '?', '*', ':' };
        private static Dictionary<string, bool> s_validCultureNames = null;
        internal const string XmlnsAttribute = "xmlns:";

        internal static string QuoteJScriptString(string value, bool forUrl)
        {
            StringBuilder builder = null;
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            int startIndex = 0;
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                switch (value[i])
                {
                    case '%':
                        {
                            if (!forUrl)
                            {
                                break;
                            }
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 6);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append("%25");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\'':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\'");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\\':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\\");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\t':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\t");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\n':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\n");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\r':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\r");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '"':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append("\\\"");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                }
                count++;
            }
            if (builder == null)
            {
                return value;
            }
            if (count > 0)
            {
                builder.Append(value, startIndex, count);
            }
            return builder.ToString();
        }
        internal static string EnsureEndWithSemiColon(string value)
        {
            if (value != null)
            {
                int length = value.Length;
                if ((length > 0) && (value[length - 1] != ';'))
                {
                    return (value + ";");
                }
            }
            return value;
        }
        internal static string MergeScript(string firstScript, string secondScript)
        {
            if (!string.IsNullOrEmpty(firstScript))
            {
                return (firstScript + secondScript);
            }
            if (secondScript.TrimStart(new char[0]).StartsWith("javascript:", StringComparison.Ordinal))
            {
                return secondScript;
            }
            return ("javascript:" + secondScript);
        }
    }
}
