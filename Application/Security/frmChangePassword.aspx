<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="True" CodeBehind="frmChangePassword.aspx.cs" Inherits="UI.Web.frmChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
        <div id="texto" style="margin-bottom: 30px">
        <h2>Cambiar Contraseña</h2>
        </div>
        
    <asp:UpdatePanel runat="server" ID="upChangePassword">
        <ContentTemplate>       
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Panel ID="pData" runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                Contraseña Actual:
                                                <td>
                                                    <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" Columns="50"
                                                        MaxLength="50" Width="300px" />
                                                    <asp:requiredfieldvalidator id="CurrentPasswordValidator" runat="server" ControlToValidate="CurrentPassword" Text="*" />
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Nueva Contraseña:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"
                                                    Columns="50" MaxLength="50" Width="300px" />
                                                <asp:requiredfieldvalidator ID="NewPasswordValidator" runat="server" ControlToValidate="NewPassword" Text="*" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Confirmar Contraseña:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="ConfirmPassword" runat="server"
                                                    TextMode="Password" Columns="50" MaxLength="50" Width="300px" />
                                                <asp:requiredfieldvalidator ID="ConfirmPasswordValidator" runat="server" ControlToValidate="ConfirmPassword" Text="*" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <table width="100%">

                                    <tr>
                                    <td>
                                          <asp:Label  ID="lblMessage"  runat="server" Font-Bold="true" ForeColor="Red" ></asp:Label>    
                                    </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                        <br />
                                        <br />
                                            <asp:Button ID="ChangePasswordButton" runat="server" Text="Aceptar" SkinID="LightButton" OnClick="Aceptar_Click"
                                                CausesValidation="true" />
                                            <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancelar" SkinID="LightButton"
                                                CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>