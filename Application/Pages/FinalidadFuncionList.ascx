<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FinalidadFuncionList.ascx.cs" Inherits=" UI.Web.FinalidadFuncionList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
     <asp:TemplateField   HeaderText="Padre"  SortExpression="FinalidadFuncionPadre_BreadcrumbCodeOrden" HeaderStyle-Width="25%" >            
            <ItemTemplate>
                <asp:Label ID="lbPadre" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("PadreCodigoNombre"),35) %>' ToolTip='<%# Eval("PadreCodigoNombre") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="Codigo" HeaderText="C�digo" SortExpression="Codigo" HeaderStyle-Width="8%" />
	<asp:TemplateField   HeaderText="Denominaci�n"  SortExpression="Denominacion"  HeaderStyle-Width="32%" >            
            <ItemTemplate>
                <asp:Label ID="lblDenominacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Denominacion"),45) %>' ToolTip='<%# Eval("Denominacion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="FinalidadFuncionTipo_Nombre" HeaderText="Nivel/Tipo" SortExpression="FinalidadFuncionTipo_Nombre" HeaderStyle-Width="18%" />
	 <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" HeaderStyle-Width="8%" />
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">           
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
