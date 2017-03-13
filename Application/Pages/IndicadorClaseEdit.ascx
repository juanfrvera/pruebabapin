<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndicadorClaseEdit.ascx.cs" Inherits="UI.Web.IndicadorClaseEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table   cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liIndicadorTipo" Text="Tipo de Indicador" runat="server" ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvIndicadorTipo" runat="server" ControlToValidate="ddlIndicadorTipo"  ValidationGroup="EditionIndicadorClase"   Text="*" Width="1px" Height="1px" InitialValue="0" ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlIndicadorTipo" runat="server" ></cc:ExtendedDropDownList></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liSigla" Text="Sigla" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revSigla" runat="server"   ControlToValidate="txtSigla"  ValidationGroup="EditionIndicadorClase"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvSigla" runat="server" ControlToValidate="txtSigla"  ValidationGroup="EditionIndicadorClase"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtSigla"  Width="60px"  MaxLength="10"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionIndicadorClase"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionIndicadorClase"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre"  Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liUnidad" Text="Unidad" runat="server" ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvUnidad" runat="server" ControlToValidate="ddlUnidad"  ValidationGroup="EditionIndicadorClase"   Text="*" Width="1px" Height="1px" InitialValue="0" ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlUnidad" runat="server"  CssClass="field_input" ></cc:ExtendedDropDownList></asp:DropDownList></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liRangoInicial" Text="Rango Inicial" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revRangoInicial" runat="server" ControlToValidate="txtRangoInicial"  ValidationGroup="EditionIndicadorClase"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtRangoInicial" Width="60px" type="text" min="0"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liRangoFinal" Text="Rango Final" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revRangoFinal" runat="server" ControlToValidate="txtRangoFinal"  ValidationGroup="EditionIndicadorClase"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtRangoFinal" Width="60px" type="text" min="0"  runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	 </table>
	 
    <asp:Panel runat="server" GroupingText="Sectores de Indicador"  ID="pnlFilterIndicadorSector"  >
    <div>
         <asp:DataList ID="dlRubros" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal" >
            <ItemTemplate>
                <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("IndicadorRubro_Nombre") %>' runat="server" />
                <asp:HiddenField ID="hdValue" Value='<%# Bind("IdIndicadorRubro") %>' runat="server" />
            </ItemTemplate>
         </asp:DataList>
    </div>
    </asp:Panel>
	
	
