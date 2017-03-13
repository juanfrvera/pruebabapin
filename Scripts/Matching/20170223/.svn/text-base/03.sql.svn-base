 /*
 QUERY AGRUPADO SIDIF
 ESTE QUERY ANALIZA LOS CAMBIOS DE PROYECTOS POSTERIOR A LA ACTUALIZACIÓN DEL SIDIF

 */
 
 --SETEO LAS VARIABLES
DECLARE @EjercicioPresupuestario as int
SET @EjercicioPresupuestario=YEAR(GETDATE())-1

DECLARE @mesSidif as nvarchar(2)
SET @mesSidif= 12


--Elimina los proyectos del período que no tienen código de Bapin Actualizado
DELETE FROM Matching_InfoPresupuestoAgrupado
WHERE EjercicioPresupuestario=@EjercicioPresupuestario and MesSidif=@mesSidif 
INSERT INTO Matching_InfoPresupuestoAgrupado
SELECT [IdentificadorProyectoSidif]
      ,[EjercicioPresupuestario]
      ,[MesSidif]
      ,[CodJurisdiccion]
      ,[Jurisdiccion]
      ,[CodSAF]
      ,[SAF]
      ,[CodPrograma]
      ,[Programa]
      ,[CodSubprograma]
      ,[Subprograma]
      ,[CodProyecto]
      ,[Proyecto]
      ,[CodActividad]
      ,[Actividad]
      ,[CodObra]
      ,[Obra]
      ,[AperturaProgramatica]
      ,[AperturaPresupuestaria]
	  ,[AperturaProgramaticaSeparada]
      ,[AperturaPresupuestariaSeparada]
	  ,SUM([CredInicial]) as CreditoInicial
      ,SUM([CredVigente]) as CreditoVigente
      ,SUM([Devengado]) as Devengado
      ,SUM([Pagado]) as Pagado

	FROM [Matching_InfoPresupuesto]
    WHERE EjercicioPresupuestario=@EjercicioPresupuestario AND MesSidif=@mesSidif 
	GROUP BY [IdentificadorProyectoSidif]
      ,[EjercicioPresupuestario]
      ,[MesSidif]
      ,[CodJurisdiccion]
      ,[Jurisdiccion]
      ,[CodSAF]
      ,[SAF]
      ,[CodPrograma]
      ,[Programa]
      ,[CodSubprograma]
      ,[Subprograma]
      ,[CodProyecto]
      ,[Proyecto]
      ,[CodActividad]
      ,[Actividad]
      ,[CodObra]
      ,[Obra]
      ,[AperturaProgramatica]
      ,[AperturaPresupuestaria]
	  ,[AperturaProgramaticaSeparada]
      ,[AperturaPresupuestariaSeparada]
	
	
--Realiza el update de proyectos de sidif que tengan código de BAPIN

UPDATE Matching_InfoPresupuestoAgrupado 
SET 
Matching_InfoPresupuestoAgrupado.CreditoInicial=IP.CreditoInicial,
Matching_InfoPresupuestoAgrupado.CreditoVigente=IP.CreditoVigente,
Matching_InfoPresupuestoAgrupado.Devengado=IP.Devengado,
Matching_InfoPresupuestoAgrupado.Pagado=IP.Pagado
FROM 
(SELECT 
	   [IdentificadorProyectoSidif]
      ,[EjercicioPresupuestario]
      ,[MesSidif]
	  ,SUM([CredInicial]) as CreditoInicial
      ,SUM([CredVigente]) as CreditoVigente
      ,SUM([Devengado]) as Devengado
      ,SUM([Pagado]) as Pagado
	    FROM [Matching_InfoPresupuesto]
				GROUP BY  [IdentificadorProyectoSidif]
      ,[EjercicioPresupuestario]
      ,[MesSidif]
	  ) AS IP 
	  
	  WHERE IP.[IdentificadorProyectoSidif] = Matching_InfoPresupuestoAgrupado.[IdentificadorProyectoSidif] 
	  AND Matching_InfoPresupuestoAgrupado.MesSidif=@mesSidif and Matching_InfoPresupuestoAgrupado.EjercicioPresupuestario=@EjercicioPresupuestario
	--  AND Matching_InfoPresupuestoAgrupado.CodigoBapin<>0




	  