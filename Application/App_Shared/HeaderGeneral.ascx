<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderGeneral.ascx.cs" Inherits="UI.Web.HeaderGeneral" %>

<div class="headerExtendido">
    <div id="header">
        <table>
            <tr>
                <!-- Matias 20140114 - Tarea 106 -->
                <!--<td>-->
                <!--<img src="../Images/logoMECON.png" width="174" height="52" alt="Logo Ministerio de Economía" title="Logo Ministerio de Economía" align="absmiddle"/> <span class="mainTitle">BAPIN</span>-->

                <!-- Matias 20161031 - Tarea Limpiar Header -->
  <!--  -->
  <!--</td>-->
    <td style=" width:630px; text-align:right">
      <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="Logo Ministerio de Economía" ImageUrl="~/Images/logoMECON.png" width="1" height="1" OnClick="Logo_Click"/>
                    <span class="mainTitle">Sistema Nacional de Inversiones Públicas</span>
                    <br />
                    <span class="mainTitleSubtitle">BAPIN</span>
                </td>
                <td style="width: 300px; text-align: right">
                    <!-- Matias 20131206 - Tarea 97 -->
                    <span class="admin">
                        <asp:Label ID="liUser" runat="server" />
                        &nbsp;<b></b>&nbsp;<asp:Label ID="liUserName" runat="server" Visible="false" />

                        <!--<asp:LinkButton ID="lbLogout" runat="server" OnClick="Logout_Click"> Cerrar sesión</asp:LinkButton>-->
                        <!--<asp:LinkButton ID="lbPassword" runat="server" OnClick="Password_Click">Cambiar password</asp:LinkButton>-->

                    </span>
                </td>
  <!--<td width="26">-->
  <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Cambiar contraseña" ToolTip="Cambiar contraseña" ImageUrl="~/Images/key_02.png" Height="16" Width="16" OnClick="Password_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Cerrar sesión" ToolTip="Cerrar sesión" ImageUrl="~/Images/logout.ico" Height="24" Width="24" OnClick="Logout_Click" />
                </td>
            </tr>
            <!-- FinMatias 20131206 - Tarea 97 -->
        </table>
    </div>
</div>


