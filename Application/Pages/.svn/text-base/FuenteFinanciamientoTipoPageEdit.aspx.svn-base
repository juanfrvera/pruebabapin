<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="FuenteFinanciamientoTipoPageEdit.aspx.cs" Inherits="UI.Web.FuenteFinanciamientoTipoPageEdit" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="EditFuenteFinanciamientoTipo" Src="FuenteFinanciamientoTipoEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table >
		<tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>
                        <uc:EditFuenteFinanciamientoTipo runat="server" ID="editFuenteFinanciamientoTipo" ></uc:EditFuenteFinanciamientoTipo>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		<tr>
		    <td>
		        <asp:ValidationSummary id="vsEditionFuenteFinanciamientoTipo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionFuenteFinanciamientoTipo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
		    </td>
		</tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upEditButtons" runat="server">
                    <ContentTemplate>
                       <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionFuenteFinanciamientoTipo" ></uc:EditButtons >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>		
    </table>
</asp:Content>
