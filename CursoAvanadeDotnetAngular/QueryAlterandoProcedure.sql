USE [Cursos]
GO
/****** Object:  StoredProcedure [dbo].[spSalvarAlunos]    Script Date: 3/30/2023 5:17:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSalvarAlunos]
	@Id int output
	,@Nome varchar(50),
	@Documento varchar(max),
	@Nascimento date
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @Id = 0 begin
		INSERT INTO [dbo].[Alunos]
		           ([Nome]
		           ,[Documento]
		           ,[Nascimento])
		     VALUES
		           (@Nome, 
					@Documento,
					@Nascimento)

		--set @Id = (SELECT  top 1 Id  FROM [dbo].[Alunos] ORDER BY id DESC)
		-- @@ Variável da sessão
		  set @Id = @@IDENTITY

		end
		else
		begin
			UPDATE [dbo].[Alunos]
			   SET [Nome] = @Nome
			      ,[Documento] = @Documento
			      ,[Nascimento] = @Nascimento
			 WHERE Id = @Id
		end

END
