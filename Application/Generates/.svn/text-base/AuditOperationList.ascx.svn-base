<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditOperationList.ascx.cs" Inherits=" UI.Web.AuditOperationList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    EmptyDataText="No se encontraron registros..."        
    >
    <Columns> 
<asp:BoundField DataField="AuditSession_UserName" HeaderText="AuditSession" SortExpression="AuditSession_UserName" />
	<asp:TemplateField   HeaderText="UserName"  SortExpression="UserName"  >            
            <ItemTemplate>
                <asp:Label ID="lblUserName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("UserName"),25) %>' ToolTip='<%# Eval("UserName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="EntityName"  SortExpression="EntityName"  >            
            <ItemTemplate>
                <asp:Label ID="lblEntityName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntityName"),25) %>' ToolTip='<%# Eval("EntityName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="EntityBaseName"  SortExpression="EntityBaseName"  >            
            <ItemTemplate>
                <asp:Label ID="lblEntityBaseName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntityBaseName"),25) %>' ToolTip='<%# Eval("EntityBaseName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="TypeName"  SortExpression="TypeName"  >            
            <ItemTemplate>
                <asp:Label ID="lblTypeName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("TypeName"),25) %>' ToolTip='<%# Eval("TypeName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Entity"  SortExpression="EntityId"  >            
            <ItemTemplate>
                <asp:Label ID="lblEntityId" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntityId"),25) %>' ToolTip='<%# Eval("EntityId") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="EntityKey"  SortExpression="EntityKey"  >            
            <ItemTemplate>
                <asp:Label ID="lblEntityKey" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("EntityKey"),25) %>' ToolTip='<%# Eval("EntityKey") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Module"  SortExpression="Module"  >            
            <ItemTemplate>
                <asp:Label ID="lblModule" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Module"),25) %>' ToolTip='<%# Eval("Module") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="ServiceType"  SortExpression="ServiceType"  >            
            <ItemTemplate>
                <asp:Label ID="lblServiceType" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("ServiceType"),25) %>' ToolTip='<%# Eval("ServiceType") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Service"  SortExpression="Service"  >            
            <ItemTemplate>
                <asp:Label ID="lblService" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Service"),25) %>' ToolTip='<%# Eval("Service") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Operation"  SortExpression="Operation"  >            
            <ItemTemplate>
                <asp:Label ID="lblOperation" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Operation"),25) %>' ToolTip='<%# Eval("Operation") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="StatusName"  SortExpression="StatusName"  >            
            <ItemTemplate>
                <asp:Label ID="lblStatusName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("StatusName"),25) %>' ToolTip='<%# Eval("StatusName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Info"  SortExpression="Info"  >            
            <ItemTemplate>
                <asp:Label ID="lblInfo" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Info"),25) %>' ToolTip='<%# Eval("Info") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Comment"  SortExpression="Comment"  >            
            <ItemTemplate>
                <asp:Label ID="lblComment" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Comment"),25) %>' ToolTip='<%# Eval("Comment") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="DataOld"  SortExpression="DataOld"  >            
            <ItemTemplate>
                <asp:Label ID="lblDataOld" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("DataOld"),25) %>' ToolTip='<%# Eval("DataOld") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="DataPreOperation"  SortExpression="DataPreOperation"  >            
            <ItemTemplate>
                <asp:Label ID="lblDataPreOperation" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("DataPreOperation"),25) %>' ToolTip='<%# Eval("DataPreOperation") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="DataPostOperation"  SortExpression="DataPostOperation"  >            
            <ItemTemplate>
                <asp:Label ID="lblDataPostOperation" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("DataPostOperation"),25) %>' ToolTip='<%# Eval("DataPostOperation") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy}"  />
	<asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" DataFormatString="{0:dd/MM/yyyy}"  />
	<asp:CheckBoxField DataField="EnableViewLog" HeaderText="EnableViewLog" SortExpression="EnableViewLog" />
	<asp:TemplateField   HeaderText="ApplicationName"  SortExpression="ApplicationName"  >            
            <ItemTemplate>
                <asp:Label ID="lblApplicationName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("ApplicationName"),25) %>' ToolTip='<%# Eval("ApplicationName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="FormPath"  SortExpression="FormPath"  >            
            <ItemTemplate>
                <asp:Label ID="lblFormPath" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("FormPath"),25) %>' ToolTip='<%# Eval("FormPath") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="FormName"  SortExpression="FormName"  >            
            <ItemTemplate>
                <asp:Label ID="lblFormName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("FormName"),25) %>' ToolTip='<%# Eval("FormName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="UserControlName"  SortExpression="UserControlName"  >            
            <ItemTemplate>
                <asp:Label ID="lblUserControlName" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("UserControlName"),25) %>' ToolTip='<%# Eval("UserControlName") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="UserControlPath"  SortExpression="UserControlPath"  >            
            <ItemTemplate>
                <asp:Label ID="lblUserControlPath" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("UserControlPath"),25) %>' ToolTip='<%# Eval("UserControlPath") %>'  ></asp:Label>
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
