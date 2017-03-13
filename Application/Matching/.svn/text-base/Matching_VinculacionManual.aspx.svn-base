<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="Matching_VinculacionManual.aspx.cs" Inherits="UI.Web.Matching.Matching_VinculacionManual" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
   
    
       
    <fieldset>
     <legend><asp:Literal ID="litFiltros" Text="Filtros" runat="server" ></asp:Literal></legend>
     <div id="filtro">

       
      <table width="100%"  cellpadding="0" cellspacing="10" border="0">
            
          <tr>

	            <td class="tdFilter" style=" width:230px" >
	                <div ><asp:Literal ID="liJurisdiccion" Text="Jurisdicción" runat="server" ></asp:Literal>&nbsp;</div>
		            <div><asp:DropDownList ID="ddlJurisdiccion" runat="server" CssClass="field_input"  
		                    onselectedindexchanged="ddlJurisdiccion_SelectedIndexChanged" AutoPostBack ="true" SkinID="AnchoLibre" Width="230px" ></asp:DropDownList></div>
	            </td>
	            <td class="tdFilter" style=" width:230px">
	                <div ><asp:Literal ID="liSAF" Text="SAF" runat="server" ></asp:Literal>&nbsp;</div>
		            <div><asp:DropDownList ID="ddlSAF" runat="server" CssClass="field_input" 
                            onselectedindexchanged="ddlSAF_SelectedIndexChanged" AutoPostBack ="true" Enabled="false" SkinID="AnchoLibre" Width="230px"  ></asp:DropDownList></div>
	            </td>
	            <td class="tdFilter" style=" width:230px">
	                <div ><asp:Literal ID="liPrograma" Text="Programa" runat="server" ></asp:Literal>&nbsp;</div>
		            <div><asp:DropDownList ID="ddlPrograma" runat="server" CssClass="field_input" 
                            onselectedindexchanged="ddlPrograma_SelectedIndexChanged" AutoPostBack ="true" Enabled="false"  SkinID="AnchoLibre" Width="230px" ></asp:DropDownList></div>
	        
	            </td>
		
	            <td class="tdFilter" style=" width:230px" >
	                <div ><asp:Literal ID="liSubPrograma" Text="SubPrograma" runat="server" ></asp:Literal>&nbsp;</div>
		            <div><asp:DropDownList ID="ddlSubPrograma" runat="server" CssClass="field_input"  Enabled="false"  SkinID="AnchoLibre" Width="230px" ></asp:DropDownList></div>
	            </td> 
                </tr><tr> 
                <td>     <asp:Button ID="cmdBuscar" Text="Buscar" runat="server" OnClick="cmdBuscar_Click" />
        
                </td>
                </tr>
            <tr>
                <td>
                <asp:Label ID="lblCodBapin" Visible="true" runat="server">Cod. Bapin:</asp:Label>
                <asp:TextBox ID="txtCodBapin" Visible="true" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCodBapin" runat="server" ErrorMessage="Ingrese solo números" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                    
              </td>
               </tr>
          <tr>
                 <td><asp:Button ID="cmdBuscarBapin" Text="Buscar por Bapin" runat="server" OnClick="cmdBuscarBapin_Click" /></td>

            </tr>

          <tr>
              <td>
                  <asp:Label ID="lblJurisdiccion" Visible="false" runat="server"  ></asp:Label>
                  <asp:Label ID="lblSaf" Visible="false" runat="server"  ></asp:Label>
                  <asp:Label ID="lblPrograma" Visible="false" runat="server"  ></asp:Label>
                  <asp:Label ID="lblSubprograma" Visible="false" runat="server" ></asp:Label>
              </td>

          </tr>

            </table>

    
         
    
         </div>
        </fieldset> 
    
     
    <!--Sección de Trabajo-->
       <fieldset>
     <legend><asp:Literal ID="Literal1" Text="Proyectos No Vinculados" runat="server" ></asp:Literal></legend>
        <table width="100%">
             
       
         <tr>
          <td><h2>Vinculación Manual de Proyectos</h2></td></tr>

       <tr><td><asp:Label ID="lblProyectoSidif" BackColor="WhiteSmoke" ForeColor="SteelBlue" runat="server" Font-Bold="true" Font-Size="Medium" ></asp:Label></td></tr>         
        <tr>
            <td>
          
                <asp:GridView ID="grdProyectosAutomatch"  
                      autogeneratecolumns="false"
                    emptydatatext="Sin datos disponibles!"
                    AllowPaging="true" PageSize="10" runat="server" OnSelectedIndexChanged="grdProyectosAutomatch_SelectedIndexChanged"  OnRowDataBound="grdProyectosAutomatch_RowDataBound" DataKeyNames="CodigoProyectoBapin" AllowSorting="true"  OnPageIndexChanging="grdProyectosAutomatch_PageIndexChanging" >
                    
               <Columns>
                  
                   <asp:BoundField DataField="ProyectoDenominacion" HeaderText="Denominación"  />
                   <asp:BoundField DataField="CodigoProyectoBAPIN" HeaderText="Bapin" />
                   <asp:BoundField DataField="Nombre" HeaderText="Jurisdicción" />
                   <asp:BoundField DataField="SAF_Denominacion" HeaderText="SAF" />
                   <asp:BoundField DataField="Programa" HeaderText="Programa" />
                   <asp:BoundField DataField="SubPrograma" HeaderText="SubPrograma" />
                   <asp:ButtonField Text="Vincular Proyecto" CommandName="Select" ItemStyle-Width="30" HeaderText="Acciones" />
           
               
               </Columns>
                    
                 </asp:GridView>
           </td>
        </tr>
     </table>
        
          </fieldset>



    
     <!--Acciones-->
       <fieldset>
        <legend><asp:Literal ID="Literal2" Text="Acciones" runat="server" ></asp:Literal></legend>
        <table>
            <tr>
               <td><asp:Button ID="cmdMatchingVinculados" Text="Volver" OnClick="cmdMatchingVinculados_Click"  runat="server" /></td>
              
            </tr>
        </table>    
        

    </fieldset>


</asp:Content>
