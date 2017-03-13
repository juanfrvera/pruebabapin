<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditSessionList.ascx.cs" Inherits=" UI.Web.AuditSessionList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
    <asp:BoundField DataField="StartDate" HeaderText="Inicio" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"  HeaderStyle-Width="8%"/>
	<asp:BoundField DataField="EndDate" HeaderText="Fin" SortExpression="EndDate" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"  HeaderStyle-Width="8%"/>
	<asp:TemplateField   HeaderText="Usuario"  SortExpression="UserName"  HeaderStyle-Width="24%">            
            <ItemTemplate>
                <asp:Label ID="lblUserName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("UserName"),25) %>' ToolTip='<%# Eval("UserName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
    <%--
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
    --%>
	<asp:TemplateField   HeaderText="Session ID"  SortExpression="SessionId"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblSessionId" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("SessionId"),25) %>' ToolTip='<%# Eval("SessionId") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>	
	<asp:BoundField DataField="Ip" HeaderText="IP" SortExpression="Ip" HeaderStyle-Width="8%"/>
	<asp:TemplateField   HeaderText="Browser"  SortExpression="BrowserVersion"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblBrowserVersion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("BrowserVersion"),25) %>' ToolTip='<%# Eval("BrowserVersion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="S.O."  SortExpression="OperatingSystem"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblOperatingSystem" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("OperatingSystem"),25) %>' ToolTip='<%# Eval("OperatingSystem") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="Mandate" HeaderText="Mandato" SortExpression="Mandate" HeaderStyle-Width="8%"/>
	<asp:TemplateField   HeaderText="Message"  SortExpression="Message"  >            
            <ItemTemplate>
                <asp:Label ID="lblMessage" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Message"),25) %>' ToolTip='<%# Eval("Message") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Comentarios"  SortExpression="Comments"  HeaderStyle-Width="8%">            
            <ItemTemplate>
                <asp:Label ID="lblComments" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Comments"),25) %>' ToolTip='<%# Eval("Comments") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="6%">           
            <ItemTemplate>
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
			 </ItemTemplate>            
            <ItemStyle Width ="30px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
