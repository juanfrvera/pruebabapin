<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_CopyProject.ascx.cs" Inherits="UI.Web.WebControl_CopyProject" %>
<script>
 function PleaseWaitButton(Control) {
    document.forms[0].submit();
    window.setTimeout("DisableButton('" + Control + "')", 0);
}
function DisableButton(buttonID) {
    $(buttonID).disabled=true;
    $(buttonID).value = "Procesando.. Espere por favor...";
}
function $(id){return document.getElementById(id);}
</script>
<asp:Panel ID="pnPopupCopy" runat="server" Width="400px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color:Gray;">
    <asp:Panel ID="pnPopupCopyDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td><asp:Literal ID="liTitle" runat="server" Text="Copiar Proyecto" ></asp:Literal></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:UpdatePanel ID="upControls" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <table width="100%" >
                <tr>
                    <td>
                        <asp:Literal ID="liNombre" runat="server" Text="Denominación" ></asp:Literal><br />
                       <asp:TextBox ID="txtNombre" runat="server" MaxLength="500" TextMode="MultiLine" Columns="60" Rows="5"  ></asp:TextBox>
                   </td>
                </tr>
                <tr>
                    <td >
                        <asp:Panel ID="pnSolapas" runat="server" GroupingText="Solapas" >
                            <table>
                                <tr>
                                    <td><asp:CheckBox runat="server" ID="chkGeneral" Text="General" /></td>
                                    <td><asp:CheckBox runat="server" ID="chkAlcanceGeografico" Text="Alcance Geografico" /></td>
                                </tr>
                                <tr>
                                    <td><asp:CheckBox runat="server" ID="chkObjetivos" Text="Objetivos" /></td>
                                    <td><asp:CheckBox runat="server" ID="chkEvaluacion" Text="Evaluacion" /></td>
                                </tr>
                                <tr>
                                    <td><asp:CheckBox runat="server" ID="chkCronograma"  AutoPostBack="true" OnCheckedChanged="chkCronograma_CheckedChanged" Text="Cronograma" /></td>
                                    <td><asp:CheckBox runat="server" ID="chkProductoIntermedio" AutoPostBack="true" OnCheckedChanged="chkProductoIntermedio_CheckedChanged" Text ="Producto Intermedio" /> </td>
                                </tr>
                                <tr>                                    
                                
                                    <td><asp:Literal ID="liOffset" runat="server" Text="Desplazamiento" ></asp:Literal><br />
                                     <asp:DropDownList runat="server" ID="ddlOffset" ></asp:DropDownList>
                                     <%--<asp:CheckBox runat="server" ID="chkProductosIntermedios" Text="Productos Intermedios" />--%>
                                     </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>                           
                <tr>
                    <td align ="center" >
                        <asp:Button runat="server" ID="btAceptar" Text="Aceptar" CausesValidation ="false"  OnClick="btAceptar_Click" />
                        <asp:Button runat="server" ID="btCancelar" Text="Cancelar" CausesValidation ="false"  OnClick="btCancelar_Click" />
                   </td>
                </tr>
            </table> 
        </ContentTemplate>
    </asp:UpdatePanel>     
    <asp:Button ID="btPopup" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="mpePopupCopy" runat="server" CancelControlID="btPopup" PopupDragHandleControlID ="pnPopupCopyDragHandle"
    PopupControlID="pnPopupCopy" OkControlID="btPopup" TargetControlID="btPopup" BackgroundCssClass="modalBackground" />
</asp:Panel>

