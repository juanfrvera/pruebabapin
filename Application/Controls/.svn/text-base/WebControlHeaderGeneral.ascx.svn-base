<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControlHeaderGeneral.ascx.cs" Inherits="UI.Web.WebControlHeaderGeneral" %>

<link  rel="stylesheet" type="text/css" href ="../App_Themes/Sky/Header.css"/>

<script  src="../App_Scripts/SpyTabbedPanels.js" type="text/javascript"></script>

<link  href ="../App_Themes/Sky/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />

<div style="width:994px;margin:auto;">
  <div id="header">
	<table>
		<tr>
			<td>
   		<div style="float:left;">
   		    <img src="../Images/logo.jpg" title="Logo"/> <img src="../Images/divider.jpg" style="margin-right:150px;"/>
   		</div> 
			</td>
			<td>

			      	<div >
			                Reports
			      	</div>

            	</td>
	<td>
        </div>
	    <div style="float:left;margin-top:7px">
	        <img src="../Images/divider.jpg" style="margin-left:150px; margin-right:43px"/>
	    </div>
        <div class="user">
            User Name: 
            <span class="greyFont"> 
                <asp:Literal ID="liUser" runat ="server" ></asp:Literal> 
            </span>
            <br/>
            Full Name: 
            <span class="greyFont"> 
                <asp:Literal ID="liUserName" runat ="server" ></asp:Literal> 
            </span>
            <br/>
            <asp:LinkButton ID="lbLogout" runat="server" OnClick="Logout_Click">
                Cerrar Sesión
            </asp:LinkButton>
            <br /> 
            <span > 
                <a href="../frmChangePassword.aspx">Cambiar Contrase&ntilde;a</a> 
            </span>
            <br/>
            <br/>
            
        </div> 
	</td>
	</tr>
</table>

        <div class="sucursales" style ="vertical-align:middle ">
           <%--<div style ="height:5px"></div>--%>
          
                <table width = "100%">
                    <tr>
                       <td class="user" style ="color:White ;" align = "left" >  
                           <div >
                                <a href ="../Pages/Statistics.aspx" ><span style ="color:White "> Estadisticas</span> </a>
                                <span>&nbsp</span>
                                <a href="../Pages/Administracion.aspx"><span style ="color:White "> Administraci&oacute;n</span> </a>
                           </div>
                        </td>
                        <td align ="right" >
                            <div>
                                <label for="PuntoDeVenta" >Punto de Venta</label>
                                <asp:DropDownList ID="ddlPuntoVenta" runat ="server" AutoPostBack ="true" ></asp:DropDownList> 
                            </div>
                        </td>
                    </tr>
                </table>
          
        </div>
    </div>
</div>