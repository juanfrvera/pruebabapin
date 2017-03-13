<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditOperationFilter.ascx.cs" Inherits="UI.Web.AuditOperationFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" width="25%" ><div ><asp:Literal ID="liFechaInicio" Text="Fecha de Inicio" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdStartDate"  />         
		</td>	    
	    <td class="tdFilter" width="25%" >
	        <div ><asp:Literal ID="liSesion" Text="Sesi�n" runat="server" ></asp:Literal><asp:RegularExpressionValidator ID="revSessionId" runat="server"  ControlToValidate="txtSessionId" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtSessionId" runat="server" CssClass="field_input"  ></asp:TextBox></div>
		</td>
		<td class="tdFilter" width="25%" >
		    <div ><asp:Literal ID="liUsuario" Text="Usuario" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revUserName" runat="server"  ControlToValidate="txtUserName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtUserName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
        <td class="tdFilter" width="25%" >
            <div ><asp:Literal ID="liOperacion" Text="Operaci�n" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revOperation" runat="server"  ControlToValidate="txtOperation" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtOperation" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>       
	</tr>
	<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liFechaFin" Text="Fecha de Fin" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdEndDate"  />         
		</td>
		 <td class="tdFilter" >
            <div ><asp:Literal ID="liEntidad" Text="entidad" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revEntityName" runat="server"  ControlToValidate="txtEntityName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtEntityName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
        <td class="tdFilter" >
            <div ><asp:Literal ID="liEntidadBase" Text="Entidad Base" runat="server" >&</asp:Literal>nbsp;<asp:RegularExpressionValidator ID="revEntityBaseName" runat="server"  ControlToValidate="txtEntityBaseName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtEntityBaseName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>	
	    <td class="tdFilter" >
	        <div ><asp:Literal ID="liTipo" Text="Tipo" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revTypeName" runat="server"  ControlToValidate="txtTypeName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtTypeName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
               
	</tr>
	<tr>
	    <td class="tdFilter" >
            <div ><asp:Literal ID="liID" Text="ID" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revEntityId" runat="server"  ControlToValidate="txtEntityId" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtEntityId" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
        <td class="tdFilter" >
            <div ><asp:Literal ID="liClave" Text="Clave" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revEntityKey" runat="server"  ControlToValidate="txtEntityKey" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtEntityKey" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>	    
        <td class="tdFilter" >
            <div ><asp:Literal ID="liServicio" Text="Servicio" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revService" runat="server"  ControlToValidate="txtService" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtService" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>        
        <td class="tdFilter" >
            <div ><asp:Literal ID="liEstado" Text="Estado" runat="server" >&</asp:Literal>nbsp;<asp:RegularExpressionValidator ID="revStatusName" runat="server"  ControlToValidate="txtStatusName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtStatusName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr>
	<tr>
	    <td class="tdFilter" >      
		</td>
        <td class="tdFilter" > 
        </td>
        <td class="tdFilter" > 
        </td>
        <td align="right" valign="bottom" >
            <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true"  />
            &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterAuditOperation"/>
        </td>
	</tr>
	
	<tr>
</table>
