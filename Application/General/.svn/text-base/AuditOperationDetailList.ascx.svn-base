<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditOperationDetailList.ascx.cs" Inherits=" UI.Web.AuditOperationDetailList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:BoundField DataField="AuditOperation_UserName" HeaderText="AuditOperation" SortExpression="AuditOperation_UserName" HeaderStyle-Width="33%"/>
	<asp:BoundField DataField="ParentId" HeaderText="Parent" SortExpression="ParentId" HeaderStyle-Width="8%"/>
	<asp:TemplateField   HeaderText="Deatil"  SortExpression="Deatil"  HeaderStyle-Width="34%">            
            <ItemTemplate>
                <asp:Label ID="lblDeatil" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Deatil"),25) %>' ToolTip='<%# Eval("Deatil") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="8%"/>
	<asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="8%"/>
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
