<%@ Page Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="CacheManagerPageEdit.aspx.cs" Inherits="UI.Web.CacheManagerPageEdit" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
<asp:UpdatePanel ID ="upManagers" runat = "server" UpdateMode = "Conditional" >
    <ContentTemplate >
        <table width ="100%" >
            <tr>
                <td align ="right" >
                    <asp:Button ID="btLimpiar" runat = "server" Text ="Limpiar" 
                        onclick="btLimpiar_Click"  />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="Grid" runat="server"  Width="100%"
                        AutoGenerateColumns="False" DataKeyNames="ID"     
                        OnRowCommand="Grid_RowCommand"    
                        AllowSorting="False"
                        AllowPaging ="false" 
                        >
                        <Columns> 
                                <asp:BoundField HeaderText ="Caché" DataField ="Nombre"  />
			                    <asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="9%">           
                                <ItemTemplate>                
			                        <asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'   CommandName='<%# Command.DELETE %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
       	                         </ItemTemplate>            
                                <ItemStyle />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>    
                </td>
            </tr>

        </table>
    </ContentTemplate>
</asp:UpdatePanel>    
</asp:Content>