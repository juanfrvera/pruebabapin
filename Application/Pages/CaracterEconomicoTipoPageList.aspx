<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="CaracterEconomicoTipoPageList.aspx.cs" Inherits="UI.Web.CaracterEconomicoTipoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterCaracterEconomicoTipo" Src="CaracterEconomicoTipoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListCaracterEconomicoTipo" Src="CaracterEconomicoTipoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro"  ID="pnlFilter" >
                            <div>
                               <uc:FilterCaracterEconomicoTipo runat="server" ID="ftCaracterEconomicoTipo" ></uc:FilterCaracterEconomicoTipo>
						    </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="vsFilterCaracterEconomicoTipo" runat="server" DisplayMode="BulletList"
                    ValidationGroup="FilterCaracterEconomicoTipo" ShowSummary="false"
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
                                <asp:Button  ID ="btNew"  runat = "server" Text="Agregar" OnClick ="btNew_OnClick"  Visible="true" />
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterCaracterEconomicoTipo" ></uc:PaggingButtons ></td>
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
                       <uc:ListCaracterEconomicoTipo runat="server" ID="lstCaracterEconomicoTipo" ></uc:ListCaracterEconomicoTipo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
