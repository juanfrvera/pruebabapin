<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_DateInput.ascx.cs"
    Inherits="UI.Web.WebControl_DateInput" %>
<asp:TextBox runat="server" ID="txFecha" Width="70px" OnTextChanged="txFecha_OnTextChanged" />
<asp:ImageButton runat="server" ID="btCalendario" ImageUrl="~/Images/Calendar.png"
    Width="16px" Height="16px" TabIndex="-1" CssClass="imgButton" />
<asp:RangeValidator runat="server" ID="rvFecha" Display="Dynamic" ControlToValidate="txFecha"
    MaximumValue="01/01/2100" MinimumValue="01/01/1900" Text="*" Width="1px" Type="Date"></asp:RangeValidator>
<asp:RequiredFieldValidator runat="server" ID="rfvFecha" Enabled="false" Display="Dynamic"
    ControlToValidate="txFecha" Text="*" Width="1px"></asp:RequiredFieldValidator>
<ajaxToolkit:CalendarExtender ID="txFechaCalendar" runat="server" TargetControlID="txFecha"
    PopupButtonID="btCalendario">
</ajaxToolkit:CalendarExtender>
<ajaxToolkit:MaskedEditExtender TargetControlID="txFecha" ID="MaskedEditExtender1"
    runat="server" MaskType="Date" Mask="99/99/9999" CultureName="en-GB" />
<%--<ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlToValidate="txFecha"
    ControlExtender="MaskedEditExtender1" IsValidEmpty="true" ValidationGroup="" 
    MaximumValue="01/01/2100" MinimumValue="01/01/1900"/>--%>
<style type="text/css">
    .imgButton
    {
        padding: 0px 0px 0px 0px;
    }
</style>