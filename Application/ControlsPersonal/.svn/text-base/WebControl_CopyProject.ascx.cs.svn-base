using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;

namespace UI.Web
{

   


    public partial class WebControl_CopyProject : WebControlPopup
    {
        protected ProyectCopy Result = new ProyectCopy();

        #region Methods 
        protected override void _Initialize()
        {
            base._Initialize();
            List<SimpleIntResult> list = new List<SimpleIntResult>(10);
            for(int i=1;i<=10;i++)
                list.Add(new SimpleIntResult(){ ID = i,Text=i.ToString()});
            UIHelper.Load<SimpleIntResult>(ddlOffset, list, "Text", "ID", new SimpleIntResult() { ID = 0, Text = "Seleccione Desplazamiento" }, false);

            //Matias 20140319 - Tarea 129 - Error ==> Investigar!
            //btAceptar.Attributes.Add("onclick", "PleaseWaitButton('" + btAceptar.ClientID + "');$('" + btCancelar.ClientID + "').disabled=true; ");     
            // >> Hay que analizar la funcion javascript PleaseWaitButton...
            // >> Por ahora funciona pero no deshabilita el boton ACEPTAR con lo cual hay que tener cuidado porque puede generar varias copias!
            btAceptar.Attributes.Add("onclick", " $('" + btCancelar.ClientID + "').disabled=true; $('" + btAceptar.ClientID + "').value= 'Procesando... (Espere por favor)' "); /*$('" + btAceptar.ClientID + "').disabled=true;  "Procesando.. Espere por favor...";*/
            //FinMatias 20140319 - Tarea 129
        
        }
        public override void HidePopup()
        {
            Clear();
            mpePopupCopy.Hide();
        }
        public override void ShowPopup()
        {
            mpePopupCopy.Show();
            upControls.Update();
        }
        public void Aceptar()
        {
            GetValue();
            RaiseControlCommand(CommandName, Result);
			//Matias 20140331 - Tarea 131
            UIHelper.ShowAlert(SolutionContext.Current.TextManager.Translate("MSG_NEWPROJECT") + " " + Result.Codigo, this.Page);
            //FinMatias 20140331 - Tarea 131
        }
        public string Nombre
        {
            get { return txtNombre.Text; }
            set { this.txtNombre.Text = value; }
        }
        public void Clear()
        {
            chkGeneral.Enabled = false;
            UIHelper.SetValue(chkGeneral, true);
            UIHelper.Clear(chkAlcanceGeografico);
            UIHelper.Clear(chkCronograma);
            UIHelper.Clear(chkEvaluacion);
            UIHelper.Clear(chkProductoIntermedio);
            UIHelper.Clear(chkObjetivos);
            UIHelper.Clear(ddlOffset);
            UIHelper.Clear(txtNombre);
            chkCronograma.Enabled = false;  
            ddlOffset.Enabled = false;  
            upControls.Update();
        }
        protected void GetValue()
        {
            int id;
            if (int.TryParse(CommandValue, out id))
                Result.IdProject = id;

            Result.Rename = UIHelper.GetString(txtNombre);
            Result.Solapas.General = UIHelper.GetBoolean(chkGeneral);
            Result.Solapas.AlcanceGeografico = UIHelper.GetBoolean(chkAlcanceGeografico);
            Result.Solapas.Cronograma = UIHelper.GetBoolean(chkCronograma);
            Result.Solapas.ProductosIntermedios = UIHelper.GetBoolean(chkProductoIntermedio);
            Result.Solapas.Evaluacion = UIHelper.GetBoolean(chkEvaluacion);
            Result.Solapas.Objetivos = UIHelper.GetBoolean(chkObjetivos);
            Result.Offset = UIHelper.GetInt(ddlOffset);
        }
        #endregion 

        #region Events
        protected void chkProductoIntermedio_CheckedChanged(Object sender, EventArgs e)
        {
            if (chkProductoIntermedio.Checked)
            {
                this.chkCronograma.Checked = true;
                ddlOffset.Enabled = true;
                chkCronograma.Enabled = true;
            }
            else
            {
                UIHelper.SetValue(ddlOffset, 0);
                chkCronograma.Checked = false;
                ddlOffset.Enabled = false;
                chkCronograma.Enabled = false;
            }
            upControls.Update();
 
        }

        protected void chkCronograma_CheckedChanged(Object sender, EventArgs e)
        {
            if (chkCronograma.Checked)
            {
                chkProductoIntermedio.Checked = true;
                ddlOffset.Enabled = true;
            }
            else
            {
                UIHelper.SetValue(ddlOffset, 0);
                ddlOffset.Enabled = false;

            }
            upControls.Update();
        }





        protected void btAceptar_Click(object sender, EventArgs e)
        {
            CallTryMethod(Aceptar);
        }
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            CallTryMethod(HidePopup);
        }
        #endregion

        

        
    }
}