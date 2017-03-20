
----------------------------------------------------
-- Actualiza texto Préstamo

select * from ProyectoOrigenFinanciamiento
select * from ProyectoOrigenFinanciamientoTipo

update ProyectoOrigenFinanciamientoTipo
set Nombre = 'Préstamo'
where Nombre = 'Prestamo'


----------------------------------------------------
-- Auditorias de operaciones.

/*

-- Limpia el DataPreOperation

update	AuditOperation
set		DataPreOperation = null
where	DataPreOperation is not null

update	AuditOperation
set		DataPostOperation = null
where	IdAuditOperation in ( select IdAuditOperation from AuditOperation where StartDate<'2014-10-01' and DataPostOperation is not null )

*/

----------------------------------------------------
-- Recorre todos los programas
select * from Programa

select * from Sectorialistas

select		pr.Nombre, u.IdUsuario, ss.*, pr.*
from		Usuario	u
inner join	Sectorialistas	s	on s.ID=u.IdUsuario
left join	Saf				ss	on ss.IdSaf=s.IdSaf
left join	Programa		pr	on pr.IdSAF=ss.IdSaf


select		pr.Nombre, u.IdUsuario
from		Usuario	u
inner join	Sectorialistas	s	on s.ID=u.IdUsuario
inner join	Saf				ss	on ss.IdSaf=s.IdSaf
inner join	Programa		pr	on pr.IdSAF=ss.IdSaf
group by  pr.Nombre, u.IdUsuario


update	Programa
set		IdSectorialista = 
(
select	top 1 u.IdUsuario
from		Usuario	u
inner join	Sectorialistas s	on s.ID=u.IdUsuario
inner join	Saf		ss			on ss.IdSaf=s.IdSaf
where	Programa.IdSAF = ss.IdSaf
)



----------------------------------------------------
-- Aumentaron la cantidad de char's del campo ProyectoDictamenX . Numero a "Varchar(35)"


----------------------------------------------------
