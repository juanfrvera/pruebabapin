using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;

namespace UI.Web
{
    public partial class OficinaEdit : WebControlEdit<nc.OficinaCompose>
    {
        #region Override
        protected override void _Initialize()
        {
            base._Initialize();
            PopUpSafsOficina.Attributes.CssStyle.Add("display", "none");
            UIHelper.Load<SafResult>(ddlOficinaSaf, SafService.Current.GetResultFromList(new nc.SafFilter() { Activo = true }), "CodigoDenominacion", "IdSaf", new nc.SafResult() { IdSaf = 0, Codigo="", Denominacion = "Seleccione Saf" });
           // UIHelper.Load<nc.Jurisdiccion>(txtJurisdiccion, JurisdiccionService.Current.GetList(new nc.JurisdiccionFilter() { Activo = true }), "Nombre", "IdJurisdiccion", new nc.Jurisdiccion() { IdJurisdiccion = 0, Nombre = "Seleccione Jurisdicción" });
            revOficina.ValidationExpression = Contract.DataHelper.GetExpRegString(100);
            revOficina.ErrorMessage = TranslateFormat("InvalidField", "Oficina");
            rfvOficina.ErrorMessage = TranslateFormat("FieldIsNull", "Oficina");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
           
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            ActualOficinaSaf = ActualOficinaSaf;
        }
        public override void Clear()
        {
            UIHelper.Clear(txtJurisdiccion);
            txtJurisdiccion.Focus();
            UIHelper.Clear(chkActivo);
            UIHelper.Clear(chkSeleccionable);
            UIHelper.Clear(chkVisible);
            UIHelper.Clear(txtOficina);
             UIHelper.Clear(toOficinaPadre);
            UIHelper.ClearItems(ddlSaf);
            UIHelper.Clear(dlProgramas);
        }
        public override void SetValue()
        {
            if (CrudAction == CrudActionEnum.Create)
            {                
                tcContainer.ActiveTabIndex = 0;
            }
            txtJurisdiccion.Focus();
       //     if(Entity.Oficina.Saf_IdJurisdiccion.HasValue)
        //        UIHelper.SetValue<Jurisdiccion,int>(ddlJurisdiccion, Entity.Oficina.Saf_IdJurisdiccion.Value,JurisdiccionService.Current.GetById);
            UIHelper.SetValue(txtJurisdiccion,  Entity.Oficina.Jurisdiccion_Nombre );
            UIHelper.SetValue(txtOficina, Entity.Oficina.Nombre);
            UIHelper.SetValue(txtCodigo, Entity.Oficina.Codigo);
            UIHelper.SetValue(chkActivo, Entity.Oficina.Activo);
            UIHelper.SetValue(chkVisible, Entity.Oficina.Visible);
            UIHelper.SetValue(chkSeleccionable, Entity.Oficina.Seleccionable);
            
            
            UIHelper.SetValue(toOficinaPadre, Entity.Oficina.IdOficinaPadre);
            UIHelper.Load<nc.OficinaSafResult>(ddlSaf, Entity.ToSafResult(), "Saf_Denominacion", "IdSaf", new nc.OficinaSafResult() { IdSaf = 0, Saf_Denominacion = "Seleccione Saf" });
            if(Entity.Oficina.IdSaf.HasValue)
                UIHelper.SetValue<Saf,int>(ddlSaf, Entity.Oficina.IdSaf.Value, SafService.Current.GetById);
            
            upAgregarSafOficina.Update();
            OficinaSafRefresh();
        }
        public override void GetValue()
        {
           // Entity.Oficina.Saf_IdJurisdiccion = UIHelper.GetIntNullable(ddlJurisdiccion);
            Entity.Oficina.Nombre = UIHelper.GetString(txtOficina);
            Entity.Oficina.Codigo = UIHelper.GetString(txtCodigo);
            Entity.Oficina.Activo = UIHelper.GetBoolean(chkActivo);
            Entity.Oficina.Visible = UIHelper.GetBoolean(chkVisible);
            Entity.Oficina.Seleccionable = UIHelper.GetBoolean(chkSeleccionable);
            Entity.Oficina.IdOficinaPadre = UIHelper.GetIntNullable(toOficinaPadre);
            Entity.Oficina.IdSaf = UIHelper.GetIntNullable(ddlSaf);
            OficinaSafProgramaSave();            
        }
        protected void RefreshDefaultSafs()
        {
            int id = UIHelper.GetInt(ddlSaf);
            UIHelper.ClearItems(ddlSaf);
            UIHelper.Load<nc.OficinaSafResult>(ddlSaf, Entity.ToSafResult(), "Saf_Denominacion", "IdSaf", new nc.OficinaSafResult() { IdSaf = 0, Saf_Denominacion = "Seleccione Saf" });
            UIHelper.SetValue<Saf,int>(ddlSaf,id,SafService.Current.GetById);
            upAgregarSafOficina.Update();
        }
        #endregion

        #region OficinaSaf
        private OficinaSafCompose actualOficinaSaf;
        protected OficinaSafCompose ActualOficinaSaf
        {
            get
            {
                if (actualOficinaSaf == null)
                    if (ViewState["actualOficinaSaf"] != null)
                        actualOficinaSaf = ViewState["actualOficinaSaf"] as OficinaSafCompose;
                    else
                    {
                        actualOficinaSaf = GetNewOficinaSaf();
                        ViewState["actualOficinaSaf"] = actualOficinaSaf;
                    }
                return actualOficinaSaf;
            }
            set
            {
                actualOficinaSaf = value;
                ViewState["actualOficinaSaf"] = value;
            }
        }
        OficinaSafCompose GetNewOficinaSaf()
        {
            int id = 0;
            if (Entity.Safs.Count > 0) id = Entity.Safs.Min(o => o.Saf.IdOficinaSaf);
            if (id > 0) id = 0;
            id--;
            OficinaSafCompose oficinaSafCompose = new OficinaSafCompose();
            oficinaSafCompose.Saf = new OficinaSafResult();
            OficinaSafService.Current.Set(OficinaSafService.Current.GetNew(), oficinaSafCompose.Saf);
            oficinaSafCompose.Saf.IdOficinaSaf = id;
            //oficinaSafCompose.Programas = OficinaComposeService.Current.GetNewsOficinaSafPrograma(Entity.Oficina.IdOficina);
            return oficinaSafCompose;
        }
        #region Methods
        void HidePopUpSafsOficina()
        {
            ModalPopupExtenderSafsOficina.Hide();
        }
        void ShowPopUpSafsOficina()
        {
            ModalPopupExtenderSafsOficina.Show();
        }
        //void BuscarOficinaSaf()
        //{
        //    int idSaf=UIHelper.GetInt(ddlOficinaSaf);
        //    if (idSaf == 0) return;
        //    SafResult Saf =SafService.Current.GetResult(new nc.SafFilter() { IdSaf = idSaf }).FirstOrDefault();
        //    if (Saf == null) return;
        //    ActualOficinaSaf.Saf.IdSaf = Saf.IdSaf;
        //    ActualOficinaSaf.Saf.Saf_Denominacion = Saf.Denominacion;
        //    ActualOficinaSaf.Saf.Saf_Codigo = Saf.Codigo;
        //    ActualOficinaSaf.Programas = OficinaComposeService.Current.GetNewsOficinaSafPrograma(new nc.ProgramaFilter() { IdSAF = idSaf });
        //}
        #endregion

        #region Clear SetValue GetValue Refresh
        void OficinaSafRefresh()
        {
            UIHelper.Load(gridSafs, Entity.ToSafResult());
            if (Entity.Safs.Count > 0)SelectOficinaFirstSaf();                      
            upGridSafs.Update();
        }
        void OficinaSafClear()
        {
            UIHelper.Clear(dlProgramas);
            UIHelper.Clear(ddlOficinaSaf);
            ActualOficinaSaf = GetNewOficinaSaf();
        }
        void OficinaSafSetValue()
        {            
            UIHelper.SetValue<Saf,int>(ddlOficinaSaf, ActualOficinaSaf.Saf.IdSaf,SafService.Current.GetById);
        }
        void OficinaSafGetValue()
        {
            int idSaf = UIHelper.GetInt(ddlOficinaSaf);
            if (ActualOficinaSaf.Saf.IdSaf != idSaf)
            {//cambio el SAF
                if (idSaf == 0) return;
                SafResult Saf = SafService.Current.GetResult(new nc.SafFilter() { IdSaf = idSaf }).FirstOrDefault();
                if (Saf == null) return;
                ActualOficinaSaf.Saf.IdSaf = Saf.IdSaf;
                ActualOficinaSaf.Saf.Saf_Denominacion = Saf.Denominacion;
                ActualOficinaSaf.Saf.Saf_Codigo = Saf.Codigo;
                ActualOficinaSaf.Programas = OficinaComposeService.Current.GetNewsOficinaSafPrograma(new nc.ProgramaFilter() { IdSAF = idSaf });
            }
        }
        #region Events
        protected void GridSafs_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualOficinaSaf = (from o in Entity.Safs where o.Saf.IdOficinaSaf == id select o).FirstOrDefault();
            
            switch (e.CommandName)
            {
                case Command.EDIT:
                    CallTryMethod(CommandOficinaSafEdit);
                    break;
                case Command.DELETE:
                    CallTryMethod(CommandOficinaSafDelete);
                    break;
            }
        }       
        protected void btSaveSafsOficina_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandOficinaSafSave);
            CallTryMethod(HidePopUpSafsOficina);
        }        
        protected void btCancelSafsOficina_Click(object sender, EventArgs e)
        {
            CallTryMethod(OficinaSafClear);
            CallTryMethod(HidePopUpSafsOficina);
        }
        protected void btAddAndNewSafsOficina_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandOficinaSafSave);
            CallTryMethod(OficinaSafClear);
        }
        protected void btAgregarSafOficina_Click(object sender, EventArgs e)
        {
            CallTryMethod(OficinaSafClear);
            CallTryMethod(ShowPopUpSafsOficina);
        }       
        #endregion

        #region Commands
        //Seteo controloles del PopUp
        //Muestro PopUp
        void CommandOficinaSafEdit()
        {
            OficinaSafSetValue();
            ShowPopUpSafsOficina();
        }
        void CommandOficinaSafSave()
        {            
            OficinaSafGetValue();
            
            foreach(OficinaSafProgramaResult pr in ActualOficinaSaf.Programas)
            {
                pr.Selected = true;
            }
            OficinaSafCompose oficinaSafCompose = (from l in Entity.Safs
                                          where l.Saf.IdOficinaSaf == ActualOficinaSaf.Saf.IdOficinaSaf
                                          select l).FirstOrDefault();                    
            if (oficinaSafCompose != null)
            {                
                ActualOficinaSaf.Saf=oficinaSafCompose.Saf;
                oficinaSafCompose.Programas = ActualOficinaSaf.Programas;
            }
            else
            {
                Entity.Safs.Add(ActualOficinaSaf);
            }
            OficinaSafClear();
            
            OficinaSafRefresh();
            RefreshDefaultSafs();
            HidePopUpSafsOficina();
            SelectOficinaSaf(ActualOficinaSaf.Saf.IdOficinaSaf);
            if (Entity.Safs.Count == 1)
            {
                UIHelper.Load<nc.OficinaSafResult>(ddlSaf, Entity.ToSafResult(), "Saf_Denominacion", "IdSaf", new nc.OficinaSafResult() { IdSaf = 0, Saf_Denominacion = "Seleccione Saf" });
                UIHelper.SetValue<Saf, int>(ddlSaf, ActualOficinaSaf.Saf.IdSaf, SafService.Current.GetById);
                BuscarJurisdiccion();
            }
        }
        void CommandOficinaSafDelete()
        {
            OficinaSafCompose oficinaSafCompose = (from l in Entity.Safs
                                                   where l.Saf.IdOficinaSaf == ActualOficinaSaf.Saf.IdOficinaSaf
                                                   select l).FirstOrDefault();
            if (oficinaSafCompose != null)
            {
                Entity.Safs.Remove(ActualOficinaSaf);
                int IdSafPropio = Convert.ToInt32(ddlSaf.SelectedValue);
                UIHelper.Load<nc.OficinaSafResult>(ddlSaf, Entity.ToSafResult(), "Saf_Denominacion", "IdSaf", new nc.OficinaSafResult() { IdSaf = 0, Saf_Denominacion = "Seleccione Saf" });

                if (IdSafPropio != ActualOficinaSaf.Saf.IdSaf)
                {
                    UIHelper.SetValue<Saf, int>(ddlSaf, IdSafPropio, SafService.Current.GetById);
                }
                else
                {
                    BuscarJurisdiccion();
                }

            }
            

            OficinaSafClear();
            OficinaSafRefresh();
            RefreshDefaultSafs();
            SelectOficinaFirstSaf();
        }
        #endregion
        #region OficinaSafPrograma
        void SelectOficinaFirstSaf()
        {
            if (Entity.Safs.Count() > 0)
                SelectOficinaSaf(Entity.Safs[0].Saf.IdOficinaSaf);
        }
        void SelectOficinaSaf(int idOficinaSaf)
        {
            if (ActualOficinaSaf != null)
            {//guada la anterior seleccion
                OficinaSafProgramaSave();
            }
            //Obtiene el Actual OficinaSaf
            ActualOficinaSaf = (from o in Entity.Safs where o.Saf.IdOficinaSaf == idOficinaSaf select o).FirstOrDefault();
            //Refrescar la lista de Programas
            OficinaSafProgramaEdit();
        }
        void OficinaSafProgramaEdit()
        {
            UIHelper.Sort<OficinaSafProgramaResult>(ActualOficinaSaf.Programas, "Programa_Codigo");
            UIHelper.SetValue(dlProgramas, ActualOficinaSaf.Programas);            
            UIHelper.SetValue(chkTodosProgramas, ActualOficinaSaf.Programas.Count(p => p.Selected) == ActualOficinaSaf.Programas.Count);
            upProgramas.Update();
        }
        void OficinaSafProgramaSave()
        {
            if (ActualOficinaSaf != null)
            {
                Update(dlProgramas, ActualOficinaSaf.Programas);
                OficinaSafCompose oficinaSafCompose = (from l in Entity.Safs
                                                       where l.Saf.IdOficinaSaf == ActualOficinaSaf.Saf.IdOficinaSaf
                                                       select l).FirstOrDefault();
                if (oficinaSafCompose != null)
                {
                    oficinaSafCompose.Programas = ActualOficinaSaf.Programas;
                }
            }
        }
        void Update(DataList dataList, List<OficinaSafProgramaResult> list)
        {
            for (int i = 0; i < dataList.Items.Count; i++)
            {
                bool isChecked = ((CheckBox)dataList.Items[i].FindControl("chk")).Checked;
                int value = int.Parse(((HiddenField)dataList.Items[i].FindControl("hdValue")).Value);
                OficinaSafProgramaResult item = (from o in list where o.IdPrograma == value select o).FirstOrDefault();
                if (item == null) continue;
                item.Selected = isChecked;
            }
        }
        #region Events
        //Coloco como checked el 1ro
        protected void GridSafs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == 0)
                ((RadioButton)e.Row.Cells[0].FindControl("rbSaf")).Checked = true;
        }
        public void rbSaf_OnCheckedChanged(object sender, EventArgs e)
        {
            //obtiene el Id Seleccionado
            GridViewRow gvr = ((GridViewRow)((WebControl)sender).NamingContainer);
            Int32 idOficinaSaf = Int32.Parse(gridSafs.DataKeys[gvr.RowIndex].Value.ToString());
            //Desselecciona los otros rows(si es que estan seleccioando)
            foreach (GridViewRow row in gridSafs.Rows)
            {
                Int32 idRowAux = Int32.Parse(gridSafs.DataKeys[row.RowIndex].Value.ToString());
                RadioButton rb = ((RadioButton)row.Cells[0].FindControl("rbSaf"));
                if (rb.Checked && idRowAux != idOficinaSaf) rb.Checked = false;
            }
            //Muestra el Saf Seleccionado
            SelectOficinaSaf(idOficinaSaf);
        }
        protected void chkTodosProgramas_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool chk = chkTodosProgramas.Checked;
                //Marco todas las provincias como seleccionadas
                foreach (DataListItem item in dlProgramas.Items)
                {
                    CheckBox c = (CheckBox)item.FindControl("chk");
                    c.Checked = chk;
                }
            }
            catch { }

        }
        #endregion
        #endregion

        #endregion

        #region Events
        protected void ddlSafPropio_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarJurisdiccion);
        }
        #endregion

        private void BuscarJurisdiccion()
        {
            Int32 idSafPropio = UIHelper.GetInt(ddlSaf);
            if (idSafPropio == 0)
            {
                txtJurisdiccion.Text = "";
            }
            else
            {
                txtJurisdiccion.Text = SafService.Current.GetList(new nc.SafFilter() {  IdSaf= idSafPropio }).FirstOrDefault().Jurisdiccion.Nombre;
            }
        }
        #endregion
    }
}
