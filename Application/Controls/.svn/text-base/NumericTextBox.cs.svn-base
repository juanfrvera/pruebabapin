using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;

namespace UI.Web
{
    public class NumericTextBox : TextBox
    {
        public enum Separator
        {
            Comma,
            Dot
        }

        public enum NumericType
        {
            Integer,
            Fractional,
            PositiveInteger,
            PositiveFractional
        }

        public enum InputAlign
        {
            Right,
            Left
        }

        private bool useSeparadorMiles = false;

        public bool UseSeparadorMiles
        {
            get { return useSeparadorMiles; }
            set { useSeparadorMiles = value; }
        }

        private Separator _FractionalSeparator = Separator.Dot;

        public Separator FractionalSeparator
        {
            get { return _FractionalSeparator; }
            set { _FractionalSeparator = value; }
        }

        private NumericType _InputType = NumericType.Fractional;

        public NumericType InputType
        {
            get { return _InputType; }
            set { _InputType = value; }
        }

        private int _NumDecimals = 2;
        public int NumDecimals
        {
            get { return _NumDecimals; }
            set { _NumDecimals = value; }
        }

        private InputAlign _InputDirection = InputAlign.Right;

        public InputAlign InputDirection
        {
            get
            {
                return _InputDirection;
            }
            set
            {
                _InputDirection = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {

            this._FractionalSeparator = (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",") ? Separator.Comma : Separator.Dot;
            base.OnLoad(e);

            string Script0 = @"var NT_MaxDecimalDigits = 0;
                               var NT_Separator = ''; 
                                function NumericTBgetKeyEvent(e)
                                { 
                                    var keynum;
                                    if(e.keyCode){keynum = e.keyCode}
                                    else
                                    {
                                       if(e.charCode) {keynum = e.charCode;}
                                       else{keynum = -1;}
                                    } 
                                    return keynum;
                                }
                ";
            string Script1 = "function validateFractionalPositiveNUM(e,field)\n" +
                "{" +
                    "var key = NumericTBgetKeyEvent(e); \n" +

                    //Matias 20140121 - Tarea 104
                    //No pude hacer funcionar el ctrl+c/ctrl+v.
                    //Agregué estas lineas de abajo pero no le da bola!
                    //"if (e.ctrlKey == true) \n" +
                    //"{" +
                        //"if ((key == 67)|| (key == 86))\n" +
                        //"{ return true;}" +
                    // "} \n" +
                    //FinMatias 20140121 - Tarea 104

                    //Matias 20141126 - Tarea 183
                    //"if ( (key == 37)|| (key == 39) || (key == 46) || (key == 9))\n" +
                    "if ( (key == 46) || (key == 9))\n" +
                    //FinMatias 20141126 - Tarea 183
                    "{ return true;}" +
                    "if(key < 0) return true;" +
                    //Matias 20141126 - Tarea 183
                    //"if ((key >= 48 && key <= 57)  || (key == 37)|| (key == 39)|| (key == 46) || (key == 44) || (key == 9)  || (key == 8)) \n" +
                    "if ((key >= 48 && key <= 57)  || (key == 46) || (key == 44) || (key == 9)  || (key == 8)) \n" +
                    //FinMatias 20141126 - Tarea 183
                    
                    "{" +
                        "var returnvalue = true;" +
                        //Matias 20141126 - Tarea 183
                        //"if (key != 46 && key != 44 && key != 45  && key != 37  && key != 39  && key != 9 ) \n" +
                        "if (key != 46 && key != 44 && key != 45 && key != 9 ) \n" +
                        //FinMatias 20141126 - Tarea 183
                            "returnvalue = true; \n" +
                        "else \n" +
                            "returnvalue = (field.value.search(/\\.|\\,/) == -1 && field.value.length > 0); \n" +
                        "if(NT_MaxDecimalDigits > 0 && returnvalue)\n" +
                        "{" +
                            "var indexofseparator = field.value.indexOf(NT_Separator); \n" +
                            "if(indexofseparator == -1 && key != 46 && key != 44 && key != 8 && (field.maxLength != -1 && (field.value.length + 1) > (field.maxLength-(NT_MaxDecimalDigits + 1))))  returnvalue = false;" +
                        // " if(key != 46 && key != 44 && key != 8 && indexofseparator > -1 && field.value.length - indexofseparator > NT_MaxDecimalDigits) returnvalue = false;" +
                        "}" +
                        "return returnvalue;" +
                    "} \n" +
                    "return false; \n" +
                "} ";
            string Script2 = "function validateFractionalNUM(e,field)\n" +
                "{" +
                    "var key = NumericTBgetKeyEvent(e); \n" +

                    //Matias 20141126 - Tarea 183
                    //"if ( (key == 37)|| (key == 39) || (key == 46) || (key == 9))\n" +
                    "if ( (key == 46) || (key == 9))\n" +
                    //FinMatias 20141126 - Tarea 183
                    "{ return true;}" +
                    "if(key < 0) return true;" +

                    //Matias 20141126 - Tarea 183
                    //"if ((key == 37)|| (key == 39) || (key == 46) || (key == 9))\n" +
                    "if ( (key == 46) || (key == 9))\n" +
                    //FinMatias 20141126 - Tarea 183
                    "{ return true;}" +
                    //Matias 20141126 - Tarea 183
                    //"if ((key >= 48 && key <= 57) || (key == 37)|| (key == 39) || (key == 46) || (key == 44) || (key == 45) || (key == 9)  || (key == 8))\n" +
                    "if ((key >= 48 && key <= 57) || (key == 46) || (key == 44) || (key == 45) || (key == 9)  || (key == 8))\n" +
                    //FinMatias 20141126 - Tarea 183
                    "{" +
                        "var returnvalue = false;" +
                        //Matias 20141126 - Tarea 183
                        //"if (key != 46 && key != 44 && key != 45  && key != 37  && key != 39  && key != 9 ) \n" +
                        "if (key != 46 && key != 44 && key != 45 && key != 9 ) \n" +
                        //FinMatias 20141126 - Tarea 183
                            "returnvalue = true; \n" +
                        "else if(key != 45)\n" +
                             "returnvalue = (field.value.search(/\\.|\\,/) == -1 && field.value.length > 0); \n" +
                        " else " +
                             "returnvalue = (field.value.search(/\\-,/) == -1 && field.value.length == 0); \n" +
                        "if(NT_MaxDecimalDigits > 0 && returnvalue)\n" +
                        "{" +
                            "var indexofseparator = field.value.indexOf(NT_Separator); \n" +
                            "if(indexofseparator == -1 && key != 46 && key != 44 && key != 8 && (field.maxLength != -1 && (field.value.length + 1) > (field.maxLength-(NT_MaxDecimalDigits + 1))))  returnvalue = false;" +
                            " if( key != 46 && key != 44 && key != 8 && indexofseparator > -1 && field.value.length - indexofseparator > NT_MaxDecimalDigits) returnvalue = false;" +
                        "}" +
                        "return returnvalue;" +
                    "}" +
                    "return false; \n" +
                "} ";

            string Script3 = "function validateIntegerNUM(e,field)\n" +
                "{" +
                "var key = NumericTBgetKeyEvent(e); \n" +

                "if ((key == 37)|| (key == 39) || (key == 46) || (key == 9))\n" +
                "{ return true;}" +
                "if(key < 0) return true;" +
                "if ((key >= 48 && key <= 57)  || (key == 37)|| (key == 39)|| (key == 46) || (key == 45) || (key == 9)  || (key == 8)) \n" +
                "{" +
                    "if (key != 46 && key != 44 && key != 45  && key != 37  && key != 39  && key != 9) \n" +
                    "returnvalue = true; \n" +
                    "else  \n" +
                        "return (field.value.search(/\\-,/) == -1 && field.value.length == 0); \n" +
                "} \n" +
                "return false; \n" +
            "} ";

            string Script4 = "function validatePositiveIntegerNUM(e,field)\n" +
                "{" +
                "var key = NumericTBgetKeyEvent(e); \n" +
                //Matias 20140401 - Tarea 126
                //"if ((key == 37)|| (key == 39) || (key == 46) || (key == 9))\n" +
                "if ((key == 37)|| (key == 39) || (key == 9))\n" +
                //FinMatias 20140401 - Tarea 126
                "{ return true;}" +
                "if(key < 0) return true;" +
                //Matias 20140401 - Tarea 126
                //"if ((key >= 48 && key <= 57) || (key == 37) || (key == 39) || (key == 46) || (key == 9) || (key == 8)) \n" +
                "if ((key >= 48 && key <= 57) || (key == 37) || (key == 9) || (key == 8)) \n" +
                //FinMatias 20140401 - Tarea 126
                "return true; \n" +
                "return false; \n" +
                "} ";

            string Script5 = @"
                                    function ChangedWithThousandsFormat(input)
                                    {                                   
                                        var num = input.value.replace(/\./g,'');
                                        num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g,'$1.');
                                        num = num.split('').reverse().join('').replace(/^[\.]/,'');
                                        input.value = num;
                                        
                                    }";

            string Script6 = @"
                                    function ClearThousandsFormat(input)
                                    {                             
                                        var num = input.value.replace(/\./g,'');
                                        input.value = num;       
                                        input.select();                                 
                                        //setCaretPosition(input, input.value.length);
                                    }";


            string Script7 = @"
                                    function doGetCaretPosition (ctrl) {
	                                    var CaretPos = 0;	// IE Support
	                                    if (document.selection) {
	                                    ctrl.focus ();
		                                    var Sel = document.selection.createRange ();
		                                    Sel.moveStart ('character', -ctrl.value.length);
		                                    CaretPos = Sel.text.length;
	                                    }
	                                    // Firefox support
	                                    else if (ctrl.selectionStart || ctrl.selectionStart == '0')
		                                    CaretPos = ctrl.selectionStart;
	                                    return (CaretPos);
                                    }";

            string Script8 = @"
                                    function setCaretPosition(ctrl, pos){
	                                    if(ctrl.setSelectionRange)
	                                    {
		                                    ctrl.focus();
		                                    ctrl.setSelectionRange(pos,pos);
	                                    }
	                                    else if (ctrl.createTextRange) {
		                                    var range = ctrl.createTextRange();
		                                    range.collapse(true);
		                                    range.moveEnd('character', pos);
		                                    range.moveStart('character', pos);
		                                    range.select();
	                                    }
                                    }";

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "NumericTextboxScipt0", Script0, true);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "NumericTextboxScipt1", Script1, true);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "NumericTextboxScipt2", Script2, true);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "NumericTextboxScipt3", Script3, true);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "NumericTextboxScipt4", Script4, true);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "NumericTextboxScipt5", Script5, true);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "NumericTextboxScipt6", Script6, true);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "NumericTextboxScipt7", Script7, true);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "NumericTextboxScipt8", Script8, true);

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.Style[HtmlTextWriterStyle.TextAlign] = (_InputDirection == InputAlign.Right ? "right" : "left");
            string ntype = string.Empty;
            switch (this.InputType)
            {
                case NumericType.Integer:
                    ntype = "return validateIntegerNUM(event,this); ";
                    break;
                case NumericType.Fractional:
                    ntype = "return validateFractionalNUM(event,this); ";
                    break;
                case NumericType.PositiveInteger:
                    ntype = "return validatePositiveIntegerNUM(event,this); ";
                    break;
                case NumericType.PositiveFractional:
                    ntype = "return validateFractionalPositiveNUM(event,this); ";
                    break;
                default:
                    break;
            }
            string inValidSeparatorChar = this.FractionalSeparator == Separator.Comma ? "." : ",";
            string ValidSeparatorChar = this.FractionalSeparator == Separator.Comma ? "," : ".";
            string oldKeypress = this.Attributes["onkeypress"];

            this.Attributes["onkeypress"] = "NT_MaxDecimalDigits = \n" + _NumDecimals.ToString() + "; NT_Separator = '" + ValidSeparatorChar + "'; \n" + ntype + (oldKeypress != null ? oldKeypress : string.Empty);


            if (InputType == NumericType.PositiveFractional || InputType == NumericType.Fractional)
            {
                string onkeyup = "NT_MaxDecimalDigits = \n" + _NumDecimals.ToString() + "; NT_Separator = '" + ValidSeparatorChar + "'; \n" +
                "if(this.value.indexOf('" + inValidSeparatorChar + "')>-1) this.value=this.value.replace(/\\" + inValidSeparatorChar + "/,'" + ValidSeparatorChar + "'); ";
                string oldkeyup = this.Attributes["onkeyup"];

                this.Attributes["onkeyup"] = onkeyup + (oldkeyup != null ? oldkeyup : string.Empty);
            }

            if (InputType == NumericType.PositiveInteger && UseSeparadorMiles)
            {
                //this.Attributes["onkeyup"] = "ChangedWithThousandsFormat( this );";
                //string oldOnchange = this.Attributes["onchange"];
                string oldOnBlur = this.Attributes["onBlur"];
                this.Attributes["onBlur"] = "ChangedWithThousandsFormat( this );" + (oldOnBlur != null ? oldOnBlur : string.Empty);
                string oldOnFocus = this.Attributes["onFocus"];
                this.Attributes["onFocus"] = "ClearThousandsFormat( this );" + (oldOnFocus != null ? oldOnFocus : string.Empty);
            }
        }

        public override string Text
        {
            get
            {
                //if (InputType == NumericType.PositiveInteger && UseSeparadorMiles)
                //    return base.Text.Replace(".", string.Empty);
                //else
                return base.Text;
            }
            set
            {
                if (InputType == NumericType.PositiveInteger && UseSeparadorMiles)
                {
                    int intValue = 0;
                    String ValueWithoutDecimals = value.Contains(',') ? value.Substring(0, value.IndexOf(',')) : value;

                    if (Int32.TryParse(ValueWithoutDecimals, out intValue))
                    {
                        String Formated = intValue.ToString("N0");
                        base.Text = Formated;
                    }
                    else
                    {
                        base.Text = ValueWithoutDecimals;
                    }
                }
                else
                {
                    base.Text = value;
                }

            }
        }

    }
}
