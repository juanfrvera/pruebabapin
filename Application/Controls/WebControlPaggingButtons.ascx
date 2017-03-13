<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControlPaggingButtons.ascx.cs" Inherits=" UI.Web.WebControlPaggingButtons" %>

<Table> 
    <tr>  
        <td>
            <asp:Button ID="btFirst" OnClick="btFirst_Click" ToolTip="Primer Página"  runat="server" Text="<<" style="padding:0px;"   />
            <asp:Button ID="btPrevious" OnClick="btPrevious_Click" ToolTip="Anterior Página" runat="server" Text="<" style="padding:0px;"   />        
        </td>
        <td><div >&nbsp;<asp:Literal ID="liRegistros" Text="Reg." runat="server" ></asp:Literal>&nbsp;<asp:TextBox ID= "tbPageSize" ToolTip="Registros por página" runat = "server" Width="20px" ></asp:TextBox></div></td>        
        <td><div >&nbsp;<asp:Literal ID="liPagina" Text="Pág" runat="server" ></asp:Literal>&nbsp;<asp:TextBox ID= "tbPageNumber" ToolTip="Número de página" runat = "server" Width="20px"></asp:TextBox></div></td>
        <td><div >&nbsp;<asp:Literal ID="liDe" Text="de" runat="server" ></asp:Literal>&nbsp;<asp:Label ID= "lblTotalPages" ToolTip="Total de páginas" runat = "server" ></asp:Label></div></td>
        <td>
            <asp:Button ID="btNext" OnClick="btNext_Click" ToolTip="Próxima Página"  runat="server" Text=">" style="padding:0px;"  />
            <asp:Button ID="btLast" OnClick="btLast_Click" ToolTip="Ultima Página"  runat="server" Text=">>"  style="padding:0px;"   />       
        </td>
        <td>&nbsp;<asp:Button  ID ="btPageGo"  runat = "server" Text="Ir" OnClick ="btPageGo_Click"  Visible="false" style="padding:0px;"  /></td>
    </tr>
</Table>