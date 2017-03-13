using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;
using Newtonsoft.Json;

namespace UI.Web
{
    

    public partial class ActividadEdit : WebControlEdit<nc.ActividadCompose>
    { 
		protected override void _Initialize()
        {   
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
		}
        protected override void _Load()
        {
            base._Load();
            System.Web.UI.HtmlControls.HtmlForm frm = (System.Web.UI.HtmlControls.HtmlForm)this.Page.Master.FindControl("formMaster");
            frm.Attributes.Add("onSubmit", "AlwaysFireBeforeFormSubmit();");
        }
		public override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
			UIHelper.Clear(chkActivo);				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtNombre, Entity.Actividad.Nombre);
			txtNombre.Focus();
			UIHelper.SetValue(chkActivo, Entity.Actividad.Activo);
            UIHelper.SetValue(hdTreeData,JsonConvert.SerializeObject(Entity.GetActividadPermisosNodes()));
            //UIHelper.SetValue(tvPermisos, Entity.GetActividadPermisosNodes());	
        }	
        public override void GetValue()
        {
			Entity.Actividad.Nombre =UIHelper.GetString(txtNombre);
			Entity.Actividad.Activo=UIHelper.GetBoolean(chkActivo);
            List<NodeModel> nodes = JsonConvert.DeserializeObject<List<NodeModel>>(hdTreeData.Value);
            Update(nodes, Entity.ActividadPermisos);	
            //Update(tvPermisos.Nodes, Entity.ActividadPermisos);	
        }
        protected void Update(List<NodeModel> nodes, List<ActividadPermisoResult> actividadPermisos)
        {
            int idPermiso;
            ActividadPermisoResult actividadPermiso;
            foreach (NodeModel node in nodes)
            {
                if (int.TryParse(node.Value, out idPermiso))
                {
                    actividadPermiso = (from o in actividadPermisos where o.IdPermiso == idPermiso select o).FirstOrDefault();
                    if (actividadPermiso != null)
                        actividadPermiso.Selected = node.Checked;
                    if (node.Childs.Count > 0)
                        Update(node.Childs, actividadPermisos);
                }
            }
        }
        //protected void Update(TreeNodeCollection nodes, List<ActividadPermisoResult> actividadPermisos)
        //{
        //    int idPermiso;
        //    ActividadPermisoResult actividadPermiso;
        //    foreach (TreeNode node in nodes)
        //    {
        //        if (int.TryParse(node.Value, out idPermiso))
        //        {
        //            actividadPermiso = (from o in actividadPermisos where o.IdPermiso == idPermiso select o).FirstOrDefault();
        //            if (actividadPermiso != null)
        //                actividadPermiso.Selected = node.Checked;
        //            if (node.ChildNodes.Count > 0)
        //                Update(node.ChildNodes,actividadPermisos);
        //        }
        //    }
        //}

    }
}
