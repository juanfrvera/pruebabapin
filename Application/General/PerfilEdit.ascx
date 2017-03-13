<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PerfilEdit.ascx.cs" Inherits="UI.Web.PerfilEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>


<table   cellpadding="0" cellspacing="5px" border="0">	  	
    <tr>
		<td class="tdLabel" ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionPerfil"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionPerfil"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre" Width="400px" runat="server" CssClass="field_input" MaxLength="50" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel" ><asp:Literal ID="liCodigo" Text="Codigo" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="EditionPerfil"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="EditionPerfil"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCodigo"  runat="server" CssClass="field_input" MaxLength ="5"  ></asp:TextBox></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liPerfilTipo" Text="Tipo de Perfil" runat="server" ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvPerfilTipo" runat="server" ControlToValidate="ddlPerfilTipo"  ValidationGroup="EditionPerfil"   Text="*" Width="1px" Height="1px" InitialValue="0" ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><asp:DropDownList ID="ddlPerfilTipo" runat="server" 
            CssClass="field_input" ></asp:DropDownList></td>
	</tr>
	<tr>
	    <td colspan="3" >	         
	        <table>	            
		        <tr>
		            <td class="filaInput"><asp:CheckBox ID="chkActivo" Text="Activo"  runat="server" CssClass="field_input" ></asp:CheckBox></td>
		            <td class="filaInput"><asp:CheckBox ID="chkEsDefault" Text="Es Default" runat="server" CssClass="field_input" ></asp:CheckBox></td>	
	                <td>&nbsp;</td>
	            </tr>
	        </table>	        
	    </td>
	</tr>
</table>


<asp:Panel runat="server" GroupingText="Actividades"  ID="pnlFilter" >
    <div>
         <asp:DataList ID="dlActividades" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Vertical" >
            <ItemTemplate>
                <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Actividad_Nombre") %>' runat="server" />
                <asp:HiddenField ID="hdValue" Value='<%# Bind("IdActividad") %>' runat="server" />
            </ItemTemplate>
         </asp:DataList>
	</div>
</asp:Panel>
	   