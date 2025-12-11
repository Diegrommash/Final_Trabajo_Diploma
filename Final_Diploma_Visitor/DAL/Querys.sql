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

INSERT INTO Personaje (Tipo, Vida, Mana, Ataque, Defensa)
VALUES 
('Guerrero', 120, 20, 35, 25),
('Mago', 70, 100, 15, 10),
('Arquero', 90, 40, 30, 15);
GO