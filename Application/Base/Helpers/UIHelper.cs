using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Reflection;
using Contract;
using System.Data.SqlClient;
using Ingematica.Librerias.Helpers;
using System.IO;
using Service;
using System.Web.Security;
using System.Data;
using System.Collections;
using Application.Controls;

namespace UI.Web
{
    public class ReverseIntCompare : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            return x == y ? 0 : x > y ? -1 : 1;
        }
    }

    public class CompareProperties<T> : Comparer<T> where T : class, new()
    {
        private Dictionary<string, PropertyInfo> propertyInfo;
        private SortDirection _Direction = SortDirection.Ascending;

        public SortDirection Direction { get { return _Direction; } set { _Direction = value; } }

        public List<string> PropertyNames { get; set; }
        public Dictionary<string, PropertyInfo> PropertyInfo
        {
            get
            {
                if (propertyInfo == null)
                {
                    propertyInfo = new Dictionary<string, PropertyInfo>();
                    T item = new T();
                    foreach (string property in PropertyNames)
                    {
                        PropertyInfo pInfo = (from f in item.GetType().GetProperties()
                                              where f.Name == property
                                              select f).FirstOrDefault();
                        propertyInfo.Add(property, pInfo);
                    }
                }
                return propertyInfo;
            }
            set { propertyInfo = value; }
        }
        public override int Compare(T x, T y)
        {
            int Dir = (_Direction == SortDirection.Ascending) ? 1 : -1;
            if (x == null) return -1 * Dir;
            if (y == null) return 1 * Dir;
            foreach (string property in PropertyNames)
            {
                object sx = PropertyInfo[property].GetValue(x, null);
                object sy = PropertyInfo[property].GetValue(y, null);
                if (sx == null) return -1 * Dir;
                if (sy == null) return 1 * Dir;
                int PropertyResult = 0;
                if (sx is Int16 || sx is Int32 || sx is Int64 || sx is Decimal || sx is Single || sx is Double)
                {
                    double nx = double.Parse(sx.ToString());
                    double ny = double.Parse(sy.ToString());
                    PropertyResult = ((nx == ny) ? 0 : (nx > ny) ? 1 : -1) * Dir;
                }
                else if (sx is DateTime)
                {
                    DateTime dx = DateTime.Parse(sx.ToString());
                    DateTime dy = DateTime.Parse(sy.ToString());
                    PropertyResult = ((dx == dy) ? 0 : (dx > dy) ? 1 : -1) * Dir;
                }
                else
                {
                    PropertyResult = String.Compare(sx.ToString(), sy.ToString(), true) * Dir;
                }
                if (PropertyResult != 0)
                {
                    return PropertyResult;
                }
            }
            return 0;
        }
    }
    public class CompareProperty<T> : Comparer<T> where T : class, new()
    {
        private PropertyInfo propertyInfo;
        private SortDirection _Direction = SortDirection.Ascending;

        public SortDirection Direction { get { return _Direction; } set { _Direction = value; } }
        public string PropertyName { get; set; }
        public PropertyInfo PropertyInfo
        {
            get
            {
                if (propertyInfo == null)
                {
                    T item = new T();
                    propertyInfo = (from f in item.GetType().GetProperties()
                                    where f.Name == PropertyName
                                    select f).FirstOrDefault();
                }
                return propertyInfo;
            }
            set { propertyInfo = value; }
        }
        public override int Compare(T x, T y)
        {
            int Dir = (_Direction == SortDirection.Ascending) ? 1 : -1;
            if (x == null) return -1 * Dir;
            if (y == null) return 1 * Dir;
            object sx = PropertyInfo.GetValue(x, null);
            object sy = PropertyInfo.GetValue(y, null);
            if (sx == null) return -1 * Dir;
            if (sy == null) return 1 * Dir;
            int PropertyResult = 0;
            if (sx is Int16 || sx is Int32 || sx is Int64 || sx is Decimal || sx is Single || sx is Double)
            {
                double nx = double.Parse(sx.ToString());
                double ny = double.Parse(sy.ToString());
                PropertyResult = ((nx == ny) ? 0 : (nx > ny) ? 1 : -1) * Dir;
            }
            else if (sx is DateTime)
            {
                DateTime dx = DateTime.Parse(sx.ToString());
                DateTime dy = DateTime.Parse(sy.ToString());
                PropertyResult = ((dx == dy) ? 0 : (dx > dy) ? 1 : -1) * Dir;
            }
            else
            {
                PropertyResult = String.Compare(sx.ToString(), sy.ToString(), true) * Dir;
            }
            return PropertyResult;
        }
    }
    public class CompareStringProperty<T> : Comparer<T> where T : class, new()
    {
        private PropertyInfo propertyInfo;

        public string PropertyName { get; set; }
        public PropertyInfo PropertyInfo
        {
            get
            {
                if (propertyInfo == null)
                {
                    T item = new T();
                    propertyInfo = (from f in item.GetType().GetProperties()
                                    where f.Name == PropertyName
                                    select f).FirstOrDefault();
                }
                return propertyInfo;
            }
            set { propertyInfo = value; }
        }
        public override int Compare(T x, T y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            object sx = PropertyInfo.GetValue(x, null);
            object sy = PropertyInfo.GetValue(y, null);
            if (sx == null) return -1;
            if (sy == null) return 1;
            return String.Compare(sx.ToString(), sy.ToString(), true);
        }
    }
    public class CompareDateProperty<T> : Comparer<T> where T : class, new()
    {
        private PropertyInfo propertyInfo;

        public string PropertyName { get; set; }
        public PropertyInfo PropertyInfo
        {
            get
            {
                if (propertyInfo == null)
                {
                    T item = new T();
                    propertyInfo = (from f in item.GetType().GetProperties()
                                    where f.Name == PropertyName
                                    select f).FirstOrDefault();
                }
                return propertyInfo;
            }
            set { propertyInfo = value; }
        }
        public override int Compare(T x, T y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            object sx = PropertyInfo.GetValue(x, null);
            object sy = PropertyInfo.GetValue(y, null);
            if (sx == null) return -1;
            if (sy == null) return 1;
            return DateTime.Compare((DateTime)sx, (DateTime)sy);
        }
    }
    public class CompareInt32Property<T> : Comparer<T> where T : class, new()
    {
        private PropertyInfo propertyInfo;

        public string PropertyName { get; set; }
        public PropertyInfo PropertyInfo
        {
            get
            {
                if (propertyInfo == null)
                {
                    T item = new T();
                    propertyInfo = (from f in item.GetType().GetProperties()
                                    where f.Name == PropertyName
                                    select f).FirstOrDefault();
                }
                return propertyInfo;
            }
            set { propertyInfo = value; }
        }
        public override int Compare(T x, T y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            object sx = PropertyInfo.GetValue(x, null);
            object sy = PropertyInfo.GetValue(y, null);
            if (sx == null) return -1;
            if (sy == null) return 1;

            int _x, _y;
            if(int.TryParse(sx.ToString(),out _x) && int.TryParse(sy.ToString(),out _y))
                return _x <= _y ? -1 : 1;
            return 0;            
        }
    }

    public delegate void TryMethodDelegate();
    public delegate void ShowInfoDelegate(string message);
    public delegate void ShowExceptionDelegate(Exception exception);
    public delegate TEntity GetByIdDelegate<TEntity, TIdType>(TIdType id);

    public class UIHelper
    {
        #region General

        public static string PageName
        {
            get { return System.IO.Path.GetFileNameWithoutExtension(System.Web.HttpContext.Current.Request.Url.AbsolutePath); }
        }


        #region Exceptions

        public static void CallTryMethod(TryMethodDelegate method)
        {
            try
            {
                 method();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CallTryMethod(TryMethodDelegate method, ShowInfoDelegate showMethod)
        {
            try
            {
                method();
            }
            catch (Exception ex)
            {
                showMethod(ex.Message);
            }
        }
        public static void CallTryMethod(TryMethodDelegate method, ShowExceptionDelegate showMethod)
        {
            try
            {
                method();
            }
            catch (Exception ex)
            {
                showMethod(ex);
            }
        }
        public static void Validate(bool condition, string errorMessage)
        {
            if (!condition)
                throw new ValidationException(Translate(errorMessage));
        }
        public static void Validate(bool condition, string errorMessage,params object[] parametros)
        {
            if (!condition)
            {
                for(int i= 0, count = parametros.Length;i<count;i++)
                {
                    object parameter  = parametros[i];
                    if(parameter is string) parametros[i] = Translate(parameter as string);                        
                }
                throw new ValidationException(string.Format(Translate(errorMessage),parametros));
            }
        }
        #endregion

        public static object GetDefault(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
        
        public static void Sort<T>(List<T> list, string field) where T : class, new()
        {      
            Sort<T>(list,field, SortDirection.Ascending);
        }
        public static void Sort<T>(List<T> list, string field, SortDirection sortDirection) where T : class, new()
        {
            try
            {                
                CompareStringProperty<T> comparer = new CompareStringProperty<T>();
                comparer.PropertyName = field;
                list.Sort(comparer);
                if (sortDirection == SortDirection.Descending) list.Reverse();
            }
            catch { }
        }
        public static void Sort<T>(List<T> list, string field, SortDirection sortDirection, Type orderType) where T : class, new()
        {
            try
            {                
                if (orderType == Type.GetType("System.Int32"))
                {
                    CompareInt32Property<T> comparer = new CompareInt32Property<T>();
                    comparer.PropertyName = field;
                    list.Sort(comparer);
                    if (sortDirection == SortDirection.Descending) list.Reverse();
                }
                else if (orderType == Type.GetType("System.DateTime"))
                {
                    CompareDateProperty<T> comparer = new CompareDateProperty<T>();
                    comparer.PropertyName = field;
                    list.Sort(comparer);
                    if (sortDirection == SortDirection.Descending) list.Reverse();
                }
                else
                {
                    CompareStringProperty<T> comparer = new CompareStringProperty<T>();
                    comparer.PropertyName = field;
                    list.Sort(comparer);
                    if (sortDirection == SortDirection.Descending) list.Reverse();
                }                
            }
            catch { }
        }
        public static void Sort<T>(List<T> list, List<string> fields, SortDirection sortDirection) where T : class, new()
        {
            try
            {
                CompareProperties<T> comparer = new CompareProperties<T>();
                comparer.PropertyNames = fields;
                comparer.Direction = sortDirection;
                list.Sort(comparer);
            }
            catch { }
        }
        #endregion

        #region Load
        #region GridView

        public static void Load<T>(GridView control, List<T> dataSource, string fieldOrder) where T : class, new()
        {
            Load<T>(control, dataSource, fieldOrder,SortDirection.Ascending);
        }
        public static void Load<T>(GridView control, List<T> dataSource,string fieldOrder,SortDirection sortDirection) where T : class, new()
        {
            Sort<T>(dataSource, fieldOrder, sortDirection);
            Load<T>(control,dataSource);
        }
        public static void Load<T>(GridView control, List<T> dataSource, string fieldOrder, SortDirection sortDirection, Type orderType) where T : class, new()
        {
            Sort<T>(dataSource, fieldOrder, sortDirection, orderType);
            Load<T>(control, dataSource);
        }
        public static void Load<T>(GridView control, List<T> dataSource) where T : class, new()
        {
            control.DataSource = dataSource;
            control.DataBind();
        }
        public static void Load(GridView control, DataTable dataSource) 
        {
            control.DataSource = dataSource;
            control.DataBind();
        }
        #endregion
        #region DropDownList


        public static void Load<T>(DropDownList control, List<T> dataSource, string display, string value, bool Sort) where T : class, new()
        {
            List<T> othersEntities = new List<T>(0);
            Load<T>(control, dataSource, display, value, othersEntities, Sort);
        }        
        public static void Load<T>(DropDownList control, List<T> dataSource, string display, string value, T otherEntity) where T : class, new()
        {
            List<T> othersEntities = new List<T>(1);
            othersEntities.Add(otherEntity);
            Load<T>(control, dataSource, display, value, othersEntities,true);
        }
        public static void Load<T>(DropDownList control, List<T> dataSource, string display, string value, T otherEntity, bool Sort) where T : class, new()
        {
            List<T> othersEntities = new List<T>(1);
            othersEntities.Add(otherEntity);
            Load<T>(control, dataSource, display, value, othersEntities, Sort);
        }
        public static void Load<T>(DropDownList control, List<T> dataSource, string display, string value, List<T> othersEntities, bool Sort) where T : class, new()
        {
            Load<T>(control, dataSource, display, value, othersEntities, Sort, display);
        }

        public static void Load<T>(DropDownList control, List<T> dataSource, string display, string value, T otherEntity, bool Sort, string OrderField) where T : class, new()
        {
            List<T> othersEntities = new List<T>(1);
            othersEntities.Add(otherEntity);
            Load<T>(control, dataSource, display, value, othersEntities, Sort, OrderField);
        }
        public static void Load<T>(DropDownList control, List<T> dataSource, string display, string value, List<T> othersEntities, bool Sort, string OrderField) where T : class, new()
        {
            
            Load<T>(control, dataSource, display, value, othersEntities, Sort,OrderField , Type.GetType("System.String") );
        }
        public static void Load<T>(DropDownList control, List<T> dataSource, string display, string value, T otherEntity, bool Sort, string OrderField, Type OrderType) where T : class, new()
        {
            List<T> othersEntities = new List<T>(1);
            othersEntities.Add(otherEntity);
            Load<T>(control, dataSource, display, value, othersEntities, Sort, OrderField, OrderType);
        }
        public static void Load<T>(DropDownList control, List<T> dataSource, string display, string value, List<T> othersEntities, bool Sort, string OrderField, Type OrderType) where T : class, new()
        {

            if (dataSource == null || dataSource.Count == 0)
            {
                control.Items.Clear();
                return;
            }
            if (Sort)
                Sort<T>(dataSource, OrderField, SortDirection.Ascending, OrderType);
            if (othersEntities.Count > 0)
            {
                try
                {
                    T defaultEntity = othersEntities[0];
                    PropertyInfo fValue = (from f in defaultEntity.GetType().GetProperties()
                                           where f.Name == value
                                           select f).FirstOrDefault();

                    if (UIContext.Current.HadTranslate)
                    {
                        PropertyInfo fDispplay = (from f in defaultEntity.GetType().GetProperties()
                                                  where f.Name == display
                                                  select f).FirstOrDefault();
                        foreach (T othersEntity in othersEntities)
                        {
                            string text = fDispplay.GetValue(othersEntity, null).ToString();
                            string transaleText = "";

                            foreach (string word in text.Split(' '))
                                if (word != string.Empty) transaleText += Translate(word);

                            if (transaleText != string.Empty)
                                fDispplay.SetValue(othersEntity, text, null);
                        }
                    }
                    List<T> list = new List<T>();
                    list.AddRange(othersEntities);
                    list.AddRange(dataSource);
                    if (Sort)
                        Load(control, (Object)list, display, value);
                    else
                        LoadNotSort(control, list, display, value);
                    UIHelper.SetValue(control, fValue.GetValue(defaultEntity, null));
                }
                catch
                {
                    Load(control, dataSource, display, value);
                }
            }
            else if (Sort)
            {
                Load(control, dataSource, display, value);
            }
            else
            {
                LoadNotSort(control, dataSource, display, value);
            }
        }
        public static void Load<T>(DropDownList control, List<T> dataSource, string dataTextField, string dataValueField)
            where T:class, new()
        {
            Load<T>(control, dataSource, dataTextField, dataValueField, SortDirection.Ascending);
        }
        public static void Load<T>(DropDownList control, List<T> dataSource, string dataTextField, string dataValueField,SortDirection sortDirection)
            where T : class, new()
        {
            Load<T>(control, dataSource, dataTextField, dataValueField, dataTextField, sortDirection);
        }
        public static void Load<T>(DropDownList control, List<T> dataSource, string dataTextField, string dataValueField,string dataSortField,SortDirection sortDirection)
            where T : class, new()
        {
            if (sortDirection == SortDirection.Ascending)
                Sort<T>(dataSource, dataSortField);
            else
            {
                Sort<T>(dataSource, dataSortField);
                dataSource.Reverse();
            }
            //Este tipo de orden fallaba con cuando habia numeros y texto
            //Util.Ordenar<T>(dataSource.AsQueryable(), dataTextField, sortDirection);
            Load(control, (dataSource as object), dataTextField, dataValueField);
        }
        public static void LoadNotSort<T>(DropDownList control, List<T> dataSource, string dataTextField, string dataValueField)
            where T : class, new()
        {
            Load(control, (dataSource as object), dataTextField, dataValueField);
        }
        public static void Load(DropDownList control, object dataSource, string dataTextField, string dataValueField)
        {
            ClearItems(control);
            control.SelectedValue = null;
            control.SelectedIndex = -1;
            control.DataTextField = dataTextField;
            control.DataValueField = dataValueField;
            control.DataSource = dataSource;
            control.DataBind();
        }       
        public static void Load(DropDownList control, Type value)
        {
            control.DataSource = Enum.GetNames(value);
            control.DataBind();
        }
        public static void Load<TKey, TValue>(DropDownList control, List<KeyValuePair<TKey, TValue>> values)
        {
            control.DataTextField = "Key";
            control.DataValueField = "Value";
            control.DataSource = values;
            control.DataBind();
        }




        public static void LoadPaginacion(DropDownList control )
        {
            List<Int32> Paginacion = new List<int>();
            Paginacion.Add(5);
            Paginacion.Add(10);
            Paginacion.Add(15);
            Paginacion.Add(20);
            Paginacion.Add(25);
            Paginacion.Add(30);
            Paginacion.Add(50);
            Paginacion.Add(75);
            Paginacion.Add(100);
            control.DataSource = Paginacion;
            control.DataBind();
            control.SelectedValue = "20";
        }
        #endregion
        #region ListBox
        public static void Load<T>(ListBox control, List<T> dataSource, string dataTextField, string dataValueField)
        {
            Load<T>(control, dataSource, dataTextField, dataValueField, SortDirection.Ascending);
        }
        public static void Load<T>(ListBox control, List<T> dataSource, string dataTextField, string dataValueField, SortDirection sortDirection)
        {
            var SortedDataSource = Util.Ordenar<T>(dataSource.AsQueryable(), dataTextField, sortDirection);
            Load(control, (SortedDataSource as object), dataTextField, dataValueField);
        }
        public static void Load<T>(ListBox control, List<T> dataSource, string dataTextField, string dataValueField, string OrderField, SortDirection sortDirection)
        {
            var SortedDataSource = Util.Ordenar<T>(dataSource.AsQueryable(), OrderField, sortDirection);
            Load(control, (SortedDataSource as object), dataTextField, dataValueField);
        }
        /*public static void Load<T>(ListBox control, List<T> dataSource, string dataTextField, string dataValueField, string OrderField, SortDirection sortDirection) where T : class, new()
        {
            var SortedDataSource = Util.Ordenar<T>(dataSource.AsQueryable(), OrderField, sortDirection);
            Load(control, (SortedDataSource as object), dataTextField, dataValueField);
        }*/
        public static void Load(ListBox control, object dataSource, string dataTextField, string dataValueField)
        {
            control.DataTextField = dataTextField;
            control.DataValueField = dataValueField;
            control.DataSource = dataSource;
            control.DataBind();
        }
        #endregion
        #endregion

        #region Clear
        public static void Clear(TextBox control)
        {
            control.Text = String.Empty;
        }
        public static void Clear(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            control.Text = String.Empty;
        }
        public static void Clear(ITextControl control)
        {
            control.Text = String.Empty;
        }
        public static void Clear(ListBox control)
        {
            if (control.DataSource == null)
            {
                control.Items.Clear();
            }
            else
                control.DataSource = null;
            control.DataBind();
        }
        public static void Clear(DropDownList control)
        {
            if ( control.Items.Count > 0 )
                control.SelectedIndex = 0;            
        }
        public static void Clear(ExtendedDropDownList control)
        {
            if (control.DataInactiveSelected != string.Empty)
            {
                foreach (ListItem item in control.Items)
                {
                    if (item.Value == control.DataInactiveSelected)
                    {
                        control.Items.Remove(item);
                        control.DataInactiveSelected = string.Empty;
                        break;
                    }
                }                
            }
            if ( control.Items.Count > 0 )
                control.SelectedIndex = 0;            
        }

        
        public static void Clear(HtmlGenericControl control)
        {
            control.InnerHtml = "";
        }
        public static void Clear(HtmlInputHidden control)
        {
            control.Value = "";
        }  
        public static void Clear(CheckBox control)
        {
            control.Checked = false;
        }
        public static void Clear(Label control)
        {
            control.Text = String.Empty;
        }
        public static void Clear(HiddenField control)
        {
            control.Value = null;
        }
        public static void Clear(RadioButton control)
        {
            control.Checked = false;
        }
        public static void Clear(GridView control)
        {
            control.DataSource = null;
            control.DataBind();
        }
        public static void Clear(Repeater control)
        {
            control.DataSource = null;
            control.DataBind();
        }
        public static void Clear(UI.Web.WebControl_DateInput control)
        {
            control.Clear ();
        }
        public static void Clear(UI.Web.WebControl_DateRangeInput control)
        {
            control.Clear();
        }
        public static void Clear(UI.Web.WebControl_NumericRangeInput control)
        {
            control.Clear();
        }
        public static void Clear(WebControlAutocomplete<int> control)
        {
            control.ValueId =0;
            control.ValueText = "";
            control.Clear();
        }
        public static void Clear(WebControlAutocomplete<int?> control)
        {
            control.ValueId = null;
            control.ValueText = "";
            control.Clear();
        }


        public static void ClearItems(DropDownList ddl)
        {
            ddl.Items.Clear();
        }

        public static void Clear(WebControl_Autocomplete control)
        {
            control.Clear();
        }
        public static void Clear(WebControl_ThreeStatesCheckbox control)
        {
            control.CheckedValue = null;
        }
        internal static void Clear(WebControl_TwoPartsNumber tpnNumero)
        {
            tpnNumero.Clear();
        }
        internal static void Clear(WebControlHourInput  hiControl)
        {
            hiControl.Clear();
        }
        internal static void Clear(WebControlHourInput2 hiControl)
        {
            hiControl.Clear();
        }
        public static void Clear(IWebControlTreeSelect control)
        {
            control.Clear();
        }
        public static void Clear(IWebControlAutocompleteSimple control)
        {
            control.Clear();
        }

        #region DataList
        public static void Clear(DataList control)
        {
            control.DataSource = null;
            control.DataBind();
        }
        #endregion

        #endregion

        #region GetValue

        #region DropDownList
        public static T GetEntity<T>(DropDownList control) where T : class
        {
            return control.SelectedItem as T;
        }
        public static string GetString(DropDownList control)
        {
            if (control.SelectedItem != null)
                return control.SelectedItem.Text.Trim();
            else
            {
                return String.Empty;
            }
        }
        public static object GetObject(DropDownList control)
        {
            return control.SelectedItem;
        }
        public static int GetInt(DropDownList control)
        {
            int _value;
            if (control.SelectedIndex > -1 && int.TryParse(control.SelectedValue.ToString(), out _value))
                return _value;
            return 0;
        }
        public static int? GetIntNullable(DropDownList control)
        {
            int _value;
            if (control.SelectedIndex > -1 && int.TryParse(control.SelectedValue.ToString(), out _value))
                if (_value > 0) return _value;
            return null;
        }

        public static byte GetByte(DropDownList control)
        {
            byte _value;
            if (control.SelectedIndex > -1 && byte.TryParse(control.SelectedValue.ToString(), out _value))
                return _value;
            return 0;
        }
        public static byte? GetByteNullable(DropDownList control)
        {
            byte _value;
            if (control.SelectedIndex > -1 && byte.TryParse(control.SelectedValue.ToString(), out _value))
                return _value;
            return null;
        }
        public static short GetShort(DropDownList control)
        {
            short _value;
            if (control.SelectedIndex > -1 && short.TryParse(control.SelectedValue.ToString(), out _value))
                return _value;
            return 0;
        }
        public static short? GetShortNullable(DropDownList control)
        {
            short _value;
            if (control.SelectedIndex > -1 && short.TryParse(control.SelectedValue.ToString(), out _value))
                return _value;
            return null;
        }

        public static bool GetBoolean(DropDownList control)
        {
            if (control.SelectedIndex > -1 && control.SelectedValue.ToString() == "Y")
                return true;
            return false;
        }
        public static decimal GetDecimal(DropDownList control)
        {
            decimal _value;
            if (control.SelectedIndex > -1 && decimal.TryParse(control.SelectedValue.ToString(), out _value))
                return _value;
            return 0;
        }
        public static bool? GetBooleanNullable(DropDownList control)
        {
            if (control.SelectedIndex > -1 && control.SelectedValue.ToString() == "Y")
                return true;
            else if (control.SelectedIndex > -1 && control.SelectedValue.ToString() == "N")
                return false;
            else
                return null;
        }
        #endregion

        #region ListBox
        public static T GetEntity<T>(ListBox control) where T : class
        {
            return control.SelectedItem as T;
        }
        public static List<string> GetSelectedValues(ListBox control)
        {
            List<string> list = new List<string>();
            foreach (System.Web.UI.WebControls.ListItem li in control.Items)
                if (li.Selected) list.Add(li.Value);
            return list;
        }
        public static List<int> GetSelectedIntValues(ListBox control)
        {
            List<int> list = new List<int>();
            int value;
            foreach (System.Web.UI.WebControls.ListItem li in control.Items)
            {
                if (li.Selected)
                   if(int.TryParse(li.Value,out value))
                       list.Add(value);
                
            }
            return list;
        }
        public static List<string> GetSelectedTexts(ListBox control)
        {
            List<string> list = new List<string>();
            foreach (System.Web.UI.WebControls.ListItem li in control.Items)
                if (li.Selected) list.Add(li.Text);
            return list;
        }
        public static string GetString(ListBox control)
        {
            return control.SelectedItem.Text.Trim();
        }
        public static short GetShort(ListBox control)
        {
            short _value;
            if (control.SelectedIndex > -1 && short.TryParse(control.SelectedValue.ToString(), out _value))
                return _value;
            return 0;
        }
        public static short? GetShortNullable(ListBox control)
        {
            short _value;
            if (control.SelectedIndex > -1 && short.TryParse(control.SelectedValue.ToString(), out _value))
                return _value;
            return null;
        }
        public static List<T> GetSelectedItems<T>(ListBox control) where T : class
        {
            List<T> list = new List<T>();
            foreach (var selected in control.Items)
            {
                if (((System.Web.UI.WebControls.ListItem)selected).Selected)
                {
                    T entity = selected as T;
                    if (entity != null)
                        list.Add(entity);
                }
            }
            return list;
        }
        #endregion

        #region HtmlEditor
        public static string GetString(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            return control.Text.Trim();
        }
        public static string GetStringFilter(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            return control.Text.Trim()+"%";
        }
        public static DateTime GetDateTime(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            DateTime value;
            if (DateTime.TryParse(control.Text, out value))
                return value;
            return DateTime.Now;
        }
        public static DateTime? GetDateTimeNullable(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            DateTime value;
            if (control.Text == string.Empty || !(DateTime.TryParse(control.Text, out value)))
                return null;
            return value;
        }
        public static String GetDateTimeString(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            DateTime value;
            if (control.Text == string.Empty || !(DateTime.TryParse(control.Text, out value)))
                return null;
            return value.ToShortDateString();
        }
        public static int GetInt(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            int _value;
            if (int.TryParse(control.Text, out _value))
                return _value;
            return 0;
        }
        public static int? GetIntNullable(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            int _value;
            if (int.TryParse(control.Text.ToString(), out _value) && control.Text != String.Empty)
                return _value;
            return null;
        }
        public static short GetShort(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            short _value;
            if (short.TryParse(control.Text, out _value))
                return _value;
            return 0;
        }
        public static short? GetShortNullable(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            short _value;
            if (short.TryParse(control.Text.ToString(), out _value) && control.Text != String.Empty)
                return _value;
            return null;
        }
        public static decimal GetDecimal(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            return GetDecimal(control, true);
        }
        public static decimal GetDecimal(Winthusiasm.HtmlEditor.HtmlEditor control, bool defaultFormat)
        {
            decimal _value;
            if (decimal.TryParse(control.Text, out _value))
                return _value;
            return 0;
        }
        public static decimal? GetDecimalNullable(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            decimal _value;
            if (decimal.TryParse(control.Text, out _value))
                return _value;
            return null;
        }
        public static bool GetBoolean(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            if (control.Text.Trim() == "Y")
                return true;
            return false;
        }
        public static bool? GetBooleanNullable(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            if (control.Text.Trim() == "Y")
                return true;
            return false;
        }
        public static object GetObject(Winthusiasm.HtmlEditor.HtmlEditor control)
        {
            return control.Text;
        }
        #endregion

        #region TextBox
        public static string GetString(TextBox control)
        {
            return control.Text.Trim();
        }
        public static string GetStringNullable(TextBox control)
        {
            if (control.Text != string.Empty)
                return control.Text.Trim();
            else
                return null;
        }
        public static string GetStringFilter(TextBox control)
        {
            return control.Text.Trim()+"%";
        }
        public static string GetStringBetweenFilter(TextBox control)
        {
            if(control.Text !=null &&  control.Text.Trim() != string.Empty)
              return "%"+control.Text.Trim() + "%";
            return control.Text.Trim();
        }
        public static DateTime GetDateTime(TextBox control)
        {
            DateTime value;
            if (DateTime.TryParse(control.Text, out value))
                return value;
            DateTime date = DateTime.Now;
            return new DateTime(date.Year, date.Month, date.Day);
        }
        public static DateTime? GetDateTimeNullable(TextBox control)
        {
            DateTime value;
            if (control.Text == string.Empty || !(DateTime.TryParse(control.Text, out value)))
                return null;
            return value;
        }
        public static String GetDateTimeString(TextBox control)
        {
            DateTime value;
            if (control.Text == string.Empty || !(DateTime.TryParse(control.Text, out value)))
                return null;
            return value.ToShortDateString();
        }
        public static int GetInt(TextBox control)
        {
            decimal _value;
            if (decimal.TryParse(control.Text, out _value))
                return (int)_value;
            return 0;
        }
        public static int GetInt(Label control)
        {
            int _value;
            if (int.TryParse(control.Text, out _value))
                return _value;
            return 0;
        }
        public static int? GetIntNullable(TextBox control)
        {
            int _value;
            if (int.TryParse(control.Text.ToString(), out _value) && control.Text != String.Empty)
                return _value;
            return null;
        }
        public static short GetShort(TextBox control)
        {
            short _value;
            if (short.TryParse(control.Text, out _value))
                return _value;
            return 0;
        }
        public static short? GetShortNullable(TextBox control)
        {
            short _value;
            if (short.TryParse(control.Text.ToString(), out _value) && control.Text != String.Empty)
                return _value;
            return null;
        }
        public static decimal GetDecimal(TextBox control)
        {
            return GetDecimal(control, true);
        }
        public static decimal GetDecimal(TextBox control, bool defaultFormat)
        {
            decimal _value;
            if (decimal.TryParse(control.Text, out _value))
                return _value;
            return 0;
        }
        public static decimal GetDecimal(Label control)
        {            
            return GetDecimal(control,true);
        }
        public static decimal GetDecimal(Label control,bool defaultFormat)
        {
            decimal _value;
            if (decimal.TryParse(control.Text, out _value))
                return _value;

            return 0;
        }
        public static decimal? GetDecimalNullable(TextBox control)
        {
            decimal _value;
            if (decimal.TryParse(control.Text, out _value))
                return _value;
            return null;
        }
        public static decimal? GetDecimalNullable(Label control)
        {
            decimal _value;
            if (decimal.TryParse(control.Text, out _value))
                return _value;
            return null;
        }
        public static bool GetBoolean(TextBox control)
        {
            if (control.Text.Trim() == "Y")
                return true;
            return false;
        }
        public static bool? GetBooleanNullable(TextBox control)
        {
            if (control.Text.Trim() == "Y")
                return true;
            return false;
        }
        public static object GetObject(TextBox control)
        {
            return control.Text;
        }
        #endregion

        #region HiddenField
        public static string GetString(HiddenField control)
        {
            return control.Value.Trim();
        }
        public static string GetStringFilter(HiddenField control)
        {
            return control.Value.Trim() + "%";
        }
        public static DateTime GetDateTime(HiddenField control)
        {
            DateTime value;
            if (DateTime.TryParse(control.Value, out value))
                return value;
            return DateTime.Now;
        }
        public static DateTime? GetDateTimeNullable(HiddenField control)
        {
            DateTime value;
            if (control.Value == string.Empty || !(DateTime.TryParse(control.Value, out value)))
                return null;
            return value;
        }
        public static String GetDateTimeString(HiddenField control)
        {
            DateTime value;
            if (control.Value == string.Empty || !(DateTime.TryParse(control.Value, out value)))
                return null;
            return value.ToShortDateString();
        }
        public static int GetInt(HiddenField control)
        {
            int _value;
            if (int.TryParse(control.Value, out _value))
                return _value;
            return 0;
        }
        public static int? GetIntNullable(HiddenField control)
        {
            int _value;
            if (int.TryParse(control.Value.ToString(), out _value) && control.Value != String.Empty)
                return _value;
            return null;
        }
        public static short GetShort(HiddenField control)
        {
            short _value;
            if (short.TryParse(control.Value, out _value))
                return _value;
            return 0;
        }
        public static short? GetShortNullable(HiddenField control)
        {
            short _value;
            if (short.TryParse(control.Value.ToString(), out _value) && control.Value != String.Empty)
                return _value;
            return null;
        }
        public static decimal GetDecimal(HiddenField control)
        {
            return GetDecimal(control, true);
        }
        public static decimal GetDecimal(HiddenField control, bool defaultFormat)
        {
            decimal _value;
            if (decimal.TryParse(control.Value, out _value))
                return _value;
            return 0;
        }
        public static decimal? GetDecimalNullable(HiddenField control)
        {
            decimal _value;
            if (decimal.TryParse(control.Value, out _value))
                return _value;
            return null;
        }
        public static bool GetBoolean(HiddenField control)
        {
            if (control.Value.Trim() == "Y")
                return true;
            return false;
        }
        public static bool? GetBooleanNullable(HiddenField control)
        {
            if (control.Value.Trim() == "Y")
                return true;
            return false;
        }
        public static object GetObject(HiddenField control)
        {
            return control.Value;
        }
        #endregion

        #region ITextControl
        public static string GetString(ITextControl control)
        {
            return control.Text.Trim();
        }
        #endregion

        #region CheckBox
        public static string GetString(CheckBox control)
        {
            return control.Checked.ToString();
        }
        public static object GetObject(CheckBox control)
        {
            return control.Checked;
        }
        public static int GetInt(CheckBox control)
        {
            if (control.Checked)
                return 1;
            return 0;
        }
        public static short GetShort(CheckBox control)
        {
            if (control.Checked)
                return 1;
            return 0;
        }
        public static bool GetBoolean(CheckBox control)
        {
            return control.Checked;
        }
        public static bool? GetBooleanNullable(CheckBox control)
        {
            return control.Checked;
        }

        #endregion

        #region RadioButton
        public static bool GetBoolean(RadioButton control)
        {
            return control.Checked;
        }
        public static bool? GetBooleanNullable(RadioButton control)
        {
            return control.Checked;
        }
        /// <summary>
        /// Se utiliza en caso que se tengan 3 controles, El primero es el que define si es true, el segundo false, el tercero null. 
        /// Ejemplo: Pendientes  S/N/Todos
        /// </summary>
        /// <param name="control"></param>
        /// <param name="control2"></param>
        /// <param name="control3"></param>
        /// <returns></returns>
        public static bool? GetBooleanNullable(RadioButton control, RadioButton control2, RadioButton control3)
        {
            if (control.Checked) return true;
            if (control2.Checked) return false;
            return null;
            
        }

        #endregion
                
        #region WebControl_DateInput
        public static DateTime? GetDateTimeNullable(UI.Web.WebControl_DateInput  control)
        {
            if (control.Fecha <= DateTime.MinValue) return null;
            return control.Fecha;
        }
        public static DateTime GetDateTime(UI.Web.WebControl_DateInput control)
        {
            DateTime date = SystemConfig.MinValeDateTime;
            if (control.Fecha.HasValue)
            {
                if (control.Fecha.Value < SystemConfig.MinValeDateTime) return new DateTime(date.Year , date.Month , date.Day  )  ;
                return control.Fecha.Value;
            }
            return new DateTime(date.Year, date.Month, date.Day );
        }
        public static DateTime? GetFromDateTimeNullable(UI.Web.WebControl_DateInput control)
        {
            DateTime? value = control.Fecha;
            if (value.HasValue)
            {
                if (value <= DateTime.MinValue) return null;
                value = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, 0, 0, 1);
            }
            return value;
        }
        public static DateTime? GetToDateTimeNullable(UI.Web.WebControl_DateInput control)
        {
            DateTime? value = control.Fecha;
            if (value.HasValue)
            {
                if (value <= DateTime.MinValue) return null;
                value = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, 23, 59, 59);
            }
            return value;
        }
        #endregion
        
        #region WebControl_DateInput
        public static DateTime? GetDateTimeNullable(UI.Web.WebControlHourInput2 controlHour, UI.Web.WebControl_DateInput controlDate)
        {
            if (!controlDate.Fecha.HasValue && !controlHour.Date.HasValue)
                return null;

            DateTime date = controlDate.Fecha.HasValue?controlDate.Fecha.Value:DateTime.Now;
            DateTime hour = controlHour.Date.HasValue?controlHour.Date.Value: new DateTime(2000,1,1,12,1,1);

            return new DateTime(date.Year, date.Month, date.Day, hour.Hour, hour.Minute, hour.Second);
        }       
        public static DateTime? GetTimeNullable(UI.Web.WebControlHourInput2 control)
        {
            return control.Date;            
        }    
        #endregion
        
        #region RangeValue<TType>
        public static RangeValue<TType> GetRangeValue<TType>(WebControlRangeInput<TType> control)
        {
            return control.Value;  
        }
        public static TType GetValueFrom<TType>(WebControlRangeInput<TType> control)
        {
            return control.ValueFrom;
        }
        public static TType GetValueTo<TType>(WebControlRangeInput<TType> control)
        {
            return control.ValueTo;
        }
        public static DateTime? GetValueFromDate(WebControlRangeInput<DateTime?> control)
        {
            DateTime? value= control.ValueFrom;
            if (value.HasValue)
               value=new DateTime(value.Value.Year,value.Value.Month,value.Value.Day,0,0,0);
            return value;
        }
        public static DateTime? GetValueToDate(WebControlRangeInput<DateTime?> control)
        {
            DateTime? value = control.ValueTo;
            if (value.HasValue)
                value = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, 23, 59, 59);
            return value;
        }

        #endregion

        #region WebControlAutocomplete<TIdType>
        
        public static int GetInt(WebControlAutocomplete<int> control)
        {
            return control.ValueId;
        }
        public static int GetInt(WebControlAutocomplete<int?> control)
        {
            if (!control.ValueId.HasValue) return 0;
            return control.ValueId.Value;
        }
        public static TIdType GetValue<TIdType>(WebControlAutocomplete<TIdType> control)
        {
            return control.ValueId;  
        }
        public static string GetString<TIdType>(WebControlAutocomplete<TIdType> control)
        {
            return control.ValueText;
        }
        public static string GetString(WebControl_Autocomplete control)
        {
            return control.ValueText;
        }
        public static string GetStringBetweenFilter(WebControl_Autocomplete control)
        {
            return "%" + control.ValueText + "%";
        }
        public static int? GetIntNullable(WebControl_Autocomplete control)
        {
            return control.ValueId;
        }
        #endregion

        #region WebControl_ThreeStatesCheckbox
        public static bool? GetBooleanNullable(WebControl_ThreeStatesCheckbox control)
        {
            return control.CheckedValue;
        }
        public static bool GetBoolean(WebControl_ThreeStatesCheckbox control)
        {
            if (!control.CheckedValue.HasValue) return false;
            return control.CheckedValue.Value;
        }
        #endregion

        #region WebControl_TwoPartsNumber
        internal static string GetString(WebControl_TwoPartsNumber tpnNumero)
        {
            return tpnNumero.Value;
        }
        #endregion

        #region WebControl_TreeSelect
        public static NodeResult GetNodeResult(IWebControlTreeSelect control)
        {
            return control.Value;
        }
        public static int GetInt(IWebControlTreeSelect control)
        {
            return control.ValueId.HasValue?control.ValueId.Value:0;
        }
        public static int? GetIntNullable(IWebControlTreeSelect control)
        {
            return control.ValueId;
        }
        public static string GetString(IWebControlTreeSelect control)
        {
            if (control.ValueId.HasValue)
                return control.Value.Text.Trim();
            else
            {
                return String.Empty;
            }
        }
        #endregion

        #region WebControlAutocompleteSimple
        public static SimpleIntResult GetSimpleResult(IWebControlAutocompleteSimple control)
        {
            return control.Value;
        }
        public static int GetInt(IWebControlAutocompleteSimple control)
        {
            return control.ValueId.HasValue?control.ValueId.Value:0;
        }
        public static int? GetIntNullable(IWebControlAutocompleteSimple control)
        {
            return control.ValueId;
        }
        public static string GetString(IWebControlAutocompleteSimple control)
        {
            if (control.ValueId.HasValue)
                return control.Value.Text.Trim();
            else
            {
                return String.Empty;
            }
        }
        #endregion
        
        #region FileUpload
        public static string GetString(FileUpload fileuploadcontrol)
        {
            return  DataHelper.BytesToString(fileuploadcontrol.FileBytes);
        }
        public static Stream GetStream(FileUpload fileuploadcontrol)
        {
            return fileuploadcontrol.FileContent;
        }
        public static Byte[] GetBytes(FileUpload fileuploadcontrol)
        {
            return fileuploadcontrol.FileBytes;
        }
        #endregion       

        #endregion

        #region SetValue

        #region Label
        public static void SetValue(Label control, string value)
        {
            control.Text = value != null ? value.Trim() : "";
        }
        public static void SetValue(Label control, char value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Label control, char? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Label control, int value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Label control, int? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Label control, decimal value)
        {
            SetValue(control, value, true);
        }
        public static void SetValue(Label control, decimal value,bool defaultFormatDecimal)
        {
            if(defaultFormatDecimal)
                control.Text = CultureHelper.DecimalToString(value, SystemConfig.FORMATO_DECIMAL, SystemConfig.SeparadorComa).ToString();
            else
              control.Text = value.ToString();
        }
        public static void SetValue(Label control, decimal value,Predicate<decimal> conditionHide)
        {
            if(conditionHide(value))
                control.Text = "";
            else
                control.Text = value.ToString();
        }
        public static void SetValue(Label control, decimal value, string format)
        {
            control.Text = value.ToString(format);
        }
        public static void SetValue(Label control, decimal? value)
        {
            if (value.HasValue)
                SetValue(control, value.Value);
            else
                control.Text = "";
        }
        public static void SetValue(Label control, byte value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Label control, byte? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Label control, bool value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Label control, bool? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Label control, short value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Label control, short? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Label control, DateTime value)
        {
            control.Text = value.ToString(SystemConfig.DateTimeFormat);
        }
        public static void SetValue(Label control, DateTime? value)
        {
            control.Text = value.HasValue ? ((DateTime)value).ToString(SystemConfig.DateTimeFormat) : "";
        }
        #endregion
        
        #region HtmlEditor
        public static void SetValueFilter(Winthusiasm.HtmlEditor.HtmlEditor control, string value)
        {
            control.Text = value != null ?  (value.Trim().EndsWith("%")?value.Trim().TrimEnd('%'):value.Trim()) : "";
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, string value)
        {
            control.Text = value != null ? value.Trim() : "";
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, char value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, char? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, int value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, int? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, int? value, bool IncludeZero)
        {
            if (IncludeZero)
                SetValue(control, value);
            else
                control.Text = value.HasValue ? (value.Value != 0 ? value.Value.ToString() : "") : "";
        }

        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, decimal value)
        {
            SetValue(control, value, true);            
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, decimal value, bool defaultFormatDecimal)
        {
            if (defaultFormatDecimal)
                control.Text = CultureHelper.DecimalToString(value, SystemConfig.FORMATO_DECIMAL, SystemConfig.SeparadorComa).ToString();
            else
                control.Text = value.ToString();
        }

        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, decimal? value)
        {            
            if (value.HasValue)
                SetValue(control, value.Value);
            else
                control.Text = "";
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, byte value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, byte? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, bool value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, bool? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, short value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, short? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, DateTime value)
        {
            control.Text = string.Format("{0:dd/MM/yyyy)",value);
        }
        public static void SetValue(Winthusiasm.HtmlEditor.HtmlEditor control, DateTime? value)
        {
            control.Text = value.HasValue ? value.Value.ToString () : "";
        }
        #endregion
        
        #region TextBox
        public static void SetValueFilter(TextBox control, string value)
        {
            //control.Text = value != null ?  (value.Trim().EndsWith("%")?value.Trim().TrimEnd('%'):value.Trim()) : "";
            if (value == null) value = "";
            else
            {
                if (value.Trim().EndsWith("%")) value = value.Trim().TrimEnd('%');
                if (value.Trim().StartsWith("%")) value = value.Trim().TrimStart('%');
            }
            control.Text = value.Trim();
        }
        public static void SetValueBetweenFilter(TextBox control, string value)
        {
            if (value == null) value = "";
            else
            {
                if (value.Trim().EndsWith("%")) value = value.Trim().TrimEnd('%');
                if (value.Trim().StartsWith("%")) value = value.Trim().TrimStart('%');
            }
            control.Text = value.Trim();
        }
        public static void SetValue(TextBox control, string value)
        {
            control.Text = value != null ? value.Trim() : "";
        }
        public static void SetValue(TextBox control, char value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(TextBox control, char? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(TextBox control, int value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(TextBox control, int? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(TextBox control, int? value, bool IncludeZero)
        {
            if (IncludeZero)
                SetValue(control, value);
            else
                control.Text = value.HasValue ? (value.Value != 0 ? value.Value.ToString() : "") : "";
        }

        public static void SetValue(TextBox control, decimal value)
        {
            SetValue(control, value, true);            
        }
        public static void SetValue(TextBox control, decimal value, bool defaultFormatDecimal)
        {
            if (defaultFormatDecimal)
                control.Text = CultureHelper.DecimalToString(value, SystemConfig.FORMATO_DECIMAL, SystemConfig.SeparadorComa).ToString();
            else
                control.Text = value.ToString();
        }
        public static void SetValue(TextBox control, decimal? value, bool defaultFormatDecimal)
        {
            decimal _value = value.HasValue ? value.Value : 0;
            if (defaultFormatDecimal)
                control.Text = CultureHelper.DecimalToString(_value, SystemConfig.FORMATO_DECIMAL, SystemConfig.SeparadorComa).ToString();
            else
                control.Text = _value.ToString();
        }

        public static void SetValue(TextBox control, decimal? value)
        {            
            if (value.HasValue)
                SetValue(control, value.Value);
            else
                control.Text = "";
        }

        public static void SetValue(TextBox control, byte value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(TextBox control, byte? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(TextBox control, bool value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(TextBox control, bool? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(TextBox control, short value)
        {
            control.Text = value.ToString();
        }
        public static void SetValue(TextBox control, short? value)
        {
            control.Text = value.HasValue ? value.Value.ToString() : "";
        }
        public static void SetValue(TextBox control, DateTime value)
        {
            control.Text = string.Format("{0:dd/MM/yyyy)",value);
        }
        public static void SetValue(TextBox control, DateTime? value)
        {
            control.Text = value.HasValue ? value.Value.ToString () : "";
        }


        /// <summary>
        /// Setea el ValueText
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        public static void SetValue(WebControl_Autocomplete control, String value)
        {
            control.ValueText = value;
        
        }
        /// <summary>
        /// Setea el ValueText
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        public static void SetValue(WebControl_Autocomplete control, Int32 value)
        {
            control.ValueId  = value;

        }

        #endregion

        #region Literal
        public static void SetValue(Literal control, string value)
        {
            control.Text = value;
        }
        #endregion

        #region HiddenField
        public static void SetValue(HiddenField control, string value)
        {
            control.Value = value;
        }
        public static void SetValue(HiddenField control, int value)
        {
            control.Value = value.ToString();
        }
        public static void SetValue(HiddenField control, short value)
        {
            control.Value = value.ToString();
        }
        #endregion
        
        #region ListControl
        public static void SetValue(ListControl control, object value)
        {
            if (value != null)
            {
                for (int i = 0, count = control.Items.Count; i < count; i++)
                {
                    if (control.Items[i].Value == value.ToString())
                    {
                        control.SelectedIndex = i;
                        return;
                    }
                }
                //control.SelectedValue = value.ToString();
            }
            control.SelectedIndex = -1;
        }
        public static void SetValue(ListControl control, string value)
        {
            if (value != null)
                control.SelectedValue = value;
            else
                control.SelectedIndex = -1;
        }
        public static void SetValue(ListBox control,List<int> values)
        {
            foreach (int value in values)
            {
                control.Items.FindByValue(value.ToString()).Selected = true;
            }
        }
        public static void SetValue(ListBox control, string[] values)
        {
            foreach (string value in values)
                control.Items.FindByValue(value).Selected = true;
        }
        public static void SetValue(ListControl control, char value)
        {
           control.SelectedValue = value.ToString();
        }
        public static void SetValue(ListControl control, char? value)
        {
            if (value.HasValue)
                control.SelectedValue = value.Value.ToString();
            else
                control.SelectedIndex = -1;
        }
        public static void SetValue(ListControl control, int value)
        {
            control.SelectedValue = value.ToString();
        }
        public static void SetValue(ListControl control, int? value)
        {
            if (value.HasValue)
                try
                {
                    control.SelectedValue = value.Value.ToString();
                }
                catch
                {
                    control.SelectedIndex = -1;
                }
            else
                control.SelectedIndex = -1;
        }
        public static void SetValue(ListControl control, decimal value)
        {
            if (control.Items.FindByValue(value.ToString()) != null)
                control.SelectedValue = value.ToString();
            else
                control.SelectedIndex = -1;
        }
        public static void SetValue(ListControl control, decimal? value)
        {
            if (value.HasValue)
                SetValue(control,value.Value);
            else
                control.SelectedIndex = -1;
        }
        public static void SetValue(ListControl control, byte value)
        {
            control.SelectedValue = value.ToString();
        }
        public static void SetValue(ListControl control, byte? value)
        {
            if (value.HasValue)
                control.SelectedValue = value.Value.ToString();
            else
                control.SelectedIndex = -1;
        }
        public static void SetValue(ListControl control, bool value)
        {
            control.SelectedValue = value.ToString();
        }
        public static void SetValue(ListControl control, bool? value)
        {
            if (value.HasValue)
                control.SelectedValue = value.Value.ToString();
            else
                control.SelectedIndex = -1;
        }
        public static void SetValue(ListControl control, short value)
        {
            control.SelectedValue = value.ToString();
        }
        public static void SetValue(ListControl control, short? value)
        {
            if (value.HasValue)
                control.SelectedValue = value.Value.ToString();
            else
                control.SelectedIndex = -1;
        }
        //#region ComboBox
        //public static void SetValue(ComboBox control, string value)
        //{
        //    if (value != null)
        //        control.SelectedValue = value;
        //    else
        //        control.SelectedIndex = -1;
        //}
        //public static void SetValue(ComboBox control, char value)
        //{
        //    if (value != null)
        //        control.SelectedValue = value;
        //    else
        //        control.SelectedIndex = -1;
        //}
        //public static void SetValue(ComboBox control, char? value)
        //{
        //    if (value.HasValue)
        //        control.SelectedValue = value.Value;
        //    else
        //        control.SelectedIndex = -1;
        //}
        //public static void SetValue(ComboBox control, int value)
        //{
        //     control.SelectedValue = value;
        //}
        //public static void SetValue(ComboBox control, int? value)
        //{
        //    if (value.HasValue)
        //        control.SelectedValue = value.Value;
        //    else
        //        control.SelectedIndex = -1;
        //}
        //public static void SetValue(ComboBox control, decimal value)
        //{
        //    control.SelectedValue = value;
        //}
        //public static void SetValue(ComboBox control, decimal? value)
        //{
        //    if (value.HasValue)
        //        control.SelectedValue = value.Value;
        //    else
        //        control.SelectedIndex = -1;
        //}
        //public static void SetValue(ComboBox control, byte value)
        //{
        //    control.SelectedValue = value;
        //}
        //public static void SetValue(ComboBox control, byte? value)
        //{
        //    if (value.HasValue)
        //        control.SelectedValue = value.Value;
        //    else
        //        control.SelectedIndex = -1;
        //}
        //public static void SetValue(ComboBox control, bool value)
        //{
        //    control.SelectedValue = value;
        //}
        //public static void SetValue(ComboBox control, bool? value)
        //{
        //    if (value.HasValue)
        //        control.SelectedValue = value.Value;
        //    else
        //        control.SelectedIndex = -1;
        //}
        //public static void SetValue(ComboBox control, short value)
        //{
        //    control.SelectedValue = value;
        //}
        //public static void SetValue(ComboBox control, short? value)
        //{
        //    if (value.HasValue)
        //        control.SelectedValue = value.Value;
        //    else
        //        control.SelectedIndex = -1;
        //}
        //#endregion
        #endregion

        #region CheckBox
        public static void SetValue(CheckBox control, string value)
        {
            if (value != null)
                control.Checked = value == "Y" ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(CheckBox control, char value)
        {
            if (value != null)
                control.Checked = value == 'Y' ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(CheckBox control, char? value)
        {
            if (value.HasValue)
                control.Checked = value.Value == 'Y' ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(CheckBox control, int value)
        {
            control.Checked = value != 0 ? true : false;
        }
        public static void SetValue(CheckBox control, int? value)
        {
            if (value.HasValue)
                control.Checked = value.Value != 0 ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(CheckBox control, decimal value)
        {
            control.Checked = value != 0 ? true : false;
        }
        public static void SetValue(CheckBox control, decimal? value)
        {
            if (value.HasValue)
                control.Checked = value.Value != 0 ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(CheckBox control, byte value)
        {
            control.Checked = value != 0 ? true : false;
        }
        public static void SetValue(CheckBox control, byte? value)
        {
            if (value.HasValue)
                control.Checked = value.Value != 0 ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(CheckBox control, bool value)
        {
            control.Checked = value;
        }
        public static void SetValue(CheckBox control, bool? value)
        {
            if (value.HasValue)
                control.Checked = value.Value;
            else
                control.Checked = false;
        }
        public static void SetValue(CheckBox control, short value)
        {
            control.Checked = value != 0 ? true : false;
        }
        public static void SetValue(CheckBox control, short? value)
        {
            if (value.HasValue)
                control.Checked = value.Value != 0 ? true : false;
            else
                control.Checked = false;
        }
        #endregion

        #region RadioButton
        public static void SetValue(RadioButton control, string value)
        {
            if (value != null)
                control.Checked = value == "Y" ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(RadioButton control, char value)
        {
            control.Checked = value == 'Y' ? true : false;
        }
        public static void SetValue(RadioButton control, char? value)
        {
            if (value.HasValue)
                control.Checked = value.Value == 'Y' ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(RadioButton control, int value)
        {
            control.Checked = value != 0 ? true : false;
        }
        public static void SetValue(RadioButton control, int? value)
        {
            if (value.HasValue)
                control.Checked = value.Value != 0 ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(RadioButton control, decimal value)
        {
            control.Checked = value != 0 ? true : false;
        }
        public static void SetValue(RadioButton control, decimal? value)
        {
            if (value.HasValue)
                control.Checked = value.Value != 0 ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(RadioButton control, byte value)
        {
            control.Checked = value != 0 ? true : false;
        }
        public static void SetValue(RadioButton control, byte? value)
        {
            if (value.HasValue)
                control.Checked = value.Value != 0 ? true : false;
            else
                control.Checked = false;
        }
        public static void SetValue(RadioButton control, bool value)
        {
            control.Checked = value;
        }
        public static void SetValue(RadioButton control, bool? value)
        {
            if (value.HasValue)
                control.Checked = value.Value;
            else
                control.Checked = false;
        }
        public static void SetValue(RadioButton control, short value)
        {
            control.Checked = value != 0 ? true : false;
        }
        public static void SetValue(RadioButton control, short? value)
        {
            if (value.HasValue)
                control.Checked = value.Value != 0 ? true : false;
            else
                control.Checked = false;
        }



        #endregion

        #region DropDownList

        public static void SetValue(DropDownList control, short value)
        {
            try
            {
                control.SelectedValue = value.ToString();
            }
            catch (Exception)
            {
                control.SelectedIndex = 0;
            }            
        }
        public static void SetValue(DropDownList control, int value)
        {
            try
            {
                control.SelectedValue = value.ToString();
            }
            catch (Exception)
            {
                control.SelectedIndex = 0;
            }
        }
        
        #endregion

        #region ExtendedDropDownList
        public static void SetValue<TEntity, TIdType>(ExtendedDropDownList control, TIdType id, GetByIdDelegate<TEntity, TIdType> MethodGetById)
            where TIdType : IComparable
        {
            SetValue(control, id);
            if (control.SelectedIndex < 0 && !id.Equals(default(TIdType)))
            {
                TEntity entity = MethodGetById(id);
                if (entity != null)
                {
                    string textValue = GetTextValue<TEntity>(control, entity);
                    control.Items.Add(new ListItem(textValue, id.ToString()));
                    SetValue(control, id);
                    control.DataInactiveSelected = id.ToString();
                }
            }
        }
        public static string GetTextValue<TEntity>(DropDownList control, TEntity entity)
        {
            PropertyInfo fValue = (from f in entity.GetType().GetProperties()
                                   where f.Name == control.DataTextField
                                   select f).FirstOrDefault();
            if (fValue == null ) return null;
            object o = fValue.GetValue(entity, null);
            if (o == null) return null;
            return o.ToString();
        }
        #endregion

        #region Repeater
        public static void SetValue(Repeater control, object value)
        {
            control.DataSource = value;
            control.DataBind();
        }
        #endregion

        #region DataList
        public static void SetValue(DataList control, object value)
        {
            control.DataSource = value;
            control.DataBind();
        }
        #endregion

        #region HtmlInputHidden
        public static void SetValue(HtmlInputHidden control, string value)
        {
            control.Value = value;
        }
        #endregion

        #region HtmlGenericControl
        public static void SetValue(HtmlGenericControl control, string value)
        {
            control.InnerHtml = value;
        }
        #endregion

        #region Grilla

        public static void SetSelectedHtmlInputDataKeys<T>(GridView grid, string controlName, T[] ListaKeys) where T : IComparable
        {
            foreach (GridViewRow row in grid.Rows)
            {
                var check = row.FindControl(controlName) as HtmlInputCheckBox;
                var key = grid.DataKeys[row.RowIndex];
                foreach ( T keyLista in ListaKeys )
                {
                    if (keyLista.CompareTo ( (T)  key.Values[0] ) == 0 )
                        check.Checked = true;

                }
            }

            
        }


        
        #endregion

        #region WebControl_DateInput
        public static void SetValue(UI.Web.WebControl_DateInput control, DateTime? value)
        {
            control.Fecha = value;
        }

        #endregion

        #region WebControlHourInput2
        public static void SetValue(UI.Web.WebControlHourInput2 control, DateTime? value)
        {
            control.Date = value;
        }

        #endregion

        #region RangeValue<TType>
        public static void SetValue<TType>(WebControlRangeInput<TType> control,RangeValue<TType> value)
        {
            control.Value = value;
        }
        public static void SetValue<TType>(WebControlRangeInput<TType> control, TType from,TType to)
        {
            control.ValueFrom = from;
            control.ValueTo = to;
        }
        #endregion

        #region WebControlAutocomplete
        public static void SetValue<TIdType>(WebControlAutocomplete<TIdType> control, TIdType valueId, string valueText)
        {
            //if (valueText == null) valueText = "";
            //else
            //{
            //    if (valueText.Trim().EndsWith("%")) valueText = valueText.Trim().TrimEnd('%');
            //    if (valueText.Trim().StartsWith("%")) valueText = valueText.Trim().TrimStart('%');
            //}
            control.ValueId = valueId;
            control.ValueText = valueText;
        }
        public static void SetValue(WebControlAutocomplete<int> control,int valueId,string valueText)
        {
            SetValue<int>(control, valueId, valueText);
        }
        public static void SetValue(WebControlAutocomplete<int?> control, int? valueId, string valueText)
        {
            SetValue<int?>(control, valueId, valueText);
        }
        public static void SetValue(WebControlAutocomplete<short> control, short valueId, string valueText)
        {
            SetValue<short>(control, valueId, valueText);
        }
        public static void SetValue(WebControlAutocomplete<short?> control, short? valueId, string valueText)
        {
            SetValue<short?>(control, valueId, valueText);
        }
        #endregion

        #region WebControl_ThreeStatesCheckbox
        public static void SetValue(WebControl_ThreeStatesCheckbox control, bool? value)
        {
            control.CheckedValue = value ;
        }
        #endregion

        #region WebControl_TwoPartsNumber
        public static void SetValue(WebControl_TwoPartsNumber control, string value)
        {
            control.Value = value!=null?value:"";
        }
        #endregion

        #region TreeView
        public static void SetValue(TreeView control, List<NodeModel> model)
        {
            TreeNode root = new TreeNode("Asignar Todas");
            root.Value = "-1";
            root.ShowCheckBox = true;
            LoadTree(model, root);
            root.Expanded = true;
            control.Nodes.Add(root);
        }
        public static void LoadTree(List<NodeModel> NodesModel, TreeNode parentTreeNode)
        {
            TreeNode node;
            foreach (NodeModel nodeModel in NodesModel)
            {
                node = new TreeNode(nodeModel.Text, nodeModel.Value);
                node.Expanded = false;
                node.ShowCheckBox = true;
                node.Checked = nodeModel.Checked;                
                if (nodeModel.Childs.Count > 0)
                    LoadTree(nodeModel.Childs, node);
                parentTreeNode.ChildNodes.Add(node);
            }
        }
        #endregion
        
        #region WebControlAutocompleteSimple
        public static void SetValue(IWebControlAutocompleteSimple control, SimpleIntResult value)
        {
            control.Value = value;
        }
        public static void SetValue(IWebControlAutocompleteSimple control, int id,string text )
        {
            control.Value = new SimpleIntResult() { ID = id, Text = text };
        }
        public static void SetValue(IWebControlAutocompleteSimple control, int value)
        {
            control.ValueId = value;
        }
        public static void SetValue(IWebControlAutocompleteSimple control, int? value)
        {
            control.ValueId = value;
        }
        #endregion

        #region WebControl_TreeSelect
        public static void SetValue(IWebControlTreeSelect control, NodeResult value)
        {
            control.Value = value;
        }
        public static void SetValue(IWebControlTreeSelect control, int value)
        {
            control.ValueId = value;
        }
        public static void SetValue(IWebControlTreeSelect control, int? value)
        {
            control.ValueId = value;
        }
        #endregion 

        #region MessageBar
        public static void SetValue(MessageBar control, string value)
        {
            control.DisplayError(value);
        }
        #endregion

        #endregion

        #region UI
        public static String ListToString(ListControl lb, bool todos)
        {
            String respuesta = String.Empty;
            foreach (string s in (from item in lb.Items.Cast<ListItem>()
                                  where item.Selected || todos
                                  select item.Value))
                respuesta += s + ",";
            return respuesta.Length == 0 ? String.Empty : respuesta.Substring(0, respuesta.Length - 1);
        }
        public static List<int> ListaInts(ListBox lb, bool devolverTodos)
        {
            if (lb == null) return new List<int>();

            List<int> idLista;

            if (devolverTodos)
            {
                //si esta seleccionado el item 0, retorna todos los items de la lista
                var lista = from li in lb.Items.Cast<ListItem>()
                            select new
                            {
                                li.Value,
                                li.Selected,
                            };

                idLista = (from li in lista
                           where (lista.Any(l => l.Value == 0.ToString() && l.Selected) || li.Selected)
                           && (li.Value != 0.ToString())
                           select Convert.ToInt32(li.Value)).ToList();
            }
            else
            {
                //si esta seleccionado el item 0, retorna una lista vacia
                idLista = (from li in lb.Items.Cast<ListItem>()
                           where li.Selected
                           select Convert.ToInt32(li.Value)).ToList();

                if (idLista.Contains(0)) return new List<int>();
            }

            return idLista;
        }
        public static List<byte> ListaBytes(ListBox lb, bool devolverTodos)
        {
            if (lb == null) return new List<byte>();

            List<byte> idLista;

            if (devolverTodos)
            {
                //si esta seleccionado el item 0, retorna todos los items de la lista
                var lista = from li in lb.Items.Cast<ListItem>()
                            select new
                            {
                                li.Value,
                                li.Selected,
                            };

                idLista = (from li in lista
                           where (lista.Any(l => l.Value == 0.ToString() && l.Selected) || li.Selected)
                           && (li.Value != 0.ToString())
                           select Convert.ToByte(li.Value)).ToList();
            }
            else
            {
                //si esta seleccionado el item 0, retorna una lista vacia
                idLista = (from li in lb.Items.Cast<ListItem>()
                           where li.Selected
                           select Convert.ToByte(li.Value)).ToList();

                if (idLista.Contains(0)) return new List<byte>();
            }

            return idLista;
        }
        public static void AgregarScrollField(ListBox lb, ControlCollection Controls)
        {
            //agrega un hidden field almacenando la posición del scroll, para no perderla en un postback
            var hf = new HiddenField();
            hf.ID = "hf" + lb.ID;
            Controls.Add(hf);

            //lb.Attributes.Add("onchange", "javascript:grabarPos('" + lb.ClientID + "', '" + hf.ClientID + "');");
            //lb.Attributes.Add("onmouseout", "javascript:grabarPos('" + lb.ClientID + "', '" + hf.ClientID + "');");
            //lb.Attributes.Add("onmouseover", "javascript:setearPos('" + lb.ClientID + "', '" + hf.ClientID + "');");
            //lb.Attributes.Add("onblur", "javascript:resetearPos('" + lb.ClientID + "', '" + hf.ClientID + "');");
        }
        public static bool VerificarCombo(DropDownList ddList)
        {
            if (ddList.Items.Count == 0)
            {
                ddList.Enabled = false;
                // Agregar Configuracion UI
                //ddList.CssClass = ConfiguracionUI.CssClassError;
                return false;
            }
            else
            {
                ddList.Enabled = true;
                ddList.CssClass = String.Empty;
                return true;
            }
        }
        public static void VerificarCombo(DropDownList ddList, Button invalidarBoton)
        {
            if (ddList.Items.Count == 0)
            {
                ddList.Enabled = false;
                //Agregar Configuracion UI
                //ddList.CssClass = ConfiguracionUI.CssClassError;
                invalidarBoton.Enabled = false;
            }
            else
            {
                ddList.Enabled = true;
                ddList.CssClass = String.Empty;
                invalidarBoton.Enabled = true;
            }
        }
        public static void AgregarItemEnCero(ListControl lc, string mensaje)
        {
            lc.DataBind();
            lc.Items.Insert(0, new ListItem(mensaje, "0"));
            ControlHelper.SetSelectedItem(lc, "0");
        }
        public static void InsertarScript(WebControl control, string atributo, string script)
        {
            if (!control.Attributes.Keys.Cast<string>().Any(k => k == atributo))
                control.Attributes.Add(atributo, script);
            else
                control.Attributes[atributo] += script;
        }
        public static void InsertarScriptDecimales(WebControl control)
        {
            string script = ";javascript:ReemplazarPuntoPorComa('" + control.ClientID + "');";
            InsertarScript(control, "onblur", script);
            InsertarScript(control, "onkeyup", script);
        }
        public static DateTime? FechaCortaNullable(TextBox fechaCorta)
        {
            return DataHelper.FechaCortaNullable(fechaCorta.Text);
        }
        public static Control BuscarControl(ControlCollection controles, string id)
        {
            foreach (Control c in controles)
            {
                if (c.Controls.Count > 0)
                {
                    Control lcHijo = BuscarControl(c.Controls, id);
                    if (lcHijo != null) return lcHijo;
                }
                if (c.ID == id)
                    return c;
            }

            return null;
        }
        #endregion
        
        public static List<byte> ListaBytes(String stringArray)
        {
            var listaByte = new List<byte>();

            foreach (String s in stringArray.Split(','))
                if (!stringArray.Split(',').Contains(0.ToString())) listaByte.Add(Convert.ToByte(s));

            return listaByte;
        }
        public static List<int> ListaInts(String stringArray)
        {
            if (String.IsNullOrEmpty(stringArray)) stringArray = "0";

            var listaInts = new List<int>();

            foreach (String s in stringArray.Split(','))
                if (!stringArray.Split(',').Contains(0.ToString())) listaInts.Add(Convert.ToInt32(s));

            return listaInts;
        }
        public static List<int> ListaInts(String stringArray, bool todos)
        {
            if (String.IsNullOrEmpty(stringArray)) stringArray = "0";

            var listaInts = new List<int>();

            foreach (String s in stringArray.Split(','))
                if (todos)
                    listaInts.Add(Convert.ToInt32(s));
                else
                    if (!stringArray.Split(',').Contains(0.ToString())) listaInts.Add(Convert.ToInt32(s));

            return listaInts;
        }
        
        #region Validate
        protected virtual void ValidarDecimal(object source, ServerValidateEventArgs args)
        {
            if (DataHelper.EsDecimal(args.Value))
                args.IsValid = Convert.ToDecimal(args.Value) >= 0;
            else
                args.IsValid = false;
        }
        public static void ValidarDecimalMayorACero(object source, ServerValidateEventArgs args)
        {
            if (DataHelper.EsDecimal(args.Value))
                args.IsValid = Convert.ToDecimal(args.Value) > 0;
            else
                args.IsValid = false;
        }
        protected virtual void ValidarDosDecimalMayorACero(object source, ServerValidateEventArgs args)
        {
            if (DataHelper.EsDecimal(args.Value))
                args.IsValid = Decimal.Round(Convert.ToDecimal(args.Value), 2) > 0;
            else
                args.IsValid = false;
        }
        protected virtual void ValidarCotizacion(object source, ServerValidateEventArgs args)
        {
            if (DataHelper.EsDecimal(args.Value))
                args.IsValid = Decimal.Round(Convert.ToDecimal(args.Value), 2) > 0;
            else
                args.IsValid = false;
        }
        protected virtual void ValidarFecha(object source, ServerValidateEventArgs args)
        {
            args.IsValid = DataHelper.EsFecha(args.Value);
        }
        #endregion 

        #region Translate
        public static string TranslateFormat(string format, params string[] args)
        {
            try
            {
                format = Translate(format);
                List<string> list = new List<string>(args.Length);
                foreach (string arg in args)
                    list.Add(Translate(arg));
                return string.Format(format, list.ToArray());
            }
            catch
            {
                return format;
            } 
        }
        public static string Translate(string textCode)
        {
            return SolutionContext.Current.TextManager.Translate(textCode, UIContext.Current.LanguageCode);
        }
        public static string Translate(string textCode, string languageCode)
        {
            return SolutionContext.Current.TextManager.Translate(textCode, languageCode);
        }
        public static void TranslateControl(ControlCollection controls, string languageCode)
        {
            foreach (Control control in controls)
            {
                if (control.Controls.Count > 0)
                    TranslateControl(control.Controls, languageCode);

                if (control is Literal)
                {
                    Literal li = control as Literal;
                    if (li.Text != string.Empty) li.Text = Translate(li.Text, languageCode);
                }
                //else if (control is Label)
                //{
                //    Label lbl = control as Label;
                //    if (lbl.Text != string.Empty) lbl.Text = Translate(lbl.Text, languageCode);
                //    if (lbl.ToolTip != string.Empty) lbl.ToolTip = Translate(lbl.ToolTip, languageCode);
                //}
                else if (control is Button)
                {
                    Button bt = control as Button;
                    if (bt.Text != string.Empty) bt.Text = Translate(bt.Text, languageCode);
                    if (bt.ToolTip != string.Empty) bt.ToolTip = Translate(bt.ToolTip, languageCode);
                }
                else if (control is LinkButton)
                {
                    LinkButton bt = control as LinkButton;
                    if (bt.Text != string.Empty) bt.Text = Translate(bt.Text, languageCode);
                    if (bt.ToolTip != string.Empty) bt.ToolTip = Translate(bt.ToolTip, languageCode);
                }
                else if (control is Panel)
                {
                    Panel pnl = control as Panel;
                    if (pnl.GroupingText != string.Empty) pnl.GroupingText = Translate(pnl.GroupingText, languageCode);
                    if (pnl.ToolTip != string.Empty) pnl.ToolTip = Translate(pnl.ToolTip, languageCode);
                }
                else if (control is Menu)
                {
                    Menu menu = control as Menu;
                    TranslateControl(menu.Items, languageCode);
                }
                //else if (control is UserControl)
                //{ 
                //    UserControl uc = control as UserControl;
                //    TranslateControls(uc.Controls, languageCode); 
                //}
                else if (control is GridView)
                {
                    GridView grid = control as GridView;
                    foreach (DataControlField column in grid.Columns)
                    {
                        if (column.HeaderText != string.Empty) column.HeaderText = Translate(column.HeaderText, languageCode);
                    }
                }
            }
        }
        public static void TranslateControl(MenuItemCollection items)
        {
            TranslateControl(items, UIContext.Current.LanguageCode);
        }
        public static void TranslateControl(MenuItemCollection items, string languageCode)
        {
            foreach (MenuItem item in items)
            {
                if (item.Text != string.Empty) item.Text = Translate(item.Text, languageCode);
                if (item.ChildItems.Count> 0)TranslateControl(item.ChildItems, languageCode);
            }
        }
        public static void ShowAlert(string message, Page control)
        {
            string cleanMessage = message.Replace("'", "\\'");
            string script = "alert('" + cleanMessage + "')";
            Guid guid = Guid.NewGuid();  
            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(control, control.GetType(), guid.ToString(), script, true);
        }
        public static void ShowAlert(string message, Control control)
        {
            string cleanMessage = message.Replace("'", "\\'");
            string script = "alert('" + cleanMessage + "')";
            Guid guid = Guid.NewGuid();           
            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(control, control.GetType(), guid.ToString(), script, true);
        }  

        #endregion
                
        #region Old ControlHelper
        ///Metodos que se sacaron de la anterior libreria de Control Helper
        // Methods
        public static ListControl FillList(ListControl list, object dataSource, string dataValueField, string dataTextField)
        {
            return FillList(list, dataSource, dataValueField, dataTextField, null);
        }

        public static ListControl FillList(Control container, string listControlName, object dataSource, string dataValueField, string dataTextField)
        {
            ListControl list = container.FindControl(listControlName) as ListControl;
            return FillList(list, dataSource, dataValueField, dataTextField);
        }

        public static ListControl FillList(ListControl list, object dataSource, string dataValueField, string dataTextField, string dataTextFormatString)
        {
            if (list != null)
            {
                list.DataValueField = dataValueField;
                list.DataTextField = dataTextField;
                list.DataTextFormatString = dataTextFormatString;
                list.DataSource = dataSource;
                list.DataBind();
            }
            return list;
        }

        public static T[] GetSelectedDataKeys<T>(GridView grid, string controlName)
        {
            List<T> list = new List<T>();
            foreach (GridViewRow row in grid.Rows)
            {
                CheckBox box = row.FindControl(controlName) as CheckBox;
                if ((box != null) && box.Checked)
                {
                    DataKey key = grid.DataKeys[row.RowIndex];
                    if (key != null)
                    {
                        T item = (T)key.Value;
                        list.Add(item);
                    }
                }
            }
            return list.ToArray();
        }

        public static T[] GetSelectedHtmlInputDataKeys<T>(GridView grid, string controlName)
        {
            List<T> list = new List<T>();
            foreach (GridViewRow row in grid.Rows)
            {
                HtmlInputCheckBox box = row.FindControl(controlName) as HtmlInputCheckBox;
                if ((box != null) && box.Checked)
                {
                    DataKey key = grid.DataKeys[row.RowIndex];
                    if (key != null)
                    {
                        for (int i = 0; i < key.Values.Count; i++)
                        {
                            T item = (T)key.Values[i];
                            list.Add(item);
                        }
                    }
                }
            }
            return list.ToArray();
        }

        public static List<KeySelected<TIdType>> GetDataKeySelected<TIdType>(GridView grid, string controlName)
        {
            List<KeySelected<TIdType>> list = new List<KeySelected<TIdType>>();
            foreach (GridViewRow row in grid.Rows)
            {
                HtmlInputCheckBox box = row.FindControl(controlName) as HtmlInputCheckBox;
                if ((box != null))
                {
                    DataKey key = grid.DataKeys[row.RowIndex];
                    if (key != null)
                    {                        
                        TIdType id = (TIdType)key.Value;
                        list.Add(new KeySelected<TIdType>() { ID = id, Selected = box.Checked });
                    }
                }
            }
            return list;
        }
        public static void  SetDataKeySelected<TIdType>(GridView grid, string controlName,List<KeySelected<TIdType>> selecteds)
        {            
            foreach (GridViewRow row in grid.Rows)
            {
                HtmlInputCheckBox box = row.FindControl(controlName) as HtmlInputCheckBox;
                if ((box != null))
                {
                    DataKey key = grid.DataKeys[row.RowIndex];
                    TIdType id = (TIdType)key.Value;
                    box.Checked = (from o in selecteds where o.ID.Equals(id) select o).Count() == 1;                    
                }
            }
        }

        


        public static T[] GetSelectedHtmlRadioDataKeys<T>(GridView grid, string controlName)
        {
            List<T> list = new List<T>();
            foreach (GridViewRow row in grid.Rows)
            {
                HtmlInputRadioButton button = row.FindControl(controlName) as HtmlInputRadioButton;
                if ((button != null) && button.Checked)
                {
                    DataKey key = grid.DataKeys[row.RowIndex];
                    if (key != null)
                    {
                        for (int i = 0; i < key.Values.Count; i++)
                        {
                            T item = (T)key.Values[i];
                            list.Add(item);
                        }
                    }
                }
            }
            return list.ToArray();
        }

        public static int[] GetSelectedRowIndexes(GridView grid, string controlName)
        {
            List<int> list = new List<int>();
            foreach (GridViewRow row in grid.Rows)
            {
                CheckBox box = row.FindControl(controlName) as CheckBox;
                if ((box != null) && box.Checked)
                {
                    int rowIndex = row.RowIndex;
                    list.Add(rowIndex);
                }
            }
            return list.ToArray();
        }

        public static void SetCheckBoxes(GridView grid, string controlName, bool value)
        {
            foreach (GridViewRow row in grid.Rows)
            {
                CheckBox box = row.FindControl(controlName) as CheckBox;
                if (box != null)
                {
                    box.Checked = value;
                }
            }
        }

        public static void SetSelectedItem(DropDownList dd, bool SelectFirstItem)
        {
            dd.SelectedIndex = -1;
            if (SelectFirstItem && (dd.Items.Count > 0))
            {
                dd.Items[0].Selected = true;
            }
        }

        public static void SetSelectedItem(DropDownList dd, string key)
        {
            dd.SelectedIndex = -1;
            foreach (ListItem item in dd.Items)
            {
                if (item.Value == key)
                {
                    item.Selected = true;
                    break;
                }
            }
        }

        public static void SetSelectedItem(ListBox lb, string key)
        {
            lb.SelectedIndex = -1;
            foreach (ListItem item in lb.Items)
            {
                if (item.Value == key)
                {
                    item.Selected = true;
                    break;
                }
            }
        }

        public static void SetSelectedItem(ListControl lc, bool SelectFirstItem)
        {
            lc.SelectedIndex = -1;
            if (SelectFirstItem && (lc.Items.Count > 0))
            {
                lc.Items[0].Selected = true;
            }
        }

        public static void SetSelectedItem(ListControl lc, string key)
        {
            lc.SelectedIndex = -1;
            foreach (ListItem item in lc.Items)
            {
                if (item.Value == key)
                {
                    item.Selected = true;
                    break;
                }
            }
        }

        public static void SetSelectedItems<T>(ListControl lc, List<T> keys)
        {
            Type conversionType = typeof(T);
            lc.SelectedIndex = -1;
            foreach (ListItem item in lc.Items)
            {
                object obj2;
                if (conversionType.BaseType != typeof(Enum))
                {
                    obj2 = Convert.ChangeType(item.Value, conversionType);
                }
                else
                {
                    obj2 = Enum.Parse(conversionType, item.Value);
                }
                if (keys.Contains((T)obj2))
                {
                    item.Selected = true;
                }
            }
        }

        #endregion
    }
}
