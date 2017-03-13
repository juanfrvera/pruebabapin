<%@ Page Language="C#" MasterPageFile="~/App_Shared/UnSecure.Master"  AutoEventWireup="true"  CodeBehind="frmError.aspx.cs" Inherits="UI.Web.frmError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
<fieldset>
    <legend><asp:Literal ID="liInicioSesion" Text="Error" runat="server" ></asp:Literal></legend>
        <table width ="100%" >
           <tr>
               <td align ="center" >
                   <asp:Label ID="MessageLabel" CssClass="error" runat="server" />
               </td>
           </tr>             
           <tr>
               <td align ="center" >
                    <asp:Button ID="btOk" runat="server" Text="Ok" OnClick="btOk_Click" CausesValidation="false" />
               </td>
           </tr>               
        </table>
</fieldset>
</asp:Content>