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
nombre varchar(100),
apellidoPaterno varchar(100),
apellidoMaterno varchar(100),
fechaNacimiento date,
ocupacion varchar(50),
direccion varchar(100),
telefono varchar(10),
correoElectronico varchar(50)
)
GO
CREATE TABLE tblHistoriaClinica(
numeroHistoriaClinica int PRIMARY KEY IDENTITY,
cedulaPaciente varchar(10) UNIQUE FOREIGN KEY REFERENCES tblPaciente (cedula) ON UPDATE CASCADE ON DELETE CASCADE,
antecendentesPersonales varchar(150),
antecedentesPersonalesFamiliares varchar(150),
observaciones varchar(100),
fechaIngreso date
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
CREATE TABLE tblPlanTratamiento(
idPlanTratamiento int PRIMARY KEY,
numeroHistoriaClinica int FOREIGN KEY REFERENCES tblHistoriaClinica (numeroHistoriaClinica) ON UPDATE CASCADE ON DELETE CASCADE,
estado bit,
fechaPlanTratamiento date,
subtotal money,
descuento money,
total money
)
GO
CREATE TABLE tblDetalle(
idPlanTratamiento int FOREIGN KEY REFERENCES tblPlanTratamiento (idPlanTratamiento) ON UPDATE CASCADE ON DELETE CASCADE,
idDetalle int,
detalle varchar(100),
cantidad int,
precioUnitario money
)
GO
CREATE TABLE tblTratamiento(
idPlanTratamiento int FOREIGN KEY REFERENCES tblPlanTratamiento (idPlanTratamiento) ON UPDATE CASCADE ON DELETE CASCADE,
idTratamiento int,
fechaTratamiento date,
numeroPieza int,
tratamiento varchar(100),
fechaAbono date,
abono money
)
GO
INSERT INTO tblDoctor VALUES ('drManuelGuerrero', '25522552')