<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramaList.ascx.cs" Inherits=" UI.Web.ProgramaList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"    
    >
    <Columns> 
    <asp:BoundField DataField="Saf_Codigo" HeaderText="Código SAF" SortExpression="Saf_Codigo" HeaderStyle-Width ="8%"/>
    <asp:TemplateField   HeaderText="Denominación SAF"  SortExpression="SAF_Denominacion"  HeaderStyle-Width ="20%" >            
            <ItemTemplate>
                <asp:Label ID="lblSAF" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("SAF_Denominacion"),25) %>' ToolTip='<%# Eval("SAF_Denominacion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="Codigo" HeaderText="Código" SortExpression="Codigo"  HeaderStyle-Width ="6%"/>
	<asp:TemplateField   HeaderText="Denominación"  SortExpression="Nombre"  HeaderStyle-Width ="20%" >            
            <ItemTemplate>
                <asp:Label ID="lblNombre" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Nombre"),25) %>' ToolTip='<%# Eval("Nombre") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta" SortExpression="FechaAlta" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width ="10%" />
	<asp:BoundField DataField="FechaBaja" HeaderText="Fecha de Baja" SortExpression="FechaBaja" DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width ="10%" />
	<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo"  HeaderStyle-Width ="6%"/>
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right"  HeaderStyle-Width ="10%">           
            <ItemTemplate>                
			    <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'  CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>'  Enabled='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png"   ToolTip='<%# Translate("Editar") %>'  CssClass='<%# CanEdit(Eval("ID"))?"":"ibDisable" %>'    Enabled='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CssClass='<%# CanDelete(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	        &nbsp;
				<asp:ImageButton ID ="btObjetivos" runat ="server"  src="../Images/table.png" ToolTip ='<%# Translate("Objetivos") %>' CssClass='<%# CanEditObjetivo(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanEditObjetivo(Eval("ID")) %>'  CommandName='<%# Command.SHOW_DETAILS %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />			
       	     </ItemTemplate>            
            <ItemStyle  />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
