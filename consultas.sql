use StoreSample;
GO
-- Crear una consulta que retorne por cliente la fecha de cuando ocurrirá la próxima orden, 
-- esta fecha se calculara sumando el promedio de días entre las órdenes existentes del cliente a la fecha de la última orden.
SELECT
    C.companyname AS [Customer Name],
    MAX(O.orderdate) AS [Last Order Date],
    DATEADD(DAY, AVG(DATEDIFF(DAY, P.orderdate, O.orderdate)), MAX(O.orderdate)) AS [Next Predicted Order]
FROM
    Sales.Customers C
INNER JOIN
    Sales.Orders O ON C.custid = O.custid
LEFT JOIN
    Sales.Orders P ON C.custid = P.custid AND P.orderdate < O.orderdate
GROUP BY
    C.companyname;

-- Crear una consulta que retorne las ordenes de un cliente

SELECT
    orderid,
    requireddate,
    shippeddate,
    shipname,
    shipaddress,
    shipcity
FROM
    Sales.Orders
WHERE
    custid = 11; -- Reemplaza @CustomerId con el ID del cliente deseado


-- Crear una consulta que retorne todos los empleados
SELECT
    empid,
    firstname + ' ' + lastname AS FullName
FROM
    HR.Employees;

-- Crear una consulta que retorne todos los transportistas
SELECT 
    Shipperid,
    Companyname
FROM
    Sales.Shippers

-- Crear una consulta que retorne todos los productos
SELECT
    Productid,
    Productname
FROM
    Production.productos

