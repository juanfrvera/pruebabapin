<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_NumericRangeInput.ascx.cs" Inherits="UI.Web.WebControl_NumericRangeInput" %>
<asp:Panel ID="pnControl" runat="server" >
<%=this.TagFrom %>
<asp:TextBox runat="server" ID="txtFrom" Width="60px"/>
<%=this.TagTo %>
<asp:TextBox runat="server" ID="txtTo" Width="60px"/>
<asp:CompareValidator ID="compareValidator" runat="server" 
                      ControlToValidate="txtFrom"
                      ControlToCompare="txtTo" 
                      Type="Double" ValidationGroup="" 
                      Operator="LessThanEqual" Enabled="false"
                      Text="*"></asp:CompareValidator>

<asp:RequiredFieldValidator id="requiredFrom" 
                            runat="server" 
                            ControlToValidate="txtFrom"
                            Text="*"
                            Display="dynamic" 
                            Enabled="false" 
                            ValidationGroup=""/>
                                
<asp:RequiredFieldValidator id="requiredTo" 
                            runat="server" 
                            ControlToValidate="txtTo"
                            Text="*" 
                            Display="dynamic" 
                            Enabled="false" 
                            ValidationGroup=""/>
                                
<asp:RegularExpressionValidator ID="RegularExpressionValidatorFrom" runat="server" ControlToValidate="txtFrom"
                                Text="*"
                                ValidationExpression="(?!^0*$)(?!^0*\.0*$)^\d{1,18}(\,\d{1,2})?$" ValidationGroup=""></asp:RegularExpressionValidator>
                                
<asp:RegularExpressionValidator ID="RegularExpressionValidatorTo" runat="server" ControlToValidate="txtTo"
                                Text="*" 
                                ValidationExpression="(?!^0*$)(?!^0*\.0*$)^\d{1,18}(\,\d{1,2})?$" ValidationGroup=""></asp:RegularExpressionValidator>

</asp:Panel>