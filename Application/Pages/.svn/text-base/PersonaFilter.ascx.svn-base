<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonaFilter.ascx.cs" Inherits="UI.Web.PersonaFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_Oficinas.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
        <td class="tdFilter" >
            <div ><asp:Literal ID="liApellido" Text="Apellido" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revApellido" runat="server"  ControlToValidate="txtApellido" ValidationGroup="FilterPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtApellido" runat="server" CssClass="field_input" MaxLength="70" ></asp:TextBox></div>
        </td>
        <td class="tdFilter" >
            <div ><asp:Literal ID="liJurisdiccion" Text="Jurisdicción" runat="server" ></asp:Literal></div>
		    <div><asp:DropDownList ID="ddlJurisdiccion" runat = "server" onselectedindexchanged="ddlJurisdiccion_SelectedIndexChanged" AutoPostBack ="true" ></asp:DropDownList></div>
        </td>
        <td class="tdFilter" >
            <div ><asp:Literal ID="liUsuario" Text="Usuario" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revUsuario" runat="server"  ControlToValidate="txtUsuario" ValidationGroup="FilterPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div>
		        <asp:TextBox ID="txtUsuario" runat = "server"  CssClass="field_input" MaxLength="50" ></asp:TextBox>
		    </div>
        </td>
       <td class="tdFilter" ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server"   CssClass="field_input" ></uc:ThreeState></div>        
		</td>
 
	</tr>
	<tr>
	    <td class="tdFilter" >
		    <div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input" MaxLength="70" ></asp:TextBox></div>
        </td>
        <td class="tdFilter" >
            <div ><asp:Literal ID="liSAF" Text="SAF" runat="server" ></asp:Literal></div>
		    <div><asp:DropDownList ID="ddlSaf" runat = "server" onselectedindexchanged="ddlSAF_SelectedIndexChanged" AutoPostBack ="true" Enabled="false"></asp:DropDownList></div>
        </td>
	   
        <td class="tdFilter" ><div ><asp:Literal ID="liEsUsuarioContacto" Text="Tipo" runat="server" ></asp:Literal></div>
		<div ><uc:ThreeState ID="chkUsuarioContacto" runat="server" CssClass="field_input"  ></uc:ThreeState></div>        
		</td>
       
      
	</tr>
	<tr>
	    <td class="tdFilter" colspan="3">
            <asp:Panel runat="server" GroupingText="Oficina"  ID="PnlOficinaFamilia"  Width="770px"   >
                <table  cellpadding="0" cellspacing="0" border="0" style="  ">
                    <tr>
                        <td>
                        
                             <uc:TreeOficinas runat="server" ID="toOficina" SelectOption="OnlySelectedDefined"  ShowOption="All" Handler="../Handlers/OficinaHandler.ashx"  ></uc:TreeOficinas> 
                        
                        </td>
                        <td class="tdFilter">
                                <asp:CheckBox ID="chkIncluirOficinasInteriores" runat="server" Text="Incluir Of. Interiores"
                                    CssClass="field_input"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
		    </asp:Panel>
         </td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterPersona" />
		</td>
		</tr> 
</table>
