/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[Nome]
      ,[Documento]
      ,[Nascimento]
  FROM [Cursos].[dbo].[Alunos]

  /***truncate table [Alunos];