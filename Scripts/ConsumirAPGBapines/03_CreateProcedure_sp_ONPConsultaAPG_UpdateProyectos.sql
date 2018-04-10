
USE [bapin]

GO

CREATE PROCEDURE [dbo].[sp_ONPConsultaAPG_UpdateProyectos]
AS
BEGIN

Update P
Set 
	P.NroProyecto = W.proyectoEsidif,
	P.NroActividad = W.actividadEsidif,
	P.NroObra = W.obraEsidif
FROM
    Proyecto AS P
    INNER JOIN wsONPConsultaAPG AS W
        ON P.Codigo = W.codigoBapin

END

GO