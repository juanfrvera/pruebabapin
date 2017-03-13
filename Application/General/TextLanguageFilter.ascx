<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextLanguageFilter.ascx.cs" Inherits="UI.Web.TextLanguageFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:230px" >
	    <div ><asp:Literal ID="liText" Text="Texto" runat="server" ></asp:Literal>&nbsp;</div>
		<div><uc:Autocomplete runat="server" ID="acText" WebServiceName="~/Services/wsTexto.asmx"
                    ServiceMethod="GetSimpleList" MinimumPrefixLength="4" AutoPostback="false" CssClass="CompletInput"
                    RequiredMessage="*" RequiredValue="false" ValidationGroup="FilterTextLanguage"
                    ShowClearButton="true"></uc:Autocomplete>
		</div>
		</td><td class="tdFilter" style=" width:230px" ><div ><asp:Literal ID="liLanguage" Text="Lenguaje" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="ddlLanguage"  ValidationGroup="FilterTextLanguage" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlLanguage" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" style=" width:230px" ><div ><asp:Literal ID="liStartDate" Text="Fecha de Inicio" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdStartDate"  />         
		</td><td class="tdFilter" style=" width:230px" ><div ><asp:Literal ID="liIsAutomaticLoad" Text="Carga Automática" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkIsAutomaticLoad" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liTranslateText" Text="Traducir Texto " runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revTranslateText" runat="server"  ControlToValidate="txtTranslateText" ValidationGroup="FilterTextLanguage" Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtTranslateText" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" >
		<div ><asp:Literal ID="liUsuarioChecked" Text="Usuario Comprobado" runat="server" ></asp:Literal>&nbsp;</div>
		<div><uc:Autocomplete runat="server" ID="acUsuarioChecked" WebServiceName="~/Services/wsUsuario.asmx"
                    ServiceMethod="GetSimpleList" MinimumPrefixLength="4" AutoPostback="false" CssClass="CompletInput"
                    RequiredMessage="*" RequiredValue="false" ValidationGroup="FilterTextLanguage"
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
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterTextLanguaje" />
		</td>
	</tr>
</table>
