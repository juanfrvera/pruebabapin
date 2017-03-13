<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextLanguageList.ascx.cs" Inherits=" UI.Web.TextLanguageList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:BoundField DataField="Text_Code" HeaderText="Código de Texto" SortExpression="Text_Code" HeaderStyle-Width="8%"/>
	<asp:BoundField DataField="Language_Name" HeaderText="Lenguaje" SortExpression="Language_Name" HeaderStyle-Width="12%"/>
	<asp:TemplateField   HeaderText="Traducción"  SortExpression="TranslateText" HeaderStyle-Width="20%" >            
            <ItemTemplate>
                <asp:Label ID="lblTranslateText" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("TranslateText"),30) %>' ToolTip='<%# Eval("TranslateText") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:CheckBoxField DataField="IsAutomaticLoad" HeaderText="Carga Automática" SortExpression="IsAutomaticLoad" HeaderStyle-Width="10%"/>
	<asp:BoundField DataField="StartDate" HeaderText="Fecha Inicio" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="10%"/>
	<asp:CheckBoxField DataField="Checked" HeaderText="Chequeado" SortExpression="Checked" HeaderStyle-Width="10%"/>
	<asp:BoundField DataField="CheckedDate" HeaderText="Fecha Chequeado" SortExpression="CheckedDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="10%"/>
	<asp:BoundField DataField="UsuarioChecked_NombreUsuario" HeaderText="Usuario Chequeado" SortExpression="UsuarioChecked_NombreUsuario" HeaderStyle-Width="11%"/>
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
