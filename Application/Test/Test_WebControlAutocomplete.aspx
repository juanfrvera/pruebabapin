<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Shared/General.Master" CodeBehind="Test_WebControlAutocomplete.aspx.cs" Inherits="UI.Web.Test_WebControlAutocomplete" %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumericRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro de Búsqueda"  ID="pnlWCDR" >
                            <div style="width:100%;" >                                                       
                                <uc:Autocomplete runat="server" ID="wcAutocomplete1" ></uc:Autocomplete>
                                <uc:Autocomplete runat="server" ID="wcAutocomplete2" ></uc:Autocomplete>
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