<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoCambioEstructuraFilter.ascx.cs" Inherits="UI.Web.ProyectoCambioEstructuraFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_Oficinas.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeLocalizacionGeografica" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
    <td class="tdFilter" style=" width:230px" >
        <div ><asp:Literal ID="liJurisdiccion" Text="Jurisdicción" runat="server" ></asp:Literal>&nbsp;</div>
	    <div><asp:DropDownList ID="ddlJurisdiccion" runat="server" CssClass="field_input"  
	            onselectedindexchanged="ddlJurisdiccion_SelectedIndexChanged" AutoPostBack ="true" ></asp:DropDownList></div>
    </td>
    <td class="tdFilter" style=" width:230px">
        <div ><asp:Literal ID="liSAF" Text="SAF" runat="server" ></asp:Literal>&nbsp;</div>
	    <div><asp:DropDownList ID="ddlSAF" runat="server" CssClass="field_input" 
                onselectedindexchanged="ddlSAF_SelectedIndexChanged" AutoPostBack ="true" Enabled="false"  ></asp:DropDownList></div>
    </td>
    <td class="tdFilter" style=" width:230px">
        <div ><asp:Literal ID="liPrograma" Text="Programa" runat="server" ></asp:Literal>&nbsp;</div>
	    <div><asp:DropDownList ID="ddlPrograma" runat="server" CssClass="field_input" 
                onselectedindexchanged="ddlPrograma_SelectedIndexChanged" AutoPostBack ="true" Enabled="false" ></asp:DropDownList></div>
        
    </td>	
    <td class="tdFilter" style=" width:230px" >
        <div ><asp:Literal ID="liSubPrograma" Text="SubPrograma" runat="server" ></asp:Literal>&nbsp;</div>
	    <div><asp:DropDownList ID="ddlSubPrograma" runat="server" CssClass="field_input"  Enabled="false" ></asp:DropDownList></div>
    </td>  
</tr>
<tr>
    <td colspan="2" >
      <div><asp:Literal ID="liOficina" Text="Oficina" runat="server" ></asp:Literal></div>
      <div><uc:TreeOficinas runat="server" ID="toOficina" SelectOption="OnlySelectedDefined" ShowOption="All" OnValueChanged="toOficina_OnValueChanged" Autopostback="true" ></uc:TreeOficinas></div>
    </td>
    <td style="padding-top:8px" width="160px" >
        <asp:CheckBox ID="chkIncluirOficinasInteriores" runat="server" Text="Incluir Subitems" CssClass="field_input" ></asp:CheckBox>
    </td>
    
    <td class="tdFilter" style=" padding-bottom:0px; margin-bottom:0px; Width="115px"  >
     <div><asp:Literal ID="liRol" Text="Rol" runat="server" ></asp:Literal></div>
     <div><asp:DropDownList ID="ddlRol" runat="server" SkinID="AnchoLibre" Width="115px"  ></asp:DropDownList></div>
    </td>
</tr> 
<tr>         	    
   <td>
       <div ><asp:Literal ID="liBorrador" Text="Borrador" runat="server" ></asp:Literal>
       </div>
        <div >
            <uc:ThreeState ID="chkBorrador" runat="server" CssClass="field_input" ></uc:ThreeState>
        </div>
   </td>
    <td class="tdFilter" style=" width:230px" rowspan ="3">
       <div ><asp:Literal ID="liEstado" Text="Estado" runat="server" ></asp:Literal>&nbsp;</div>
	    <div><asp:ListBox ID="lbxEstado" runat="server" CssClass="field_input" SelectionMode="Multiple" Rows="4"  Height="70px" Width="205px" ></asp:ListBox></div>
    </td>
    <td class="tdFilter" style=" padding-top:10px;padding-bottom:10px;" > 
        <asp:Panel runat="server"  ID="pnlNroBapin"  BorderWidth="1" BackColor=" #e6f7ff" Width="200px"   >
            <table width="100%"  cellpadding="0" cellspacing="0" border="0" style=" height:20px; padding:10px; "  >
                <tr>
                    <td class="tdFilter" align="center" ><div ><asp:Literal ID="liNroProyecto" Text="Código BAPIN" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNroProyecto" runat="server"  ControlToValidate="txtNroProyecto" ValidationGroup="FilterProyecto" Text="*" Width="1px" Height="1px"  ErrorMessage="El Nro. de Proyecto no es válido"></asp:RegularExpressionValidator></div>
	                <div><asp:TextBox ID="txtNroProyecto" type="text" min="0" runat="server" CssClass="field_input" Width="100px"  ></asp:TextBox></div>
            		 </td>  
                </tr> 
            </table>
        </asp:Panel>
    </td>
    <td align="right" valign="bottom"style ="height:30px;" align="center"  >
	    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
	    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterProyecto"/>
	</td>
</tr> 
</table>
