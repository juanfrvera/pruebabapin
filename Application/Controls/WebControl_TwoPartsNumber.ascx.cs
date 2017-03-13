using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace UI.Web
{
    public partial class WebControl_TwoPartsNumber : WebControlBase
    {
        #region Atributos
        private char separador = '-';
        private char completeWith = '0';
        private bool complete = false;
        #endregion Atributos

        #region Metodos
        protected override void _Initialize()
        {
            base._Initialize();

            valPartOne.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            valPartTwo.ValidationExpression = Contract.DataHelper.GetExpRegNumber();

            base.Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/Autocomplete.js", Page.ResolveClientUrl("~/App_Scripts/Autocomplete.js"));
        }
        protected override void _Load()
        {
            if (complete)
            {
                txtPartOne.Attributes["onblur"] = "onLostFocusComplete('" + txtPartOne.ClientID + "','" + completeWith.ToString() + "', " + txtPartOne.MaxLength + ")";
                txtPartTwo.Attributes["onblur"] = "onLostFocusComplete('" + txtPartTwo.ClientID + "','" + completeWith.ToString() + "', " + txtPartTwo.MaxLength + ")";

                txtPartOne.Attributes["onfocus"] = "onFocusDelete('" + txtPartOne.ClientID + "','" + completeWith.ToString() + "', " + txtPartOne.MaxLength + ")";
                txtPartTwo.Attributes["onfocus"] = "onFocusDelete('" + txtPartTwo.ClientID + "','" + completeWith.ToString() + "', " + txtPartTwo.MaxLength + ")";
            }

            base._Load();
        }
        public override void Focus()
        {
            txtPartOne.Focus();
        }
        public void Clear()
        {
            txtPartOne.Text = "";
            txtPartTwo.Text = "";
        }
        #endregion Metodos

        #region Propiedades
        public char Separador
        {
            set { separador = value; }
        }
        public int PartOneMaxLength
        {
            set{txtPartOne.MaxLength = value;}
        }
        public int PartTwoMaxLength
        {
            set{txtPartTwo.MaxLength = value;}
        }
        public string ValidationGroup
        {
            set
            {
                txtPartOne.ValidationGroup = value;
                txtPartTwo.ValidationGroup = value; 
            }
        }
        public int PartOneWidth
        {
            set { txtPartOne.Width = value; }
        }
        public int PartTwoWidth
        {
            set { txtPartTwo.Width = value; }
        }
        public bool Complete
        {
            set { complete = value; }
        }
        public char CompleteWith
        {
            set { completeWith = value; }
        }
        public string Value
        {
            get 
            {
                return txtPartOne.Text + separador + txtPartTwo.Text;
            }
            set 
            {
                if (value.IndexOf(separador) != (-1))
                {
                    string[] partes = value.Split(separador);
                    if (partes.Length == 2)
                    {
                        txtPartOne.Text = partes[0];
                        txtPartTwo.Text = partes[1];
                    }
                }
            }
        }
        public string ValuePartOne
        {
            get
            {
                return txtPartOne.Text;
            }
            set
            {
                txtPartOne.Text = value;
            }
        }
        public string ValuePartTwo
        {
            get
            {
                return txtPartTwo.Text;
            }
            set
            {
                txtPartTwo.Text = value;
            }
        }
        #endregion Propiedades
    }
}