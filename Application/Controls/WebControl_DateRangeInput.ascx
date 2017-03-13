<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_DateRangeInput.ascx.cs" Inherits="UI.Web.WebControl_DateRangeInput" %>
<%@ Register Tagprefix="uc" TagName="DateInputFrom" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateInputTo" Src="~/Controls/WebControl_DateInput.ascx"   %>
<asp:Panel ID="pnControl" runat="server" >
<%=this.TagFrom %>
<uc:DateInputFrom runat="server" ID="diDateValueFrom"/>
<%=this.TagTo%>
<uc:DateInputTo runat="server" ID="diDateValueTo"/>
<asp:CompareValidator ID="compareValidator" runat="server" 
                      ControlToValidate="diDateValueFrom$txFecha"
                      ControlToCompare="diDateValueTo$txFecha" 
                      Type="Date" ValidationGroup="" 
                      Operator="LessThanEqual"
                      Text="*"
                      ErrorMessage="Rango de fechas incorrecto"></asp:CompareValidator>
</asp:Panel>