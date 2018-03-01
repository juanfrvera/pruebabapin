using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Resources;
using System.Globalization;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Data.Linq;
using iTextSharp.text;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.IO.Compression;
//using System.Windows.Forms;


namespace Contract
{
    public class DataColumnMapping
    {
        public DataColumnMapping(string title, string name) : this(title, name, "{0}") { }
        public DataColumnMapping(string title, string name, string format)
        {
            this.Title = title;
            this.Name = name;
            this.Format = format;
        }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
    }
    public class DataTableMapping
    {
        public DataTableMapping(string title, List<DataColumnMapping> columns)
        {
            this.Title = title;
            this.Columns = columns;
        }

        public string Title { get; set; }

        private List<DataColumnMapping> columns;
        public List<DataColumnMapping> Columns
        {
            get
            {
                if (columns == null) columns = new List<DataColumnMapping>();
                return columns;
            }
            set { columns = value; }
        }
    }
    public static class Compressor
    {
        public static byte[] Compress(byte[] data)
        {
            MemoryStream output = new MemoryStream();
            GZipStream gzip = new GZipStream(output,
                              CompressionMode.Compress, true);
            gzip.Write(data, 0, data.Length);
            gzip.Close();
            return output.ToArray();
        }

        public static byte[] Decompress(byte[] data)
        {
            MemoryStream input = new MemoryStream();
            input.Write(data, 0, data.Length);
            input.Position = 0;
            GZipStream gzip = new GZipStream(input,
                              CompressionMode.Decompress, true);
            MemoryStream output = new MemoryStream();
            byte[] buff = new byte[64];
            int read = -1;
            read = gzip.Read(buff, 0, buff.Length);
            while (read > 0)
            {
                output.Write(buff, 0, read);
                read = gzip.Read(buff, 0, buff.Length);
            }
            gzip.Close();
            return output.ToArray();
        }
    }
    public class RangeValue<TType>
    {
        public TType From { get; set; }
        public TType To { get; set; }
    }
    public class IntRangeValue : RangeValue<int> { }
    public class IntNullableRangeValue : RangeValue<int?> { }
    public class DateTimeRangeValue : RangeValue<DateTime> { }
    public class DateTimeNullableRangeValue : RangeValue<DateTime?> { }

    public delegate bool TryParseDelegate<T>(string s, out T result);
    public class ValidationException : Exception
    {
        public int ErrorCode { get; set; }
        public string MessageCode { get; set; }
        public string[] MessageParameters { get; set; }

        public ValidationException(string messageCode, params string[] messageParameters)
            : base(messageCode)
        {

            this.MessageCode = messageCode;
               this.MessageParameters = messageParameters;
        }
        public ValidationException(string messageCode)
            : base(messageCode)
        {
            this.MessageCode = messageCode;
        }

        public ValidationException(string messageCode, int errorCode)
            : base(messageCode)
        {
            this.MessageCode = messageCode;
            this.ErrorCode = errorCode;
        }

        public ValidationException() : base() { }
        public ValidationException(string message, Exception innerException) : base(message, innerException) { }
        public ValidationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public class EqualityComparer<T> : IEqualityComparer<T>
    {
        public EqualityComparer(Func<T, T, Boolean> pEqualityComparerMethod)
        {
            EqualityComparerMethod = pEqualityComparerMethod;
        }

        public Func<T, T, Boolean> EqualityComparerMethod { get; set; }

        #region IEqualityComparer<T> Members

        public bool Equals(T x, T y)
        {
            return EqualityComparerMethod(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }

    public sealed class DataHelper
    {
        #region Expresion Regular

        #region info
        //http://www.idg.es/pcworld/Expresiones-regulares/art175601.htm
        //http://www.dubasdey.com/2007/05/21/expresiones-regulares/
        #endregion

        public const string EXPREG_CODE = @"^[0-9\.]{1,50}$";
        public const string EXPREG_NUMBER_INTEGER = @"^[0-9\-]{1,20}$";
        public const string EXPREG_NUMBER_INTEGER_NULLABLE = @"^[0-9\-]{1,20}$";
        public const string EXPREG_NUMBER_INTEGER_NULLABLE_WITH_MILES = @"^\d{1,3}.(\d{3}.)*\d{3}$";
        
        // Uso el caracter 'N' para hacer un replace por que format {0} me trajo problemas con format
        public const string EXPREG_NUMBER_DECIMAL_NULLABLE = @"^\d*[0-9](|.\d{0,N}|,\d{0,N})?$";
        
        public const string EXPREG_NUMBER = @"^[0-9\.\,\-]{1,20}$";
        public const string EXPREG_NUMBER_NULLABLE = @"^[0-9\.\,\-]{1,20}$";
        public const string EXPREG_STRING = @"^([\w\W\d\s\@])([^<>]){{1,{0}}}$";
        //public const string EXPREG_STRING = @"^[a-zA-Z0-9_ñÑñÑáéíóúÁÉÍÓÚ\ \-\$\,\.\:\;\%]{{1,{0}}}$";
        public const string EXPREG_STRING_NULLABLE = @"^([\w\W\d\s\@])([^<>]){{0,{0}}}$";
        public const string EXPREG_EMAIL = @"/[\w-\.]{3,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/";
        public const string EXPREG_URL = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)( [a-zA-Z0-9\-\.\?\,\’\/\\\+&%\$#_]*)?$";
        public const string EXPREG_PASSWORD_SECURE = @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$";
        public const string EXPREG_DATE_ARG = @"^\d{2}/\d{2}/d{4}$";
        public const string EXPREG_HOUR = @"^(0[1-9]|1\d|2[0-3]):([0-5]\d):([0-5]\d)$";
        public const string EXPREG_CREADIT_CARD = @"^((67\d{2})|(4\d{3})|(5[1-5]\d{2})|(6011))(-?\s?\d{4}){3}|(3[4,7])\ d{2}-?\s?\d{6}-?\s?\d{5}$";
        public const string EXPREG_TELHEFONE = @"^[0-9]{2,3}-? ?[0-9]{6,7}$";
        public const string EXPREG_ZIP_CODE = @"^([1-9]{2}|[0-9][1-9]|[1-9][0-9])[0-9]{3}$";
        public const string EXPREG_CERTIFICADO_IDENTIFICACION_FISCAL = @"^(X(-|\.)?0?\d{7}(-|\.)?[A-Z]|[A-Z](-|\.)?\d{7}(-|\.)? [0-9A-Z]|\d{8}(-|\.)?[A-Z])$";


        static Regex regex = new Regex(GetExpRegNumber());
        public static bool IsCode(string value)
        {
            return regex.IsMatch(value);
        }
        public static string GetExpRegNumber()
        {
            return EXPREG_NUMBER;
        }
        public static string GetExpRegCode()
        {
            return EXPREG_CODE;
        }
        public static string GetExpRegString(int lenght)
        {
            return string.Format(EXPREG_STRING, lenght);
        }
        public static string GetExpRegNumberNullable()
        {
            return EXPREG_NUMBER_NULLABLE;
        }
        public static string GetExpRegNumberInteger()
        {
            return EXPREG_NUMBER_INTEGER;
        }
        public static string GetExpRegNumberIntegerNullable()
        {
            return EXPREG_NUMBER_INTEGER_NULLABLE;
        }

        public static string GetExpRegNumberIntegerNullableWithMiles()
        {
            return EXPREG_NUMBER_INTEGER_NULLABLE_WITH_MILES;
        }

        public static string GetExpRegStringNullable(int lenght)
        {
            return string.Format(EXPREG_STRING_NULLABLE, lenght);
        }
        
        public static string GetExpRegDecimalNullable(int decimales)
        {
            return EXPREG_NUMBER_DECIMAL_NULLABLE.Replace("N", decimales.ToString());
        }

        #endregion

        public static string CutString(object value, int length)
        {
            if (value == null) return "";
            return CutString(value.ToString(), length);
        }
        public static string CutString(string value, int length)
        {
            if (value == null) return value;
            if (value.Length > length) return value.Substring(0, length - 3) + "...";
            return value;
        }

        #region Converts
        public static string ImageToBase64(System.Drawing.Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        public static System.Drawing.Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);
            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        public static string BytesToString(byte[] value)
        {
            return Convert.ToBase64String(value);
        }
        public static byte[] StringToBytes(string value)
        {
            return Convert.FromBase64String(value);
        }
        public static Binary StringToBinary(string value)
        {
            byte[] buffer = StringToBytes(value);
            return new Binary(buffer);
        }
        public static string BinaryToString(Binary value)
        {
            return BytesToString(value.ToArray());
        }
        #endregion

        #region Validate
        public static void Validate(bool condition, string errorMessage)
        {
            //tener en cuenta que el validar espera un false para ser efectivo el error, 
            //por ende debo preguntar por lo que espero que sea correcto
            if (!condition)
                throw new ValidationException(errorMessage);

        }

        public static void Validate(bool condition, string errorMessage, int code)
        {
            //tener en cuenta que el validar espera un false para ser efectivo el error, 
            //por ende debo preguntar por lo que espero que sea correcto
            if (!condition)
                throw new ValidationException(errorMessage, code);

        }

        public static void Validate(bool condition, string errorCode, params string[] parameters)
        {
            if (!condition)
                throw new ValidationException(errorCode, parameters);
        }

        public static void ValidateForeignKey(bool condition, string errorCode, params string[] parameters)
        {
            if (condition)
                throw new ValidationException(errorCode, parameters);
        }

        #endregion

        public static List<T> ToList<S, T>(List<S> source)
            where S : class, new()
            where T : class, new()
        {
            List<T> list = new List<T>(source.Count);
            foreach (S item in source)
                list.Add(item as T);
            return list;
        }
        public static List<T> GetList<T>(List<SerializableEntity<T>> listSerializable) where T : class, new()
        {
            List<T> list = new List<T>(listSerializable.Count);
            foreach (SerializableEntity<T> sitem in listSerializable)
                list.Add(sitem.Entity);
            return list;
        }
        public static T[] PartialArray<T>(T[] array, int from, int to)
        {
            int newLength = to - from;
            T[] newArray = new T[newLength + 1];
            for (int i = 0; i <= newLength; i++)
                newArray[i] = array[i + from];
            return newArray;
        }
        public static T[] ExcludeArrayIndexes<T>(T[] array, params int[] indexes)
        {
            T[] newArray = new T[array.Length - indexes.Length];
            int excludeCount = 0;
            List<int> listIndex = new List<int>(indexes);
            for (int i = 0, count = array.Length; i < count; i++)
            {
                if (listIndex.Contains(i))
                {
                    excludeCount++;
                    continue;
                }
                newArray[i - excludeCount] = array[i];
            }
            return newArray;
        }

        public static void Write<T>(Stream stream, List<T> list, DataTableMapping mapping, ReportEnum reportEnum) where T : class, new()
        {
            DataTable dataTable = ToDataTable<T>(list, mapping);
            Write(stream, dataTable, ReportEnum.Excel);
        }
        public static void Write(Stream stream, DataTable dataSource, ReportEnum reportEnum)
        {
            using (Writer writer = WriterManager.Get(reportEnum, stream))
            {
                writer.Write(dataSource);
            }
            if (stream.CanWrite)
                stream.Flush();
        }

        public static Stream WriteTemplate<T>(Stream stream, List<T> list, DataTableMapping mapping, ReportEnum reportEnum) where T : class, new()
        {
            DataTable dataTable = ToDataTable<T>(list, mapping);
            return WriteTemplate(stream, dataTable, ReportEnum.Excel);
        }
        public static Stream WriteTemplate(Stream stream, DataTable dataSource, ReportEnum reportEnum)
        {
            WriterEXCELTemplate writer = new WriterEXCELTemplate(stream);
            return writer.Write(dataSource);
        }
        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
        
        #region IsEmpty
        public static bool IsEmpty(int field)
        {
            if (field != default(int)) return false;
            return true;
        }
        public static bool IsEmpty(string field)
        {
            if (field != string.Empty) return false;
            return true;
        }
        public static bool IsEmpty(DateTime field)
        {
            if (field != default(DateTime)) return false;
            return true;
        }
        public static bool IsEmpty(DateTime? field)
        {
            if (field.HasValue) return IsEmpty(field.Value);
            return true;
        }
        public static bool IsEmpty(int? field)
        {
            if (field.HasValue) return IsEmpty(field.Value);
            return true;
        }
        public static bool IsEmpty(IList field)
        {
            if (field != null) return false;
            return true;
        }

        #endregion
        public static float ColumnSize(DataColumn column)
        {
            switch (column.DataType.FullName)
            {
                case "System.Decimal":
                case "System.Int32":
                case "System.DataTime":
                    return 60;
                case "System.Boolean":
                    return 30;
                case "System.Object":
                case "System.String":
                    return 100;
                default: return 100;
            }
        }



        #region Gets


        public static int GetIntOrDefault(int? value)
        {
            return value.HasValue ? value.Value : 0;
        }
        public static decimal GetDecimalOrDefault(decimal? value)
        {
            return value.HasValue ? value.Value : 0;
        }
        public static IList GetList(DataTable dataTable)
        {
            List<DataRow> list = new List<DataRow>();
            foreach (DataRow row in dataTable.Rows)
                list.Add(row);
            return list;
        }
        public static bool IsLanguageType(Type type)
        {
            if (type.IsPrimitive) return true;
            switch (type.FullName)
            {
                //case "System.DateTime":
                case "System.String":
                    return true;
            }
            return false;
        }
        //public static DataTable GetDataTable(Result result)
        //{
        //    DataTable dataTable = new DataTable();
        //    dataTable.TableName = result.Name;
        //    foreach (Column column in result.Columns)
        //        dataTable.Columns.Add(column.Name, GetType(column.ColumnType));

        //    for (int i = 0, count = result.Count; i < count; i++)
        //        dataTable.Rows.Add(result[i]);

        //    return dataTable;
        //}
        //public static Result GetResult(DataSet dataSet)
        //{           
        //    return GetResult(dataSet,1, -1);;
        //}
        //public static Result GetResult(DataSet dataSet, int pageNumber, int pageSize)
        //{
        //    Result result = new Result();
        //    DataTable dataTable=null;
        //    int allRows=0;
        //    if (dataSet.Tables.Count > 1)
        //    {
        //        dataTable = dataSet.Tables[1];
        //        if (dataSet.Tables[0].Rows.Count > 0)
        //            allRows = Int32.Parse(dataSet.Tables[0].Rows[0][0].ToString());
        //    }
        //    else if (dataSet.Tables.Count == 1)
        //    {
        //        dataTable = dataSet.Tables[0];
        //        allRows = dataTable.Rows.Count;
        //    }
        //    if (dataTable!=null)
        //        return GetResult(dataTable, allRows, pageNumber, pageSize);
        //    return null;
        //}
        //public static Result GetResult(DataTable dataTable)
        //{
        //    return GetResult(dataTable, dataTable.Rows.Count, 1, -1);
        //}
        //public static Result GetResult(DataTable dataTable,int allRows,int pageNumber, int pageSize)
        //{
        //   Result result = new Result();
        //   result.Name = dataTable.TableName; 
        //   int columnsCount = dataTable.Columns.Count;
        //   for (int i = 0; i < columnsCount; i++)
        //   {
        //        DataColumn c= dataTable.Columns[i];
        //        result.Columns.Add(new Column(c.ColumnName,i,GetColumnType(c.DataType),(decimal)c.MaxLength,c.AllowDBNull));
        //   }
        //   for (int i = 0, count = dataTable.Rows.Count; i < count; i++)
        //   {
        //       object[] row = new object[columnsCount];
        //       for (int j = 0; j < columnsCount; j++)
        //             row[j]=dataTable.Rows[i][j];

        //       result.Rows.Add(row);              
        //   }
        //   //carga los datos de paginado
        //   if (dataTable.Rows.Count > 0)
        //   {
        //       result.AllRowsCount = allRows;
        //       result.PageNumber = pageNumber;
        //       result.PageSize = pageSize < 0 ? allRows : pageSize;
        //   }
        //   else
        //   {
        //       result.AllRowsCount = 0;
        //       result.PageNumber = 1;
        //       result.PageSize = pageSize < 0 ? 20: pageSize;
        //   }
        //   return result;
        //}
        #endregion

        #region Serialization
        public static byte[] ToArrByte(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return buffer;
        }
        public static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }
        public static Byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }
        public static string SerializeObject<T>(T obj)
        {
            return SerializeObject(typeof(T), obj);
        }
        public static string SerializeObject(Type type,object obj)
        {
            string xmlString = null;
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(type);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            xs.Serialize(xmlTextWriter, obj);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            xmlString = UTF8ByteArrayToString(memoryStream.ToArray());
            return xmlString;
        }
        public static T DeserializeObject<T>(string xml)
        {
            return (T)DeserializeObject(typeof(T),xml);
        }
        public static object DeserializeObject(Type type,string xml)
        {
            XmlSerializer xs = new XmlSerializer(type);
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return xs.Deserialize(memoryStream);
        }
        public static string XmlSerialize<T>(T obj)
        {
            string xmlString = null;
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(T));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            xs.Serialize(xmlTextWriter, obj);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            xmlString = UTF8ByteArrayToString(memoryStream.ToArray());
            return xmlString;
        }
        public T XmlDeserializeFomFile<T>(string path)
        {
            return XmlDeserialize<T>(File.Open(path, FileMode.Open));
        }
        public static T XmlDeserialize<T>(Stream stream)
        {
            string xml = "";
            using (TextReader tr = new StreamReader(stream))
                xml = tr.ReadToEnd();
            return XmlDeserialize<T>(xml);
        }
        public static T XmlDeserialize<T>(string xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return (T)xs.Deserialize(memoryStream);
        }
        #endregion

        #region Sin Ordenar (Anteriores)
        public static string AjustarLongitud(string comentario, int length)
        {
            string resultado = String.Empty, linea = String.Empty;
            string[] stringArray = comentario.Split(' ');

            if (comentario.Length <= length)
                return comentario;
            else
                foreach (var s in stringArray)
                {
                    string sf = s.Trim();

                    if ((sf.Length + linea.Length) > length)
                    {
                        resultado += linea + Environment.NewLine;
                        linea = String.Empty;
                    }

                    linea += sf + ' ';
                }

            resultado += linea.Trim();

            return resultado;
        }
        public static Int32? ConvertirEntero(string entero)
        {
            return EsEntero(entero) ? (Int32?)Convert.ToInt32(entero) : null;
        }
        public static DateTime? ConvertirFecha(string fecha)
        {
            return EsFecha(fecha) ? (DateTime?)Convert.ToDateTime(fecha) : null;
        }
        public static List<T> StringEnumToList<T>(String str)
        {
            var lista = new List<T>();
            foreach (string s in str.Split(','))
                lista.Add((T)Enum.Parse(typeof(T), s));

            return lista;
        }
        public static List<Int32> StringIntToList(String str, bool todos)
        {
            var lista = new List<Int32>();
            foreach (var s in str.Split(','))
                lista.Add(Convert.ToInt32(s));

            if (lista.Contains(0) && !todos) return new List<int>();

            return lista;
        }
        public static String ListToString<T>(List<T> lista)
        {
            String respuesta = String.Empty;
            foreach (T o in lista)
                respuesta += o + ",";
            return respuesta.Length == 0 ? String.Empty : respuesta.Substring(0, respuesta.Length - 1);
        }
        public static DateTime? FechaCortaNullable(string fechaCorta)
        {
            if (fechaCorta.Length < 5 || fechaCorta.IndexOf('/') < 0)
                return null;

            DateTime fecha;
            bool ok = DateTime.TryParse("1/" + fechaCorta.Substring(5) + "/" + fechaCorta.Substring(0, 4), out fecha);

            if (!ok) return null;

            return fecha;
        }
        public static DateTime ObtenerUltimoDiaMesSiguiente(DateTime fecha)
        {
            DateTime rta = new DateTime(fecha.Year, fecha.Month + 1, DateTime.DaysInMonth(fecha.Year, fecha.Month + 1));
            return rta;
        }
        #endregion

        #region Validations
        public static Boolean EsDecimal(String valor)
        {
            decimal result;
            bool ok = Decimal.TryParse(valor, out result);

            return ok;
        }
        public static Decimal EsDecimal(String valor, Decimal valorAlternativo)
        {
            decimal result;
            bool ok = Decimal.TryParse(valor, out result);

            if (ok)
                return Convert.ToDecimal(valor);

            return valorAlternativo;
        }
        public static Boolean EsEntero(String valor)
        {
            Int32 result;
            bool ok = Int32.TryParse(valor, out result);

            return ok;
        }
        public static Boolean EsFecha(String valor)
        {
            DateTime result;
            bool ok = DateTime.TryParse(valor, out result);

            return ok;
        }
        public static DateTime EsFecha(String valor, DateTime valorAlternativo)
        {
            DateTime result;
            bool ok = DateTime.TryParse(valor, out result);

            if (ok)
                return Convert.ToDateTime(valor);

            return valorAlternativo;
        }
        #endregion Validations

        public static int GetInt(object value)
        {
            return GetInt(value.ToString());
        }
        public static int GetInt(string value)
        {
            int r;
            if (int.TryParse(value, out r))
                return r;
            return 0;
        }
        public static int TryParseList<T, S>(S[] source, out List<T> target, TryParseDelegate<T> tryParse) where T : struct
        {
            return TryParseList<T, S>(new List<S>(source), out target, tryParse);
        }
        public static int TryParseList<T, S>(List<S> source, out List<T> target, TryParseDelegate<T> tryParse) where T : struct
        {
            string str;
            int count = 0;
            target = new List<T>();
            foreach (S s in source)
            {
                str = s.ToString();
                if (string.IsNullOrEmpty(str))
                {
                    target = null;
                    return -1;
                }
                else
                {
                    T temp;
                    if (tryParse(str, out temp))
                    {
                        target.Add(temp);
                        count++;
                    }
                }
            }
            return count;
        }
        public static bool TryParseNullable<T>(string s, out Nullable<T> result, TryParseDelegate<T> tryParse) where T : struct
        {
            if (string.IsNullOrEmpty(s))
            {
                result = null;
                return false;
            }
            else
            {
                T temp;
                if (tryParse(s, out temp))
                {
                    result = temp;
                    return true;
                }
                result = null;
                return false;
            }
        }
        public static bool TryParseNullableDateTime(string s, out DateTime? result)
        {
            return TryParseNullable<DateTime>(s, out result, DateTime.TryParse);
        }
        public static bool TryParseNullableBoolean(string s, out bool? result)
        {
            return TryParseNullable<bool>(s, out result, bool.TryParse);
        }

        public static T CopyEntity<T>(T entity) where T : class, new()
        {
            T copy = new T();
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo p in props)
            {
                MethodInfo m = p.GetSetMethod();
                if (m == null)
                    continue;
                p.SetValue(copy, p.GetValue(entity, null), null);
            }
            return copy;
        }
        public static bool CompareEntity<T>(T entity, T compareEntity) where T : class
        {
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo p in props)
            {
                MethodInfo m = p.GetSetMethod();
                if (m == null)
                    continue;
                //p.SetValue(copy, p.GetValue(entity, null), null);
            }
            return true;
        }
        
        #region ToDataTable
        public static DataTable ToDataTable<T>(List<T> source, DataTableMapping dataTableMapping) where T : class, new()
        {
            DataTable dataTabe = new DataTable(dataTableMapping.Title);
            T row = new T();
            Type tyepEntity = row.GetType();
            Dictionary<string, PropertyInfo> propertiesInfo = new Dictionary<string, PropertyInfo>();

            foreach (DataColumnMapping dataColumnMapping in dataTableMapping.Columns)
            {
                DataColumn dc=null;
                PropertyInfo propertyInfo = tyepEntity.GetProperty(dataColumnMapping.Name);
                if (propertyInfo == null) continue;

                if (IsLanguageType(propertyInfo.PropertyType) ) 
                   dc = new DataColumn(dataColumnMapping.Title, propertyInfo.PropertyType); 
                else
                    dc = new DataColumn(dataColumnMapping.Title, typeof(string));
                dataTabe.Columns.Add(dc);
                propertiesInfo.Add(propertyInfo.Name, propertyInfo);
            }
            foreach (T entity in source)
            {
                DataRow dataRow = dataTabe.NewRow();
                foreach (DataColumnMapping dataColumnMapping in dataTableMapping.Columns)
                {
                    if (propertiesInfo.ContainsKey(dataColumnMapping.Name))
                    {
                        if (dataColumnMapping.Format != string.Empty)
                        {
                            if (dataColumnMapping.Format == "HtmlToPlainText")
                            {
                                object html = propertiesInfo[dataColumnMapping.Name].GetValue(entity, null);
                                dataRow[dataColumnMapping.Title] = html!=null?HtmlToPlainText(html.ToString()):"";                         
                            }
                            else 
                            {
                               dataRow[dataColumnMapping.Title] = string.Format(dataColumnMapping.Format, propertiesInfo[dataColumnMapping.Name].GetValue(entity, null));
                            }
                        }
                        else
                        {
                            dataRow[dataColumnMapping.Title] = propertiesInfo[dataColumnMapping.Name].GetValue(entity, null);
                        }
                     }
                }
                dataTabe.Rows.Add(dataRow);
            }
            return dataTabe;
        }
        public static DataTable ToDataTable<T>(List<T> source, string tableName) where T : class, new()
        {
            DataTable dataTabe = new DataTable(tableName);
            T row = new T();
            Type tyepEntity = row.GetType();
            Dictionary<string, PropertyInfo> propertiesInfo = new Dictionary<string, PropertyInfo>();

            foreach (PropertyInfo propertyInfo in tyepEntity.GetProperties())
            {
                if (!IsLanguageType(propertyInfo.PropertyType)) continue;
                dataTabe.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
                propertiesInfo.Add(propertyInfo.Name, propertyInfo);
            }
            foreach (T entity in source)
            {
                DataRow dataRow = dataTabe.NewRow();
                foreach (DataColumn dataColumn in dataTabe.Columns)
                    dataRow[dataColumn] = propertiesInfo[dataColumn.ColumnName].GetValue(entity, null);
                dataTabe.Rows.Add(dataRow);
            }
            return dataTabe;
        }
        #endregion



        

        public static string HtmlToPlainText(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                return result;
            }
            catch
            {
                return source;
            }
        }
            
    }
}
