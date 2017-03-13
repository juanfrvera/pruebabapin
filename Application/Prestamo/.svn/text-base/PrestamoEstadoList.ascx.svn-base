<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoEstadoList.ascx.cs" Inherits=" UI.Web.PrestamoEstadoList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
<asp:BoundField DataField="Prestamo_Descripcion" HeaderText="Préstamo" SortExpression="Prestamo_Descripcion" HeaderStyle-Width="66%" />
	<asp:BoundField DataField="Estado_Nombre" HeaderText="Estado" SortExpression="Estado_Nombre" HeaderStyle-Width="12%"/>
	<asp:BoundField DataField="FechaEstimada" HeaderText="Fecha Estimada" SortExpression="FechaEstimada" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="8%" />
	<asp:BoundField DataField="FechaRealizada" HeaderText="Fecha  Realizada" SortExpression="FechaRealizada" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="8%" />
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="8%" >           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	     </ItemTemplate>             
            <ItemStyle />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
