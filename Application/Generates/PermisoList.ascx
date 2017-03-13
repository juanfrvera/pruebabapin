<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermisoList.ascx.cs" Inherits=" UI.Web.PermisoList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    EmptyDataText="No se encontraron registros..."        
    >
    <Columns> 
<asp:TemplateField   HeaderText="Nombre"  SortExpression="Nombre"  >            
            <ItemTemplate>
                <asp:Label ID="lblNombre" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Nombre"),25) %>' ToolTip='<%# Eval("Nombre") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
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
