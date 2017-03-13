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
    public partial class IndicadorClaseEdit : WebControlEdit<nc.IndicadorClaseCompose>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.IndicadorTipo>(ddlIndicadorTipo, IndicadorTipoService.Current.GetList(new nc.IndicadorTipoFilter() { Activo = true }), "Nombre", "IdIndicadorTipo", new IndicadorTipo() { IdIndicadorTipo = 0, Nombre = "Seleccione Indicador Tipo" });
            revSigla.ValidationExpression=Contract.DataHelper.GetExpRegString(10);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(100);
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvSigla.ErrorMessage = TranslateFormat("FieldIsNull", "Sigla");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvIndicadorTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Sector de Indicador");
            rfvUnidad.ErrorMessage = TranslateFormat("FieldIsNull", "Unidad");
           // rfvIndicadorRubro.ErrorMessage = TranslateFormat("FieldIsNull", "Sector de Indicador");
            UIHelper.Load<nc.UnidadMedidaResult>(ddlUnidad, UnidadMedidaService.Current.GetResult(new nc.UnidadMedidaFilter() { Activo = true }), "Nombre", "IdUnidadMedida", new UnidadMedidaResult() { IdUnidadMedida = 0, Nombre = "Seleccione UnidadMedida" });
			revRangoInicial.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			revRangoFinal.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
            revRangoInicial.ErrorMessage = TranslateFormat("InvalidField", "Rango Inicial");
            revRangoFinal.ErrorMessage = TranslateFormat("InvalidField", "Rango Final");
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlIndicadorTipo);
			ddlIndicadorTipo.Focus();
			UIHelper.Clear(txtSigla);
			UIHelper.Clear(txtNombre);
			UIHelper.Clear(ddlUnidad);
			UIHelper.Clear(txtRangoInicial);
			UIHelper.Clear(txtRangoFinal);
			UIHelper.Clear(chkActivo);
            UIHelper.Clear(dlRubros);
				
        }		
		public override void SetValue()
        {
           
            UIHelper.SetValue<IndicadorTipo, int>(ddlIndicadorTipo, Entity.IndicadorClase.IdIndicadorTipo, IndicadorTipoService.Current.GetById);
			ddlIndicadorTipo.Focus();
			UIHelper.SetValue(txtSigla, Entity.IndicadorClase.Sigla);
			UIHelper.SetValue(txtNombre, Entity.IndicadorClase.Nombre);
            UIHelper.SetValue<UnidadMedida, int>(ddlUnidad, Entity.IndicadorClase.IdUnidad, UnidadMedidaService.Current.GetById);
			UIHelper.SetValue(txtRangoInicial, Entity.IndicadorClase.RangoInicial);
			UIHelper.SetValue(txtRangoFinal, Entity.IndicadorClase.RangoFinal);
			UIHelper.SetValue(chkActivo, Entity.IndicadorClase.Activo);
            UIHelper.Sort<IndicadorRelacionRubroResult>(Entity.Rubros, "IndicadorRubro_Nombre");
            UIHelper.SetValue(dlRubros, Entity.Rubros);
            	
        }	
        public override void GetValue()
        {
            Entity.IndicadorClase.IdIndicadorTipo = UIHelper.GetInt(ddlIndicadorTipo);
            Entity.IndicadorClase.Sigla = UIHelper.GetString(txtSigla);
            Entity.IndicadorClase.Nombre = UIHelper.GetString(txtNombre);
            Entity.IndicadorClase.IdUnidad = UIHelper.GetInt(ddlUnidad);
            Entity.IndicadorClase.RangoInicial = UIHelper.GetIntNullable(txtRangoInicial);
            Entity.IndicadorClase.RangoFinal = UIHelper.GetIntNullable(txtRangoFinal);
            Entity.IndicadorClase.Activo = UIHelper.GetBoolean(chkActivo);
            Update(dlRubros, Entity.Rubros);
				
        }
        private void Update(DataList dataList, List<IndicadorRelacionRubroResult> list)
        {
            for (int i = 0; i < dataList.Items.Count; i++)
            {
                bool isChecked = ((CheckBox)dataList.Items[i].FindControl("chk")).Checked;
                short value = short.Parse(((HiddenField)dataList.Items[i].FindControl("hdValue")).Value);
                IndicadorRelacionRubroResult item = (from o in list where o.IdIndicadorRubro == value select o).FirstOrDefault();
                if (item == null) continue;
                item.Selected = isChecked;
            }
        }  
    }
}
