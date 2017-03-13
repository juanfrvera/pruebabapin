<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoCambioEstructuraDestino.ascx.cs" Inherits="UI.Web.ProyectoCambioEstructuraDestino"  %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_Oficinas.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeSelect" Src="~/Controls/WebControl_TreeSelect.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<style type ="text/css">
    .tdLabel
    {
        width :140px;   
    }
    .tdLabel2
    {
        width :160px;   
    }
    .filaInput
    {
        width:350px;    
    }
    .field_input
    {
        width:350px ;
    }
    .field_inputDropDown
    {
        width:305px ;
    }
    .filaValidator
    {
        width:1px ;
    }

    .style1
    {
        width: 120px;
    }

</style>
<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
    <tr>
        <td >
            <table width="100%" cellpadding="0" cellspacing="5px" border="0" style ="height:160px"> 
                <tr>
                    <td  ><asp:Literal ID="liSAF" Text="SAF" runat="server" ></asp:Literal></td>
                    <td >&nbsp;</td>
                    <td  style ="width:300px">
                        <cc:ExtendedDropDownList ID="ddlSAF" runat="server" CssClass="field_input" OnSelectedIndexChanged="ddlSaf_IndexChanged" AutoPostBack ="true" SkinID ="AnchoLibre" Width ="250px" ></cc:ExtendedDropDownList>
                    </td>
                    <td class="filaValidator">&nbsp;
                    <asp:RequiredFieldValidator ID="rfvSAF" runat="server" ControlToValidate="ddlSAF"  ValidationGroup="EditionProyecto" Text="*" Width="1px" Height="1px" InitialValue ="0" ></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td  ><asp:Literal ID="liPrograma" Text="Programa" runat="server" ></asp:Literal></td>
                    <td >&nbsp;</td>
                    <td >
                        <cc:ExtendedDropDownList ID="ddlPrograma" runat="server" CssClass="field_input" OnSelectedIndexChanged="ddlPrograma_IndexChanged" AutoPostBack ="true" Enabled="false" SkinID ="AnchoLibre" Width ="250px" ></cc:ExtendedDropDownList>
                    </td>
                    <td class="filaValidator">&nbsp;
                        <asp:RequiredFieldValidator ID="rfvPrograma2" runat="server" ControlToValidate="ddlPrograma"  ValidationGroup="EditionProyecto"   Text="*" Width="1px" Height="1px" InitialValue ="" ></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvPrograma" runat="server" ControlToValidate="ddlPrograma"  ValidationGroup="EditionProyecto"  InitialValue="0" Text="*" Width="1px" Height="1px" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Literal ID="liSubPrograma" Text="Subprograma" runat="server" ></asp:Literal></td>
                        <td >&nbsp;</td>
                    <td >
                        <cc:ExtendedDropDownList ID="ddlSubPrograma" runat="server" CssClass="field_input" Enabled="false" SkinID ="AnchoLibre" Width ="250px" ></cc:ExtendedDropDownList>
                    </td>
                    <td class="filaValidator">&nbsp;
                        <asp:RequiredFieldValidator ID="rfvSubPrograma" runat="server" ControlToValidate="ddlSubPrograma"  ValidationGroup="EditionProyecto"   Text="*" Width="1px" Height="1px" InitialValue ="0" ></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvSubPrograma2" runat="server" ControlToValidate="ddlSubPrograma"  ValidationGroup="EditionProyecto"   Text="*" Width="1px" Height="1px" InitialValue ="" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>        
        </td>
        <td style=" width:550px">
            <asp:Panel ID="pnlOficinasYFuncionarios" runat = "server" GroupingText ="Oficinas y Funcionarios" Width="550px">
                <table  cellpadding="0" cellspacing="0px" border="0" style ="height:120px">	  	
                    <tr>
                        <td class="tdLabel"  ><asp:Literal ID="liIniciador" Text="Iniciador" runat="server" ></asp:Literal></td>
                        <td >&nbsp;</td>
                        <td  class="filaInput">
                           <uc:TreeOficinas runat="server" ID="toIniciador" Width ="250px" ></uc:TreeOficinas>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel"  ><asp:Literal ID="liEjecutor" Text="Ejecutor" runat="server" ></asp:Literal></td>
                        <td >&nbsp;</td>
                        <td  class="filaInput">
                            <uc:TreeOficinas runat="server" ID="toEjecutor" Width ="250px" ></uc:TreeOficinas>    
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel"  ><asp:Literal ID="liResponsable" Text="Responsable" runat="server" ></asp:Literal></td>
                        <td >&nbsp;</td>
                        <td  class="filaInput">
                            <uc:TreeOficinas runat="server" ID="toResponsable" Width ="250px" ></uc:TreeOficinas>    
                        </td>
                    </tr>
                </table>   
            </asp:Panel>
        </td>
    </tr>                
</table>


