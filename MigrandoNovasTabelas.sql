USE InfinitySO
GO

SET IDENTITY_INSERT CertificateProgrammatic ON

INSERT INTO CertificateProgrammatic (Id, CertificateCourseId, ProgrammaticContent)
SELECT Id,1,ProgrammaticContent
FROM InfinitySolutions.dbo.CertificateProgrammatic; /*Copia desse banco para o banco do USE*/

SET IDENTITY_INSERT CertificateProgrammatic OFF
GO


/*verifica duplicidade*/

select EAD, count(*)
from Student
group by EAD
having count(*) > 1