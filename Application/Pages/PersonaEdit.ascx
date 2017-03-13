<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonaEdit.ascx.cs" Inherits="UI.Web.PersonaEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeSelect" Src="~/Controls/WebControl_TreeSelect.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_Oficinas.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeOficinasSinJurisdiccion" Src="~/ControlsPersonal/WebControl_OficinasSinJudisdiccion.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeLocalizacion" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<style>
    .tdLabel {
        width: 140px;
    }

    .filaInput {
        width: 350px;
    }

    .field_input {
        width: 300px;
    }

    .field_inputDropDown {
        width: 305px;
    }

    .filaValidator {
        width: 1px;
    }
</style>
<asp:UpdatePanel ID="upEdit" runat="server">
    <ContentTemplate>
        <ajaxToolkit:TabContainer ID="tcContainer" runat="server" Width="100%">
            <ajaxToolkit:TabPanel ID="tpDatosGenerales" runat="server" HeaderText="Datos Generales">
                <ContentTemplate>
                    <asp:Panel ID="pnlDatosGenerales" runat="server" GroupingText="Datos Personales">
                        <asp:UpdatePanel ID="upDatosGenerales" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liNombre" Text="Nombre" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtNombre" MaxLength="70" runat="server" CssClass="field_input" TabIndex="1"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liApellido" Text="Apellido" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtApellido" MaxLength="70" runat="server" CssClass="field_input" TabIndex="2"></asp:TextBox></td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liTelefono" Text="Teléfono" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtTelefono" MaxLength="100" runat="server" CssClass="field_input" TabIndex="3"></asp:TextBox></td>
                                                </tr>

                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liEmailPersonal" Text="e-mail Personal" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revEMailPersonal" runat="server" ControlToValidate="txtEMailPersonal" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtEMailPersonal" MaxLength="100" runat="server" CssClass="field_input" TabIndex="4"></asp:TextBox></td>
                                                </tr>

                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liSexo" Text="Sexo" runat="server"></asp:Literal></td>
                                                    <%--<td class="filaValidator"><asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" InitialValue ="0"  ValidationGroup="EditionPersona"   Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator> </td>--%>
                                                    <td class="filaValidator"></td>
                                                    <td class="filaInput">
                                                        <%--<asp:DropDownList id="ddlSexo" runat = "server" CssClass ="field_inputDropDown"  SkinID ="AnchoLibre"  TabIndex ="16">
		                                <asp:ListItem Selected="true" Value="0" Text ="Seleccione Sexo" ></asp:ListItem>
		                                <asp:ListItem Value="M" Text ="M" ></asp:ListItem>
		                                <asp:ListItem Value="F" Text ="F" ></asp:ListItem>
		                            </asp:DropDownList>--%>
                                                        <asp:RadioButton ID="rbMasculino" runat="server" GroupName="groupSexo" Text="Masculino" TabIndex="5" />
                                                        <asp:RadioButton ID="rbFemenino" runat="server" GroupName="groupSexo" Text="Femenino" TabIndex="6" />
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel"></td>
                                                    <td class="filaValidator"></td>
                                                    <td class="filaInput"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                    <asp:Panel ID="pnlDomicilio" runat="server" GroupingText="Datos Domicilio">
                        <asp:UpdatePanel ID="upDomicilio" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liDomicilio" Text="Domicilio" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revDomicilio" runat="server" ControlToValidate="txtDomicilio" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtDomicilio" MaxLength="150" runat="server" CssClass="field_input" TabIndex="7"></asp:TextBox></td>
                                                </tr>

                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liCodigoPostal" Text="Código Postal" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revCodPostal" runat="server" ControlToValidate="txtCodPostal" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtCodPostal" MaxLength="10" runat="server" CssClass="field_input" TabIndex="8"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liLocalidad" Text="Alcance Geográfico" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator"></td>
                                                    <td class="filaInput">
                                                        <uc:TreeLocalizacion runat="server" ID="tsAlcanceGeografico" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue"></uc:TreeLocalizacion>
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                        <%-- <td>
	                        <table>
	                             <tr>
	                               <td class="tdLabel"  ><asp:Literal ID="liProvincia" Text="Provincia" runat="server" ></asp:Literal></td>
	                                <td class="filaValidator"></td>
	                                <td  class="filaInput"><asp:DropDownList ID="ddlProvincia" runat="server" CssClass="field_inputDropDown" SkinID ="AnchoLibre" TabIndex ="10" ></asp:DropDownList></td>
            	                  
	                            </tr>
    	                       
	                        </table>
	                    </td>--%>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                    <asp:Panel ID="pnlDatosLaborales" runat="server" GroupingText="Datos Laborales">
                        <asp:UpdatePanel ID="upDatosLaborales" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                                    <tr>
                                        <td colspan="2">
                                            <table>
                                                <tr>
                                                    <%-- <td class="tdLabel"  ><asp:Literal ID="liOficina" Text="Oficina" runat="server" ></asp:Literal></td>	
		                        <td class="filaValidator">
		                           <asp:RequiredFieldValidator  ID="rfvOficina" runat="server"   ControlToValidate="ddlOficina"  ValidationGroup="EditionPersona"  InitialValue ="0" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
		                        </td>
		                        <td class="filaInput"> <asp:DropDownList ID="ddlOficina" runat ="server" CssClass ="field_inputDropDown" SkinID ="AnchoLibre" TabIndex ="11"></asp:DropDownList> </td> 
                                                    --%>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liOficina" Text="Oficina" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <%--<asp:RequiredFieldValidator  ID="rfvOficina" runat="server"   ControlToValidate="ddlOficina"  ValidationGroup="EditionPersona"  InitialValue ="0" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>--%>
                                                    </td>
                                                    <td class="filaInput">
                                                        <uc:TreeOficinas runat="server" ID="toOficina" RequiredValue="true" ValidationGroup="EditionPersona" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue" Autopostback="true" OnValueChanged="toOficina_OnChanged"></uc:TreeOficinas>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liCargo" Text="Cargo" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RequiredFieldValidator ID="rfvCargo" runat="server" ControlToValidate="ddlCargo" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></td>
                                                    <td class="filaInput">
                                                        <cc:ExtendedDropDownList ID="ddlCargo" runat="server" CssClass="field_input"></cc:ExtendedDropDownList></td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liCargoEspecifico" Text="Cargo Específico" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revCargoEspecifico" runat="server" ControlToValidate="txtCargoEspecifico" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtCargoEspecifico" MaxLength="150" runat="server" CssClass="field_input" TabIndex="13"></asp:TextBox></td>
                                                </tr>

                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liNivelJerarquico" Text="Nivel Jerárquico" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revNivelJerarquico" runat="server" ControlToValidate="txtNivelJerarquico" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtNivelJerarquico" MaxLength="50" runat="server" CssClass="field_input" TabIndex="14"></asp:TextBox></td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liTelefonoLaboral" Text="Teléfono Laboral" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revTelefonoLaboral" runat="server" ControlToValidate="txtTelefonoLaboral" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="rfvTelefonoLaboral" runat="server" ControlToValidate="txtTelefonoLaboral" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtTelefonoLaboral" MaxLength="100" runat="server" CssClass="field_input" TabIndex="15"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="lifax" Text="Fax" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revFax" runat="server" ControlToValidate="txtFax" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtFax" MaxLength="50" runat="server" CssClass="field_input" TabIndex="16"></asp:TextBox></td>
                                                </tr>

                                            </table>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liEmailLaboral" Text="e-mail Laboral" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator">
                                                        <asp:RegularExpressionValidator ID="revEMailLaboral" runat="server" ControlToValidate="txtEMailLaboral" ValidationGroup="EditionPersona" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                                                    <td class="filaInput">
                                                        <asp:TextBox ID="txtEMailLaboral" runat="server" CssClass="field_input" TabIndex="17" MaxLength="100"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel"></td>
                                                    <td class="filaValidator"></td>
                                                    <td class="filaInput"></td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                    <asp:Panel ID="pnlChecks" runat="server" GroupingText="Configuración">
                        <asp:UpdatePanel ID="upPnlChecks" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liContacto" Text="Es Contacto" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator"></td>
                                                    <td class="filaInput">
                                                        <asp:CheckBox ID="chkContacto" runat="server" CssClass="field_input" TabIndex="20" AutoPostBack="true" OnCheckedChanged="chkContacto_CheckedChanged"></asp:CheckBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liEnviarNota" Text="Enviar Nota" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator"></td>
                                                    <td class="filaInput">
                                                        <asp:CheckBox ID="chkEnviarNota" runat="server" CssClass="field_input" TabIndex="18"></asp:CheckBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liActivo" Text="Activo" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator"></td>
                                                    <td class="filaInput">
                                                        <asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" TabIndex="19"></asp:CheckBox></td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liEsUsuario" Text="Es Usuario" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator"></td>
                                                    <td class="filaInput">
                                                        <asp:CheckBox ID="chkEsUsuario" runat="server" CssClass="field_input" TabIndex="22" AutoPostBack="true" OnCheckedChanged="chkEsUsuario_CheckedChanged"></asp:CheckBox></td>

                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel">
                                                        <asp:Literal ID="liEnviarMail" Text="Enviar Mail" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator"></td>
                                                    <td class="filaInput">
                                                        <asp:CheckBox ID="chkEnviarMail" runat="server" TabIndex="21" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>


                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="tpDatosUsuario" runat="server" HeaderText="Datos Usuario" Enabled="false">
                <ContentTemplate>
                    <asp:Panel ID="pnlDatosUsuario" runat="server" GroupingText="Datos del Usuario">
                        <asp:UpdatePanel ID="upDatosUsuario" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td class="tdLabel" style="width: 300px">
                                            <table>
                                                <tr>
                                                    <td class="tdLabel" style="width: 100px">
                                                        <asp:Literal ID="liNombreUsuario" Text="Nombre" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator" style="width: 10px">
                                                        <asp:RegularExpressionValidator ID="revNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" ValidationGroup="EditionUsuario" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td class="filaInput" style="width: 150px">
                                                        <asp:TextBox ID="txtNombreUsuario" MaxLength="50" runat="server" Width="150" TabIndex="22"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="tdLabel" style="width: 300px">
                                            <table>
                                                <tr>
                                                    <td class="tdLabel" style="width: 100px">
                                                        <asp:Literal ID="liClave" Text="Clave" runat="server"></asp:Literal></td>
                                                    <td class="filaInput" style="width: 150px">
                                                        <asp:TextBox ID="txtClave" MaxLength="50" runat="server" Width="150" TabIndex="23"></asp:TextBox></td>
                                                   
                                                </tr>

                                            </table>
                                        </td>
                                        <td class="tdLabel" style="width: 300px">
                                            <table>
                                                <tr>
                                                    <td class="tdLabel" style="width: 100px">
                                                        <asp:Literal ID="liLanguage" Text="Lenguaje" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator" style="width: 10px">
                                                        <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="ddlLanguage" ValidationGroup="EditionUsuario" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></td>
                                                    <td class="filaInput" style="width: 150px">
                                                        <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="field_inputDropDown" SkinID="AnchoLibre" Width="150px" TabIndex="24"></asp:DropDownList></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel" style="width: 100px">
                                                        <asp:Literal ID="liUsuarioActivo" Text="Activo" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator" style="width: 10px"></td>
                                                    <td class="filaInput" style="width: 150px">
                                                        <asp:CheckBox ID="chkUsuarioActivo" runat="server" CssClass="field_input" TabIndex="25" AutoPostBack="true"></asp:CheckBox></td>

                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel" style="width: 100px">
                                                        <asp:Literal ID="liUsuarioSectorialista" Text="Es Sectorialista" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator" style="width: 10px"></td>
                                                    <td class="filaInput" style="width: 150px">
                                                        <asp:CheckBox ID="chkUsuarioSectorialista" runat="server" CssClass="field_input" TabIndex="25"></asp:CheckBox></td>

                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="tdLabel" style="width: 100px">
                                                        <asp:Literal ID="liAccesoTotal" Text="Acceso Total" runat="server"></asp:Literal></td>
                                                    <td class="filaValidator" style="width: 10px"></td>
                                                    <td class="filaInput" style="width: 150px">
                                                        <asp:CheckBox ID="chkUsuarioAccesoTotal" runat="server" CssClass="field_input" TabIndex="25"></asp:CheckBox></td>

                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>

                                <asp:Panel runat="server" GroupingText="Perfiles de Sistema" ID="pnlPerfiles">
                                    <div>
                                        <asp:DataList ID="dlPerfiles" runat="server" RepeatColumns="4" RepeatDirection="Vertical" Width="100%" TabIndex="26">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Perfil_Nombre") %>' runat="server" />
                                                <asp:HiddenField ID="hdValue" Value='<%# Bind("IdPerfil") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>


                    <asp:Panel ID="pnlRoles" runat="server" GroupingText="Perfiles de Oficina">
                        <asp:UpdatePanel ID="upRoles" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="right">
                                            <asp:UpdatePanel ID="pnlAgregarRolOficina" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Button ID="btAgregarRolOficina" runat="server" Text="Agregar" OnClick="btAgregarRolOficina_Click" TabIndex="27" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <asp:UpdatePanel ID="upGridRoles" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div style="overflow: auto; width: 978px; height: 250px">
                                            <%-- Matias 20131105 - Tarea  77--%>
                                            <%-- Matias 20131105 - Tarea  77 - asp: AllowPaging="False" y AllowSorting="False"--%>
                                            <asp:GridView ID="gridRoles" runat="server"
                                                AutoGenerateColumns="False" DataKeyNames="ID"
                                                AllowPaging="False"
                                                OnRowCommand="GridRoles_RowCommand"
                                                AllowSorting="False"
                                                OnSorting="Grid_Sorting"
                                                OnPageIndexChanging="Grid_PageIndexChanging"
                                                EmptyDataText="No hay Roles definidos"
                                                Width="100%">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Oficina" DataField="Oficina_Nombre" SortExpression="Oficina_Nombre" />
                                                    <asp:BoundField HeaderText="Perfil" DataField="Perfil_Nombre" SortExpression="PerfilNombre" />
                                                    <asp:CheckBoxField DataField="HeredaConsulta" HeaderText="Hereda Consulta" />
                                                    <asp:CheckBoxField DataField="HeredaEdicion" HeaderText="Hereda Edición" />
                                                    <asp:CheckBoxField DataField="AccesoTotal" HeaderText="Acceso Total" />

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            &nbsp;
                                    <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                                            &nbsp;
                                    <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar" CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <%-- FinMatias 20131105 - Tarea  77 --%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </ContentTemplate>
</asp:UpdatePanel>



<asp:Panel ID="PopUpRolesOficina" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="RolesOficinaPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpRolesOficina" runat="server" Text="Roles Oficina" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnRolesOficina" runat="server">
        <asp:UpdatePanel ID="upRolesOficinaPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Literal ID="liOficinaRoles" Text="Oficina:" runat="server"></asp:Literal></td>
                        <td>
                            <uc:TreeOficinasSinJurisdiccion runat="server" ID="toOficinaPopUp" Width="700px" Handler="../Handlers/OficinaHandler.ashx" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue" Autopostback="true"></uc:TreeOficinasSinJurisdiccion>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="liRol" Text="Perfil:" runat="server"></asp:Literal></td>
                        <td>
                            <asp:DropDownList ID="ddlRol" runat="server" Width="700px" SkinID="AnchoLibre"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvRol" runat="server" ValidationGroup="vgRolesOficina" ControlToValidate="ddlRol" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr align="center">
                                    <td class="filaInput">
                                        <asp:CheckBox ID="chkHeredaConsulta" Text="Hereda Consulta" runat="server" CssClass="field_input"></asp:CheckBox></td>
                                    <td class="filaInput">
                                        <asp:CheckBox ID="chkHeredaEdicion" Text="Hereda Edición" runat="server" CssClass="field_inpu123t"></asp:CheckBox></td>
                                    <td class="filaInput">
                                        <asp:CheckBox ID="chkAccesoTotal" Text="Acceso Total" runat="server" CssClass="field_inpu123t"></asp:CheckBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveRolesOficina" Text="Aceptar" OnClick="btSaveRolesOficina_Click" runat="server" ValidationGroup="vgRolesOficina" />
                            <asp:Button ID="btNewRolesOficina" Text="Aceptar y Crear Nuevo" OnClick="btNewRolesOficina_Click" runat="server"
                                ValidationGroup="vgRolesOficina" />
                            <asp:Button ID="btCancelRolesOficina" Text="Cerrar" OnClick="btCancelRolesOficina_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderRolesOficina" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="RolesOficinaPopUpDragHandle" PopupControlID="PopUpRolesOficina"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>


