CREATE DATABASE dbBIODENT
GO
USE dbBIODENT
GO
CREATE TABLE tblDoctor (
usuario varchar(50) PRIMARY KEY, 
contrasenia varchar(50)
)
GO
CREATE TABLE tblPaciente (
cedula varchar(10) PRIMARY KEY,
nombres varchar(100),
apellidos varchar(100),
fechaNacimiento date NULL,
sexo bit,
ocupacion varchar(50) NULL,
estadoCivil varchar(50) NULL,
direccion varchar(100),
telefono varchar(10) NULL,
celular varchar(10) NULL,
correoElectronico varchar(50) NULL
)
GO
CREATE TABLE tblHistoriaClinica(
numeroHistoriaClinica int PRIMARY KEY IDENTITY,
cedulaPaciente varchar(10) UNIQUE FOREIGN KEY REFERENCES tblPaciente (cedula) ON UPDATE CASCADE ON DELETE CASCADE,
tratamientoMedicoActual varchar(100) NULL,
tomaMedicamentoActual varchar(100) NULL,
observaciones varchar(100) NULL,
)
GO
CREATE TABLE tblPiezaDental(
numeroHistoriaClinica int FOREIGN KEY REFERENCES tblHistoriaClinica (numeroHistoriaClinica) ON UPDATE CASCADE ON DELETE CASCADE,
numeroPieza int,
colorArriba varchar(10),
colorDerecha varchar(10),
colorAbajo varchar(10),
colorIzquierda varchar(10),
colorCentro varchar(10)
)
GO
CREATE TABLE tblAntecedentePF(
numeroHistoriaClinica int FOREIGN KEY REFERENCES tblHistoriaClinica (numeroHistoriaClinica) ON UPDATE CASCADE ON DELETE CASCADE,
alergiaAntibiotico bit,
alergiaAnestesia bit,
hemorragia bit,
sida bit,
tuberculosis bit,
diabetes bit,
asma bit,
hipertension bit,
enfermedadCardiaca bit,
bebidasAlcoholicas bit,
frecuencia varchar(50),
fuma bit,
numeroCigarros varchar(50),
observaciones varchar(100)
)
GO
CREATE TABLE tblPlanTratamiento(
idPlanTratamiento int PRIMARY KEY IDENTITY,
numeroHistoriaClinica int FOREIGN KEY REFERENCES tblHistoriaClinica (numeroHistoriaClinica) ON UPDATE CASCADE ON DELETE CASCADE,
descripcion varchar(50),
estado bit,
fechaPlanTratamiento date,
subtotal money,
total money
)
GO
CREATE TABLE tblDetalle(
idPlanTratamiento int FOREIGN KEY REFERENCES tblPlanTratamiento (idPlanTratamiento) ON UPDATE CASCADE ON DELETE CASCADE,
idDetalle int,
actividad varchar(100),
cantidad int,
precioUnitario money
)
GO
CREATE TABLE tblActividad(
idPlanTratamiento int FOREIGN KEY REFERENCES tblPlanTratamiento (idPlanTratamiento) ON UPDATE CASCADE ON DELETE CASCADE,
idActividad int,
fechaActividad date,
numeroPieza int,
actividad varchar(100),
)
GO
CREATE TABLE tblAbono(
idPlanTratamiento int FOREIGN KEY REFERENCES tblPlanTratamiento (idPlanTratamiento) ON UPDATE CASCADE ON DELETE CASCADE,
fechaAbono date,
abono money
)
GO
INSERT INTO tblDoctor VALUES ('drManuelGuerrero', '25522552')
GO
CREATE PROCEDURE spIngresarPaciente 
@cedula varchar(10), @nombres varchar(100), @apellidos varchar(100), @fechaNacimiento date, 
@sexo bit, @ocupacion varchar(50), @estadoCivil varchar(50), @direccion varchar(100), 
@telefono varchar(10), @celular varchar(10), @correoElectronico varchar(50), @tratamientoMedicoActual varchar(100),
@tomaMedicamentoActual varchar(100), @observacionesH varchar(100), @alergiaAntibiotico bit, @alergiaAnestesia bit,
@hemorragia bit, @sida bit, @tuberculosis bit, @diabetes bit, @asma bit, @hipertension bit, @enfermedadCardiaca bit,
@bebidasAlcoholicas bit, @frecuencia varchar(50), @fuma bit, @numeroCigarros varchar(50), @observacionesA varchar(100), @salida bit OUTPUT AS BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF NOT EXISTS (SELECT cedula FROM tblPaciente WHERE cedula = @cedula) BEGIN
				INSERT INTO tblPaciente VALUES (@cedula, @nombres, @apellidos, @fechaNacimiento, @sexo, @ocupacion, @estadoCivil, 
				@direccion, @telefono, @celular, @correoElectronico)
				INSERT INTO tblHistoriaClinica VALUES (@cedula, @tratamientoMedicoActual, @tomaMedicamentoActual, @observacionesH)
				DECLARE @numeroHistoria int
				DECLARE @lazo int
				DECLARE @numeroPieza int
				SET @lazo = 1
				SET @numeroPieza = 11
				SET @numeroHistoria = (SELECT numeroHistoriaClinica FROM tblHistoriaClinica WHERE cedulaPaciente = @cedula)
				INSERT INTO tblAntecedentePF VALUES (@numeroHistoria, @alergiaAntibiotico, @alergiaAnestesia, @hemorragia, @sida, 
				@tuberculosis, @diabetes, @asma, @hipertension, @enfermedadCardiaca, @bebidasAlcoholicas, @frecuencia, @fuma, 
				@numeroCigarros, @observacionesA)
				WHILE @lazo <= 52 BEGIN
					INSERT INTO tblPiezaDental VALUES (@numeroHistoria, @numeroPieza,'White', 'White', 'White', 'White', 'White')
					SET @numeroPieza = @numeroPieza + 1
					IF @numeroPieza = 19 BEGIN
						SET @numeroPieza = 21
					END ELSE IF @numeroPieza = 29 BEGIN
						SET @numeroPieza = 31
					END ELSE IF @numeroPieza = 39 BEGIN
						SET @numeroPieza = 41
					END ELSE IF @numeroPieza = 49 BEGIN
						SET @numeroPieza = 51
					END ELSE IF @numeroPieza = 56 BEGIN
						SET @numeroPieza = 61
					END ELSE IF @numeroPieza = 66 BEGIN
						SET @numeroPieza = 71
					END ELSE IF @numeroPieza = 76 BEGIN
						SET @numeroPieza = 81
					END
					SET @lazo = @lazo + 1
				END
				SET @salida = 1
			END ELSE BEGIN
				 SET @salida = 0
			END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @salida = 0
		ROLLBACK TRANSACTION
	END CATCH
END
GO
CREATE PROCEDURE spActualizarPaciente
@cedulaAnterior varchar(10), @cedula varchar(10), @nombres varchar(100), @apellidos varchar(100), @fechaNacimiento date, 
@sexo bit, @ocupacion varchar(50), @estadoCivil varchar(50), @direccion varchar(100), 
@telefono varchar(10), @celular varchar(10), @correoElectronico varchar(50), @tratamientoMedicoActual varchar(100),
@tomaMedicamentoActual varchar(100), @observacionesH varchar(100), @alergiaAntibiotico bit, @alergiaAnestesia bit,
@hemorragia bit, @sida bit, @tuberculosis bit, @diabetes bit, @asma bit, @hipertension bit, @enfermedadCardiaca bit,
@bebidasAlcoholicas bit, @frecuencia varchar(50), @fuma bit, @numeroCigarros varchar(50), @observacionesA varchar(100), @salida bit OUTPUT AS BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @numeroHistoriaClinica int
			SET @numeroHistoriaClinica = (SELECT numeroHistoriaClinica FROM tblHistoriaClinica WHERE cedulaPaciente = @cedulaAnterior)
			UPDATE tblPaciente SET cedula = @cedula, nombres = @nombres, apellidos = @apellidos, fechaNacimiento = @fechaNacimiento, sexo = @sexo, 
			ocupacion = @ocupacion, estadoCivil = @estadoCivil, direccion = @direccion, telefono = @telefono, celular = @celular, correoElectronico = @correoElectronico
			WHERE cedula = @cedulaAnterior
			UPDATE tblHistoriaClinica SET tratamientoMedicoActual = @tratamientoMedicoActual, tomaMedicamentoActual = @tomaMedicamentoActual, observaciones = @observacionesH
			WHERE numeroHistoriaClinica = @numeroHistoriaClinica
			UPDATE tblAntecedentePF SET alergiaAntibiotico = @alergiaAntibiotico, alergiaAnestesia = @alergiaAnestesia, hemorragia = @hemorragia, sida = @sida, 
			tuberculosis = @tuberculosis, diabetes = @diabetes, asma = @asma, hipertension = @hipertension, enfermedadCardiaca = @enfermedadCardiaca, 
			bebidasAlcoholicas = @bebidasAlcoholicas, frecuencia = @frecuencia, fuma = @fuma, numeroCigarros = @numeroCigarros, observaciones = @observacionesA 
			WHERE numeroHistoriaClinica = @numeroHistoriaClinica
			SET @salida = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @salida = 0
		ROLLBACK TRANSACTION
	END CATCH
END
GO

DECLARE @salida bit
EXECUTE spIngresarPaciente '1716116809', 'Alejandro Esteban', 'Guerrero Tipán', '21/08/1994', 0, 'Estudiante Universitario', 'Soltero',
'De Los Guabos Pasaje N48A E10-37 El Inca', '2402538', '0987858621', 'alejo_guerrero94@hotmail.com', 'N/A', 'N/A', 'S/N', 0, 0, 0, 0,
0, 0, 0, 0, 0, 0, 'No toma', 0, 'No fuma', 'S/N', @salida OUTPUT
PRINT @salida
GO
SELECT * FROM tblHistoriaClinica
SELECT * FROM tblHistoriaClinica INNER JOIN tblAntecedentePF ON tblHistoriaClinica.numeroHistoriaClinica = tblAntecedentePF.numeroHistoriaClinica WHERE tblHistoriaClinica.cedulaPaciente = '0503628109'
SELECT * FROM tblAntecedentePF
SELECT * FROM tblPlanTratamiento
SELECT * FROM tblDetalle
SELECT TOP 1 numeroHistoriaClinica FROM tblHistoriaClinica ORDER BY numeroHistoriaClinica DESC
