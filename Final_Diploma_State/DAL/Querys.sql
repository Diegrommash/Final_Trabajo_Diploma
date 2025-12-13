CREATE DATABASE FINAL_STATE_DB;
GO

USE FINAL_STATE_DB;
GO

CREATE TABLE Tarea (
    IdTarea INT IDENTITY PRIMARY KEY,
    Titulo NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(500),
    EstadoActual NVARCHAR(50) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE HistorialEstadoTarea (
    IdHistorial INT IDENTITY PRIMARY KEY,
    IdTarea INT NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    FechaCambio DATETIME NOT NULL DEFAULT GETDATE(),
    Motivo NVARCHAR(250),

    CONSTRAINT FK_Historial_Tarea
        FOREIGN KEY (IdTarea) REFERENCES Tarea(IdTarea)
);
GO

CREATE PROCEDURE SP_Tarea_Crear
    @Titulo NVARCHAR(100),
    @Descripcion NVARCHAR(500)
AS
BEGIN
    INSERT INTO Tarea (Titulo, Descripcion, EstadoActual)
    VALUES (@Titulo, @Descripcion, 'Pendiente');

    DECLARE @IdTarea INT = SCOPE_IDENTITY();

    INSERT INTO HistorialEstadoTarea (IdTarea, Estado, Motivo)
    VALUES (@IdTarea, 'Pendiente', 'Creación de la tarea');

    SELECT @IdTarea AS IdTarea;
END;
GO

CREATE PROCEDURE SP_Tarea_CambiarEstado
    @IdTarea INT,
    @NuevoEstado NVARCHAR(50),
    @Motivo NVARCHAR(250) = NULL
AS
BEGIN
    UPDATE Tarea
    SET EstadoActual = @NuevoEstado,
        FechaUltimaActualizacion = GETDATE()
    WHERE IdTarea = @IdTarea;

    INSERT INTO HistorialEstadoTarea (IdTarea, Estado, Motivo)
    VALUES (@IdTarea, @NuevoEstado, @Motivo);
END;
GO

CREATE PROCEDURE SP_Tarea_ObtenerPorEstado
    @Estado NVARCHAR(50)
AS
BEGIN
    SELECT
        IdTarea,
        Titulo,
        Descripcion,
        EstadoActual,
        FechaCreacion
    FROM Tarea
    WHERE EstadoActual = @Estado
    ORDER BY FechaCreacion;
END;
GO

CREATE PROCEDURE SP_Tarea_ObtenerTodas
AS
BEGIN
    SELECT
        IdTarea,
        Titulo,
        Descripcion,
        EstadoActual,
        FechaCreacion,
        FechaUltimaActualizacion
    FROM Tarea
    ORDER BY FechaCreacion;
END;
GO

CREATE PROCEDURE SP_Tarea_ObtenerHistorial
    @IdTarea INT
AS
BEGIN
    SELECT
        Estado,
        FechaCambio,
        Motivo
    FROM HistorialEstadoTarea
    WHERE IdTarea = @IdTarea
    ORDER BY FechaCambio;
END;
GO