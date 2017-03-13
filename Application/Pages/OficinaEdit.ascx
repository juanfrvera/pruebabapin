<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OficinaEdit.ascx.cs" Inherits="UI.Web.OficinaEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_OficinasSinJudisdiccion.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<ajaxToolkit:TabContainer ID="tcContainer" runat = "server" >
    <ajaxToolkit:TabPanel ID="tpDatosGenerales" runat = "server" HeaderText ="Datos Generales" >
        <ContentTemplate>
            <asp:Panel ID= "pnlDatosGenerales" runat = "server" GroupingText ="Datos Personales"  Width="900px">
                 <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
                    <tr>
	                    <td class="tdLabel"  ><asp:Literal ID="liJurisdiccion" Text="Jurisdicción" runat="server" ></asp:Literal></td>
	                    <td >&nbsp;
	                    <td  class="filaInput"><asp:TextBox ID="txtJurisdiccion" Width="500px"  MaxLength="100" Enabled="false"  runat="server" CssClass="field_input" ReadOnly="true"  ></asp:TextBox></td>
	                </tr> 
	                <tr>
	                    <td>
                            <asp:Literal ID="liOficinaSaf" Text="Oficina" runat="server" ></asp:Literal></td>                       
                        <td >
                            &nbsp;<asp:RegularExpressionValidator ID="revOficina" runat="server"   ControlToValidate="txtOficina"  ValidationGroup="EditionOficina"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		                    <asp:RequiredFieldValidator ID="rfvOficina" runat="server" ControlToValidate="txtOficina"  ValidationGroup="EditionOficina"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		                  </td> 
		                    <td class="filaInput" ><asp:TextBox ID="txtOficina" Width="500px"  MaxLength="100"  runat="server" CssClass="field_input"  ></asp:TextBox>
	                 </tr>
	                <tr>
	                    <td>
                            <asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>                       
                        <td >
                            &nbsp;
                            <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="EditionOficina"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
                        </td> 
		                <td class="filaInput" ><asp:TextBox ID="txtCodigo" Width="500px"  MaxLength="15"  runat="server" CssClass="field_input"  ></asp:TextBox>
	                 </tr>
	                    <tr>
		                    <td class="tdLabel"  ><asp:Literal ID="liOficinaPadre" Text="Oficina Padre" runat="server" ></asp:Literal></td>	
		                    <td class="filaValidator">&nbsp;</td>
		                    <td class="filaInput"><uc:TreeOficinas runat="server" Width="560px" SelectOption="Any" ShowOption="ActivesAndActualValue" ID="toOficinaPadre" ></uc:TreeOficinas></td>
	                    </tr>
	                    <tr>
	                        <td class="tdLabel"  ><asp:Literal ID="liSeleccionable" Text="Seleccionable" runat="server" ></asp:Literal></td>
	                        <td class="filaValidator" >&nbsp;</td>
	                        <td class="filaInput"><asp:CheckBox ID="chkSeleccionable" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
                        </tr>
                        <tr>
		                    <td class="tdLabel"  ><asp:Literal ID="liVisible" Text="Visible" runat="server" ></asp:Literal></td>
		                    <td class="filaValidator" >&nbsp;</td>
		                    <td class="filaInput"><asp:CheckBox ID="chkVisible" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	                    </tr>
	                    <tr>
		                    <td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		                    <td class="filaValidator" >&nbsp;</td>
		                    <td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	                    </tr>
	                 </table>
	            </asp:Panel>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel ID="tpSaf" runat = "server" HeaderText ="SAF" >
        <ContentTemplate>
            <asp:Panel ID= "pnlSAF" runat = "server" GroupingText ="Datos Personales" Width="900px" >
                <asp:UpdatePanel ID="upAgregarSafOficina" runat = "server" UpdateMode ="Conditional" >
                   <ContentTemplate>                 
                     <table width ="100%">
                        <tr>
                            <td class="tdLabel"  ><asp:Literal ID="liSaf" Text="SAF Propio" runat="server" ></asp:Literal></td>
	                        <td class="filaValidator" >&nbsp;<%--  <asp:RequiredFieldValidator ID="rfvSaf" runat="server" ControlToValidate="ddlSaf"  ValidationGroup="EditionOficina"   Text="*" Width="1px" Height="1px" InitialValue=""  ></asp:RequiredFieldValidator>
	                                                         <asp:RequiredFieldValidator ID="rfvSaf2" runat="server" ControlToValidate="ddlSaf"  ValidationGroup="EditionOficina"   Text="*" Width="1px" Height="1px" InitialValue="0" ></asp:RequiredFieldValidator>--%></td>
	                        <td  class="filaInput"><cc:ExtendedDropDownList ID="ddlSaf" runat="server" style="width:400px" CssClass="field_input" AutoPostBack="true" OnSelectedIndexChanged="ddlSafPropio_SelectedIndexChanged"></cc:ExtendedDropDownList></td>
                            <td align ="right"  >
                                <asp:Button ID="btAgregarSafOficina" runat ="server" Text="Agregar" OnClick="btAgregarSafOficina_Click" TabIndex ="27"/> 
                            </td>
                        </tr>
                    </table>
                  </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID= "upGridSafs"  runat = "server" UpdateMode = "Conditional" >
                    <ContentTemplate>
                        <asp:GridView ID="gridSafs" runat = "server"
                            AutoGenerateColumns="False" DataKeyNames="ID" 
                            AllowPaging="True" 
                            OnRowCommand="GridSafs_RowCommand" 
                            OnRowDataBound="GridSafs_RowDataBound"   
                            AllowSorting="True"
                            EmptyDataText="No hay Safs definidos" 
                            Width ="100%"
                        >
                            <Columns>
                                <asp:TemplateField   HeaderText=""  SortExpression=""  HeaderStyle-Width ="4%">            
                                    <ItemTemplate>                        
                                        <asp:RadioButton id="rbSaf" runat="server" GroupName="grupoRadioSaf" OnCheckedChanged="rbSaf_OnCheckedChanged" AutoPostBack="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText ="Código" DataField ="Saf_Codigo" SortExpression ="Saf_Codigo"  HeaderStyle-Width= "10%" />
                                <asp:BoundField HeaderText ="Descripción" DataField ="Saf_Denominacion" SortExpression ="Saf_Denominacion"  HeaderStyle-Width= "84%" />
                                  
                                <asp:TemplateField  HeaderStyle-Width= "6%">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                                    </ItemTemplate>            
                                    <ItemStyle   HorizontalAlign ="Right"/>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </asp:Panel>               
            <asp:Panel runat="server" GroupingText="Programas"  ID="pnlProgramas" >
             <asp:UpdatePanel ID= "upProgramas"  runat = "server" UpdateMode ="Conditional"  >
                    <ContentTemplate>
                    <div>
                        <asp:CheckBox ID="chkTodosProgramas" runat="server" CssClass="field_input" Text="Todos" AutoPostBack="true" OnCheckedChanged="chkTodosProgramas_OnCheckedChanged" ></asp:CheckBox>                                            
                    </div>
                <div>
                     <asp:DataList ID="dlProgramas" runat="server" RepeatColumns="2" RepeatDirection="Vertical" Width="100%" TabIndex ="26" >
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Programa_NombreNumero") %> ' runat="server" />
                            <asp:HiddenField ID="hdValue" Value='<%# Bind("IdPrograma") %>' runat="server" />
                        </ItemTemplate>
                     </asp:DataList>
	            </div>
	             </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
		</ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>

<asp:Panel ID="PopUpSafsOficina" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="SafsOficinaPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpSafsOficina" runat="server" Text="Saf" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnSafsOficina" runat="server">
        <asp:UpdatePanel ID="upSafsOficinaPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 62px">
                                    </td>
                                    <td>
                                        <asp:Literal ID="liSafOficina" Text="SAF" runat="server"></asp:Literal>
                                    </td>
                                    
	                                    <td >&nbsp;</td>
	                                    <td  class="filaInput"><cc:ExtendedDropDownList ID="ddlOficinaSaf" runat="server" style="width:400px" CssClass="field_input" ></cc:ExtendedDropDownList></td>
	                                    <td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvOficinaSaf" runat="server" ControlToValidate="ddlOficinaSaf" InitialValue="0"  ValidationGroup="vgSafsOficina"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	                                </tr>
                                </tr>
                                
                            </table>
                        </td> 
                    </tr> 
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveSafsOficina" Text="Aceptar" OnClick="btSaveSafsOficina_Click"
                                runat="server" ValidationGroup="vgSafsOficina" />
                            <asp:Button ID="btNewSafsOficina" Text="Aceptar y Crear Nuevo" OnClick="btAddAndNewSafsOficina_Click"
                                runat="server" ValidationGroup="vgSafsOficina" />
                            <asp:Button ID="btCancelSafsOficina" Text="Cerrar" OnClick="btCancelSafsOficina_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderSafsOficina" runat="server"
        CancelControlID="Button2" PopupDragHandleControlID="SafsOficinaPopUpDragHandle"
        PopupControlID="PopUpSafsOficina" OkControlID="Button2" TargetControlID="Button2"
        BackgroundCssClass="modalBackground" />
</asp:Panel>