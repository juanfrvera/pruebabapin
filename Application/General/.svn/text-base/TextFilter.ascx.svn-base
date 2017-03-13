<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextFilter.ascx.cs" Inherits="UI.Web.TextFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:230px" ><div ><asp:Literal ID="liCode" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCode" runat="server"  ControlToValidate="txtCode" ValidationGroup="FilterText" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCode" runat="server" CssClass="field_input" MaxLength="50" ></asp:TextBox></div>
        </td><td class="tdFilter"  style=" width:230px"><div ><asp:Literal ID="liDescription" Text="Descripción" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revDescription" runat="server"  ControlToValidate="txtDescription" ValidationGroup="FilterText" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDescription" runat="server" CssClass="field_input" MaxLength="2000" ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:230px"><div ><asp:Literal ID="liStartDate" Text="Fecha de Inicio" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdStartDate"  />         
		</td><td class="tdFilter" style=" width:230px" ><div ><asp:Literal ID="liIsAutomaticLoad" Text="Es de Carga Automática" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkIsAutomaticLoad" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liTextCategory" Text="Texto Categoría" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvTextCategory" runat="server" ControlToValidate="ddlTextCategory"  ValidationGroup="FilterText" Text="*" Width="1px" Height="1px" ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlTextCategory" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td>
	    <td class="tdFilter" ><div ><asp:Literal ID="liUsuarioChecked" Text="Usuario Comprobado" runat="server" ></asp:Literal>&nbsp;</div>
	    <div><uc:Autocomplete runat="server" ID="acUsuarioChecked" WebServiceName="~/Services/wsUsuario.asmx"
                    ServiceMethod="GetSimpleList" MinimumPrefixLength="4" AutoPostback="false" CssClass="CompletInput"
                    RequiredMessage="*" RequiredValue="false" ValidationGroup="FilterText"
                    ShowClearButton="true"></uc:Autocomplete>
		</div>
		</td>
		<td class="tdFilter" ><div ><asp:Literal ID="liCheckedDate" Text="Fecha Comprobada" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdCheckedDate"  />         
		</td>
		<td class="tdFilter" ><div ><asp:Literal ID="liChecked" Text="Comprobado" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkChecked" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr><td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" />
		</td>
	</tr>
</table>
