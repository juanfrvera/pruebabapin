<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsuarioList.ascx.cs" Inherits=" UI.Web.UsuarioList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:BoundField DataField="IdUsuario" HeaderText="Usuario" SortExpression="IdUsuario" HeaderStyle-Width="8%"/>
	<asp:TemplateField   HeaderText="NombreUsuario"  SortExpression="NombreUsuario" HeaderStyle-Width="26%" >            
            <ItemTemplate>
                <asp:Label ID="lblNombreUsuario" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("NombreUsuario"),25) %>' ToolTip='<%# Eval("NombreUsuario") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Clave"  SortExpression="Clave" HeaderStyle-Width="26%"  >            
            <ItemTemplate>
                <asp:Label ID="lblClave" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Clave"),25) %>' ToolTip='<%# Eval("Clave") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" HeaderStyle-Width="8%"/>
	<asp:CheckBoxField DataField="EsSectioralista" HeaderText="EsSectioralista" SortExpression="EsSectioralista" HeaderStyle-Width="8%" />
	<asp:BoundField DataField="Language_Name" HeaderText="Language" SortExpression="Language_Name" HeaderStyle-Width="15%"/>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	     </ItemTemplate>  
        </asp:TemplateField>
    </Columns>
</asp:GridView>
