<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoDictamenFilter.ascx.cs"
    Inherits="UI.Web.ProyectoDictamenFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<table width="100%" cellpadding="0" cellspacing="5px" border="0">
  
    <tr>
        <td class="tdFilter">
            <asp:Literal ID="liSaf" runat = "server" Text ="Saf" ></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlSaf"  runat = "server" SkinID="AnchoLibre" Width= "450px"></asp:DropDownList>
        </td>
        <td class="tdFilter">
            <asp:Literal ID="liDenominacion" runat = "server" Text ="Denominación" ></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtDenominacion" runat = "server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="tdFilter">
            <asp:Literal ID="liAnalista" Text="Analista" runat="server" ></asp:Literal>
            &nbsp;
        </td>
        <td>
            <asp:DropDownList ID="ddlAnalista" runat ="server" SkinID="AnchoLibre" Width= "450px"></asp:DropDownList>
        </td> 
         <td class="tdFilter">
            <asp:Literal ID="liRuta" runat = "server" Text ="Ruta" ></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtRuta" runat = "server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
       
        <td class="tdFilter">
            <asp:Literal ID="liMalla" Text="Malla" runat="server"></asp:Literal>
            &nbsp;
        </td>
        <td>
            <asp:TextBox ID="txtMalla" runat ="server" ></asp:TextBox>
        </td> 
         <td class="tdFilter">
            <asp:Literal ID="liCalificacion" runat = "server" Text ="Calificación"></asp:Literal>
        </td>
        <td class="tdFilter">
            <asp:DropDownList ID="ddlCalificacion" runat = "server" ></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="tdFilter">
            <asp:Literal ID="liNumero" Text="Número" runat="server"></asp:Literal>
            &nbsp;<asp:RegularExpressionValidator
                    ID="revNumero" runat="server" ControlToValidate="txtNumero" ValidationGroup="FilterProyectoDictamen"
                    Text="*" Width="1px" Height="1px" ErrorMessage="El Numero no es valido"></asp:RegularExpressionValidator>
        </td>
        <td>
            <asp:TextBox ID="txtNumero" type="text" min="0" runat="server" CssClass="field_input"></asp:TextBox></div>
        </td> 
         <td class="tdFilter">
            <asp:Literal ID="liFecha" runat = "server" Text ="Fecha" ></asp:Literal>
        </td>
        <td>
            <uc:DateInput ID="diFecha" runat ="server" />
        </td>
    </tr>
    
    <tr>
        <td class="tdFilter">
            <asp:Literal ID="liFechaVto" Text="Fecha Vto" runat="server"></asp:Literal>
            &nbsp;
        </td>
        <td>
            <uc:DateInput ID="diFechaVto" runat = "server" />
        </td>
        
       
        <td class="tdFilter" style=" width:230px" >
	       <asp:Literal ID="liEstado" Text="Estado" runat="server" ></asp:Literal>
	    </td>
	    <td rowspan ="2"> 
		   <asp:ListBox ID="lbxEstado" runat="server" CssClass="field_input" SelectionMode="Multiple" Rows="3"  Height="45px" ></asp:ListBox></div>
	    </td>  
    </tr>
    </tr>
    <tr>
        <td class="tdFilter">
            <asp:Literal ID="liInformeTecnico" runat = "server" Text ="Informe Técnico" ></asp:Literal>
        </td>
        <td class="tdFilter">
            <asp:TextBox ID="txtInformeTecnico" runat = "server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        
        <td class="tdFilter">
            <asp:Literal ID="liBapin" Text="Bapin" runat="server"></asp:Literal>
            &nbsp;
        </td>
        <td>
            <asp:TextBox ID="txtBapin" type="text" min="0" runat="server" CssClass="field_input"></asp:TextBox>
        </td> 
        <td class="tdFilter">
            <asp:Literal ID="liEjercicio" runat = "server" Text ="Ejercicio" ></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlEjercicio"  runat = "server" ></asp:DropDownList>
        </td>
    </tr>
   
    
    

    
    
    
    
    
    
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td align="right" valign="bottom">
            <asp:Button ID="btClear" runat="server" Text="Limpiar" OnClick="btClear_Click" Visible="true" />
            &nbsp;<asp:Button ID="btSearch" runat="server" Text="Buscar" OnClick="btSearch_Click"
                    Visible="true" ValidationGroup="FilterProyectoDictamen" />
        </td>
    </tr>
</table>
