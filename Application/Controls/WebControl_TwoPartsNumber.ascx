<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_TwoPartsNumber.ascx.cs" Inherits="UI.Web.WebControl_TwoPartsNumber" %>
<asp:TextBox runat="server" ID="txtPartOne" Width="30px" MaxLength="4" />
<asp:RegularExpressionValidator ID="valPartOne" runat="server"   ControlToValidate="txtPartOne"  ValidationGroup=""  Text="*" Width="0px" Height="1px" ></asp:RegularExpressionValidator>
-&nbsp;
<asp:TextBox runat="server" ID="txtPartTwo" Width="60px" MaxLength="8"/>
<asp:RegularExpressionValidator ID="valPartTwo" runat="server"   ControlToValidate="txtPartTwo"  ValidationGroup=""  Text="*" Width="0px" Height="1px" ></asp:RegularExpressionValidator>
