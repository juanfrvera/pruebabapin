<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoList.ascx.cs" Inherits=" UI.Web.PrestamoList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"      
    >
    <Columns> 
    <asp:BoundField  DataField="Saf_Jurisdiccion" HeaderText="JU" SortExpression="Saf_Jurisdiccion" HeaderStyle-Width ="4%"/>
    <asp:BoundField  DataField="Saf_Codigo" HeaderText="SAF" SortExpression="Saf_Codigo" HeaderStyle-Width ="4%"/>
    <asp:BoundField  DataField="Programa_Codigo" HeaderText="PR" SortExpression="Programa_Codigo" HeaderStyle-Width ="4%"/>
     <asp:BoundField  DataField="Numero" HeaderText="Nro" SortExpression="Numero" HeaderStyle-Width ="4%"/>
     
    <asp:TemplateField  HeaderText="Denominación"  SortExpression="Denominacion" HeaderStyle-Width ="17%" >            
            <ItemTemplate>
                <asp:Label ID="lblDenominacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Denominacion"),25) %>' ToolTip='<%# Eval("Denominacion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
   <asp:BoundField  DataField="OrganismoFinanciero_Nombre" HeaderText="Org. Financiero" SortExpression="OrganismoFinanciero_Nombre" HeaderStyle-Width ="13%"/>
  <%-- <asp:BoundField  DataField="Nro_Bnc" HeaderText="Nro. Banc." SortExpression="Nro_Bnc" HeaderStyle-Width="12%"/>--%>
	 <asp:BoundField DataField="Estado_Nombre"  HeaderText="Estado" SortExpression="Estado_Nombre" HeaderStyle-Width ="8%" />
	 <asp:BoundField DataField="NumeroPrestamoBanco"  HeaderText="Nro Prest. Banco" SortExpression="Sigla" HeaderStyle-Width ="12%" />
	 	 <asp:BoundField  DataField="Monto" HeaderText="Monto" SortExpression="Monto" HeaderStyle-Width ="12%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}"/> 
    <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Est." SortExpression="FechaAlta" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width ="10%" />
	<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width ="15%" >           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
				 &nbsp;
				<asp:ImageButton ID ="btPrint" runat ="server"  src="../Images/imprimir.png" ToolTip='<%# Translate("Imprimir") %>'    CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable"  %>' Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.SHOW_POPUP_PRINT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
       	     </ItemTemplate>            
            <ItemStyle  />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
