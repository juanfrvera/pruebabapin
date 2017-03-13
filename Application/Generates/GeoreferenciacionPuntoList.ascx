<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GeoreferenciacionPuntoList.ascx.cs" Inherits=" UI.Web.GeoreferenciacionPuntoList" %>

<asp:GridView ID="Grid" runat="server"  Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"     
    OnRowCommand="Grid_RowCommand"    
    AllowSorting="True"
    OnSorting="Grid_Sorting"      
    >
    <Columns> 
<asp:BoundField DataField="Georeferenciacion_IdGeoreferenciacion" HeaderText="Georeferenciacion" SortExpression="Georeferenciacion_IdGeoreferenciacion" />
	<asp:BoundField DataField="Orden" HeaderText="Orden" SortExpression="Orden" />
	<asp:BoundField DataField="Longitud" HeaderText="Longitud" SortExpression="Longitud" DataFormatString="{0:F2}"  />
	<asp:BoundField DataField="Latitud" HeaderText="Latitud" SortExpression="Latitud" DataFormatString="{0:F2}"  />
	<asp:TemplateField   HeaderText="descripcion"  SortExpression="Descripcion"  >            
            <ItemTemplate>
                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Descripcion"),25) %>' ToolTip='<%# Eval("Descripcion") %>'  ></asp:Label>
            </ItemTemplate>
    </asp:TemplateField>
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
