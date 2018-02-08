<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="AdministracionTemplate.aspx.cs" Inherits="UI.Web.Cubos.AdministracionTemplate" EnableEventValidation="false" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc" TagName="AdministracionTemplateUpload" Src="AdministracionTemplateUpload.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <asp:Panel ID="pnEdicionArchivo" runat="server">
        <asp:UpdatePanel ID="upEditArchivo" runat="server" UpdateMode="Conditional" >
            <ContentTemplate>
                <uc:AdministracionTemplateUpload runat="server" ID="editTemplateAdjuntar" ></uc:AdministracionTemplateUpload>
            </ContentTemplate>
            <Triggers >
                <asp:PostBackTrigger  ControlID ="editTemplateAdjuntar"  />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>

</asp:Content>
