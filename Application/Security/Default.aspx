<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Security.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BAPIN</title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script>

        w = 800
        h = 600
        if (window.screen) {
            w = window.screen.availWidth;
            h = window.screen.availHeight;
        }
        var oDate = new Date();
        //../General/MessageSendPageList.aspx
        var wOpen = window.open("<%=RedirectPageInitial%>?qt=" + oDate.getTime(), "BAPIN", "width=" + (w - 10) + ",height=" + (h - 122) + ",top=0,left=0,scrollbars=yes,location=0");
        wOpen.resizeTo(w, h);

        if(window.opener == null)
        {
            window.open('', '_self', '');
            window.close();
        }



    </script>    
    </div>
    </form>
</body>
</html>
