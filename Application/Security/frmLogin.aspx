<%@ Page Title="BAPIN" Language="C#" MasterPageFile="~/App_Shared/UnSecure.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="UI.Web.frmLogin" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
  <fieldset>
    <legend><asp:Literal ID="liInicioSesion" Text="Inicio de Sesión" runat="server" ></asp:Literal></legend>
    <div id="iniciarSesion">
      <label for="usuario"><asp:Literal ID="liUsuario" Text="Usuario" runat="server" ></asp:Literal></label>      
      <asp:requiredfieldvalidator id="UserNameRequired" runat="server" ControlToValidate="txtUserName" Text="*" />
      <asp:TextBox id="txtUserName" runat="server" CssClass="listwidth2" />
      <label for="password"><asp:Literal ID="liContrania" Text="Contraseña" runat="server" ></asp:Literal></label>
      <asp:requiredfieldvalidator id="PasswordRequired" runat="server" ControlToValidate="txtPassword" Text="*" />
      <asp:TextBox id="txtPassword" runat="server" textMode="Password" CssClass="listwidth2"/>       
      <asp:button id="btLogin" runat="server" Text="Iniciar Sesión" OnClick ="btLogin_Click" CssClass="loginbutton"/>
      <asp:Label  ID="lblMessage"  runat="server" Font-Bold="true" ForeColor="Red" ></asp:Label>    
    </div>  
  </fieldset>
</asp:Content>
