<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true"
    CodeBehind="TextPageList.aspx.cs" Inherits="UI.Web.TextPageList" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="FilterText" Src="TextFilter.ascx" %>
<%@ Register TagPrefix="uc" TagName="ListText" Src="TextList.ascx" %>
<%@ Register TagPrefix="uc" TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
                        <asp:Panel runat="server" GroupingText="Filtro de Búsqueda" ID="pnlFilter">
                            <div>
                                <uc:FilterText runat="server" ID="ftText"></uc:FilterText>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="vsFilterText" runat="server" DisplayMode="BulletList"
                    ValidationGroup="FilterText" ShowSummary="false"
                    ShowMessageBox="True"></asp:ValidationSummary>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upListButtons" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td align="left">
                                    <asp:Button ID="btNew" runat="server" Text="Agregar" OnClick="btNew_OnClick" />
                                </td>
                                <td align="right">
                                    <uc:PaggingButtons runat="server" ID="pgButtons" SearchVisible="true" ValidationGroup="FilterText">
                                    </uc:PaggingButtons>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upGrilla" runat="server">
                    <ContentTemplate>
                        <uc:ListText runat="server" ID="lstText"></uc:ListText>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
