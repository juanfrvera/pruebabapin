<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="OrganismoPageList.aspx.cs" Inherits="UI.Web.OrganismoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterOrganismo" Src="OrganismoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListOrganismo" Src="OrganismoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro"  ID="pnlFilter" >
                            <div  >
                               <uc:FilterOrganismo runat="server" ID="ftOrganismo" ></uc:FilterOrganismo>
						    </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="vsFilterOrganismo" runat="server" DisplayMode="BulletList"
                    ValidationGroup="FilterOrganismo" ShowSummary="false"
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
								    <asp:Button  ID ="btNew"  runat = "server" Text="Agregar" OnClick ="btNew_OnClick"   />
								    <asp:Button  ID ="btExportExcel"  runat = "server" Text="Exportar a Excel" OnClick ="btExportExcel_OnClick"   />
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterOrganismo" ></uc:PaggingButtons ></td>
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
                       <uc:ListOrganismo runat="server" ID="lstOrganismo" ></uc:ListOrganismo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
