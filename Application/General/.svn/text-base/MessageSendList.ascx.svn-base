<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageSendList.ascx.cs" Inherits=" UI.Web.MessageSendList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
        <asp:BoundField DataField="Message_StartDate" HeaderText="Fecha" SortExpression="Message_StartDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="8%"/>
	    <asp:BoundField DataField="Message_UserFrom_NombreCompleto" HeaderText="De" SortExpression="Message_UserFrom_NombreCompleto" HeaderStyle-Width="15%"/>
	    <asp:BoundField DataField="UserTo_NombreCompleto" HeaderText="Para" SortExpression="UserTo_NombreCompleto" HeaderStyle-Width="15%"/>
	    <asp:BoundField DataField="Message_NamePriority" HeaderText="Prioridad" SortExpression="Message_NamePriority" HeaderStyle-Width="8%"/>
	    <asp:BoundField DataField="Message_Proyecto_Codigo" HeaderText="Código BAPIN" SortExpression="Message_Proyecto_Codigo" HeaderStyle-Width="12%"/>
	    <asp:TemplateField   HeaderText="Asunto"  SortExpression="Message_Subject" HeaderStyle-Width="13%" >            
                <ItemTemplate>
                    <asp:Label ID="lblSubject" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Message_Subject"),20) %>' ToolTip='<%# Eval("Message_Subject") %>'  ></asp:Label>
                </ItemTemplate>
        </asp:TemplateField>
        <asp:CheckBoxField DataField="IsRead" HeaderText="Leído" SortExpression="IsRead" HeaderStyle-Width="6%"/>
	    <asp:CheckBoxField DataField="Message_IsManual" HeaderText="Es Manual" SortExpression="Message_IsManual" HeaderStyle-Width="8%"/>
	    <asp:BoundField DataField="ReadDate" HeaderText="Fecha Leído" SortExpression="ReadDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="9%"/>
		<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="6%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"   src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	     </ItemTemplate>           
            <ItemStyle  />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
