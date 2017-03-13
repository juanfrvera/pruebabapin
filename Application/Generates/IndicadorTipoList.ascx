<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndicadorTipoList.ascx.cs" Inherits=" UI.Web.IndicadorTipoList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    EmptyDataText="No se encontraron registros..."        
    >
    <Columns> 
<asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
	<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
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
