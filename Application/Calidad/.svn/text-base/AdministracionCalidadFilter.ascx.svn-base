<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdministracionCalidadFilter.ascx.cs"
    Inherits="UI.Web.AdministracionCalidadFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<style type="text/css">
    .style1
    {
        width: 96px;
    }
    .style2
    {
        width: 240px;
    }
    .style3
    {
        width: 200px;
    }
</style>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td width="90px">
                        <asp:Literal ID="Literal1" Text="Analista" runat="server"></asp:Literal>&nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAnalista" runat="server" SkinID="AnchoLibre" Width="300px"
                            TabIndex="1" OnSelectedIndexChanged="ddlAnalista_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td width="90px">
                        <asp:Literal ID="Literal4" Text="Tipo Org." runat="server"></asp:Literal>&nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOrganismoTipo" runat="server" TabIndex="2" SkinID="AnchoLibre"
                            Width="300px" OnSelectedIndexChanged="ddlAnalista_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td rowspan="4">
                        <div>
                            <asp:Literal ID="Literal5" Text="Estado" runat="server"></asp:Literal>&nbsp;</div>
                        <div>
                            <asp:ListBox ID="lbxEstado" runat="server" SelectionMode="Multiple" Rows="3" Height="45px"
                                Width="165px" Style="margin-left: 0px"></asp:ListBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td width="90px">
                        <asp:Literal ID="Literal2" Text="SAF" runat="server"></asp:Literal>&nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSAF" runat="server" OnSelectedIndexChanged="ddlSAF_SelectedIndexChanged"
                            AutoPostBack="true" TabIndex="3" SkinID="AnchoLibre" Width="300px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td width="90px">
                        <asp:Literal ID="Literal3" Text="Programa" runat="server"></asp:Literal>&nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrograma" runat="server" TabIndex="4" SkinID="AnchoLibre"
                            Width="300px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td width="90px">
                        <asp:Literal ID="litTipo" Text="Tipo de Proyecto" runat="server"></asp:Literal>&nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoProyecto" runat="server" TabIndex="5" OnSelectedIndexChanged="ddlTipoProyecto_SelectedIndexChanged"
                            AutoPostBack="true" SkinID="AnchoLibre" Width="300px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td width="90px">
                        <asp:Literal ID="Literal6" Text="Proceso" runat="server"></asp:Literal>&nbsp;
                    </td>
                    <td>
                        <%--<asp:ListBox ID="lbxProceso" runat="server" Width="300px"></asp:ListBox>--%>
                        <asp:DropDownList ID="ddlProceso" runat = "server" SkinID ="AnchoLibre" Width ="300px" ></asp:DropDownList>
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td rowspan="4">
                        <div>
                            <asp:Literal ID="liEstadoCalidad" Text="Estado Calidad" runat="server"></asp:Literal>&nbsp;</div>
                        <div>
                            <asp:ListBox ID="lbxEstadoCalidad" runat="server" SelectionMode="Multiple" Rows="3"
                                Height="45px" Width="165px"></asp:ListBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td width="90px">
                        <asp:Literal ID="litEstado" Text="Fechas Estado" runat="server"></asp:Literal>
                    </td>
                    <td colspan="1" class="style2">
                        <uc:DateRangeInput runat="server" ID="drFechaEstado" ValidationGroup="AdministracionCalidad"
                            TabIndexFrom="6" OperatorValidator="LessThanEqual" TabIndexTo="7" />
                    </td>
                    <td></td>
                     <td width="90px">
                        <asp:Literal ID="Literal7" Text="Código Bapin" runat="server"></asp:Literal>
                    </td>
                    <td colspan="1" class="style2">
                        <asp:TextBox ID="txtNroProyecto" 
                             min="0" runat="server" CssClass="field_input" 
                                Width="100px" ></asp:TextBox>
                        &nbsp;<asp:RegularExpressionValidator ID="revNroProyecto" runat="server"  ControlToValidate="txtNroProyecto" ValidationGroup="FilterProyecto" Text="*" Width="1px" Height="1px"  ErrorMessage="El NroProyecto no es válido"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            <asp:Panel runat="server" GroupingText="Plan" ID="pnlFilter">
                <table cellpadding="0" cellspacing="0" border="0" width="760px">
                    <tr>
                        <td style="width: 33%">
                            <div>
                                <asp:Literal ID="liPlanTipo" Text="Tipo" runat="server"></asp:Literal>&nbsp;</div>
                            <div>
                                <asp:DropDownList ID="ddlPlanTipo" runat="server" OnSelectedIndexChanged="ddlPlanTipo_SelectedIndexChanged"
                                    AutoPostBack="true" TabIndex="10">
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td style="width: 33%">
                            <div>
                                <asp:Literal ID="liPlanPeriodo" Text="Período" runat="server"></asp:Literal>&nbsp;</div>
                            <div>
                                <asp:DropDownList ID="ddlPlanPeriodo" runat="server" Enabled="false" TabIndex="11">
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td style="width: 33%">
                            <div>
                                <asp:Literal ID="liPlanVersion" Text="Versión" runat="server"></asp:Literal>&nbsp;</div>
                            <div>
                                <asp:DropDownList ID="ddlPlanVersion" runat="server" Enabled="false" TabIndex="12">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td align="right" valign="bottom" style="width: 100%" colspan="2">
            <asp:Button ID="btClear" runat="server" Text="Limpiar" OnClick="btClear_Click" Visible="true"
                TabIndex="13" />
            &nbsp;<asp:Button ID="btSearch" runat="server" Text="Buscar" OnClick="btSearch_Click"
                Visible="true" ValidationGroup="AdministracionCalidad" TabIndex="14" />
        </td>
    </tr>
</table>
