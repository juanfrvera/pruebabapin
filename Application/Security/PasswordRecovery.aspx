<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="Application.PasswordRecovery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>¿Olvidó su contraseña?</title>
        <style type="text/css">
        .loginbutton
        {
            font-family: Verdana;
            font-size: 11px;
            color: White;
            background: url(App_Themes/Sky/Imagenes/Layout/back2.gif) #336699 0px 100% repeat-x;
            padding: 2px;
            border: #003366 1px solid;
        }
        .loginfailuretext
        {
            font-family: Verdana;
            font-size: 12px;
            color: #FF2222;
        }
        .listwidth2
        {
            width: 200px;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
        }
    </style>

</head>
<body>

<div class="negro">
        <div id="header">
            <div id="logo">
                <img src="../Images/logo.png" alt="Logo" />
            </div>
            <div id="eslogan">
                Sistema de control de pautas y campañas publicitarias
            </div>
        </div>
        <div class="gris">
            <div id="navegacion" style="height: 15px">
            </div>
        </div>
        <form id="form1" runat="server">
        <div class="blanco">
            <div id="contenido">
                 <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" GeneralFailureText="Su intento de recuperar contraseña ha fallado. Por favor intente de nuevo."
                     UserNameFailureText="No se pudo acceder a sus datos. Por favor intente de nuevo."
                     UserNameInstructionText="Ingrese su usuario para recuperar su contraseña." UserNameRequiredErrorMessage="Se requiere nombre de usuario.">
                     <MailDefinition From="info@GestionLogistica.com" Subject="Gestión Agraria" BodyFileName="~/PasswordRecovery.txt" />
                     <UserNameTemplate>
                         <table width="400" border="0" cellpadding="5px" cellspacing="5px">
                             <tr>
                                 <td colspan="2" class="texto">
                                     <h2>Recuperar Contraseña</h2>
                                     <p>Ingrese su usuario para recuperar su contraseña:</p>
                                 </td>
                             </tr>

                             <tr>
                                 <td colspan="2">
                                 Nombre de Usuario: &nbsp;
                                     <asp:TextBox ID="UserName" runat="server" CssClass="listwidth2" />
                                     <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                         Text="*" />
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     <asp:Button ID="Submit" CommandName="Submit" runat="server" Text="Enviar" CssClass="loginbutton" />
                                 </td>
                                 <td>
                                  <asp:Button OnClick="Volver_Click" ID="Cancelar" runat="server" Text="Volver" CssClass="loginbutton"
                                         CausesValidation="false" />
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="2" align="center" class="loginfailuretext">
                                     <asp:Literal ID="FailureText" runat="server" />
                                 </td>
                             </tr>
                         </table>
                     </UserNameTemplate>
                     <SuccessTemplate>

                <table width="400" border="0" class="iniciofondo2">
                   
                        <tr>
                                 <td colspan="2" class="texto">
                                     <h2>Recuperar Contraseña</h2>
                                     <p>La contraseña ha sido enviada a su casilla de correo.</p>
                                 </td>
                             </tr>
                    
                    <tr>
                        <td width="203" align="left">&nbsp;</td>
                        <td width="176" align="left">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold;"><asp:button OnClick="Volver_Click" id="Volver" runat="server" Text="Volver" CssClass="loginbutton" /></td>
                    </tr>
                </table>
            </SuccessTemplate>
        </asp:PasswordRecovery>   
                     
            </div>
        </div>
        </form>
    </div>
       

</body>
</html>
