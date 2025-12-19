CREATE DATABASE FINAL_STRATEGY_DB;
GO

USE FINAL_STRATEGY_DB;
GO

CREATE TABLE Cliente
(
    Id INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,

    IngresosMensuales DECIMAL(18,2) NOT NULL,
    Edad INT NOT NULL,
    ScoreHistorial INT NOT NULL,      -- 0 a 100
    ValorGarantias DECIMAL(18,2) NOT NULL,

    Activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE EstrategiaRiesgo
(
    Id INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    TipoEstrategia INT NOT NULL, -- enum TipoEstrategiaRiesgo
    Activa BIT NOT NULL DEFAULT 1,
    Observaciones NVARCHAR(200)
);
GO

CREATE TABLE EvaluacionCrediticia
(
    Id INT IDENTITY PRIMARY KEY,
    ClienteId INT NOT NULL,
    EstrategiaRiesgoId INT NOT NULL,

    Score INT NOT NULL,
    NivelRiesgo INT NOT NULL, -- enum NivelRiesgo
    Aprobado BIT NOT NULL,

    Observaciones NVARCHAR(250),
    FechaEvaluacion DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Evaluacion_Cliente
        FOREIGN KEY (ClienteId) REFERENCES Cliente(Id),

    CONSTRAINT FK_Evaluacion_Estrategia
        FOREIGN KEY (EstrategiaRiesgoId) REFERENCES EstrategiaRiesgo(Id)
);
GO

CREATE PROCEDURE SP_Cliente_ObtenerTodos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nombre,
        IngresosMensuales,
        Edad,
        ScoreHistorial,
        ValorGarantias,
        Activo
    FROM Cliente
    WHERE Activo = 1;
END;
GO

CREATE PROCEDURE SP_Cliente_ObtenerPorId
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nombre,
        IngresosMensuales,
        Edad,
        ScoreHistorial,
        ValorGarantias,
        Activo
    FROM Cliente
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE SP_Cliente_Insertar
    @Nombre NVARCHAR(100),
    @IngresosMensuales DECIMAL(18,2),
    @Edad INT,
    @ScoreHistorial INT,
    @ValorGarantias DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Cliente
    (
        Nombre,
        IngresosMensuales,
        Edad,
        ScoreHistorial,
        ValorGarantias,
        Activo
    )
    VALUES
    (
        @Nombre,
        @IngresosMensuales,
        @Edad,
        @ScoreHistorial,
        @ValorGarantias,
        1
    );
END;
GO

CREATE PROCEDURE SP_Cliente_Modificar
    @Id INT,
    @Nombre NVARCHAR(100),
    @IngresosMensuales DECIMAL(18,2),
    @Edad INT,
    @ScoreHistorial INT,
    @ValorGarantias DECIMAL(18,2)
AS
BEGIN
    UPDATE Cliente
    SET
        Nombre = @Nombre,
        IngresosMensuales = @IngresosMensuales,
        Edad = @Edad,
        ScoreHistorial = @ScoreHistorial,
        ValorGarantias = @ValorGarantias
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE SP_Cliente_Eliminar
    @Id INT
AS
BEGIN
    UPDATE Cliente
    SET Activo = 0
    WHERE Id = @Id;
END;
GO


CREATE PROCEDURE SP_EstrategiaRiesgo_ObtenerActivaPorTipo
    @TipoEstrategia INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nombre,
        TipoEstrategia,
        Activa,
        Observaciones
    FROM EstrategiaRiesgo
    WHERE TipoEstrategia = @TipoEstrategia
      AND Activa = 1;
END;
GO

CREATE PROCEDURE SP_EstrategiaRiesgo_ObtenerTodas
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nombre,
        TipoEstrategia,
        Activa,
        Observaciones
    FROM EstrategiaRiesgo
    WHERE Activa = 1;
END;
GO


CREATE PROCEDURE SP_EvaluacionCrediticia_Insertar
    @ClienteId INT,
    @EstrategiaRiesgoId INT,
    @Score INT,
    @NivelRiesgo INT,
    @Aprobado BIT,
    @Observaciones NVARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO EvaluacionCrediticia
    (
        ClienteId,
        EstrategiaRiesgoId,
        Score,
        NivelRiesgo,
        Aprobado,
        Observaciones,
        FechaEvaluacion
    )
    VALUES
    (
        @ClienteId,
        @EstrategiaRiesgoId,
        @Score,
        @NivelRiesgo,
        @Aprobado,
        @Observaciones,
        GETDATE()
    );
END;
GO

CREATE PROCEDURE SP_EvaluacionCrediticia_ObtenerPorCliente
    @ClienteId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ec.Id,
        er.Nombre AS Estrategia,
        ec.Score,
        ec.NivelRiesgo,
        ec.Aprobado,
        ec.Observaciones,
        ec.FechaEvaluacion
    FROM EvaluacionCrediticia ec
    INNER JOIN EstrategiaRiesgo er
        ON er.Id = ec.EstrategiaRiesgoId
    WHERE ec.ClienteId = @ClienteId
    ORDER BY ec.FechaEvaluacion DESC;
END;
GO

INSERT INTO EstrategiaRiesgo (Nombre, TipoEstrategia, Activa, Observaciones)
VALUES
('Riesgo Conservador', 0, 1, 
    '• Prioriza un historial crediticio alto
    • Otorga alta importancia a las garantías
    • Minimiza el riesgo de impago'),

('Riesgo Moderado', 1, 1, 
    '• Balancea ingresos y historial
    • Considera garantías como respaldo
    • Riesgo controlado'),

('Riesgo Agresivo', 2, 1, 
    '• Prioriza ingresos actuales
    • Reduce el peso del historial crediticio
    • Asume mayor riesgo'),

('Riesgo Social', 3, 1, 
    '• Prioriza edad productiva e ingresos básicos
    • Reduce exigencia de garantías
    • Enfoque inclusivo'),

('Riesgo Prudente', 4, 1, 
    '• Evalúa todos los factores
    • Penaliza debilidades críticas del perfil
    • Aprobación solo con perfil sólido');
GO

INSERT INTO Cliente
(
    Nombre,
    IngresosMensuales,
    Edad,
    ScoreHistorial,
    ValorGarantias,
    Activo
)
VALUES
('Juan Pérez',   180000, 22, 45,  50000, 1),   -- joven, bajo historial
('María Gómez',  420000, 35, 80, 300000, 1),  -- perfil ideal
('Carlos López', 600000, 48, 60, 800000, 1),  -- buen ingreso y garantías
('Ana Torres',   250000, 28, 30,  20000, 1),  -- riesgo alto
('Luis Romero',  500000, 55, 90, 1000000, 1); -- perfil premium
GO
