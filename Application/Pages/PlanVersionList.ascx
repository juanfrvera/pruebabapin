<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlanVersionList.ascx.cs" Inherits=" UI.Web.PlanVersionList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:BoundField DataField="PlanTipo_Nombre" HeaderText="Tipo de Plan" SortExpression="PlanTipo_Nombre" HeaderStyle-Width="20%" />
	<asp:TemplateField   HeaderText="Nombre"  SortExpression="Nombre" HeaderStyle-Width="55%" >            
            <ItemTemplate>
                <asp:Label ID="lblNombre" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Nombre"),100) %>' ToolTip='<%# Eval("Nombre") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="Orden" HeaderText="Orden" SortExpression="Orden" HeaderStyle-Width="8%"/>
	<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" HeaderStyle-Width="8%"/>
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
