<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="GeoreferenciacionPageList.aspx.cs" Inherits="UI.Web.GeoreferenciacionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterGeoreferenciacion" Src="GeoreferenciacionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListGeoreferenciacion" Src="GeoreferenciacionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditGeoreferenciacion" Src="GeoreferenciacionEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro"  ID="pnlFilter" >
                            <div style="padding:15px" >
                               <uc:FilterGeoreferenciacion runat="server" ID="ftGeoreferenciacion" ></uc:FilterGeoreferenciacion>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar Georeferenciacion" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick="return confirm('Está seguro de eliminar?');" OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterGeoreferenciacion" ></uc:PaggingButtons ></td>
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
                       <uc:ListGeoreferenciacion runat="server" ID="lstGeoreferenciacion" ></uc:ListGeoreferenciacion >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT Georeferenciacion-->
            <asp:Panel ID="pnPopUpEditGeoreferenciacion" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditGeoreferenciacionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n Georeferenciacion</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditGeoreferenciacion" runat="server">             
                <asp:UpdatePanel ID="upEditGeoreferenciacion" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditGeoreferenciacionrunat="server" ID="editGeoreferenciacion" ></uc:EditGeoreferenciacion>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionGeoreferenciacion" runat="server" DisplayMode="BulletList" ValidationGroup="EditionGeoreferenciacion" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnGeoreferenciacion" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditGeoreferenciacion" runat="server" CancelControlID="btPnGeoreferenciacion" 
					PopupDragHandleControlID="pnPopUpEditGeoreferenciacionDragHandle" PopupControlID="pnPopUpEditGeoreferenciacion"
					OkControlID="Button2" TargetControlID="btPnGeoreferenciacion" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT Georeferenciacion -->            
           </td>
        </tr>
    </table>
</asp:Content>
