<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigMensajesList.ascx.cs" Inherits="UI.Web.ConfigMensajesList" %>

<asp:GridView ID="Grid" runat="server" Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"
    OnRowCommand="Grid_RowCommand"
    OnRowDataBound="Grid_RowDataBound"
    AllowSorting="True"
    OnSorting="Grid_Sorting">
    <Columns>
        <asp:BoundField DataField="Page" HeaderText="Página" SortExpression="Page" HeaderStyle-Width="25%" />
        <asp:BoundField DataField="OperationType" HeaderText="Tipo de operación" SortExpression="OperationType" HeaderStyle-Width="10%" />
        <asp:BoundField DataField="Subject" HeaderText="Asunto" SortExpression="Subject" HeaderStyle-Width="10%" />
        <asp:TemplateField HeaderText="Mensaje"  SortExpression="Message" HeaderStyle-Width="34%" >            
            <ItemTemplate>
                <asp:Label ID="lblMensaje" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Message"),80) %>' ToolTip='<%# Eval("Message") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">
            <ItemTemplate>
                <asp:ImageButton ID="btRead" runat="server" src="../Images/read.png" ToolTip='<%# Translate("Consultar") %>' CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanRead(Eval("ID")) %>' CommandName='<%# Command.READ %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />
                &nbsp;
				<asp:ImageButton ID="btEdit" runat="server" src="../Images/edit.png" ToolTip='<%# Translate("Editar") %>' CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanEdit(Eval("ID")) %>' CommandName='<%# Command.EDIT %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />
                &nbsp;
				<asp:ImageButton ID="btDelete" runat="server" src="../Images/delete.jpg" ToolTip='<%# Translate("Eliminar") %>' CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>' CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
            </ItemTemplate>
            <ItemStyle />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
