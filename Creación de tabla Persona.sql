--/****************** DEMO API REST ******************/
USE master;
GO

BEGIN TRANSACTION;

-- Verificar si la tabla Persona
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Persona')
BEGIN
    DROP TABLE Persona;
END


CREATE TABLE Persona (
    cPersonaId INT PRIMARY KEY IDENTITY(1,1),
    cNombres NVARCHAR(100) NOT NULL,
    cApellidoPaterno NVARCHAR(100) NOT NULL,
    cApellidoMaterno NVARCHAR(100) NOT NULL,
    nTipoDOI INT NOT NULL, 
    cNumeroDOI NVARCHAR(20) NOT NULL,
    cNumeroTelefono NVARCHAR(20),
    cCorreoElectronico NVARCHAR(100),
    cDireccion NVARCHAR(255)
);	

--   cPersonaId: Identificador único de la persona, generado automáticamente.
--   cNombres: Nombres de la persona.
--   cApellidoPaterno: Apellido paterno de la persona.
--   cApellidoMaterno: Apellido materno de la persona.
--   nTipoDOI: Tipo de documento de identidad de la persona (1 = DNI, 2 = Pasaporte, 3 = Carnet de extranjería, 4 = Otros). 
--   cNumeroDOI: Número de documento de identidad de la persona.
--   cNumeroTelefono: Número de teléfono de la persona.
--   cCorreoElectronico: Correo electrónico de la persona.
--   cDireccion: Dirección de la persona.

--Dependiendo de la complejidad los valores del campo nTipoDOI pueden ir en un diccionario de datos o ser la llave primaria de una segunda tabla, por lo que se trabajará con un formato FK entero.
--En la mayoría de sistemas los campos número de teléfono, correo y dirección son opcionales. Por lo que se manejará un formato estándar.



INSERT INTO Persona (cNombres, cApellidoPaterno, cApellidoMaterno, nTipoDOI, cNumeroDOI, cNumeroTelefono, cCorreoElectronico, cDireccion)
VALUES
('Juan', 'Gonzales', 'Perez', 1, '12345678', '987654321', 'juan.gonzales@example.com', 'Calle Lima 123'),
('Maria', 'Rodriguez', 'Diaz', 1, '87654321', '123456789', 'maria.rodriguez@example.com', 'Av. Arequipa 456'),
('Pedro', 'Flores', 'Vargas', 1, '11111111', '987654321', 'pedro.flores@example.com', 'Jr. Huancayo 789'),
('Luis', 'Lopez', 'Alvarez', 1, '22222222', '123456789', 'luis.lopez@example.com', 'Av. Cusco 147'),
('Ana', 'Perez', 'Garcia', 1, '33333333', '987654321', 'ana.perez@example.com', 'Calle Tacna 258'),
('Elena', 'Gutierrez', 'Martinez', 1, '44444444', '123456789', 'elena.gutierrez@example.com', 'Jr. Ica 369'),
('Carlos', 'Chavez', 'Ramos', 1, '55555555', '987654321', 'carlos.chavez@example.com', 'Av. Puno 753'),
('Laura', 'Sanchez', 'Silva', 1, '66666666', '123456789', 'laura.sanchez@example.com', 'Calle Piura 159'),
('Jorge', 'Torres', 'Castro', 1, '77777777', '987654321', 'jorge.torres@example.com', 'Jr. Ayacucho 357'),
('Sofia', 'Ramirez', 'Quispe', 1, '88888888', '123456789', 'sofia.ramirez@example.com', 'Av. Amazonas 456'),
('Diego', 'Rojas', 'Perez', 1, '99999999', '987654321', 'diego.rojas@example.com', 'Calle Ancash 852'),
('Fernanda', 'Alvarez', 'Flores', 1, '10101010', '123456789', 'fernanda.alvarez@example.com', 'Jr. Tumbes 963'),
('Mateo', 'Garcia', 'Gonzales', 1, '12121212', '987654321', 'mateo.garcia@example.com', 'Av. Libertad 321'),
('Camila', 'Martinez', 'Torres', 1, '13131313', '123456789', 'camila.martinez@example.com', 'Calle Lambayeque 753'),
('Sebastian', 'Rios', 'Diaz', 1, '14141414', '987654321', 'sebastian.rios@example.com', 'Jr. Junin 258'),
('Valentina', 'Vargas', 'Sanchez', 3, '15151515', '123456789', 'valentina.vargas@example.com', 'Av. Moquegua 147'),
('Lucas', 'Hernandez', 'Alonso', 3, '16161616', '987654321', 'lucas.hernandez@example.com', 'Calle Madre de Dios 369'),
('Martina', 'Suarez', 'Mendoza', 3, '17171717', '123456789', 'martina.suarez@example.com', 'Jr. Loreto 753'),
('Daniel', 'Perez', 'Rojas', 2, '18181818', '987654321', 'daniel.perez@example.com', 'Av. Huancavelica 159'),
('Isabella', 'Luna', 'Gomez', 2, '19191919', '123456789', 'isabella.luna@example.com', 'Calle Piura 852'),
('Benjamin', 'Castro', 'Ramirez', 2, '20202020', '987654321', 'benjamin.castro@example.com', 'Jr. Ayacucho 357');

COMMIT TRANSACTION;

GO

