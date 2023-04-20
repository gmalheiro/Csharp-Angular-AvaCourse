BEGIN TRAN InsertAluno

INSERT INTO [dbo].[Alunos]
           ([Nome]
           ,[Documento]
           ,[Nascimento])
     VALUES
           ('Joey',
           '754.462.480-31',
           '2020-01-01')
COMMIT TRAN InsertAluno
ROLLBACK TRAN InsertAluno

