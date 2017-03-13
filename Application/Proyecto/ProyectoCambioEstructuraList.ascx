<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoCambioEstructuraList.ascx.cs" Inherits=" UI.Web.ProyectoCambioEstructuraList" %>
<div style="overflow:auto; height:200px; align:left;">
<asp:GridView ID="Grid" runat="server"  Width="980px"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
    <asp:TemplateField>
        <HeaderTemplate>
            <input ID="ToggleCheckBox" runat="server" name="ToggleCheckBox" 
                onclick=" javascript:ChequearTodo('ItemCheckBox', checked);" 
                type="checkbox" />
        </HeaderTemplate>
        <ItemTemplate>
            <input ID="ItemCheckBox" runat="server" name="ItemCheckBox" type="checkbox" />
        </ItemTemplate>
        <ItemStyle Width="25px" />
    </asp:TemplateField>
    <asp:BoundField DataField="Jurisdiccion_Codigo" HeaderText="JU" SortExpression="Jurisdiccion_Codigo"  HeaderStyle-Width ="4%"/>
    <asp:BoundField DataField="Saf_Codigo" HeaderText="SAF" SortExpression="Saf_Codigo" HeaderStyle-Width ="4%"/>
    <asp:BoundField DataField="Programa_Codigo" HeaderText="PR" SortExpression="Programa_Codigo" HeaderStyle-Width ="4%"/>
    <asp:BoundField DataField="SubPrograma_Codigo" HeaderText="SP" SortExpression="SubPrograma_Codigo" HeaderStyle-Width ="6%" />
	<asp:BoundField DataField="Codigo" HeaderText="BAPIN" SortExpression="Codigo" HeaderStyle-Width ="8%" />
    <asp:TemplateField  HeaderText="Denominación"  SortExpression="ProyectoDenominacion"  HeaderStyle-Width ="28%">            
            <ItemTemplate>
                <asp:Label ID="lblProyectoDenominacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("ProyectoDenominacion"),35) %>' ToolTip='<%# Eval("ProyectoDenominacion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="Estado_Nombre" HeaderText="Estado" SortExpression="Estado_Nombre" HeaderStyle-Width ="6%" />
    <asp:BoundField DataField="Plan_Ultimo" HeaderText="Plan" SortExpression="Plan_Ultimo" HeaderStyle-Width ="15%"/>
    <asp:BoundField DataField="TipoProyecto_Nombre" HeaderText="Tipo Inv." SortExpression="TipoProyecto_Nombre" HeaderStyle-Width ="8%"/>
    <asp:BoundField DataField="FechaAlta" HeaderText="Apertura" SortExpression="FechaAlta" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="7%"  />    
   <asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="4%">           
            <ItemTemplate>                                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CommandName='<%# Command.READ %>' CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
		    </ItemTemplate>            
            <ItemStyle />
        </asp:TemplateField>     
    </Columns>
</asp:GridView>
</div>
