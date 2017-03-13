<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SistemaEntidadList.ascx.cs" Inherits=" UI.Web.SistemaEntidadList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:TemplateField   HeaderText="Código"  SortExpression="Codigo"  HeaderStyle-Width="13%">            
            <ItemTemplate>
                <asp:Label ID="lblCodigo" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Codigo"),20) %>' ToolTip='<%# Eval("Codigo") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Nombre"  SortExpression="Nombre"  HeaderStyle-Width="14%">            
            <ItemTemplate>
                <asp:Label ID="lblNombre" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Nombre"),35) %>' ToolTip='<%# Eval("Nombre") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Clase de Entidad"  SortExpression="EntidadClase" HeaderStyle-Width="15%" >            
            <ItemTemplate>
                <asp:Label ID="lblEntidadClase" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntidadClase"),35) %>' ToolTip='<%# Eval("EntidadClase") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Clase Base de Entidad"  SortExpression="EntidadClaseBase" HeaderStyle-Width="15%" >            
            <ItemTemplate>
                <asp:Label ID="lblEntidadClaseBase" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntidadClaseBase"),35) %>' ToolTip='<%# Eval("EntidadClaseBase") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" HeaderStyle-Width="8%" />
	<asp:CheckBoxField DataField="IncluirSeguridad" HeaderText="Seguridad" SortExpression="IncluirSeguridad" HeaderStyle-Width="8%" />
	<asp:CheckBoxField DataField="IncluirConfiguracion" HeaderText="Configuración" SortExpression="IncluirConfiguracion" HeaderStyle-Width="8%" />
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				<!--&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />-->            
       	     </ItemTemplate>         
            <ItemStyle Width ="80px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
