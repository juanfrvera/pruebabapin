<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="MonedaCotizacionPageList.aspx.cs" Inherits="UI.Web.MonedaCotizacionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterMonedaCotizacion" Src="MonedaCotizacionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListMonedaCotizacion" Src="MonedaCotizacionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditMonedaCotizacion" Src="MonedaCotizacionEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro de Búsqueda"  ID="pnlFilter" >
                            <div>
                               <uc:FilterMonedaCotizacion runat="server" ID="ftMonedaCotizacion" ></uc:FilterMonedaCotizacion>
						    </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upListButtons" runat="server">
                    <ContentTemplate>
                      <table width="100%">
                        <tr>
                            <td align="left">
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar MonedaCotizacion" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterMonedaCotizacion" ></uc:PaggingButtons ></td>
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
                       <uc:ListMonedaCotizacion runat="server" ID="lstMonedaCotizacion" ></uc:ListMonedaCotizacion >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT MonedaCotizacion-->
            <asp:Panel ID="pnPopUpEditMonedaCotizacion" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditMonedaCotizacionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n MonedaCotizacion</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditMonedaCotizacion" runat="server">             
                <asp:UpdatePanel ID="upEditMonedaCotizacion" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditMonedaCotizacionrunat="server" ID="editMonedaCotizacion" ></uc:EditMonedaCotizacion>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionMonedaCotizacion" runat="server" DisplayMode="BulletList" ValidationGroup="EditionMonedaCotizacion" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnMonedaCotizacion" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditMonedaCotizacion" runat="server" CancelControlID="btPnMonedaCotizacion" 
					PopupDragHandleControlID="pnPopUpEditMonedaCotizacionDragHandle" PopupControlID="pnPopUpEditMonedaCotizacion"
					OkControlID="Button2" TargetControlID="btPnMonedaCotizacion" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT MonedaCotizacion -->            
           </td>
        </tr>
    </table>
</asp:Content>
