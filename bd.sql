CREATE DATABASE myfinanceweb
GO
USE myfinanceweb

CREATE TABLE planoconta(
    id INT IDENTITY(1,1) NOT NULL,
    descricao VARCHAR(50) NOT NULL,
    tipo CHAR(1) NOT NULL,
    PRIMARY KEY(id)
)

CREATE TABLE transacao(
    id INT IDENTITY(1,1) NOT NULL,
    historico VARCHAR(50) NOT NULL,
    tipo CHAR(1) NOT NULL,
    valor DECIMAL(9,2) NOT NULL,
    planocontaid INT NOT NULL,
    data DATETIME NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY (planocontaid) REFERENCES planoconta(id)
)

INSERT INTO planoconta(descricao, tipo) VALUES ('Alimentação', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES ('Aluguel', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES ('Combustível', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES ('Plano de Saúde', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES ('Salário', 'R')
INSERT INTO planoconta(descricao, tipo) VALUES ('Crédito de Juros', 'R')
INSERT INTO planoconta(descricao, tipo) VALUES ('Crédito de Dividendos', 'R')