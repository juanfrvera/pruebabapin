USE [BAPIN_Nacion_Operativa]

GO
BEGIN TRANSACTION

	-- Primero verifico si el job ya fue creado, si es asi lo elimino y lo vuelvo a crear (priemro elimino todas sus relaciones y por ultimo el job)
	-- Elimino el jobserver
	IF EXISTS (SELECT TOP 1 1 FROM msdb.dbo.sysjobservers WHERE sysjobservers.job_id =
					(SELECT job_id FROM msdb.dbo.sysjobs WHERE name = N'sp_Cubo_Inicia_CxT'))
			BEGIN
				DELETE FROM msdb.dbo.sysjobservers WHERE sysjobservers.job_id =
						(SELECT job_id FROM msdb.dbo.sysjobs WHERE name = N'sp_Cubo_Inicia_CxT')
			END

	-- Elimino el jobschedule
	IF EXISTS (SELECT TOP 1 1 FROM msdb.dbo.sysjobschedules WHERE sysjobschedules.job_id = 
					(SELECT job_id FROM msdb.dbo.sysjobs WHERE name = N'sp_Cubo_Inicia_CxT'))
					BEGIN
						DELETE FROM msdb.dbo.sysjobschedules WHERE sysjobschedules.job_id = 
							(SELECT job_id FROM msdb.dbo.sysjobs WHERE name = N'sp_Cubo_Inicia_CxT')
					END

	-- Elimino el jobstep
	IF EXISTS (SELECT TOP 1 1 FROM msdb.dbo.sysjobsteps WHERE step_name  = N'sp_Cubo_Inicia_CxT')
	BEGIN
		DELETE FROM msdb.dbo.sysjobsteps WHERE step_name  = N'sp_Cubo_Inicia_CxT'
	END

	-- Elimino el job
	IF EXISTS (SELECT TOP 1 1 FROM msdb.dbo.sysjobs WHERE name = N'sp_Cubo_Inicia_CxT')
	BEGIN
		DELETE FROM msdb.dbo.sysjobs WHERE name = N'sp_Cubo_Inicia_CxT'
	END

	DECLARE @ReturnCode INT
	SELECT @ReturnCode = 0

	-- Si no existe, agrego categoria para JOBs
	IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
		BEGIN
		  EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
		  IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
		END
	
	-- Declaro el JOB
	DECLARE @jobId BINARY(16)
	EXEC @ReturnCode =  msdb.dbo.sp_add_job 
	  @job_name=N'sp_Cubo_Inicia_CxT', 
	  @enabled=1, 
	  @notify_level_eventlog=0, 
	  @notify_level_email=0, 
	  @notify_level_netsend=0, 
	  @notify_level_page=0, 
	  @delete_level=0, 
	  @description=N'Ejecuta el SP [sp_Cubo_Inicia_CxT]', 
	  @category_name=N'[Uncategorized (Local)]', 
	  @job_id = @jobId OUTPUT

	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

	-- Declaro el STEP
	EXEC @ReturnCode = msdb.dbo.sp_add_jobstep 
	  @job_id=@jobId,
	  @step_name=N'Step_sp_Cubo_Inicia_CxT', 
	  @step_id=1, 
	  @cmdexec_success_code=0, 
	  @on_success_action=1, 
	  @on_success_step_id=0, 
	  @on_fail_action=2, 
	  @on_fail_step_id=0, 
	  @retry_attempts=3, -- Cantidad de reintentos si falla el procedimiento
	  @retry_interval=5, -- intervalo de tiempo en minutos por cada reintento
	  @subsystem=N'TSQL', 
	  @command=N'USE BAPIN_Nacion_Operativa
	  /* Ejecuta el Stored Procedure de depuracion de Schedule*/
	  EXEC [sp_Cubo_Inicia_CxT]', 
	  @database_name=N'BAPIN_Nacion_Operativa', 
	  @flags=12

	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

	-- Agrego STEP a JOB
	EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

	-- Agrego a tareas programadas
	EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, 
	  @name=N'Ocurrencia del JOB', 
	  @enabled=1, 
	  @freq_type=4, -- tipo de frecuencia en que se ejecutara el job (0 = solo una vez, 4 = diario, 8 = semanal , 16 = mensual, 32 = mensual en relacion con el tipo de intervalo, 64 = cuandp el servicio Agente SQL Server se inicia 128 = cuando el equipo esta inactivo)
	  @freq_interval=1, -- dia en que se ejecuta el job (0 = solo una vez, 4 = cada X dias, 8 = un dia se la semana, se puede configurar para que sea un dia distinto, se concatenan mediante un operador logico 16 = un dia del mes 32 = relativo mensual, configurable para que sea dintintos dias del mes, 64 = cuando el servicio Agente SQL Server se inicia [no se utiliza, 128 = no se utiliza]) 
	  @freq_subday_type=1, -- Especifica las unidades para el parametro  @freq_subday_interval (0x1= a la hora especifica, 0x2= Minutos, 0x3 = Horas )
	  @freq_subday_interval=0, -- periodo que se producira entre cada ejecucion del job
	  @freq_relative_interval=0, 
	  @freq_recurrence_factor=0, 
	  @active_start_date=19900101, -- fecha en la que puede comenzar la ejecucion del job. formto AAAAMMDD 
	  @active_end_date=99991231, -- fecha en la que la ejecucion del job puede parar. formto AAAAMMDD 
	  @active_start_time=33000, -- Tiempo en cualquier dia entre los parametros   @active_start_date y   @active_end_date en la que puede comenzar la ejecucion del JOB
	  @active_end_time=235959 --  Tiempo en cualquier dia entre los parametros   @active_start_date y   @active_end_date en la que puede parar la ejecucion del JOB

	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

	-- Agrego la tarea programada al servidor
	EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

-- Termino con exito
COMMIT TRANSACTION
GOTO EndSave

-- Termino con error y vuelvo deshago los cambios
QuitWithRollback:
IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION

PRINT 'Hubo un error al crear el JOB, verifique e intente nuevamente'
EndSave: