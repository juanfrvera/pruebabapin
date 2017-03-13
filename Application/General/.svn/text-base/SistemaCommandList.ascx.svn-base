<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SistemaCommandList.ascx.cs" Inherits=" UI.Web.SistemaCommandList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"      
    >
    <Columns> 
<asp:TemplateField   HeaderText="Nombre"  SortExpression="Nombre"  >            
            <ItemTemplate>
                <asp:Label ID="lblNombre" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Nombre"),25) %>' ToolTip='<%# Eval("Nombre") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField   HeaderText="Descripcion"  SortExpression="Descripcion"  >            
            <ItemTemplate>
                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Descripcion"),25) %>' ToolTip='<%# Eval("Descripcion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:BoundField DataField="SistemaEntidad_Nombre" HeaderText="sistemaEntidad" SortExpression="SistemaEntidad_Nombre" />
	<asp:TemplateField   HeaderText="CommandText"  SortExpression="CommandText"  >            
            <ItemTemplate>
                <asp:Label ID="lblCommandText" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("CommandText"),25) %>' ToolTip='<%# Eval("CommandText") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
			<asp:TemplateField  ItemStyle-HorizontalAlign="Right" >           
            <ItemTemplate>
				<asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'    Visible='<%# CanRead(Eval("ID")) %>'  CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				&nbsp;
				<asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png" ToolTip ='<%# Translate("Editar") %>'    Visible='<%# CanEdit(Eval("ID")) %>'  CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
				<!--&nbsp;
				<asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  Visible='<%# CanDelete(Eval("ID")) %>'   CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Está seguro de eliminar?');" CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />-->            
       	   </ItemTemplate>            
            <ItemStyle Width ="80px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
