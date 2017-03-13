<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PerfilActividadList.ascx.cs" Inherits=" UI.Web.PerfilActividadList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:BoundField DataField="Perfil_Nombre" HeaderText="Perfil" SortExpression="Perfil_Nombre" HeaderStyle-Width="50%"/>
	<asp:BoundField DataField="Actividad_Nombre" HeaderText="Actividad" SortExpression="Actividad_Nombre" HeaderStyle-Width="41%"/>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	     </ItemTemplate>            
            <ItemStyle Width ="80px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
