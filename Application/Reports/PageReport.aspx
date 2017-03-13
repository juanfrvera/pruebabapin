<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Shared/General.Master" CodeBehind="PageReport.aspx.cs" Inherits="UI.Web.PageReport" %>
<%@ Register Tagprefix="uc" TagName="Report" Src="~/Controls/WebControl_Report.ascx"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
  <uc:Report runat="server" ID="ucReport" ></uc:Report>
</asp:Content>