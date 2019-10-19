/*verifica duplicidade*/

select EAD, count(*)
from Student
group by EAD
having count(*) > 1



USE InfinitySO
GO

SET IDENTITY_INSERT MainBoard ON

INSERT INTO MainBoard (Id,BirthDate,Cell,CPF,Creation,Email,LastName,Name,Phone,RG)
SELECT Id,BirthDate,Cell,CPF,Creation,Email,LastName,Name,Phone,RG /*se add nova coluna colocar numero ou info que deseja*/
FROM InfinitySolutions.dbo.MainBoard; /*Copia desse banco para o banco do USE */

SET IDENTITY_INSERT MainBoard OFF
GO

USE InfinitySO
GO

SET IDENTITY_INSERT Address ON

INSERT INTO Address (Id,CEP,City,CompanyId,Complement,MainBoardId,Neighborhood,Number,State,Street)
SELECT Id,CEP,City,CompanyId,Complement,MainBoardId,Neighborhood,Number,State,Street /*se add nova coluna colocar numero ou info que deseja*/
FROM InfinitySolutions.dbo.Address; /*Copia desse banco para o banco do USE */

SET IDENTITY_INSERT Address OFF
GO

USE InfinitySO
GO

SET IDENTITY_INSERT CertificateCourse ON

INSERT INTO CertificateCourse (Id,Amount,CompanyId,FinalDate,Hour,InitialDate,NameCourse,NameCPF,NameSignature,Value)
SELECT Id,Amount,CompanyId,FinalDate,Hour,InitialDate,NameCourse,NameCPF,NameSignature,Value /*se add nova coluna colocar numero ou info que deseja*/
FROM InfinitySolutions.dbo.CertificateCourse; /*Copia desse banco para o banco do USE */

SET IDENTITY_INSERT CertificateCourse OFF
GO

USE InfinitySO
GO

SET IDENTITY_INSERT CertificateProgrammatic ON

INSERT INTO CertificateProgrammatic (Id, CertificateCourseId,Cod, ProgrammaticContent)
SELECT Id,CertificateCourseId,0,ProgrammaticContent /*se add nova coluna colocar numero ou info que deseja*/
FROM InfinitySolutions.dbo.CertificateProgrammatic; /*Copia desse banco para o banco do USE */

SET IDENTITY_INSERT CertificateProgrammatic OFF
GO

USE InfinitySO
GO

SET IDENTITY_INSERT Certificate ON

INSERT INTO Certificate (Id,Approved,CertificateCourseId,MainBoardId,Pay)
SELECT Id,Approved,CertificateCourseId,MainBoardId,Pay /*se add nova coluna colocar numero ou info que deseja*/
FROM InfinitySolutions.dbo.Certificate; /*Copia desse banco para o banco do USE */

SET IDENTITY_INSERT Certificate OFF
GO