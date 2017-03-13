<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageList.ascx.cs" Inherits=" UI.Web.MessageList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:BoundField DataField="MessageMedia_Name" HeaderText="MediaFrom" SortExpression="MessageMedia_Name" HeaderStyle-Width="12%"/>
	<asp:BoundField DataField="Usuario_NombreUsuario" HeaderText="De" SortExpression="Usuario_NombreUsuario" HeaderStyle-Width="12%"/>
	<asp:BoundField DataField="Priority_Name" HeaderText="Prioridad" SortExpression="Priority_Name" HeaderStyle-Width="8%"/>
	<asp:TemplateField   HeaderText="Asunto"  SortExpression="Subject"  HeaderStyle-Width="12%">            
            <ItemTemplate>
                <asp:Label ID="lblSubject" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Subject"),25) %>' ToolTip='<%# Eval("Subject") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Contenido"  SortExpression="Body"  HeaderStyle-Width="21%">            
            <ItemTemplate>
                <asp:Label ID="lblBody" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Body"),25) %>' ToolTip='<%# Eval("Body") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="StartDate" HeaderText="Fecha" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="8%"/>
	<asp:BoundField DataField="SendDate" HeaderText="Fecha de Envío" SortExpression="SendDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="8%"/>
	<asp:CheckBoxField DataField="IsManual" HeaderText="Es Manual" SortExpression="IsManual" HeaderStyle-Width="8%"/>
	<asp:BoundField DataField="Proyecto_ProyectoDenominacion" HeaderText="BAPIN" SortExpression="Proyecto_ProyectoDenominacion" HeaderStyle-Width="12%"/>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	     </ItemTemplate>             
            <ItemStyle />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
