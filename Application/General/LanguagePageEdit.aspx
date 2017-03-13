<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="LanguagePageEdit.aspx.cs" Inherits="UI.Web.LanguagePageEdit" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="EditLanguage" Src="LanguageEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table >		 
		<tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>
                        <uc:EditLanguage runat="server" ID="editLanguage" ></uc:EditLanguage>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		<tr>
		    <td colspan="2">
		        <asp:ValidationSummary id="vsEditionLanguage" runat="server" DisplayMode="BulletList" ValidationGroup="EditionLanguage" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
		    </td>
		</tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upEditButtons" runat="server">
                    <ContentTemplate>
                       <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionLanguage" ></uc:EditButtons >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>    
                <asp:Button  ID ="btComplete"  runat = "server" Text="Completar" OnClick ="btComplete_OnClick"   />
            </td>
        </tr>		
    </table>
</asp:Content>
