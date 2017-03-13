<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SafList.ascx.cs" Inherits=" UI.Web.SafList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"     
    >
    <Columns> 
<asp:BoundField DataField="Codigo" HeaderText="Código" SortExpression="Codigo" HeaderStyle-Width="6%"/>
	<asp:TemplateField   HeaderText="Denominación"  SortExpression="Denominacion"  HeaderStyle-Width="21%">            
            <ItemTemplate>
                <asp:Label ID="lblDenominacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Denominacion"),25) %>' ToolTip='<%# Eval("Denominacion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="CodigoSector_Nombre" HeaderText="Sector" SortExpression="Sector_Codigo" HeaderStyle-Width="13%"/>
    <asp:BoundField DataField="CodigoAdministracionTipo_Nombre" HeaderText="Tipo de Admin." SortExpression="AdministracionTipo_Codigo" HeaderStyle-Width="13%"/>
    <asp:BoundField DataField="CodigoEntidadTipo_Nombre" HeaderText="Tipo de Entidad" SortExpression="EntidadTipo_Codigo" HeaderStyle-Width="13%"/>
    <asp:BoundField DataField="CodigoJurisdiccion_Nombre" HeaderText="Jurisdicción" SortExpression="Jurisdiccion_Codigo" HeaderStyle-Width="13%"/>
	<asp:BoundField DataField="SubJurisdiccion_Codigo" HeaderText="SubJu" SortExpression="SubJurisdiccion_Codigo" HeaderStyle-Width="6%"/>
	<%--<asp:BoundField DataField="TipoOrganismo_Nombre" HeaderText="Tipo de Organismo" SortExpression="TipoOrganismo_Nombre" HeaderStyle-Width="8%"/>
	 <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta" SortExpression="FechaAlta" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="8%"/>
	<asp:BoundField DataField="FechaBaja" HeaderText="Fecha de Baja" SortExpression="FechaBaja" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="8%" />--%>
	<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" HeaderStyle-Width="6%"/>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	     </ItemTemplate>             
            <ItemStyle  />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
