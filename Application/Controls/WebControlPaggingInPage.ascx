<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControlPaggingInPage.ascx.cs" Inherits=" UI.Web.WebControlPaggingInPage" %>
<Table> 
    <tr>  
        <td>
            <asp:Button ID="btFirst" OnClick="btFirst_Click" ToolTip="Primer"  runat="server" Text="<<" CausesValidation ="false"  style="padding:0px;"  />
            <asp:Button ID="btPrevious" OnClick="btPrevious_Click" ToolTip="Anterior" runat="server" Text="<" CausesValidation ="false" style="padding:0px;"  />        
        </td>
        <td><div >&nbsp;<asp:Literal ID="liPagina" Text="Reg." runat="server" ></asp:Literal>&nbsp;<asp:TextBox ID= "tbPageNumber" ToolTip="Número de registro"  runat = "server" Width="20px"></asp:TextBox></div></td>
        <td><div >&nbsp;<asp:Literal ID="liDe" Text="de" runat="server" ></asp:Literal>&nbsp;<asp:Label ID= "lblTotalPages" ToolTip="Total de registros" runat = "server" ></asp:Label></div></td>
        <td>
            <asp:Button ID="btNext" OnClick="btNext_Click" ToolTip="Próxima"  runat="server" Text=">" CausesValidation ="false"  style="padding:0px;"   />
            <asp:Button ID="btLast" OnClick="btLast_Click" ToolTip="Ultima"  runat="server" Text=">>" CausesValidation ="false" style="padding:0px;"  />       
        </td>
        <td>&nbsp;<asp:Button  ID ="btPageGo"  runat = "server" Text="Ir" OnClick ="btPageGo_Click" style="padding:0px;" /></td>
    </tr>
</Table>