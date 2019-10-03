USE InfinitySO23
GO

SET IDENTITY_INSERT Department ON

INSERT INTO Department (Id, SectorId, Name )
SELECT Id,1,Name 
FROM InfinitySO.dbo.Department;

SET IDENTITY_INSERT Department OFF
GO