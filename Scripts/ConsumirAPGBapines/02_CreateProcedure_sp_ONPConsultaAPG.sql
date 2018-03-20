CREATE PROCEDURE [dbo].[sp_ONPConsultaAPG]
@MyXML xml
AS
BEGIN

INSERT INTO [BAPIN].[dbo].[wsONPConsultaAPG] 
		([codigoBapin], [jurisdiccion], [saf], [programa], [subprograma], 
		[jurisdiccionEsidif], [subjurisdiccionEsidif], [entidadEsidif], [safEsidif], [programaEsidif], [subprogramaEsidif], 
		[proyectoEsidif], [actividadEsidif], [obraEsidif], [ubicacionGeograficaEsidif], [ejecucionAcumulada])
select Bapin.detail.value('(codigoBapin/text())[1]','varchar(100)') as codigoBapin, 
       Bapin.detail.value('(jurisdiccion/text())[1]','bigint') as jurisdiccion, 
       Bapin.detail.value('(saf/text())[1]','varchar(100)') as saf, 
       Bapin.detail.value('(programa/text())[1]','varchar(100)') as programa, 
       Bapin.detail.value('(subprograma/text())[1]','varchar(100)') as subprograma,
			 Bapin.detail.value('(datosEsidif/jurisdiccionEsidif/text())[1]','varchar(100)') as jurisdiccionEsidif,
			 Bapin.detail.value('(datosEsidif/subjurisdiccionEsidif/text())[1]','varchar(100)') as subjurisdiccionEsidif,
 			 Bapin.detail.value('(datosEsidif/entidadEsidif/text())[1]','varchar(100)') as entidadEsidif,
	 		 Bapin.detail.value('(datosEsidif/safEsidif/text())[1]','varchar(100)') as safEsidif,
		   Bapin.detail.value('(datosEsidif/programaEsidif/text())[1]','varchar(100)') as programaEsidif,
			 Bapin.detail.value('(datosEsidif/subprogramaEsidif/text())[1]','varchar(100)') as subprogramaEsidif,
			 Bapin.detail.value('(datosEsidif/proyectoEsidif/text())[1]','varchar(100)') as proyectoEsidif,
			 Bapin.detail.value('(datosEsidif/actividadEsidif/text())[1]','varchar(100)') as actividadEsidif,
			 Bapin.detail.value('(datosEsidif/obraEsidif/text())[1]','varchar(100)') as obraEsidif,
			 Bapin.detail.value('(datosEsidif/ubicacionGeograficaEsidif/text())[1]','varchar(100)') as ubicacionGeograficaEsidif ,
			 Bapin.detail.value('(datosEsidif/ejecucionAcumulada/text())[1]','decimal') as ejecucionAcumulada 
    from @MyXML.nodes('/bapin') as Bapin(detail)

END