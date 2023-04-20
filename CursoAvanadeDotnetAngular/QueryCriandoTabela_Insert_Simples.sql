CREATE TABLE Turmas(
	id Int primary key identity(1,1),
	NomeTurma varchar(100) not null
);

INSERT INTO [dbo].[Turmas] VALUES ('C#')
GO
INSERT INTO [dbo].[Turmas] VALUES ('Angular')
GO

SELECT * FROM Turmas;