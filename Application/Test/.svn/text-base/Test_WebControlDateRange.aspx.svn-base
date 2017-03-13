<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Shared/General.Master" CodeBehind="Test_WebControlDateRange.aspx.cs" Inherits="UI.Web.TestNewControlDateRange" %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro"  ID="pnlWCDR" >
                            <div style="width:100%;" >                                                       
                                <uc:DateRangeInput runat="server" ID="wcDateRangeInput" ></uc:DateRangeInput>
                                <asp:Button ID="Button2" runat="server" Text="Enviar" />
                                <br/>
                                <asp:Label ID="mensaje" runat="server" Text="" />
						    </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>