<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextList.ascx.cs" Inherits=" UI.Web.TextList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:TemplateField   HeaderText="Código"  SortExpression="Code"    HeaderStyle-Width="16%">            
            <ItemTemplate>
                <asp:Label ID="lblCode" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Code"),20) %>' ToolTip='<%# Eval("Code") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Descripción"  SortExpression="Description"  HeaderStyle-Width="22%">            
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Description"),35) %>' ToolTip='<%# Eval("Description") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="TextCategory_Name" HeaderText="Texto Categoría" SortExpression="TextCategory_Name" HeaderStyle-Width="12%" />
	<asp:CheckBoxField DataField="IsAutomaticLoad" HeaderText="Carga Autom." SortExpression="IsAutomaticLoad" HeaderStyle-Width="10%"/>
	<asp:BoundField DataField="StartDate" HeaderText="Fecha de Inicio" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="8%"/>
	<asp:CheckBoxField DataField="Checked" HeaderText="Cheq." SortExpression="Checked" HeaderStyle-Width="6%"/>
	<asp:BoundField DataField="CheckedDate" HeaderText="Fecha Chequeado" SortExpression="CheckedDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="8%"/>
	<asp:BoundField DataField="UsuarioChecked_NombreUsuario" HeaderText="Usuario Controlador" SortExpression="UsuarioChecked_NombreUsuario" HeaderStyle-Width="8%"/>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				<!--&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />-->            
       	     </ItemTemplate>            
            <ItemStyle />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
