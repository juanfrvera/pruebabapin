<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParameterList.ascx.cs" Inherits=" UI.Web.ParameterList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
    <asp:TemplateField   HeaderText="Nombre"  SortExpression="Name" HeaderStyle-Width="20%" >            
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Name"),30) %>' ToolTip='<%# Eval("Name") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<%--<asp:TemplateField   HeaderText="Código"  SortExpression="Code"  HeaderStyle-Width="15%">            
            <ItemTemplate>
                <asp:Label ID="lblCode" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Code"),20) %>' ToolTip='<%# Eval("Code") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
    --%>
	<asp:TemplateField   HeaderText="Descripción"  SortExpression="Description"  HeaderStyle-Width="28%">            
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Description"),45) %>' ToolTip='<%# Eval("Description") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="ParameterCategory_Name" HeaderText="Categoría" SortExpression="ParameterCategory_Name" HeaderStyle-Width="11%"/>
	<asp:TemplateField   HeaderText="String"  SortExpression="StringValue" HeaderStyle-Width="13%" >            
            <ItemTemplate>
                <asp:Label ID="lblStringValue" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("StringValue"),20) %>' ToolTip='<%# Eval("StringValue") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="NumberValue" HeaderText="Número" SortExpression="NumberValue" DataFormatString="{0:F2}"  HeaderStyle-Width="8%"/>
	<asp:BoundField DataField="DateValue" HeaderText="Fecha" SortExpression="DateValue" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="8%"/>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="12%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btCopy" runat ="server"  src="../Images/copy.png" ToolTip='<%# Translate("Copiar") %>'    CssClass='<%# CanById(Eval("ID"),Contract.ActionConfig.COPY)?"":"ibDisable" %>' Enabled='<%# CanById(Eval("ID"),Contract.ActionConfig.COPY) %>'  CommandName='<%# Command.SHOW_POPUP_COPY_AND_SAVE %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				<!--&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />-->            
       	     </ItemTemplate>             
            <ItemStyle />
        </asp:TemplateField>
    </Columns>
    
</asp:GridView>
