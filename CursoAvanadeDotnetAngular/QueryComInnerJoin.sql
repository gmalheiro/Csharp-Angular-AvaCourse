
/** Quero trazer benefici�rio com agendamentos �= inner join
REGISTRO DAS DUAS TABELAS AO MESMO TEMPO
Select Beneficiario. * 
 FROM Beneficiario
 INNER JOIN Agendamento
  On Beneficiario.idBeneficiario = Agendamento.IdBeneficiario **/
  
/** Quero trazer todos os benefici�rios que n�o tem ou podem n�o ter um agendamento = right join

 Select Beneficiario.* 
 From Beneficiario.
 LEFT JOIN Agendamento
 ON Beneficiario.idBeneficiario = Agendamento.idBeneficiario

 SELECT B.* 
 FROM Beneficiario B
 INNER JOIN Agendamento A
 ON B.idBeneficiario = A.idBeneficiario


Trazer da esquerda que n�o tem na direita **/

SELECT  *
FROM Turmas
INNER JOIN Alunos 
ON Turmas.id = Alunos.idTurma

SELECT  Nome,NomeTurma,idTurma
FROM Alunos
INNER JOIN Turmas
ON Alunos.id = Turmas.id