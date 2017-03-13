<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditOperationList.ascx.cs" Inherits=" UI.Web.AuditOperationList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns>
    <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"  HeaderStyle-Width="7%"/>
	<asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"  HeaderStyle-Width="7%"/>
	<asp:TemplateField   HeaderText="Audit Session"  SortExpression="AuditSession_SessionId" HeaderStyle-Width="8%" >            
            <ItemTemplate>
                <asp:Label ID="lblAuditSession_SessionId" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("AuditSession_SessionId"),15) %>' ToolTip='<%# Eval("AuditSession_SessionId") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Usuario"  SortExpression="UserName" HeaderStyle-Width="8%" >            
            <ItemTemplate>
                <asp:Label ID="lblUserName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("UserName"),15) %>' ToolTip='<%# Eval("UserName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField   HeaderText="Operacion"  SortExpression="Operation"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblOperation" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Operation"),15) %>' ToolTip='<%# Eval("Operation") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Entidad"  SortExpression="EntityName" HeaderStyle-Width="8%" >            
            <ItemTemplate>
                <asp:Label ID="lblEntityName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntityName"),15) %>' ToolTip='<%# Eval("EntityName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Entitidad Base"  SortExpression="EntityBaseName"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblEntityBaseName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntityBaseName"),15) %>' ToolTip='<%# Eval("EntityBaseName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Tipo"  SortExpression="TypeName"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblTypeName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("TypeName"),15) %>' ToolTip='<%# Eval("TypeName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="ID"  SortExpression="EntityId"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblEntityId" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntityId"),25) %>' ToolTip='<%# Eval("EntityId") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Key"  SortExpression="EntityKey"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblEntityKey" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntityKey"),25) %>' ToolTip='<%# Eval("EntityKey") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>	
	<asp:TemplateField   HeaderText="Servicio"  SortExpression="Service"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblService" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Service"),15) %>' ToolTip='<%# Eval("Service") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>	
	<asp:TemplateField   HeaderText="Estado"  SortExpression="StatusName"  HeaderStyle-Width="8%" Visible="false">            
            <ItemTemplate>
                <asp:Label ID="lblStatusName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("StatusName"),25) %>' ToolTip='<%# Eval("StatusName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="6%">           
            <ItemTemplate>
			    &nbsp;
				<asp:ImageButton ID ="btView" runat ="server"  src="../Images/view.png" ToolTip ="Ver"  Visible='<%# Eval("EnableViewLog") %>'   CommandName='<%# Command.VIEW_LOG %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
		     </ItemTemplate>            
            <ItemStyle />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
