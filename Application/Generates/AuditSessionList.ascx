<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditSessionList.ascx.cs" Inherits=" UI.Web.AuditSessionList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    EmptyDataText="No se encontraron registros..."        
    >
    <Columns> 
<asp:TemplateField   HeaderText="UserName"  SortExpression="UserName"  >            
            <ItemTemplate>
                <asp:Label ID="lblUserName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("UserName"),25) %>' ToolTip='<%# Eval("UserName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Session"  SortExpression="SessionId"  >            
            <ItemTemplate>
                <asp:Label ID="lblSessionId" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("SessionId"),25) %>' ToolTip='<%# Eval("SessionId") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Login"  SortExpression="Login"  >            
            <ItemTemplate>
                <asp:Label ID="lblLogin" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Login"),25) %>' ToolTip='<%# Eval("Login") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Rols"  SortExpression="Rols"  >            
            <ItemTemplate>
                <asp:Label ID="lblRols" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Rols"),25) %>' ToolTip='<%# Eval("Rols") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Area"  SortExpression="Area"  >            
            <ItemTemplate>
                <asp:Label ID="lblArea" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Area"),25) %>' ToolTip='<%# Eval("Area") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="Ip" HeaderText="IP" SortExpression="Ip" />
	<asp:TemplateField   HeaderText="BrowserVersion"  SortExpression="BrowserVersion"  >            
            <ItemTemplate>
                <asp:Label ID="lblBrowserVersion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("BrowserVersion"),25) %>' ToolTip='<%# Eval("BrowserVersion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="OperatingSystem"  SortExpression="OperatingSystem"  >            
            <ItemTemplate>
                <asp:Label ID="lblOperatingSystem" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("OperatingSystem"),25) %>' ToolTip='<%# Eval("OperatingSystem") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy}"  />
	<asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" DataFormatString="{0:dd/MM/yyyy}"  />
	<asp:BoundField DataField="Mandate" HeaderText="Mandate" SortExpression="Mandate" />
	<asp:TemplateField   HeaderText="Message"  SortExpression="Message"  >            
            <ItemTemplate>
                <asp:Label ID="lblMessage" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Message"),25) %>' ToolTip='<%# Eval("Message") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Comments"  SortExpression="Comments"  >            
            <ItemTemplate>
                <asp:Label ID="lblComments" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Comments"),25) %>' ToolTip='<%# Eval("Comments") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" >           
            <ItemTemplate>
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar"    Visible='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar"   Visible='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Esta seguro de eliminar?');" CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	   </ItemTemplate>            
            <ItemStyle Width ="200px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
