<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdministracionCalidadList.ascx.cs" Inherits=" UI.Web.AdministracionCalidadList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="IdProyecto"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting">
    <Columns> 
        <asp:BoundField DataField="Proyecto_CodigoCompuesto" HeaderText="SAF.PR.SP" SortExpression="Proyecto_CodigoCompuesto" HeaderStyle-Width ="7%" ItemStyle-HorizontalAlign="Center"/>    
    	<asp:BoundField DataField="Proyecto_Codigo" HeaderText="BAPIN" SortExpression="Proyecto_Codigo"  HeaderStyle-Width ="5%" ItemStyle-HorizontalAlign="Center"/>
    	<asp:BoundField DataField="Proyecto_ProyectoDenominacion" HeaderText="Denominación" SortExpression="Proyecto_ProyectoDenominacion"  ItemStyle-Width="20%" />
    	<asp:BoundField DataField="Proyecto_PlanNombre" HeaderText="Último Plan" SortExpression="Proyecto_PlanNombre" HeaderStyle-Width ="10%"/>
    	<asp:BoundField DataField="Proyecto_Codigo" HeaderText="Última Demanda" SortExpression="Proyecto_Codigo"  HeaderStyle-Width ="7%" Visible="false"/>
    	<asp:BoundField DataField="Estado_Descripcion" HeaderText="Estado Calidad" SortExpression="Estado_Descripcion"  HeaderStyle-Width ="7%"/>
    	<asp:BoundField DataField="FechaEstado" HeaderText="Fecha"  DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" SortExpression="FechaEstado"  HeaderStyle-Width ="8%"/>
    	<asp:BoundField DataField="Proyecto_EstadoNombre" HeaderText="Estado" SortExpression="Proyecto_EstadoNombre"  HeaderStyle-Width ="7%"/>
    	<asp:BoundField DataField="Proyecto_ProcesoNombre" HeaderText="Proceso" SortExpression="Proyecto_ProcesoNombre"  HeaderStyle-Width ="7%"/>
    	<asp:BoundField DataField="Proyecto_FinalidadDenominacion" HeaderText="Finalidad" SortExpression="Proyecto_FinalidadDenominacion"  HeaderStyle-Width ="11%"/>
		<asp:TemplateField  ItemStyle-HorizontalAlign="Right"  HeaderStyle-Width ="4%">           
        <ItemTemplate>
            <asp:ImageButton ID ="ImageButton1" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("IdProyecto"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("IdProyecto")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("IdProyecto")%>'  CausesValidation="false" />
   	     </ItemTemplate>            
        </asp:TemplateField>
    </Columns>
</asp:GridView>
