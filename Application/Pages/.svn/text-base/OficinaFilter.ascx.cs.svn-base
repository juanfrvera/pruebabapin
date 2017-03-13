using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{
    public partial class OficinaFilter : WebControlFilter<nc.OficinaFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            toOficinaPadre.Width = 550;
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(15);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Codigo");
            UIHelper.Load<nc.JurisdiccionResult>(ddlJurisdiccion, JurisdiccionService.Current.GetResult(), "CodigoNombre", "IdJurisdiccion", new JurisdiccionResult() { IdJurisdiccion = 0, Codigo = "", Nombre = "Seleccione Jurisdicción" });

            chkActivo.CheckedValue = true;
        }
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(txtCodigo);
			chkActivo.CheckedValue = true;
			UIHelper.Clear(chkVisible);
			UIHelper.Clear(toOficinaPadre);
			UIHelper.ClearItems(ddlSaf);
            UIHelper.Clear(ddlJurisdiccion);
            //UIHelper.Clear(txtNumero);
            //UIHelper.Clear(txtNumeroNivel);
            //UIHelper.Clear(txtNivel);
            UIHelper.Clear(chkIncluirOficinasInteriores);
        }		
		protected override void SetValue()
        {
            UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
            txtNombre.Focus();
            UIHelper.SetValue(ddlJurisdiccion, Filter.IdJurisdiccion);
            if (Filter.IdJurisdiccion.HasValue)
            {
                BuscarSafs();
                UIHelper.SetValue(ddlSaf, Filter.IdSaf);
            }           
            UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
		    UIHelper.SetValue(chkActivo, Filter.Activo);
		    UIHelper.SetValue(chkVisible, Filter.Visible);
		    UIHelper.SetValue(toOficinaPadre, Filter.IdOficinaPadre);
            //UIHelper.SetValueFilter(txtNumero, Filter.BreadcrumbId);
            //UIHelper.SetValueFilter(txtNumeroNivel, Filter.NumeroNivel);
		    ///UIHelper.SetValue(txtNivel, Filter.Nivel);
            UIHelper.SetValue(chkIncluirOficinasInteriores, Filter.IncluirOficinasInteriores);
        }	
        protected override void GetValue()
        {
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
			Filter.Visible=UIHelper.GetBooleanNullable(chkVisible);			  
			Filter.IdOficinaPadre=UIHelper.GetIntNullable(toOficinaPadre);
			Filter.IdSaf =UIHelper.GetIntNullable(ddlSaf);
            Filter.IdJurisdiccion = UIHelper.GetIntNullable(ddlJurisdiccion);
            //Filter.Numero =UIHelper.GetStringFilter(txtNumero);
            //Filter.NumeroNivel =UIHelper.GetStringFilter(txtNumeroNivel);
			//Filter.Nivel=UIHelper.GetIntNullable(txtNivel);
            Filter.IncluirOficinasInteriores = UIHelper.GetBooleanNullable(chkIncluirOficinasInteriores);
        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
        #region Events
        protected void ddlJurisdiccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarSafs);
        }
        #endregion
        #region Private Functions
        private void BuscarSafs()
        {
            Int32 idJurisdiccion = UIHelper.GetInt(ddlJurisdiccion);
            if (idJurisdiccion == 0)
            {
                UIHelper.ClearItems(ddlSaf);
            }
            else
            {
                UIHelper.Load<nc.SafResult>(ddlSaf, SafService.Current.GetResultFromList(new nc.SafFilter() { IdJurisdiccion = idJurisdiccion }), "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione SAF" });
            }
        }
        #endregion
    }
}
