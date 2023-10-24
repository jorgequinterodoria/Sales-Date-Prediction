use StoreSample;
GO

-- Definir los valores de los parámetros para la nueva orden
DECLARE @EmployeeId INT = 1; -- Reemplaza con el ID del empleado
DECLARE @ShipperId INT = 1; -- Reemplaza con el ID del transportista
DECLARE @ShipName NVARCHAR(40) = 'Nombre del destinatario';
DECLARE @ShipAddress NVARCHAR(60) = 'Dirección de envío';
DECLARE @ShipCity NVARCHAR(15) = 'Ciudad de envío';
DECLARE @OrderDate DATETIME = GETDATE(); -- Fecha actual
DECLARE @RequiredDate DATETIME = DATEADD(DAY, 7, GETDATE()); -- Fecha requerida (7 días después)
DECLARE @ShippedDate DATETIME = NULL; -- Dejarlo en NULL inicialmente
DECLARE @Freight MONEY = 10.00; -- Reemplaza con el valor del flete
DECLARE @ShipCountry NVARCHAR(15) = 'País de envío';

-- Insertar la nueva orden en la tabla Orders
INSERT INTO Sales.Orders (Empid, Shipperid, Shipname, Shipaddress, Shipcity, Orderdate, Requireddate, Shippeddate, Freight, Shipcountry)
VALUES (@EmployeeId, @ShipperId, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry);

-- Obtener el ID de la nueva orden recién creada
DECLARE @NewOrderId INT;
SET @NewOrderId = SCOPE_IDENTITY();


CREATE PROCEDURE InsertOrder
    @EmployeeId INT,
    @ShipperId INT,
    @ShipName NVARCHAR(40),
    @ShipAddress NVARCHAR(60),
    @ShipCity NVARCHAR(15),
    @OrderDate DATETIME,
    @RequiredDate DATETIME,
    @Freight MONEY,
    @ShipCountry NVARCHAR(15),
    @ProductId INT,
    @UnitPrice MONEY,
    @Qty INT,
    @Discount DECIMAL(5, 2)
AS
BEGIN
    -- Insertar la nueva orden en la tabla Orders
    INSERT INTO Sales.Orders (Empid, Shipperid, Shipname, Shipaddress, Shipcity, Orderdate, Requireddate, Freight, Shipcountry)
    VALUES (@EmployeeId, @ShipperId, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @Freight, @ShipCountry);

    -- Obtener el ID de la nueva orden recién creada
    DECLARE @NewOrderId INT;
    SET @NewOrderId = SCOPE_IDENTITY();

    -- Insertar el producto en la tabla OrderDetails
    INSERT INTO Sales.OrderDetails (Orderid, Productid, Unitprice, Qty, Discount)
    VALUES (@NewOrderId, @ProductId, @UnitPrice, @Qty, @Discount);
END