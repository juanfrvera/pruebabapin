<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoSeguimientoList.ascx.cs" Inherits=" UI.Web.ProyectoSeguimientoList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"      
    >
    <Columns> 
    <asp:BoundField DataField="IdProyectoSeguimiento" HeaderText="Nro Secuencial" SortExpression="IdProyectoSeguimiento" ItemStyle-Width="6%" />
    <asp:BoundField DataField="Denominacion" HeaderText="Denominación" SortExpression="Denominacion" />
	<asp:BoundField DataField="Saf_CodigoDenominacion" HeaderText="Saf" SortExpression="Saf_Codigo" ItemStyle-Width="10%" />
    <asp:BoundField DataField="Analista_ApellidoYNombre" HeaderText="Analista" SortExpression="Analista_ApellidoYNombre" />
    <asp:TemplateField   HeaderText="Ruta"  SortExpression="Ruta"  >            
            <ItemTemplate>
                <asp:Label ID="lblRuta" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Ruta"),25) %>' ToolTip='<%# Eval("Ruta") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Malla"  SortExpression="Malla"  >            
            <ItemTemplate>
                <asp:Label ID="lblMalla" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Malla"),25) %>' ToolTip='<%# Eval("Malla") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="UltimoEstadoNombre" HeaderText="Estado" SortExpression="UltimoEstadoNombre" />
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" >           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	     </ItemTemplate>            
            <ItemStyle Width ="80px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
