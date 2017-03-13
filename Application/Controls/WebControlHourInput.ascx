<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControlHourInput.ascx.cs" Inherits="UI.Web.WebControlHourInput" %>

<style type="text/css">
    .style1
    {
        text-align: center;
        width: 96px;
    }
</style>

<table>

    <tr>
        <td>

<table style="width: 90px; height: 43px;">
    <tr>
        <td class="style1" >

            <div>
            <asp:TextBox ID="txtHour" runat = "server" Width ="60px"   ></asp:TextBox>
            </div>
            
            <ajaxToolkit:NumericUpDownExtender ID="nudeHour" runat="server"
                TargetControlID="txtHour" Width="100" 
                TargetButtonDownID="buttonDownHour" TargetButtonUpID="buttonUpHour"
                Tag="1"
                Minimum = "0"
                Maximum = "12"
                Step="1"/>
        </td>
        <td>    
                <div style ="width:15px">
                    <div style="text-align:center;vertical-align: middle  ">
                        
                        <asp:Button Font-Bold="True" ID="buttonUpHour" runat="server"  
                            Text="/\" Height="12px" Width="25px"  CssClass="style1 " />
                    </div>
                    <div "text-align:center;vertical-align: middle ">
                        <asp:Button Font-Bold="True" ID="buttonDownHour" runat="server" 
                            Text="\/"  Height="12px" Width="25px" CssClass="style1 " />
                    </div>
                </div>
            </td>
         <td></td>
        </tr> 
     </table>
        </td> 
        <td>
     

<div>
<table style="width: 90px; height: 43px;">
    <tr>
        <td class="style1" >

            <div >
                <asp:TextBox ID="txtMinutes" runat = "server"  Width ="60px"   ></asp:TextBox>
            </div>
            
            <ajaxToolkit:NumericUpDownExtender ID="nudeMinutes" runat="server"
                TargetControlID="txtMinutes" Width="100" 
                TargetButtonDownID="buttonDownMinutes" TargetButtonUpID="buttonUpMinutes"
                Tag="1"
                Minimum = "0"
                Maximum = "60"
                Step="1"/>
        </td>
        <td>    
             <div style ="width:15px">
                    <div style="text-align:center;vertical-align: middle  ">
                        
                        <asp:Button Font-Bold="True" ID="buttonUpMinutes" runat="server"  
                            Text="/\" Height="12px"   Width="25px"  CssClass="style1 " />
                    </div>
                    <div "text-align:center;vertical-align: middle ">
                        <asp:Button Font-Bold="True" ID="buttonDownMinutes" runat="server" 
                          Text="\/"  Height="12px" Width="25px" CssClass="style1 " />
                    </div>
                </div>
            </td>
            <td></td>
        </tr> 
     </table>
     
        </td>
        <td>

<table style="width: 90px; height: 43px;">
    <tr>
        <td class="style1" >

            <div >
            <asp:TextBox ID="txtAMFM" runat = "server"  Width ="60px"  ></asp:TextBox>
            </div>
            
            <ajaxToolkit:NumericUpDownExtender ID="nudeAMFM" runat="server"
                TargetControlID="txtAMFM" Width="100" 
                TargetButtonDownID="buttonDownAMFM" TargetButtonUpID="buttonUpAMFM"
                Tag="1"
                RefValues ="am;fm"
                Step="1"/>
        </td>
        <td>    
                <div style ="width:20px">
                    <div style="text-align:center;vertical-align: middle  ">
                        
                        <asp:Button Font-Bold="True" ID="buttonUpAMFM" runat="server"  
                            Text="/\" Height="12px"   Width="25px"  CssClass="style1 " />
                    <div "text-align:center;vertical-align: middle ">
                        <asp:Button Font-Bold="True" ID="buttonDownAMFM" runat="server" 
                            Text="\/"  Height="12px" Width="25px" CssClass="style1 " />
                    </div>
                </div>
            </td>
            <td></td>
        </tr> 
     </table>
        </td>
    </tr> 
</table>     