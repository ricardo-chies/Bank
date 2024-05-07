-- Tabela de Tipo de Usuarios
CREATE TABLE Tipo_Usuario (
    IdTipoUsuario INT PRIMARY KEY AUTO_INCREMENT,
    NomeTipoUsuario VARCHAR(30) NOT NULL
);

-- Tabela de Usuarios
CREATE TABLE Usuario (
	CPF VARCHAR(11) PRIMARY KEY,
    NomeCompleto VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Senha VARCHAR(100) NOT NULL,
    IdTipoUsuario INT NOT NULL,
    FOREIGN KEY (IdTipoUsuario) REFERENCES Tipo_Usuario(IdTipoUsuario)
);

-- Tabela de Contas Bancárias
CREATE TABLE Conta_Bancaria (
    IdConta INT PRIMARY KEY AUTO_INCREMENT,
    CPF VARCHAR(11) NOT NULL,
    Saldo DECIMAL(15, 2) DEFAULT 0,
    Status VARCHAR(1) DEFAULT 'A',
    FOREIGN KEY (CPF) REFERENCES Usuario(CPF)
);

-- Tabela de Movimentações Financeiras
CREATE TABLE Movimentacao_Financeira (
    IdMovimentacao INT PRIMARY KEY AUTO_INCREMENT,
    IdContaOrigem INT NOT NULL,
    IdContaDestino INT NOT NULL,
    Valor DECIMAL(15, 2) NOT NULL,
    DataMovimentacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Descricao VARCHAR(255),
    FOREIGN KEY (IdContaOrigem) REFERENCES Conta_Bancaria(IdConta),
    FOREIGN KEY (IdContaDestino) REFERENCES Conta_Bancaria(IdConta)
);