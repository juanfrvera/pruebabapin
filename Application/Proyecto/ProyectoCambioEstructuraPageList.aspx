<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoCambioEstructuraPageList.aspx.cs" Inherits="UI.Web.ProyectoCambioEstructuraPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterProyecto" Src="ProyectoCambioEstructuraFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListProyecto" Src="ProyectoCambioEstructuraList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="DestinoProyecto" Src="ProyectoCambioEstructuraDestino.ascx" %>
<%@ Register Tagprefix="uc"  TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro de Búsqueda"  ID="pnlFilter" >
                            <div  >
                               <uc:FilterProyecto runat="server" ID="ftProyecto" ></uc:FilterProyecto>
						    </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="vsFilterProyecto" runat="server" DisplayMode="BulletList"
                    ValidationGroup="FilterProyecto" ShowSummary="false"
                    ShowMessageBox="True"></asp:ValidationSummary>
            </td>
        </tr>
		<tr>
            <td>
                <asp:Panel runat="server" GroupingText="Selección"  ID="pnSeleccion" >
                   <div  >
                        <asp:UpdatePanel ID="upListButtons" runat="server">
                            <ContentTemplate>
                              <table >
                                <tr>
                                    <td align="left" style=" width:570px">
								         <asp:Button  ID ="btClearSelecteds"  runat = "server" Text="Limpiar" OnClick ="btClearSelecteds_OnClick"   />
								         <asp:RadioButton ID="rbOnlySelectedItems" GroupName="rbgActionItems" runat="server" TextAlign="Left"  Text="Seleccionados" />
                                         <asp:RadioButton ID="rbAllItems" GroupName="rbgActionItems" runat="server" TextAlign="Left"  Text="Todos"  />
                                     </td>
                                    <td align="right" style=" width:430px"><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterProyecto" ></uc:PaggingButtons ></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="upGrilla" runat="server">
                                            <ContentTemplate>
                                               <uc:ListProyecto runat="server" ID="lstProyecto" ></uc:ListProyecto >
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                              </table>                       
                            </ContentTemplate>
                        </asp:UpdatePanel>
                   </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="left" >
                <asp:Button  ID ="btCopiaHistoria"  runat = "server" Text="Copia Historia" OnClick ="btCopiaHistoria_OnClick"   />
				<asp:Button  ID ="btCambiarEstructura"  runat = "server" Text="Cambiar Estructura" OnClick ="btCambiarEstructura_OnClick"   />&nbsp;&nbsp;
            </td>
        </tr>	
        <tr>
            <td>
                <asp:Panel runat="server" GroupingText="Destino"  ID="pnDestino" >
                  <div  >
                    <asp:UpdatePanel ID="upDestino" runat="server">
                        <ContentTemplate>
                           <uc:DestinoProyecto runat="server" ID="destinoProyecto" ></uc:DestinoProyecto >
                        </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
