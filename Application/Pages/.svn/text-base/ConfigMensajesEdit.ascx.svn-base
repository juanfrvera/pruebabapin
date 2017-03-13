<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigMensajesEdit.ascx.cs" Inherits="UI.Web.ConfigMensajesEdit" %>

<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register TagPrefix="uc" TagName="AutocompleteDestinatario" Src="~/ControlsPersonal/WebControl_DestinatarioAutocomplete.ascx" %>

<table width="100%" cellpadding="0" cellspacing="5px" border="0">
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liPagina" Text="Pagina" runat="server"></asp:Literal></td>
        <!--Agrego todas las paginas de la aplicacion-->
        <!--Cual el usuario vaya seleccionando estos valores, si seleccionar alta, baja o modificacion, segun ese valor
                    completar el nombre de la pagina con edit o list-->
        <td class="filaInput">
            <asp:DropDownList ID="cboPagina" Width="400px" runat="server" CssClass="field_input">
                <asp:ListItem Value="ProyectoPage" Selected="True">Inversion</asp:ListItem>
                <asp:ListItem Value="PrestamoPage">Préstamo</asp:ListItem>
                <asp:ListItem Value="ProgramaPage">Programa</asp:ListItem>
                <asp:ListItem Value="ProyectoTipoPage">Tipo de proyecto</asp:ListItem>
                <asp:ListItem Value="ModalidadContratacionPage">Modalidad contratación</asp:ListItem>
                <asp:ListItem Value="ProcesoPage">Procesos</asp:ListItem>
                <asp:ListItem Value="PlanTipoPage">Tipo de plan</asp:ListItem>
                <asp:ListItem Value="PlanVersionPage">Versiones de plan</asp:ListItem>
                <asp:ListItem Value="PlanPeriodoPage">Período de plan</asp:ListItem>
                <asp:ListItem Value="PlanPeriodoVersionActivaPage">Plan período versión activa</asp:ListItem>
                <asp:ListItem Value="ProyectoRelacionTipoPage">Tipo de relación</asp:ListItem>
                <asp:ListItem Value="FasePage">Fases</asp:ListItem>
                <asp:ListItem Value="EtapaPage">Etapas</asp:ListItem>
                <asp:ListItem Value="ClasificacionPage">Clasificación</asp:ListItem>
                <asp:ListItem Value="OrganismoPrioridadPage">Prioridad de organismo</asp:ListItem>
                <asp:ListItem Value="ProyectoCalificacionPage">Calificación de proyecto</asp:ListItem>
                <asp:ListItem Value="PrioridadPage">Priorización</asp:ListItem>
                <asp:ListItem Value="OrganismoPage">Organismo</asp:ListItem>
                <asp:ListItem Value="PrestamoCalificacionPage">Calificación de préstamos</asp:ListItem>
                <asp:ListItem Value="GestionTipoPage">Tipo de gestión</asp:ListItem>
                <asp:ListItem Value="OrganismoFinancieroPage">Organismo financiero</asp:ListItem>
                <asp:ListItem Value="ModalidadFinancieraPage">Modalidad</asp:ListItem>
                <asp:ListItem Value="SectorPage">Sector</asp:ListItem>
                <asp:ListItem Value="AdministracionTipoPage">Tipo de administración</asp:ListItem>
                <asp:ListItem Value="EntidadTipoPage">Tipo de entidad</asp:ListItem>
                <asp:ListItem Value="OrganismoTipoPage">Tipo de organismo</asp:ListItem>
                <asp:ListItem Value="JurisdiccionPage">Jurisdicción</asp:ListItem>
                <asp:ListItem Value="SubJurisdiccionPage">Sub jurisdicción</asp:ListItem>
                <asp:ListItem Value="SAFPage">Saf</asp:ListItem>
                <asp:ListItem Value="MonedaPage">Moneda</asp:ListItem>
                <asp:ListItem Value="ClasificacionGastoPage">Objeto del gasto</asp:ListItem>
                <asp:ListItem Value="FinalidadFuncionPage">Finalidad-función</asp:ListItem>
                <asp:ListItem Value="ClasificacionGeograficaPage">Clasificación geográfica</asp:ListItem>
                <asp:ListItem Value="FuenteFinanciamientoPage">Fuente de financiamiento</asp:ListItem>
                <asp:ListItem Value="CaracterEconomicoPage">Carácter económico</asp:ListItem>
                <asp:ListItem Value="MedioVerificacionPage">Medios de verificación</asp:ListItem>
                <asp:ListItem Value="IndicadorClasePage">Indicadores</asp:ListItem>
                <asp:ListItem Value="IndicadorRubroPage">Sector de indicador</asp:ListItem>
                <asp:ListItem Value="UnidadMedidaPage">Unidad de medida</asp:ListItem>
                <asp:ListItem Value="CargoPage">Cargos</asp:ListItem>
                <asp:ListItem Value="ProyectoComentarioTecnicoPage">Comentarios técnicos</asp:ListItem>
                <asp:ListItem Value="AdministracionCalidadPage">Calidad</asp:ListItem>
                <asp:ListItem Value="ProyectoSeguimientoPage">Evaluación de factibilidad</asp:ListItem>
                <asp:ListItem Value="PrestamoDictamenPage">Dictamen de inversión</asp:ListItem>
                <asp:ListItem Value="ProyectoDictamenPage">Dictamen de préstamo</asp:ListItem>
                <asp:ListItem Value="OficinaPage">Oficina</asp:ListItem>
                <asp:ListItem Value="PersonaPage">Personas</asp:ListItem>
                <asp:ListItem Value="PerfilPage">Perfil</asp:ListItem>
                <asp:ListItem Value="ActividadPage">Actividad</asp:ListItem>
                <asp:ListItem Value="CaracterEconomicoTipoPage">Tipo de carácter económico</asp:ListItem>
                <asp:ListItem Value="ClasificacionGeograficaTipoPage">Tipo de clasificación geográfica</asp:ListItem>
                <asp:ListItem Value="FinalidadFuncionTipoPage">Tipo de finalidad-función</asp:ListItem>
                <asp:ListItem Value="ClasificacionGastoTipoPage">Tipos de clasificación del gasto</asp:ListItem>
                <asp:ListItem Value="FuenteFinanciamientoTipoPage">Tipos de fuente de financiamiento</asp:ListItem>
                <asp:ListItem Value="MonedaCotizacionPage">Cotizaciones</asp:ListItem>
                <asp:ListItem Value="LanguagePage">Lenguajes</asp:ListItem>
                <asp:ListItem Value="TextCategoryPage">Categoría de textos</asp:ListItem>
                <asp:ListItem Value="TextPage">Textos</asp:ListItem>
                <asp:ListItem Value="TextLanguagePage">Traducciones</asp:ListItem>
                <asp:ListItem Value="NumerationPage">Numeraciones</asp:ListItem>
                <asp:ListItem Value="ParameterCategoryPage">Categoría de parámetros</asp:ListItem>
                <asp:ListItem Value="ParameterPage">Parámetros</asp:ListItem>
                <asp:ListItem Value="SistemaEntidadPage">Entidades</asp:ListItem>
                <asp:ListItem Value="SistemaAccionPage">Acciones</asp:ListItem>
                <asp:ListItem Value="EstadoPage">Estados</asp:ListItem>
                <asp:ListItem Value="SistemaCommandPage">Excels desde base de datos</asp:ListItem>
                <asp:ListItem Value="PermisoPage">Permisos</asp:ListItem>
            </asp:DropDownList>

        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liPrioridad" Text="Prioridad" runat="server"></asp:Literal></td>

        <td class="filaInput">
            <asp:DropDownList ID="cboPrioridad" Width="400px" runat="server" CssClass="field_input">
                <asp:ListItem Value="1" Selected="True">Baja</asp:ListItem>
                <asp:ListItem Value="2">Media</asp:ListItem>
                <asp:ListItem Value="3">Alta</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liAsunto" Text="Asunto" runat="server"></asp:Literal></td>

        <td class="filaInput">
            <asp:TextBox ID="txtAsunto" type="text" Width="400" runat="server" CssClass="field_input"></asp:TextBox>

        </td>

    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liTipoOperacion" Text="Tipo de operación" runat="server"></asp:Literal></td>
        <td class="filaInput">
            <asp:DropDownList ID="cboTipoOperacion" Width="60px" runat="server">
                <asp:ListItem Value="1" Selected="True">Nuevo</asp:ListItem>
                <asp:ListItem Value="2">Eliminación</asp:ListItem>
                <asp:ListItem Value="3">Modificación</asp:ListItem>
            </asp:DropDownList></td>
    </tr>	
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liMensaje" Text="Mensaje" runat="server"></asp:Literal></td>
        <td class="filaInput">
            <asp:TextBox ID="txtMensaje" type="text" TextMode="MultiLine" Width="400" Height="100" runat="server" CssClass="field_input"></asp:TextBox></td>
    </tr>

</table>
