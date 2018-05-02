-- select * from SistemaEntidadEstado where  IdSistemaEntidad = 437 order by IdEstado

update SistemaEntidadEstado set Nombre = '1 - Idea/Perfil'
where  IdSistemaEntidad = 437 and IdEstado = 1

update SistemaEntidadEstado set Nombre = '2 - Prefact/Factib'
where  IdSistemaEntidad = 437 and IdEstado = 3

update SistemaEntidadEstado set Nombre = '5 - Cancelado'
where  IdSistemaEntidad = 437 and IdEstado = 9

update SistemaEntidadEstado set Nombre = '3 - Iniciado'
where  IdSistemaEntidad = 437 and IdEstado = 16

update SistemaEntidadEstado set Nombre = '4 - Finalizado'
where  IdSistemaEntidad = 437 and IdEstado = 50

update Proceso set Nombre = '2 - Ampliación' where IdProceso = 2
update Proceso set Nombre = '1 - Reposición' where IdProceso = 7
update Proceso set Nombre = '3 - Equipamiento Básico de Oficina' where IdProceso = 23