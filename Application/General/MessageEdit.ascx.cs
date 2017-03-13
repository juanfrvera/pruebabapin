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
    public partial class MessageEdit : WebControlEdit<nc.MessageCompose>
    {

        #region Override
        protected override void _Initialize()
        {
            base._Initialize(); 
            UIHelper.Load<nc.Priority>(ddlPriority, PriorityService.Current.GetList(),"Name","IdPriority",new nc.Priority(){IdPriority=0, Name=  "Seleccione Prioridad"});
			revSubject.ValidationExpression=Contract.DataHelper.GetExpRegString(500);
            revBapinCode.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullable();
            revSubject.ErrorMessage = TranslateFormat("InvalidField", "Asunto");
            rfvSubject.ErrorMessage = TranslateFormat("FieldIsNull", "Asunto");
            rfvPriority.ErrorMessage = TranslateFormat("FieldIsNull", "Prioridad");
            revBapinCode.ErrorMessage = TranslateFormat("InvalidField", "BAPIN");

            txtBody.AutoSave = true;
            txtBody.updateHtml = true;
			//revBody.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
	    }
        protected override void _Load()
        {
            base._Load();            
            //acUserTo.ValueChanged += new EventHandler(acUserTo_ValueChanged);
            //acUserTo.ClearControl += new EventHandler(acUserTo_ClearControl);

        }        
		public override void Clear()
        {
            txtBapinCode.Focus();
            UIHelper.Clear(lbFromUser);
            UIHelper.Clear(hdFromUser);
            UIHelper.Clear(autoCmpDestinatario);
			UIHelper.Clear(ddlPriority);
			UIHelper.Clear(txtSubject);
			UIHelper.Clear(txtBody);
            UIHelper.Clear(txtBapinCode);
            UIHelper.Clear(lbDenominacion);
            UIHelper.Clear(dlUsersTo);
        }		
        public override void SetValue()
        {
            if (CrudAction == CrudActionEnum.Create)
            {
                UIHelper.SetValue(lbFromUser, UIContext.Current.ContextUser.User.Persona_NombreCompleto);
                UIHelper.SetValue(hdFromUser, UIContext.Current.ContextUser.User.IdUsuario);
            }
            else
            {
                UIHelper.SetValue(lbFromUser, Entity.Message.UserFrom_NombreCompleto);
                UIHelper.SetValue(hdFromUser, Entity.Message.IdUserFrom);
            }
            autoCmpDestinatario.Focus();
            UIHelper.SetValue(ddlPriority, Entity.Message.IdPriority);
            UIHelper.SetValue(txtSubject, Entity.Message.Subject);
            UIHelper.SetValue(txtBody, Entity.Message.Body);
            UIHelper.SetValue(txtBapinCode, Entity.Message.Proyecto_Codigo);
        }	
        public override void GetValue()
        {
            Entity.Message.IdUserFrom = UIHelper.GetInt(hdFromUser);
            Entity.Message.UserFrom_NombreCompleto = UIHelper.GetString(lbFromUser);

            Entity.Message.IdPriority = UIHelper.GetInt(ddlPriority);
            Entity.Message.Subject = UIHelper.GetString(txtSubject);
            Entity.Message.Body = UIHelper.GetString(txtBody);
            Entity.Message.Proyecto_Codigo = UIHelper.GetIntNullable(txtBapinCode);
            //int? numero = UIHelper.GetIntNullable(txtBapinCode);
            //if (numero != null)
            //{
            //    ProyectoResult proyecto = ProyectoService.Current.GetResult(new nc.ProyectoFilter() { Codigo = numero }).FirstOrDefault();
            //    Entity.Message.IdProyecto = proyecto.IdProyecto;
            //}

            //asigna 0 a los ids negativos.
            Entity.MessageSends.ForEach(p => p.IdMessageSend = p.IdMessageSend < 0 ? 0 : p.IdMessageSend);
        }
        #endregion



        protected void btSearchProyecto_Click(object sender, EventArgs e)
        {
            int? numero = UIHelper.GetIntNullable(txtBapinCode);
            if (numero != null)
            {
                ProyectoResult proyecto = ProyectoService.Current.GetResult(new nc.ProyectoFilter() { Codigo = numero }).FirstOrDefault();
                if (proyecto == null)
                {
                    UIHelper.ShowAlert(TranslateFormat("InvalidField", "BAPIN"), upBapinBuscar);
                }
                else
                {
                    lbDenominacion.Text = proyecto.ProyectoDenominacion;
                }
            }
            else
            {
                lbDenominacion.Text = "";
            }
        }  

        
                      
            
        #region MassageSend
        private MessageSendResult actualMassageSend;
        protected MessageSendResult ActualMassageSend
        {
            get
            {
                if (actualMassageSend == null)
                    if (ViewState["actualMassageSend"] != null)
                        actualMassageSend = ViewState["actualMassageSend"] as MessageSendResult;
                    else
                    {
                        actualMassageSend = GetNewMessageSend();
                        ViewState["actualMassageSend"] = actualMassageSend;
                    }
                return actualMassageSend;
            }
            set
            {
                actualMassageSend = value;
                ViewState["actualMassageSend"] = value;
            }
        }
        MessageSendResult GetNewMessageSend()
        {
            int id = 0;
            if (Entity.MessageSends.Count > 0) id = Entity.MessageSends.Min(o => o.IdMessageSend);
            if (id > 0) id = 0;
            id--;
            MessageSendResult messageResult = new MessageSendResult();
            MessageSendService.Current.Set(MessageSendService.Current.GetNew(), messageResult);
            messageResult.IdMessageSend = id;
            return messageResult;
        }        
        #region Clear SetValue GetValue Refresh
        void MessageSendClear()
        {
            UIHelper.Clear(autoCmpDestinatario);
            ActualMassageSend = GetNewMessageSend();
            autoCmpDestinatario.Focus();
        }
        void MessageSendSetValue()
        {            
        }
        void MessageSendGetValue()
        {
            ActualMassageSend.IdUserTo = UIHelper.GetInt(autoCmpDestinatario);
            ActualMassageSend.UserTo_NombreCompleto = UIHelper.GetString(autoCmpDestinatario);
        }
        void MassageSendRefresh()
        {
            UIHelper.SetValue(dlUsersTo, Entity.MessageSends);
        }
        #endregion

        #region Commands
        void MessageSendCommandSave()
        {
            MessageSendGetValue();
            MessageSendResult a = (from o in Entity.MessageSends where o.IdMessageSend == ActualMassageSend.ID select o).FirstOrDefault();
            if (a != null)
            {
                a.IdUserTo = ActualMassageSend.IdUserTo;
                a.UserTo_NombreCompleto = ActualMassageSend.UserTo_NombreCompleto;
            }
            else
            {
                Entity.MessageSends.Add(ActualMassageSend);
            }
            MessageSendClear();
            MassageSendRefresh();
        }
        void MessageSendCommandDelete()
        {
            MessageSendResult a = (from o in Entity.MessageSends where o.IdMessageSend == ActualMassageSend.ID select o).FirstOrDefault();
            Entity.MessageSends.Remove(a);
            MessageSendClear();
            MassageSendRefresh();
        }
        #endregion
        #region Events

        protected void btAgregarDestinatario_Click(object sender, EventArgs e)
        {
            if (autoCmpDestinatario.Value != null && autoCmpDestinatario.Value.ID != 0)
                if((from o in Entity.MessageSends where o.IdUserTo == autoCmpDestinatario.Value.ID select o).Count()==0)
                    UIHelper.CallTryMethod(MessageSendCommandSave);
        }
        protected void dlUsersTo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                int id;
                if (!int.TryParse(e.CommandArgument.ToString(), out id))
                    return;
                ActualMassageSend = (from o in Entity.MessageSends where o.IdMessageSend == id select o).FirstOrDefault();

                switch (e.CommandName)
                {
                    case Command.EDIT:
                        MessageSendCommandSave();
                        break;
                    case Command.DELETE:
                        MessageSendCommandDelete();
                        break;
                }
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion
        #endregion

        
    }
}
