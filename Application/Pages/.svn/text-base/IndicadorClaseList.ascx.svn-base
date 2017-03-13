<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndicadorClaseList.ascx.cs" Inherits=" UI.Web.IndicadorClaseList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"      
    >
    <Columns> 
<asp:BoundField DataField="IndicadorTipo_Nombre" HeaderText="Tipo de Indicador" SortExpression="IndicadorTipo_Nombre" HeaderStyle-Width ="18%"/>
	<%-- <asp:BoundField DataField="IndicadorSector_Nombre" HeaderText="Sector" SortExpression="IndicadorSector_Nombre" /> --%>
	<asp:TemplateField   HeaderText="Nombre"  SortExpression="Nombre" HeaderStyle-Width ="18%" >            
            <ItemTemplate>
                <asp:Label ID="lblNombre" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Nombre"),25) %>' ToolTip='<%# Eval("Nombre") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="Unidad_Nombre" HeaderText="Unidad" SortExpression="Unidad_Nombre" HeaderStyle-Width ="18%"/>
	<asp:BoundField DataField="Sigla" HeaderText="Sigla" SortExpression="Sigla" HeaderStyle-Width ="18%"/>
	<%--- %><asp:BoundField DataField="RangoInicial" HeaderText="Rango Inicial" SortExpression="RangoInicial" />
	<asp:BoundField DataField="RangoFinal" HeaderText="Rango Final" SortExpression="RangoFinal" /> --%>
	<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" HeaderStyle-Width ="18%" />
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width ="10%">           
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
