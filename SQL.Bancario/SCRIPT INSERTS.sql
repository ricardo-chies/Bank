-- Registros para a tabela Tipo_Usuario
INSERT INTO Tipo_Usuario (NomeTipoUsuario) VALUES ('Gerente'), ('Cliente');

-- Registros para a tabela Usuario
INSERT INTO Usuario (CPF, NomeCompleto, Email, Senha, IdTipoUsuario) 
VALUES 
('12345678901', 'João Silva', 'joao@example.com', 'senha123', 1),
('23456789012', 'Maria Santos', 'maria@example.com', 'senha456', 2),
('34567890123', 'Carlos Oliveira', 'carlos@example.com', 'senha789', 2),
('45678901234', 'Ana Souza', 'ana@example.com', 'senha101', 2),
('56789012345', 'Pedro Ferreira', 'pedro@example.com', 'senha112', 2),
('67890123456', 'Julia Martins', 'julia@example.com', 'senha113', 2),
('78901234567', 'Fernanda Lima', 'fernanda@example.com', 'senha114', 2),
('89012345678', 'Rafaela Castro', 'rafaela@example.com', 'senha115', 2),
('90123456789', 'Marcos Costa', 'marcos@example.com', 'senha116', 2),
('01234567890', 'Amanda Pereira', 'amanda@example.com', 'senha117', 2);

-- Registros para a tabela Conta_Bancaria
INSERT INTO Conta_Bancaria (CPF, Saldo, Status) 
VALUES 
('12345678901', 10000.00, 'A'),
('23456789012', 5000.00, 'A'),
('34567890123', 2000.00, 'A'),
('45678901234', 3000.00, 'A'),
('56789012345', 4000.00, 'A'),
('67890123456', 6000.00, 'A'),
('78901234567', 7000.00, 'A'),
('89012345678', 8000.00, 'A'),
('90123456789', 9000.00, 'A'),
('01234567890', 1000.00, 'A');

-- Registros para a tabela Movimentacao_Financeira
INSERT INTO Movimentacao_Financeira (IdContaOrigem, IdContaDestino, Valor, Descricao) 
VALUES 
(1, 2, 500.00, 'Transferência de João para Maria'),
(1, 3, 200.00, 'Transferência de João para Carlos'),
(2, 4, 300.00, 'Transferência de Maria para Ana'),
(2, 5, 400.00, 'Transferência de Maria para Pedro'),
(3, 6, 600.00, 'Transferência de Carlos para Julia'),
(4, 7, 700.00, 'Transferência de Ana para Fernanda'),
(5, 8, 800.00, 'Transferência de Pedro para Rafaela'),
(6, 9, 900.00, 'Transferência de Julia para Marcos'),
(7, 10, 1000.00, 'Transferência de Fernanda para Amanda'),
(8, 1, 1100.00, 'Transferência de Rafaela para João');