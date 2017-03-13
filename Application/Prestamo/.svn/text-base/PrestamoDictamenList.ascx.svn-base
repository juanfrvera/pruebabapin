<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoDictamenList.ascx.cs" Inherits=" UI.Web.PrestamoDictamenList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"      
    >
    <Columns> 
    <asp:BoundField DataField="IdPrestamoDictamen" HeaderText="Sec." SortExpression="IdPrestamoDictamen" />	
    <asp:TemplateField   HeaderText="Expediente"  SortExpression="Expediente"  >            
            <ItemTemplate>
                <asp:Label ID="lblExpediente" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Expediente"),25) %>' ToolTip='<%# Eval("Expediente") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>    
    
	<asp:TemplateField   HeaderText="Denominación"  SortExpression="Denominacion"  >            
            <ItemTemplate>
                <asp:Label ID="lblDenominacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Denominacion"),25) %>' ToolTip='<%# Eval("Denominacion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="OrganismoFinanciero_Sigla" HeaderText="Org.Financiero" SortExpression="OrganismoFinanciero_Sigla" />
    <asp:BoundField DataField="Organismo_Nombre" HeaderText="Tipo Organismo" SortExpression="Organismo_Nombre" />	
    <asp:BoundField DataField="UltimoEstadoNombre" HeaderText="Estado" SortExpression="UltimoEstadoNombre" />	
	<asp:BoundField DataField="Prestamo_Numero" HeaderText="N° Préstamo" SortExpression="Prestamo_Numero" />	
	<asp:BoundField DataField="MontoTotal" HeaderText="Monto Total" SortExpression="MontoTotal" DataFormatString="{0:N0}"  ItemStyle-HorizontalAlign="Right"/>
	<asp:BoundField DataField="MontoPrestamo" HeaderText="Monto Préstamo" SortExpression="MontoPrestamo" DataFormatString="{0:N0}"  ItemStyle-HorizontalAlign="Right" />
	<asp:BoundField DataField="GestionTipo_Nombre" HeaderText="Tipo de Gestión" SortExpression="GestionTipo_Nombre" />
	<asp:BoundField DataField="Analista_ApellidoYNombre" HeaderText="Analista" SortExpression="Analista_ApellidoYNombre" />
    <asp:BoundField DataField="FechaAlta" HeaderText="Fecha " SortExpression="FechaAlta" DataFormatString="{0:dd/MM/yyyy}"  />	
    <%--
    <asp:BoundField DataField="FechaEstado" HeaderText="Fecha Estado" SortExpression="FechaEstado" DataFormatString="{0:dd/MM/yyyy}"  />
	<asp:BoundField DataField="UltimoEstadoNombre" HeaderText="Estado" SortExpression="UltimoEstadoNombre" />	--%>
 
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
