<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoList.ascx.cs" Inherits=" UI.Web.ProyectoList" %>
<asp:GridView ID="Grid" runat="server" Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ID"
    OnRowCommand="Grid_RowCommand"
    AllowSorting="True"
    OnSorting="Grid_Sorting"
    OnRowDataBound="Grid_RowDataBound">
    <Columns>
        <asp:BoundField DataField="Jurisdiccion_Codigo" HeaderText="JU" SortExpression="Jurisdiccion_Codigo" HeaderStyle-Width="2%" />
        <asp:BoundField DataField="Saf_Codigo" HeaderText="SAF" SortExpression="Saf_Codigo" HeaderStyle-Width="2%" />
        <asp:BoundField DataField="Programa_Codigo" HeaderText="PR" SortExpression="Programa_Codigo" HeaderStyle-Width="2%" />
        <asp:BoundField DataField="SubPrograma_Codigo" HeaderText="SP" SortExpression="SubPrograma_Codigo" HeaderStyle-Width="4%" />
        <asp:TemplateField HeaderText="BAPIN" SortExpression="Codigo" HeaderStyle-Width="6%">
            <ItemTemplate>
                <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("CodigoString") %>' ToolTip='<%# Eval("CodigoString") %>' ForeColor='<%# Eval("Color") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Denominaci�n" SortExpression="ProyectoDenominacion" HeaderStyle-Width="30%">
            <ItemTemplate>
                <asp:Label ID="lblProyectoDenominacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("ProyectoDenominacion"),60) %>' ToolTip='<%# Eval("ProyectoDenominacion") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Estado_Nombre" HeaderText="Etapa" SortExpression="Estado_Nombre" HeaderStyle-Width="10%" />
        <asp:BoundField DataField="Plan_Ultimo" HeaderText="Plan" SortExpression="Plan_Ultimo" HeaderStyle-Width="13%" />
        <asp:BoundField DataField="TipoProyecto_Nombre" HeaderText="Imputaci�n Presupuestaria" SortExpression="TipoProyecto_Nombre" HeaderStyle-Width="10%" />
        <asp:BoundField DataField="Apertura" HeaderText="C�digo Presupuestario" SortExpression="Apertura" HeaderStyle-Width="7%" />
        <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="Acciones" HeaderStyle-Width="14%">
            <ItemTemplate>

                <asp:ImageButton ID="btRead" runat="server" src="../Images/read.png" ToolTip='<%# Translate("Consultar") %>' CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanRead(Eval("ID")) %>' CommandName='<%# Command.READ %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />

                <asp:ImageButton ID="btEdit" runat="server" src="../Images/edit.png" ToolTip='<%# Translate("Editar") %>' CssClass='<%# CanEdit(Eval("ID")) & HabilitarOpciones(Eval("ID")) & HabilitarEdicion(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanEdit(Eval("ID")) & HabilitarOpciones(Eval("ID")) & HabilitarEdicion(Eval("ID")) %>' CommandName='<%# Command.EDIT %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />

                <asp:ImageButton ID="btDelete" runat="server" src="../Images/delete.jpg" ToolTip='<%# Translate("Eliminar") %>' CssClass='<%# CanDelete(Eval("ID")) & HabilitarOpciones(Eval("ID")) & HabilitarEdicion(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanDelete(Eval("ID")) & HabilitarOpciones(Eval("ID")) & HabilitarEdicion(Eval("ID"))%>' CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />

                <!--<asp:ImageButton ID="btPrint" runat="server" src="../Images/imprimir.png" ToolTip='<%# Translate("Imprimir") %>' CssClass='<%# CanRead(Eval("ID")) ?"":"ibDisable"  %>' Enabled='<%# CanRead(Eval("ID")) %>' CommandName='<%# Command.SHOW_POPUP_PRINT %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />-->

                <!--<asp:ImageButton ID="btHistoryPrint" runat="server" src="../Images/HistoryPrint.gif" ToolTip='<%# Translate("Hist�ricos") %>' CssClass='<%# CanRead(Eval("ID"))?"":"ibDisable"  %>' Enabled='<%# CanRead(Eval("ID"))%>' CommandName='<%# Command.SHOW_POPUP_HISTORY_PRINT %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />-->

                <!--<asp:ImageButton ID="btCopy" runat="server" src="../Images/copy.png" ToolTip='<%# Translate("Copiar") %>' CssClass='<%# CanById(Eval("ID"),Contract.ActionConfig.COPY) & HabilitarOpciones(Eval("ID")) & HabilitarEdicion(Eval("ID"))?"":"ibDisable" %>' Enabled='<%# CanById(Eval("ID"),Contract.ActionConfig.COPY) & HabilitarOpciones(Eval("ID")) & HabilitarEdicion(Eval("ID"))%>' CommandName='<%# Command.SHOW_POPUP_COPY_AND_SAVE %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />-->
                </br>
				<asp:ImageButton ID="btConformar" runat="server" src="../Images/postular.png" ToolTip='<%# Translate(VerificarEstadoDecision(Eval("ID"), Contract.ActionConfig.CONFORMAR, Contract.ActionConfig.CONFORMADO)) %>' Visible='<%# CanById(Eval("ID"),Contract.ActionConfig.CONFORMAR) %>' CommandName='<%# Command.SHOW_CONFORMAR %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />

                <asp:ImageButton ID="btPostular" runat="server" src="../Images/conformar.png" ToolTip='<%# Translate(VerificarEstadoDecision(Eval("ID"), Contract.ActionConfig.POSTULAR, Contract.ActionConfig.POSTULADO)) %>' Visible='<%# CanById(Eval("ID"),Contract.ActionConfig.POSTULAR) %>' CommandName='<%# Command.SHOW_POSTULAR %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />

                <asp:ImageButton ID="btAceptar" runat="server" src="../Images/aceptar.png" ToolTip='<%# Translate(VerificarEstadoDecision(Eval("ID"), Contract.ActionConfig.ACEPTAR, Contract.ActionConfig.ACEPTADO)) %>' Visible='<%# CanById(Eval("ID"),Contract.ActionConfig.ACEPTAR) %>' CommandName='<%# Command.SHOW_ACEPTAR %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />

                <asp:ImageButton ID="btRechazar" runat="server" src="../Images/rechazar.png" ToolTip='<%# Translate(VerificarEstadoDecision(Eval("ID"), Contract.ActionConfig.OBSERVAR, Contract.ActionConfig.OBSERVADO)) %>' Visible='<%# CanById(Eval("ID"),Contract.ActionConfig.OBSERVAR) %>' CommandName='<%# Command.SHOW_OBSERVAR %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />

                <asp:ImageButton ID="btReiniciar" runat="server" src="../Images/reiniciar.png" ToolTip='<%# Translate(VerificarEstadoDecision(Eval("ID"), Contract.ActionConfig.REINICIAR, Contract.ActionConfig.REINICIADO)) %>' Visible='<%# CanById(Eval("ID"),Contract.ActionConfig.REINICIAR) %>' CommandName='<%# Command.SHOW_REINICIAR %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />

                <%-- <asp:ImageButton ID ="btEstadoDesicionHistory" runat ="server"  src="../Images/history.png" ToolTip ='<%# Translate("Hist�rico de Estado de Decisi�n") %>'  Visible='<%# CanById(Eval("ID"),Contract.ActionConfig.ESTADO_DESICION_HISTORY) %>' CommandName='<%# Command.SHOW_ESTADO_DESICION_HISTORY %>'   CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
                --%>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
