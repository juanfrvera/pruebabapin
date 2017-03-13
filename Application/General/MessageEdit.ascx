<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageEdit.ascx.cs" Inherits="UI.Web.MessageEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register TagPrefix="uc" TagName="AutocompleteDestinatario" Src="~/ControlsPersonal/WebControl_DestinatarioAutocomplete.ascx" %>
<asp:Panel runat="server" GroupingText="Mensaje"  ID="pnlFilter" Width="805px" >
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">                   	
    <tr>           
        <td class="tdLabel"  ><asp:Literal ID="liBAPIN" Text="BAPIN" runat="server" ></asp:Literal></td>
        <td class="filaInput">
            <table>
                <tr>
                    <td ><asp:TextBox ID="txtBapinCode" Width="50px" type="text" min="0" runat="server" CssClass="field_input"   ></asp:TextBox></td>
                    <td width="20px" align="left" ><asp:RegularExpressionValidator ID="revBapinCode" runat="server"   ControlToValidate="txtBapinCode"  ValidationGroup="EditionMessage"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                    <td class="filaInput" style=" width:80px" >
                    <asp:UpdatePanel ID="upBapinBuscar" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btSearchProyecto" runat="server" Text="Buscar" OnClick="btSearchProyecto_Click" /> 
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td class="filaInput" style=" width:520px" >
                    <asp:Label ID="lbDenominacion" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table>            
        </td>
     </tr>   
     <tr>
         <td ><asp:Literal ID="liPrioridad" Text="Prioridad" runat="server" ></asp:Literal>&nbsp;</td>
                   <td> <asp:DropDownList ID="ddlPriority" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
                    <td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvPriority" runat="server" ControlToValidate="ddlPriority"  ValidationGroup="EditionMessage"   Text="*" Width="1px" Height="1px" InitialValue="0"  ></asp:RequiredFieldValidator></td>
      </tr> 
	<tr>	    
	    <td width="20px"  ><asp:Literal ID="liDe" Text="De" runat="server" ></asp:Literal>&nbsp;</td>	    
	    <td class="filaInput" Width="100%" ><asp:Label ID="lbFromUser" runat="server" ></asp:Label><asp:HiddenField ID="hdFromUser" runat="server" /></td>
	    <td class="filaValidator">&nbsp;</td>
	</tr>
	<tr>	    
	    <td width="20px" valign="top" style="padding-top:4px" ><asp:Literal ID="liA" Text="Para" runat="server" ></asp:Literal>&nbsp;</td>	    
	    <td  class="filaInput" style=" width: 400px">	       
	        <table cellpadding="0px" cellspacing="0px">
	        <tr>
	        <td>
             <uc:AutocompleteDestinatario runat="server" ID="autoCmpDestinatario" Width="350px"
                           AutocompleteHandler="../Handlers/DestinatarioAutocompleteSimpleHandler.ashx"
                           RequiredValue="false" ShowOption="ActivesAndActualValue" >
                                    </uc:AutocompleteDestinatario>  		        
	        </td>
	        <td>
	        <asp:Button ID="btAgregar" runat="server" Text="Agregar" OnClick="btAgregarDestinatario_Click" />  
	        </td>
	        </tr>
	        </table>

                                                                  	            
	            <asp:DataList ID="dlUsersTo" OnItemCommand="dlUsersTo_ItemCommand" runat="server" RepeatColumns="4" v  >
                    <ItemTemplate>
                        <asp:Label ID="lblNombreCompleto" Text='<%# Bind("UserTo_NombreCompleto") %>' runat="server" ></asp:Label>                    
                        <asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/icon_delete.gif" ToolTip ="Eliminar"   CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                    </ItemTemplate>
                </asp:DataList>	    
	    </td>
	    <td class="filaValidator">&nbsp;</td>
	</tr>	
	<tr>
		<td width="20px"><asp:Literal ID="liAsunto" Text="Asunto" runat="server" ></asp:Literal>&nbsp;</td>		
		<td class="filaInput"><asp:TextBox ID="txtSubject"  Width="700px" runat="server" CssClass="field_input"  ></asp:TextBox></td>
		<td class="filaValidator" ><asp:RegularExpressionValidator ID="revSubject" runat="server"   ControlToValidate="txtSubject"  ValidationGroup="EditionMessage"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"  ValidationGroup="EditionMessage"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
	</tr>
	</table>
</asp:Panel>  
<table>
<tr>		
	<td class="filaInput">
	    <div style="z-index:-1" >
	       <cc:HtmlEditor ID="txtBody" AutoSave="true" runat="server" Height="400px" Width="800px"/>
	    </div>
	</td>
</tr>
<tr>		
	<td class="filaInput">
	    &nbsp;</td>
</tr>
</table>
