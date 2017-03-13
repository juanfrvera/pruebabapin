<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Shared/General.Master" CodeBehind="Test_WebControlNumericRange.aspx.cs" Inherits="Application.Test.Test_WebControlNumericRange" %>
<%@ Register Tagprefix="uc" TagName="NumericRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro"  ID="pnlWCDR" >
                            <div style="width:100%;" >                                                       
                                <uc:NumericRangeInput runat="server" ID="wcNumericRangeInput" ></uc:NumericRangeInput>
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