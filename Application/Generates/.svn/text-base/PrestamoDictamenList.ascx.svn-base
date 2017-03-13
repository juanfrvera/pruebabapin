<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoDictamenList.ascx.cs" Inherits=" UI.Web.PrestamoDictamenList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    EmptyDataText="No se encontraron registros..."        
    >
    <Columns> 
<asp:BoundField DataField="Prestamo_Descripcion" HeaderText="Préstamo" SortExpression="Prestamo_Descripcion" />
	<asp:BoundField DataField="IdDictamen" HeaderText="Dictamen" SortExpression="IdDictamen" />
	<asp:TemplateField   HeaderText="Observación"  SortExpression="Observacion"  >            
            <ItemTemplate>
                <asp:Label ID="lblObservacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Observacion"),25) %>' ToolTip='<%# Eval("Observacion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="IdUsuario" HeaderText="Usuario" SortExpression="IdUsuario" />
	<asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}"  />
	<asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" SortExpression="FechaIngreso" DataFormatString="{0:dd/MM/yyyy}"  />
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" >           
            <ItemTemplate>
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar"    Visible='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar"   Visible='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Esta seguro de eliminar?');" CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	   </ItemTemplate>            
            <ItemStyle Width ="60px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
