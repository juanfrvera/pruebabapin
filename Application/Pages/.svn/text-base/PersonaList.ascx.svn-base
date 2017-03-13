<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonaList.ascx.cs" Inherits=" UI.Web.PersonaList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"         
    >
    <Columns> 
    <asp:TemplateField   HeaderText="Apellido y Nombre"  SortExpression="NombreCompleto"  HeaderStyle-Width ="17%" >            
            <ItemTemplate>
                <asp:Label ID="lblApellidoNombre" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("NombreCompleto"),20) %>' ToolTip='<%# Eval("Nombre") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="Oficina_BreadcrumbCode" HeaderText="Of. Código" SortExpression="Oficina_BreadcrumbCode" HeaderStyle-Width="14%"/>
    <asp:TemplateField   HeaderText="Oficina"  SortExpression="Oficina_Nombre"  HeaderStyle-Width ="30%" >            
            <ItemTemplate>
                <asp:Label ID="lblOficina" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Oficina_Nombre"),40) %>' ToolTip='<%# Eval("Oficina_Nombre") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Tel. Laboral"  SortExpression="TelefonoLaboral" HeaderStyle-Width ="12%"  >            
            <ItemTemplate>
                <asp:Label ID="lblTelefonoLaboral" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("TelefonoLaboral"),20) %>' ToolTip='<%# Eval("TelefonoLaboral") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:CheckBoxField DataField="EsUsuario" HeaderText="Usuario" SortExpression="EsUsuario"  HeaderStyle-Width ="5%"/>
	<asp:CheckBoxField DataField="EsContacto" HeaderText="Contacto" SortExpression="EsContacto"  HeaderStyle-Width ="5%"/>
	<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo"  HeaderStyle-Width ="5%"/>
	<asp:TemplateField  ItemStyle-HorizontalAlign="Right"  HeaderStyle-Width ="12%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	     </ItemTemplate>            
            <ItemStyle Width="90px"  HorizontalAlign ="Right"/>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
