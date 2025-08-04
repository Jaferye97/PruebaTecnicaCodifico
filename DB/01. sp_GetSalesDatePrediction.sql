USE StoreSample;
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetSalesDatePrediction] 
	@FilterCompanyName NVARCHAR(100) = NULL
AS

WITH CustomerOrderGaps AS (
    SELECT 
        o.custid,
        o.orderdate,
        LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate) AS PrevOrderDate
    FROM Sales.Orders o
	JOIN Sales.Customers c ON o.custid = c.custid
    WHERE o.custid IS NOT NULL
		AND (@FilterCompanyName IS NULL OR @FilterCompanyName = '' OR c.companyname LIKE '%' + @FilterCompanyName + '%')
),
AverageGaps AS (
    SELECT 
        custid,
        AVG(DATEDIFF(DAY, PrevOrderDate, orderdate)) AS AvgGap
    FROM CustomerOrderGaps
    WHERE PrevOrderDate IS NOT NULL
    GROUP BY custid
),
LastOrders AS (
    SELECT 
        o.custid,
        MAX(orderdate) AS LastOrderDate
    FROM Sales.Orders o
	JOIN Sales.Customers c ON o.custid = c.custid
    WHERE o.custid IS NOT NULL
		AND (@FilterCompanyName IS NULL OR @FilterCompanyName = '' OR c.companyname LIKE '%' + @FilterCompanyName + '%')
    GROUP BY o.custid
)
SELECT 
	c.custid,
    c.companyname, 
    lo.LastOrderDate,
    DATEADD(DAY, ag.AvgGap, lo.LastOrderDate) AS NextPredictedOrder
FROM LastOrders lo
JOIN AverageGaps ag ON lo.custid = ag.custid
JOIN Sales.Customers c ON c.custid = lo.custid
ORDER BY c.companyname;