<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web._Default" MasterPageFile="~/App_Shared/General.Master"%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContenidoPrincipal">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <div class="texto">
        <h3>
            <asp:Label ID="lbMsjBienvenida" runat="server" Text="" ></asp:Label>
            </h3>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
