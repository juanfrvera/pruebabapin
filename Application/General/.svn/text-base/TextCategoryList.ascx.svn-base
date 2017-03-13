<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextCategoryList.ascx.cs" Inherits=" UI.Web.TextCategoryList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:TemplateField   HeaderText="Nombre"  SortExpression="Name"  HeaderStyle-Width="30%">            
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Name"),25) %>' ToolTip='<%# Eval("Name") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Descripción"  SortExpression="Description"  HeaderStyle-Width="61%">            
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Description"),50) %>' ToolTip='<%# Eval("Description") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<!--<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />-->            
       	     </ItemTemplate>           
            <ItemStyle />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
