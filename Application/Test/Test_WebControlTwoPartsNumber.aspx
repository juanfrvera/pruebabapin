<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Shared/General.Master" CodeBehind="Test_WebControlTwoPartsNumber.aspx.cs" Inherits="UI.Web.Test_WebControlTwoPartsNumber" %>
<%@ Register Tagprefix="uc" TagName="TwoPartsNumber" Src="~/Controls/WebControl_TwoPartsNumber.ascx"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro de Búsqueda"  ID="pnlWCDR" >
                            <div style="width:100%;" >                                                       
                                <uc:TwoPartsNumber runat="server"  ID="wcTwoPartsNumber" ></uc:TwoPartsNumber>
                                <br/>
                                <uc:TwoPartsNumber runat="server"  ID="wcTwoPartsNumber2" ></uc:TwoPartsNumber>
                                <br/>
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