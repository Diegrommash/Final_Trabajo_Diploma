CREATE DATABASE FINAL_VISITOR_DB;
GO

USE FINAL_VISITOR_DB;
GO

CREATE TABLE Personaje
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tipo VARCHAR(10) NOT NULL, 
    Vida INT NOT NULL,
    Mana INT NOT NULL,
    Ataque INT NOT NULL,
    Defensa INT NOT NULL
);
GO

CREATE PROCEDURE SP_LISTAR_PERSONAJES
AS
BEGIN
    SELECT Id, Tipo, Vida, Mana, Ataque, Defensa
    FROM Personaje;
END;
GO

CREATE TABLE StatsPersonaje (
    IdPersonaje INT PRIMARY KEY,
    BatallasJugadas INT NOT NULL DEFAULT 0,
    BatallasGanadas INT NOT NULL DEFAULT 0,
    BatallasPerdidas INT NOT NULL DEFAULT 0,
    DanioCausadoTotal INT NOT NULL DEFAULT 0,
    DanioRecibidoTotal INT NOT NULL DEFAULT 0,
    EfectosAplicados INT NOT NULL DEFAULT 0,
    EfectosRecibidos INT NOT NULL DEFAULT 0,
    TurnosSobrevividosTotales INT NOT NULL DEFAULT 0,
    MaxTurnosEnBatalla INT NOT NULL DEFAULT 0
);
GO

CREATE PROCEDURE SP_OBTENER_PERSONAJE
(
    @Id INT
)
AS
BEGIN
    SELECT Id, Tipo, Vida, Mana, Ataque, Defensa
    FROM Personaje
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE SP_INSERTAR_PERSONAJE
(
    @Tipo VARCHAR(10),
    @Vida INT,
    @Mana INT,
    @Ataque INT,
    @Defensa INT
)
AS
BEGIN
    INSERT INTO Personaje (Tipo, Vida, Mana, Ataque, Defensa)
    VALUES (@Tipo, @Vida, @Mana, @Ataque, @Defensa);

    SELECT SCOPE_IDENTITY() AS NuevoId; -- Devuelve el ID creado
END;
GO

CREATE PROCEDURE SP_MODIFICAR_PERSONAJE
(
    @Id INT,
    @Tipo VARCHAR(10),
    @Vida INT,
    @Mana INT,
    @Ataque INT,
    @Defensa INT
)
AS
BEGIN
    UPDATE Personaje
    SET Tipo = @Tipo,
        Vida = @Vida,
        Mana = @Mana,
        Ataque = @Ataque,
        Defensa = @Defensa
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE SP_ELIMINAR_PERSONAJE
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Personaje
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE SP_Stats_Crear
    @IdPersonaje INT
AS
BEGIN
    INSERT INTO StatsPersonaje (IdPersonaje)
    VALUES (@IdPersonaje)
END
GO

CREATE PROCEDURE SP_Stats_SumarCampo
    @IdPersonaje INT,
    @Campo NVARCHAR(50),
    @Valor INT
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX)

    SET @SQL = 'UPDATE StatsPersonaje SET ' + QUOTENAME(@Campo) +
               ' = ' + QUOTENAME(@Campo) + ' + @Valor WHERE IdPersonaje = @IdPersonaje'

    EXEC sp_executesql @SQL,
        N'@IdPersonaje INT, @Valor INT',
        @IdPersonaje, @Valor
END
GO

CREATE PROCEDURE SP_Stats_ActualizarMaxTurnos
    @IdPersonaje INT,
    @Turnos INT
AS
BEGIN
    UPDATE StatsPersonaje
    SET MaxTurnosEnBatalla = @Turnos
    WHERE IdPersonaje = @IdPersonaje AND @Turnos > MaxTurnosEnBatalla
END
GO

CREATE PROCEDURE SP_Stats_ObtenerPorId
    @IdPersonaje INT
AS
BEGIN
    SELECT *
    FROM StatsPersonaje
    WHERE IdPersonaje = @IdPersonaje
END
GO

CREATE TRIGGER TRG_Personaje_CrearStats
ON Personaje
AFTER INSERT
AS
BEGIN
    INSERT INTO StatsPersonaje (IdPersonaje)
    SELECT Id
    FROM inserted; 
END
GO

INSERT INTO Personaje (Tipo, Vida, Mana, Ataque, Defensa)
VALUES 
('Guerrero', 120, 20, 35, 25),
('Mago', 70, 100, 15, 10),
('Arquero', 90, 40, 30, 15);
GO