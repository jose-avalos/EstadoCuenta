Create database EstadoCuentaDB


USE EstadoCuentaDB;
GO


CREATE TABLE Clientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    NoTarjetaCredito NVARCHAR(20) UNIQUE NOT NULL
);


CREATE TABLE EstadosCuenta (
    EstadoCuentaID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    LimiteCredito DECIMAL(18,2) NOT NULL, 
    Saldo DECIMAL(18,2) NOT NULL,
    InteresBonificable DECIMAL(18,2) NOT NULL,
    PorcentajeInteresBonificable DECIMAL(5,2) NOT NULL,
    PorcentajeConfigurableSaldoMin DECIMAL(5,2) NOT NULL,
    CuotaMinima DECIMAL(18,2) NOT NULL,
    MontoTotalPagar DECIMAL(18,2) NOT NULL
);

CREATE TABLE Movimientos (
    MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    Fecha DATE NOT NULL,
    Descripcion NVARCHAR(255) NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    TipoMovimiento NVARCHAR(10) 
);


CREATE PROCEDURE MostrarEstadoCuenta
    @ClienteID INT
AS
BEGIN
    SELECT 
        cl.Nombre, 
        cl.NoTarjetaCredito, 
        ec.Saldo, 
        ec.LimiteCredito,
        ec.SaldoDisponible, 
        ec.InteresBonificable, 
        ec.CuotaMinima, 
        ec.MontoTotalPagar
    FROM EstadosCuenta ec
    INNER JOIN Clientes cl ON ec.ClienteID = cl.ClienteID
    WHERE cl.ClienteID = @ClienteID;
END;



CREATE PROCEDURE CrearCompra
    @ClienteID INT,
    @Fecha DATE,
    @Descripcion NVARCHAR(255),
    @Monto DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Movimientos (ClienteID, Fecha, Descripcion, Monto, TipoMovimiento)
    VALUES (@ClienteID, @Fecha, @Descripcion, @Monto, 'COMPRA');

    UPDATE EstadosCuenta
    SET Saldo = Saldo + @Monto
    WHERE ClienteID = @ClienteID;
END;




CREATE PROCEDURE AgregarPago
    @ClienteID INT,
    @Fecha DATE,
    @Monto DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Movimientos (ClienteID, Fecha, Descripcion, Monto, TipoMovimiento)
    VALUES (@ClienteID, @Fecha, 'Pago realizado', @Monto, 'PAGO');

    UPDATE EstadosCuenta
    SET Saldo = Saldo - @Monto
    WHERE ClienteID = @ClienteID;
END;


INSERT INTO Clientes (Nombre, NoTarjetaCredito) VALUES ('Jose Herrera', '5566887890123456');

INSERT INTO EstadosCuenta (ClienteID, LimiteCredito, Saldo, InteresBonificable, PorcentajeInteresBonificable, PorcentajeConfigurableSaldoMin, CuotaMinima, MontoTotalPagar)
VALUES (1, 1000, 0, 0, 5, 25, 0, 0);



