-- Creación de la Tabla Cliente
USE PRACTICA_CLIENTE

CREATE TABLE Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    Correo VARCHAR(100) NULL,
    Telefono VARCHAR(20) NULL,
    Activo BIT DEFAULT 1,
    FechaRegistro DATETIME2 DEFAULT SYSDATETIME(),
    FechaActualizacion DATETIME2 NULL
);
GO

-- Inserción de 10 registros de prueba
INSERT INTO Cliente (Codigo, Nombre, Apellidos, Correo, Telefono)
VALUES 
('Cl1', 'Brandon', 'Calixto', 'Bra@gmail.com', '7734561236'),
('cl2', 'Pancho', 'Garcia', 'pancho@gmail.com', '7731524587'),
('CL6', 'Jonathan', 'Mendoza', 'jona@gmail.com', '7734578745'),
('cl7', 'Kevin', 'Avendaño', 'kevin@gmail.com', '7894561230'),
('cl8', 'Aylin', 'Covarrubiuas', 'aylin@gmail.com', '3216549870'),
('cl9', 'Horacio', 'Pacheco', 'hora@gmail.com', '1234567890'),
('CL10', 'Juan', 'Lopez', 'juan@gmail.com', '8527411234'),
('CL11', 'Petra', 'Hernandez', 'petra@gmail.com', '7894562584'),
('CL12', 'Pepe', 'Buendia', 'pepe@gmail.com', '1145589856'),
('CL13', 'Zully', 'Gervacio', 'zully@gmail.com', '4567891479');

-- SP de Insertar en Cliente
CREATE PROCEDURE Cliente_Insertar
	@Codigo VARCHAR(20),
	@Nombre VARCHAR(50),
	@Apellidos VARCHAR(50),
	@Correo VARCHAR(100),
	@Telefono VARCHAR(20),
	@Activo BIT
AS
BEGIN
    INSERT INTO dbo.Cliente (
        Codigo, 
        Nombre, 
        Apellidos, 
        Correo, 
        Telefono, 
        Activo, 
        FechaRegistro
    )
    VALUES (
        @Codigo,
        @Nombre,
        @Apellidos,
        @Correo,
        @Telefono,
        @Activo,
        GETDATE()
    )
END
GO

-- SP de Actualizar Cliente
ALTER PROCEDURE [dbo].[Cliente_Actualizar] 
	@IdCliente INT,
	@Codigo VARCHAR(20),
	@Nombre VARCHAR(50),
	@Apellidos VARCHAR(50),
	@Correo VARCHAR(100),
	@Telefono VARCHAR(20),
	@Activo BIT
AS
BEGIN
	UPDATE Cliente
	SET
		Codigo = @Codigo,
		Nombre = @Nombre,
		Apellidos = @Apellidos,
		Correo = @Correo,
		Telefono = @Telefono,
		Activo = @Activo,
		FechaActualizacion = SYSDATETIME()
	WHERE IdCliente = @IdCliente
END

-- SP de Eliminar Cliente
ALTER PROCEDURE [dbo].[Cliente_Eliminar] 
	@IdCliente INT
AS
BEGIN
    UPDATE Cliente
    SET 
        Activo = 0,
        FechaActualizacion = SYSDATETIME()
    WHERE 
        IdCliente = @IdCliente
END
GO

-- SP de Consultar Cliente por ID
CREATE PROCEDURE Cliente_ConsultarPorId 
	@IdCliente INT
AS
BEGIN
	SELECT
		IdCliente,
		Codigo,
		Nombre,
		Apellidos, 
        Correo, 
        Telefono, 
        Activo, 
        FechaRegistro,
		FechaActualizacion
	FROM Cliente WHERE IdCliente = @IdCliente
END
GO

-- SP de Consultar Todos los Clientes
CREATE PROCEDURE Cliente_ConsultarTodos
AS
BEGIN
	SELECT
		IdCliente as IdCliente,
		Codigo as Codigo,
		Nombre as Nombre,
		Apellidos as Apellidos,
		Correo as Correo,
		Telefono as Telefono,
		Activo as Activo,
		FechaRegistro as FechaRegistro,
		FechaActualizacion as FechaActualizacion
	FROM Cliente
END
GO