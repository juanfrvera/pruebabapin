﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControlEditionButtons.ascx.cs" Inherits="UI.Web.WebControlEditionButtons" %>


<asp:Button ID="btSave" runat="server" Text="Guardar y Cerrar RACCA" OnClick="btSave_Click" SkinID="LightButton"
    CausesValidation="True"  />
<asp:Button ID="btSaveAndNew" runat="server" Text="Guardar y Crear Nuevo" OnClick="btSaveAndNew_Click" 
    SkinID="LightButton" CausesValidation="True"  />
<asp:Button ID="btCancel" runat="server" Text="Cerrar" OnClick="btCancel_Click"
    SkinID="LightButton" CausesValidation="False" />
    
<asp:Button ID="btAplicate" runat="server" Text="Guardar" OnClick="btAplicate_Click" 
    SkinID="LightButton" CausesValidation="True"  />
<asp:Button ID="btDelete" runat="server" Text="Eliminar" OnClick="btDelete_Click"
    SkinID="LightButton" CausesValidation="True"   />
