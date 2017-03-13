<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControlPaggingListButtons.ascx.cs" Inherits=" UI.Web.WebControlPaggingListButtons" %>

<asp:ImageButton ID="btFirst" OnClick="btPrevious_Click"  runat ="server" ToolTip="Pagina Anterior" ImageUrl ="~/Images/first.png" CausesValidation="False"  />  
<asp:ImageButton ID="btPrevious" OnClick="btPrevious_Click" runat ="server"  ToolTip="Pagina Anterior" ImageUrl ="~/Images/previous.png" CausesValidation="False" />  
<asp:TextBox ID="tbPage" runat ="server" Width="60px" ></asp:TextBox>
    <asp:RegularExpressionValidator 
        ID="revPage" 
        runat = "server" 
        ValidationExpression = "[0-9]*" 
        ControlToValidate ="tbPage" 
        ErrorMessage ="*"
        ValidationGroup ="vbPaggingListButtons" 
    ></asp:RegularExpressionValidator>
<asp:TextBox ID="tbRows" runat = "server" Width="60px" ></asp:TextBox>
<asp:RegularExpressionValidator 
    ID="revRows" 
    runat = "server" 
    ValidationExpression = "[0-9]*" 
    ControlToValidate ="tbRows" 
    ErrorMessage ="*"
    ValidationGroup ="vbPaggingListButtons" 
></asp:RegularExpressionValidator>
<asp:ImageButton ID="btNext" OnClick="btPrevious_Click"  runat ="server" ToolTip="Pagina Anterior" CausesValidation="False"  ImageUrl ="~/Images/next.png"/>  
<asp:ImageButton ID="btLast" OnClick="btPrevious_Click"  runat ="server" ToolTip="Pagina Anterior" CausesValidation="False" ImageUrl ="~/Images/last.png"/>  

 

<asp:Button ID="btSearch" runat="server" Text="Buscar" OnClick="btSearch_Click" SkinID="LightButton" CausesValidation="False" />
 