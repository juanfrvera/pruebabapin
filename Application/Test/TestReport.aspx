<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestReport.aspx.cs" Inherits="Application.Test.TestReport" MasterPageFile="~/App_Shared/General.Master"  %>
<%@ Register Tagprefix="uc" TagName="Report" Src="~/Controls/WebControl_Report.ascx"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
  <uc:Report runat="server" ID="rpTest" ></uc:Report>
</asp:Content>