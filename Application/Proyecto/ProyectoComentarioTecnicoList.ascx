<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoComentarioTecnicoList.ascx.cs" Inherits=" UI.Web.ProyectoComentarioTecnicoList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnRowDataBound="GridComentarioTecnico_RowDataBound"
    OnSorting="Grid_Sorting"            
    >
    <Columns> 
    <asp:BoundField DataField="Numero" HeaderText="BAPIN" SortExpression="Numero" />
    <asp:BoundField DataField="Denominacion" HeaderText="Denominación" SortExpression="Denominacion" />    
    <asp:BoundField DataField="TipoProyecto" HeaderText="T.Proyecto" SortExpression="TipoProyecto" />  
    <asp:BoundField DataField="ComentarioTecnico_Nombre" HeaderText="Tipo" SortExpression="ComentarioTecnico_Nombre" />
    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}"  />
	<asp:BoundField DataField="FechaAlta" HeaderText="FechaAlta" SortExpression="FechaAlta" DataFormatString="{0:dd/MM/yyyy}"  />
	<asp:BoundField DataField="NombreCompleto" HeaderText="Usuario" SortExpression="NombreCompleto"  />
	<asp:TemplateField HeaderText="Observación"  SortExpression="Observacion"  >            
            <ItemTemplate>
                <asp:Label ID="lblObservacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Observacion"),25) %>' ToolTip='<%# Eval("Observacion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="GeneraComentarioTecnico" HeaderText="Genera Comentario Tecnico" SortExpression="GeneraComentarioTecnico" />
	
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
