<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageSendEdit.ascx.cs" Inherits="UI.Web.MessageSendEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<style type ="text/css">
    .tdLabel
    {
        width :140px;
        vertical-align : top;
    }
</style>


<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  
     <tr>
        <td class="tdLabel"  ><asp:Literal ID="liProyectoAsociado" Text="BAPIN" runat="server"  ></asp:Literal></td>
        <td  class="filaInput"><asp:Label ID="lbBAPIN" runat="server" ></asp:Label></td>
        <td class="filaValidator">&nbsp;</td>
    </tr>
    <tr>
        <td class="tdLabel"  ><asp:Literal ID="liProyectoDenominacion" Text="Denominación BAPIN" runat="server" ></asp:Literal></td>
        <td  class="filaInput" colspan="3"><asp:Label ID="lbDenominacionBAPIN" runat="server"  Width="650px"></asp:Label></td>
    </tr>
    <tr>
         <td ><asp:Literal ID="liPrioridad" Text="Prioridad" runat="server" ></asp:Literal>&nbsp;</td>
                   <td class="filaInput"> <asp:Label ID="lbPrioridad" runat="server" ></asp:Label></td>
                    <td class="filaValidator">&nbsp;</td>
    </tr>
    <tr>
        <td class="tdLabel"  ><asp:Literal ID="liDe" Text="De" runat="server" ></asp:Literal></td>
        <td  class="filaInput"><asp:Label ID="lbUserFrom" runat="server" ></asp:Label></td>
        <td class="filaValidator">&nbsp;</td>
    </tr>
    <tr>
        <td class="tdLabel"  ><asp:Literal ID="liA" Text="Para" runat="server" ></asp:Literal></td>
        <td  class="filaInput"><asp:Label ID="lbUserTo" runat="server" ></asp:Label></td>
        <td class="filaValidator">&nbsp;</td>
    </tr>
    <tr>
	    <td class="tdLabel"  ><asp:Literal ID="liEnviado" Text="Fecha" runat="server" ></asp:Literal></td>
	    <td class="filaInput"><asp:Label ID="lbFecha" runat="server" ></asp:Label></td>
	    <td class="filaValidator" >&nbsp;</td>
    </tr>
    <tr>
	    <td class="tdLabel"  ><asp:Literal ID="liLeido" Text="Leído" runat="server" ></asp:Literal></td>
	    <td class="filaInput"><asp:CheckBox ID="chkLeido" runat="server" CssClass="field_input" ></asp:CheckBox></td>
	    <td class="filaValidator" >&nbsp;</td>
	</tr>
    <tr>
	    <td class=""><asp:Literal ID="liFecha" runat="server" Text ="Fecha de Lectura" ></asp:Literal></td>
        <td> <asp:Label ID="lbFechaLeido" runat = "server"  ></asp:Label></td> 
        <td class="filaValidator" >&nbsp;</td>      
    </tr>
    <tr>
	    <td class="tdLabel"  ><asp:Literal ID="liEsManual" Text="Es Manual" runat="server" ></asp:Literal></td>
	    <td class="filaInput"><asp:CheckBox ID="chkEsManual" runat="server" CssClass="field_input" ></asp:CheckBox></td>
	    <td class="filaValidator" >&nbsp;</td>
    </tr>
    <tr>
        <td class="tdLabel"  ><asp:Literal ID="liAsunto" Text="Asunto" runat="server" ></asp:Literal></td>
        <td  class="filaInput"><asp:Label ID="lbAsunto" runat="server" ></asp:Label></td>
        <td class="filaValidator">&nbsp;</td>
    </tr>
    <tr>        
        <td  class="filaInput"  colspan="5" >
        <asp:Panel runat="server" GroupingText="Mensaje"  ID="pnlBody" Width="800px"  >
            <asp:Label ID="lbBody" runat="server"  ></asp:Label>
        </asp:Panel>
        </td>        
    </tr>
</table>
