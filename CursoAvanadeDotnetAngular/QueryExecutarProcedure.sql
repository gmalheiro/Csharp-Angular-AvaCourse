GO

DECLARE @RC int
DECLARE @Id int
DECLARE @Nome varchar(50)
DECLARE @Documento varchar(max)
DECLARE @Nascimento date

set @Id = 0
set @Nome = 'Isagi Yoichi'
set @Documento = '777'
set @Nascimento = '2000-01-01'

/****** IMPORTANTE A DATA ESTAR NO FORMATO AMERICANDO QUANDO ******/

EXECUTE @RC = [dbo].spSalvarAlunos
     @Id Output
	,@Nome
	,@Documento
	,@Nascimento


select @Id as IdModificadoOuCriado
