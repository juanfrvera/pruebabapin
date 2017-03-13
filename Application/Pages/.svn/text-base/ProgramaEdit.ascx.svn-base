<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramaEdit.ascx.cs"
    Inherits="UI.Web.ProgramaEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<style type="text/css">
    .tdDatosGenerales1
    {
        width: 110px;
    }
    .tdDatosGenerales2
    {
        width: 350px;
    }
    .tdDatosGenerales3
    {
        width: 100px;
    }
    .tdDatosGenerales4
    {
        width: 120px;
    }
</style>
<%--DATOS GENERALES --%>
<asp:Panel ID="pnlDatosGenerales" runat="server" GroupingText="Datos Generales">
  <asp:UpdatePanel ID="udpDatosGenerales" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="ltDatosGeneralesSaf" Text="SAF" runat="server"></asp:Literal>
            </td>
            <td class="tdDatosGenerales2">
                <cc:ExtendedDropDownList ID="ddlSAF" runat="server" Width="500px" SkinID="AnchoLibre">
                </cc:ExtendedDropDownList>
                <asp:RequiredFieldValidator ID="rfvSAF" runat="server" ControlToValidate="ddlSAF"
                    ValidationGroup="EditionPrograma" Text="*" Width="1px" Height="1px" InitialValue="0"></asp:RequiredFieldValidator>
            </td>
            <td class="tdDatosGenerales3">
                <%--<asp:Literal ID="ltDatosGeneralesFechaAlta" Text="Fecha de Alta" runat="server"></asp:Literal>--%>
            </td>
            <td class="tdDatosGenerales4">
                <%-- <uc:DateInput runat="server" IsValidEmpty="false" ID="diFechaAlta" />--%>
            </td>
        </tr>
        <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="ltDatosGeneralesCodigo" Text="Código" runat="server"></asp:Literal>
            </td>
            <td class="tdDatosGenerales2">
                <asp:TextBox ID="txtCodigo" Width="80px" MaxLength="3" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigo"
                    ValidationGroup="EditionPrograma" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"
                    ValidationGroup="EditionPrograma" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
            </td>
            <td class="tdDatosGenerales3">
                <%--<asp:Literal ID="ltDatosGeneralesFechaBaja" Text="Fecha de Baja" runat="server"></asp:Literal>--%>
            </td>
            <td class="tdDatosGenerales4">
                <%-- <uc:DateInput runat="server" ID="diFechaBaja" />--%>
            </td>
        </tr>
        <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="ltSectorialista" Text="Sectorialista" runat="server"></asp:Literal>
            </td>
            <td class="tdDatosGenerales2">
                <cc:ExtendedDropDownList ID="ddlSectorialista" runat="server" CssClass="field_input">
                </cc:ExtendedDropDownList>
   <%--             <asp:RequiredFieldValidator ID="rfvSectorialista" runat="server" ControlToValidate="ddlSectorialista"
                    InitialValue="0" ValidationGroup="EditionPrograma" Text="*" Width="1px"
                    Height="1px"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="tdDatosGenerales3">

            </td>
            <td class="tdDatosGenerales4">
                
            </td>
        </tr>        
    </table>
    <table cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="ltDatosGeneralesDenominacion" Text="Denominación" runat="server"></asp:Literal>
            </td>
            <td width="830px">
                <asp:TextBox runat="server" ID="txtDatosGeneralesDenominacion" Rows="3" TextMode="MultiLine"
                    Width="820px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revDatosGeneralesDenominacion" runat="server"
                    ControlToValidate="txtDatosGeneralesDenominacion" ValidationGroup="EditionPrograma"
                    Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvDatosGeneralesDenominacion" runat="server" ControlToValidate="txtDatosGeneralesDenominacion"
                    ValidationGroup="EditionPrograma" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="liActivo" Text="Activo" runat="server"></asp:Literal>
            </td>
            <td width="830px">
                <asp:CheckBox ID ="chkActivo"  runat ="server" />
            </td>
        </tr>
    </table>
     </ContentTemplate>
 </asp:UpdatePanel>
</asp:Panel>
<%--SUBPROGRAMAS --%>
<asp:Panel ID="pnlSubProgramas" runat="server" GroupingText="Subprogramas">
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0" width="100%">
                    <tr>
                        <td align="right">
                            <asp:UpdatePanel ID="pnlAgregarSubPrograma" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Button ID="btAgregarSubPrograma" runat="server" Text="Agregar" OnClick="btAgregarSubPrograma_Click"
                                        TabIndex="1" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="upGridSubProgramas" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gridSubProgramas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                            AllowPaging="True" AllowSorting="True" OnSorting="GridSubProgramas_Sorting" OnPageIndexChanging="GridSubProgramas_PageIndexChanging"
                            OnRowCommand="GridSubProgramas_RowCommand" EmptyDataText="No hay subprogramas definidos"
                            Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Código" DataField="Codigo" SortExpression="Codigo" />
                                <asp:BoundField HeaderText="Denominación" DataField="Nombre" SortExpression="Nombre" />
                                <asp:BoundField HeaderText="Fecha Alta" DataField="FechaAlta" SortExpression="FechaAlta"  DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="Fecha Baja" DataField="FechaBaja" SortExpression="FechaBaja" DataFormatString="{0:dd/MM/yyyy}"  />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                            CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        &nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                            CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                            CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Panel>
<%--PANEL ALTA SUBPROGRAMA --%>
<asp:Panel ID="PopUpSubProgramas" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="SubProgramasPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5px">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpSubProgramas" runat="server" Text="Subprogramas" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnSubProgramas" runat="server">
        <asp:UpdatePanel ID="upSubProgramasPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="5px">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltSubProgramaCodigo" Text="Código" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtSubProgramaCodigo" Width="60px" MaxLength="3" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="revSubProgramaCodigo" runat="server" ControlToValidate="txtSubProgramaCodigo"
                                            ValidationGroup="vgSubPrograma" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rfvSubProgramaCodigo" runat="server" ControlToValidate="txtSubProgramaCodigo"
                                            ValidationGroup="vgSubPrograma" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltSubPrograma" Text="Subprograma" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSubProgramaDenominacion" Rows="3" TextMode="MultiLine"
                                            Width="700px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RegularExpressionValidator ID="revSubProgramaDenominacion" runat="server" ControlToValidate="txtSubProgramaDenominacion"
                                            ValidationGroup="vgSubPrograma" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rfvSubProgramaDenominacion" runat="server" ControlToValidate="txtSubProgramaDenominacion"
                                            ValidationGroup="vgSubPrograma" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="0" cellspacing="5px">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveSubProgramas" Text="Aceptar" OnClick="btSaveSubPrograma_Click"
                                runat="server" ValidationGroup="vgSubPrograma" />
                            <asp:Button ID="btNewSubProgramas" Text="Aceptar y Agregar Nuevo" OnClick="btNewSubPrograma_Click"
                                runat="server" ValidationGroup="vgSubPrograma" />
                            <asp:Button ID="btCancelSubProgramas" Text="Cerrar" OnClick="btCancelSubPrograma_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsSubPrograma" runat="server" DisplayMode="BulletList"
        ValidationGroup="vgSubPrograma" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
    <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderSubProgramas" runat="server"
        CancelControlID="Button1" PopupDragHandleControlID="SubProgramasPopUpDragHandle"
        PopupControlID="PopUpSubProgramas" OkControlID="Button1" TargetControlID="Button1"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
