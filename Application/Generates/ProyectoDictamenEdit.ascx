<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoDictamenEdit.ascx.cs" Inherits="UI.Web.ProyectoDictamenEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<style type="text/css">
    .style1
    {
        width: 95px;
    }
    .style2
    {
        width: 8px;
    }
</style>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
    <tr>
        <td>
            <table>
                <tr>
		            <td class="tdLabel"  >
		                <asp:Literal ID="liNumero" Text="Numero" runat="server" ></asp:Literal>
		            </td>
		            <td class="filaValidator">
		                &nbsp;
		                <asp:RegularExpressionValidator ID="revNumero" runat="server"   ControlToValidate="txtNumero"  ValidationGroup="EditionProyectoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Numero no es valido"></asp:RegularExpressionValidator>
		            </td>
		            <td class="filaInput" >
		                <asp:TextBox ID="txtNumero"  Width="60px"  MaxLength="10"       runat="server" CssClass="field_input"  ></asp:TextBox>
		            </td>
	            </tr>
            </table>
	    </td>
	    <td>
	        <table>
	            <tr>
		             <td class="tdLabel"  >
		                <asp:Literal ID="liFecha" Text="Fecha" runat="server" ></asp:Literal>
		             </td>
	 	             <td class="filaValidator">&nbsp;</td>
		             <td class="filaInput" >
		                <uc:DateInput runat="server"  IsValidEmpty="false"   ID="diFecha" />
		            </td>
	            </tr>
	        </table>
	    </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
                    <td class="tdLabel"  >
	                    <asp:Literal ID="liProyectoCalificacion" Text="ProyectoCalificacion" runat="server" ></asp:Literal>
	                </td>
	                <td >
	                    &nbsp;
	                </td>
	                <td  class="filaInput">
	                    <asp:DropDownList ID="ddlProyectoCalificacion" runat="server" CssClass="field_input"  ></asp:DropDownList>
	                </td>
	                <td class="filaValidator">
	                    &nbsp;
	                    <asp:RequiredFieldValidator ID="rfvProyectoCalificacion" runat="server" ControlToValidate="ddlProyectoCalificacion"  ValidationGroup="EditionProyectoDictamen"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	                </tr>              
            </table>
        </td>
        <td>
            <table>
                 <tr>
		             <td class="tdLabel"  ><asp:Literal ID="liFechaVencimiento" Text="Fecha Vencimiento Calificación" runat="server" ></asp:Literal></td>
	 	             <td class="filaValidator">&nbsp;</td>
		             <td class="filaInput" ><uc:DateInput runat="server"  IsValidEmpty="true"   ID="diFechaVencimiento" /></td>
	            </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
	                <td class="tdLabel"  ><asp:Literal ID="liEstado" Text="Estado" runat="server" ></asp:Literal></td>
	                <td >&nbsp;</td>
	                <td  class="filaInput"><asp:DropDownList ID="ddlEstado" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	                <td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado"  ValidationGroup="EditionProyectoDictamen"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	            </tr>    
            </table>
        </td>
        <td>
            <table>
                <tr>
		             <td class="tdLabel"  ><asp:Literal ID="liFechaEstado" Text="FechaEstado" runat="server" ></asp:Literal></td>
	 	             <td class="filaValidator">&nbsp;</td>
		             <td class="filaInput" ><uc:DateInput runat="server"  IsValidEmpty="false"   ID="diFechaEstado" /></td>
	            </tr>
            </table>
        </td>
    </tr>
	<tr>
	    <td>
	        <table>
	            <tr>
		            <td class="tdLabel"  ><asp:Literal ID="liInformeTecnico" Text="InformeTecnico" runat="server" ></asp:Literal></td>
		            <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revInformeTecnico" runat="server"   ControlToValidate="txtInformeTecnico"  ValidationGroup="EditionProyectoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El InformeTecnico no es valido"></asp:RegularExpressionValidator>
		            </td>
		            <td class="filaInput" ><asp:TextBox ID="txtInformeTecnico"  Width="200px"  MaxLength="50"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	            </tr>
	        </table>
	    </td>
	    <td>
	        <table>
	            <tr>
		             <td class="tdLabel"  ><asp:Literal ID="liFechaComiteTecnico" Text="Fecha Reunión Comité Técnico" runat="server" ></asp:Literal></td>
	 	             <td class="filaValidator">&nbsp;</td>
		             <td class="filaInput" ><uc:DateInput runat="server"  IsValidEmpty="true"   ID="diFechaComiteTecnico" /></td>
	            </tr>
	        </table>
	    </td>
	</tr>
	<tr>
	    <td>
	        <table>
	            <tr>
	                <td class="tdLabel"  ><asp:Literal ID="liMonto" Text="Monto" runat="server" ></asp:Literal></td>	
	                <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revMonto" runat="server" ControlToValidate="txtMonto"  ValidationGroup="EditionProyectoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Monto no es valido"></asp:RegularExpressionValidator>
            		
	                </td>
	                <td class="filaInput" ><asp:TextBox ID="txtMonto" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
                </tr>
	        </table>
	    </td>
	    <td>
	        <table>
	            <tr>
	                <td class="tdLabel"  ><asp:Literal ID="liMontoInversionAprobada" Text="Monto Inversión Aprobada" runat="server" ></asp:Literal></td>	
	                <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revMontoInversionAprobada" runat="server" ControlToValidate="txtMontoInversionAprobada"  ValidationGroup="EditionProyectoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Monto no es valido"></asp:RegularExpressionValidator>
            		
	                </td>
	                <td class="filaInput" ><asp:TextBox ID="txtMontoInversionAprobada" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
                </tr>
	        </table>
	    </td>
	</tr>
	<tr>
	    <td>
	        <table>
	            <tr>
		            <td class="tdLabel"  ><asp:Literal ID="liEjercicio" Text="Ejercicio" runat="server" ></asp:Literal></td>	
		            <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEjercicio" runat="server" ControlToValidate="txtEjercicio"  ValidationGroup="EditionProyectoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Ejercicio no es valido"></asp:RegularExpressionValidator>
            		
		            </td>
		            <td class="filaInput" ><asp:TextBox ID="txtEjercicio" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>    
		        </tr>
	        </table>
	    </td>
	    <td>
	        <table>
	            <tr>
		            <td class="tdLabel"  ><asp:Literal ID="liDuracionMeses" Text="DuracionMeses" runat="server" ></asp:Literal></td>	
		            <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDuracionMeses" runat="server" ControlToValidate="txtDuracionMeses"  ValidationGroup="EditionProyectoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El DuracionMeses no es valido"></asp:RegularExpressionValidator>
            		
		            </td>
		            <td class="filaInput" ><asp:TextBox ID="txtDuracionMeses" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	            </tr>
	        </table>
	    </td>    
	</tr>
	<tr>
	    <td colspan ="2">
	        <table width ="100%">
	            <tr>
	                <td class="style1"  ><asp:Literal ID="liObservacion" Text="Observacion" runat="server" ></asp:Literal></td>
		            <td class="style2">&nbsp;<asp:RegularExpressionValidator ID="revObservacion" runat="server"   ControlToValidate="txtObservacion"  ValidationGroup="EditionProyectoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Observacion no es valido"></asp:RegularExpressionValidator>
		            </td>
		            <td class="filaInput" ><asp:TextBox ID="txtObservacion"  Width="100%"  MaxLength="2147483647"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	            </tr>
	        </table>
		</td>
	</tr>
	<tr>
	    <td colspan ="2">
	        <table width ="100%">
	            <tr>
		            <td class="style1"  ><asp:Literal ID="liRecomendacion" Text="Recomendacion" runat="server" ></asp:Literal></td>
		            <td class="style2">&nbsp;<asp:RegularExpressionValidator ID="revRecomendacion" runat="server"   ControlToValidate="txtRecomendacion"  ValidationGroup="EditionProyectoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Recomendacion no es valido"></asp:RegularExpressionValidator>
		            </td>
		            <td class="filaInput" ><asp:TextBox ID="txtRecomendacion"  Width="100%"  MaxLength="2147483647"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	            </tr>
	        </table>
		</td>
	</tr>
	<tr>
	    <td colspan ="2">
	        <asp:Panel ID="pnlRespuestaOrganismo" runat = "server" GroupingText ="Respuesta Del Organismo">
	        
	        </asp:Panel>
	    </td>
	</tr>
	
	
	
	
	
	
	
	
	
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liRespuestaOrganismo" Text="RespuestaOrganismo" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revRespuestaOrganismo" runat="server"   ControlToValidate="txtRespuestaOrganismo"  ValidationGroup="EditionProyectoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El RespuestaOrganismo no es valido"></asp:RegularExpressionValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtRespuestaOrganismo"  Width="100%"  MaxLength="2147483647"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFechaRepuesta" Text="FechaRepuesta" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server"  IsValidEmpty="true"   ID="diFechaRepuesta" /></td>
	</tr>
	 
	
	</table>
