<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Shared/General.Master" CodeBehind="Test_WebControlThreeStatesCheckbox.aspx.cs" Inherits="UI.Web.Test_WebControlThreeStatesCheckbox" %>
<%@ Register Tagprefix="uc" TagName="ThreeStatesCheckbox" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro de Búsqueda"  ID="pnlWCDR" >
                            <div style="width:100%;" >                                                       
                                <uc:ThreeStatesCheckbox runat="server"  ID="wcThreeStatesCheckbox" ></uc:ThreeStatesCheckbox>
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