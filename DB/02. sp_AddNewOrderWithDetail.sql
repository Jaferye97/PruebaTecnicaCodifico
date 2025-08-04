USE StoreSample;
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_AddNewOrderWithDetail]
    @EmpId INT,
	@CustId INT,
    @ShipperId INT,
    @ShipName NVARCHAR(40),
    @ShipAddress NVARCHAR(60),
    @ShipCity NVARCHAR(15),
    @OrderDate DATETIME,
    @RequiredDate DATETIME,
    @ShippedDate DATETIME,
    @Freight MONEY,
    @ShipCountry NVARCHAR(15),

    -- Datos del producto
    @ProductId INT,
    @UnitPrice MONEY,
    @Qty SMALLINT,
    @Discount NUMERIC(4,3),

    -- Output: Id generado
    @OrderId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar la orden
    INSERT INTO Sales.Orders (
        empid, custid, shipperid, shipname, shipaddress, shipcity,
        orderdate, requireddate, shippeddate, freight, shipcountry
    )
    VALUES (
        @EmpId, @CustId, @ShipperId, @ShipName, @ShipAddress, @ShipCity,
        @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry
    );

    -- Obtener el ID generado
    SET @OrderId = SCOPE_IDENTITY();

    -- Insertar el detalle de la orden
    INSERT INTO Sales.OrderDetails (
        orderid, productid, unitprice, qty, discount
    )
    VALUES (
        @OrderId, @ProductId, @UnitPrice, @Qty, @Discount
    );
END;