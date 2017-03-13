<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigurationList.ascx.cs" Inherits=" UI.Web.ConfigurationList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:TemplateField   HeaderText="Nombre"  SortExpression="Name"  HeaderStyle-Width="15%">            
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Name"),25) %>' ToolTip='<%# Eval("Name") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Código"  SortExpression="Code"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblCode" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Code"),25) %>' ToolTip='<%# Eval("Code") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Descripción"  SortExpression="Description"  HeaderStyle-Width="24%">            
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Description"),25) %>' ToolTip='<%# Eval("Description") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="ConfigurationCategory_Name" HeaderText="Categoría e Configuración" SortExpression="ConfigurationCategory_Name" HeaderStyle-Width="12%"/>
	<asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" HeaderStyle-Width="8%"/>
	<asp:BoundField DataField="SistemaEntidad_Nombre" HeaderText="Entidad del Sistema" SortExpression="SistemaEntidad_Nombre" HeaderStyle-Width="12%"/>
	<asp:BoundField DataField="Estado_Nombre" HeaderText="Estado" SortExpression="Estado_Nombre" HeaderStyle-Width="12%"/>
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
