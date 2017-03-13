<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="WebControl_Report.ascx.cs" Inherits="UI.Web.WebControl_Report" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<script lang ="javascript" type="text/javascript">
    function Cerrar() {
        window.close();
    }
</script>

<div>
    <rsweb:reportviewer id="reportView" runat="server" height="100%" width="100%" AsyncRendering="False" SizeToReportContent="true"  >
   </rsweb:ReportViewer>
</div>
<table style="width:100%">
    <tr style="border-style: solid">
        <td>
        </td>
    </tr>
    <tr>
        <td style="padding-top: 30px; text-align:right"">
            <asp:button id="btCancelar" runat="server" text="Cancelar" onclientclick="javascript:Cerrar()" />
        </td>
    </tr>
</table>
