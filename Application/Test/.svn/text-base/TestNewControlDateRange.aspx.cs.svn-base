using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;

namespace UI.Web
{
    public partial class TestNewControlDateRange : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (wcAutocomplete1.IsSelectionItemPostBack)
                {
                    SimpleResult<int?> resu = wcAutocomplete1.SelecttedValue;
                }

                if (wcAutocomplete2.IsSelectionItemPostBack)
                {
                    SimpleResult<int?> resu2 = wcAutocomplete2.SelecttedValue;
                }
            }

            wcAutocomplete1.WebServiceName = "~/Services/WebServiceMedio.asmx";
            wcAutocomplete1.ServiceMethod = "GetMedios";
            wcAutocomplete1.AutoPostback = true;
            wcAutocomplete1.ValueChanged += new EventHandler(this.AutocompletePostBack);

            wcAutocomplete2.WebServiceName = "~/Services/WebServiceMedio.asmx";
            wcAutocomplete2.ServiceMethod = "GetMedios";
            wcAutocomplete2.AutoPostback = true;
            wcAutocomplete2.ValueChanged += new EventHandler(this.AutocompletePostBack);


            #region lala
            //wcAutocomplete.DelimiterCharacters = " ";
            //wcAutocomplete1.MinimumPrefixLength = 1;
            //wcAutocomplete1.RequiredValue = true;
            //wcAutocomplete1.RequiredMessage = "vacion no!";
            //wcAutocomplete1.CompletionSetCount = 1;

            //    wcDateRangeInput.TagFrom = "Desde";
            //    wcDateRangeInput.TagTo = "Hasta";
            //    wcNumericRangeInput.TagFrom = "De";
            //    wcNumericRangeInput.TagTo = "A";
            //    wcNumericRangeInput.Masks = "999";
            //    wcNumericRangeInput.MinimumValueFrom = 0;
            //    wcNumericRangeInput.MaximumValueFrom = Decimal.Parse("100.5");
            //    wcNumericRangeInput.MinimumValueTo = Decimal.Parse("100.5");
            //    wcNumericRangeInput.MaximumValueTo = Decimal.Parse("999.5");

            //    wcNumericRangeInput.IsValidEmptyFrom = false;
            //    wcNumericRangeInput.IsValidEmptyTo = false;

            //    wcThreeStatesCheckbox.TagOff = "Todos";
            //    wcThreeStatesCheckbox.TagCheckedTrue = "Encendidos";
            //    wcThreeStatesCheckbox.TagCheckedFalse = "Apagados";
            //    wcThreeStatesCheckbox.CheckedDefault = true;
            //    //wcThreeStatesCheckbox.ShowOffOption = false;

            //    if (!this.IsPostBack)
            //    {
            //        //wcDateRangeInput.ErrorMessageValidator = "Mal rango de fechas!";

            //        wcDateRangeInput.ValueFrom = DateTime.Now.AddDays(-5);
            //        wcDateRangeInput.ValueTo = DateTime.Now;

            //        //wcDateRangeInput.Width = 200;

            //        //wcDateRangeInput.OperatorValidator = ValidationCompareOperator.Equal;

            //        //wcDateRangeInput.Clear();
            //        wcNumericRangeInput.ValueFrom = 50;
            //        wcNumericRangeInput.ValueTo = 51;

            //        //wcNumericRangeInput.Width = 200;
            //        //wcNumericRangeInput.ErrorMessageValidator = "El valor DE no debe ser mayor al valor A";
            //        //wcDateInput.IsValidEmpty = false;

            //    }
            //    else
            //    {
            //        DateTime? desde = wcDateRangeInput.ValueFrom;
            //        DateTime? hasta = wcDateRangeInput.ValueTo;
            //        Decimal de = wcNumericRangeInput.ValueFrom;
            //        Decimal a = wcNumericRangeInput.ValueTo;
            //        Boolean? b = wcThreeStatesCheckbox.Value;
            //    }
            #endregion
        }

        private void AutocompletePostBack(object sender, EventArgs e)
        {
            this.mensaje.Text = "OK" + 
                                ((wcAutocomplete1.IsSelectionItemPostBack)? wcAutocomplete1.SelecttedValue.Text :
                                (wcAutocomplete2.IsSelectionItemPostBack)? wcAutocomplete2.SelecttedValue.Text : "");
        }
    }
}
