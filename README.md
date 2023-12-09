

# MyFinance Web - .Net 

Projeto de trabalho da disciplina Práticas de Implementação e Evolução de Software da Especialização em Engenharia de Software da PUC-MG.

## Criando Banco de dados 
Para este projeto, usamos docker para o servidor de banco de dados, segue abaixo as instruções de como criar e configurar.

1. Em primeito lugar, faça o download da imagem do Azure SQL:

    docker pull mcr.microsoft.com/azure-sql-edge

  2. Depois, crie um container, com o comando abaixo:

    docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge

> **Nota:** Esse passo é importante, pois com esse comando, o container é
> criado, aceitando a política de uso `ACCEPT_EULA=1`

3. Com o container rodando, conecte com o banco de dados:

> Nesse exemplo estamos usando o "Microsoft SQL Server Management Studio", mas pode ser usado outro software, como o Azure Data Studio.
 

![exemplo conexão](/docs/img/exemplo-conexao.png)

Conecte com o server name 127.0.0.1 (localhost), em autenticação, use Autenticação SQL Server.
Em login, use o usuário `sa`, que foi definido no passo 2.
A senha é a mesma definida no passo 2 também: `MyPass@word`

4. Crie a estrutura de banco de dados.

Após conectar, abra o arquivo  **`bd.sql`**, que é a query para criar os bancos de dados necessários e já inserir os dados de exemplo:

```sql
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
```
Confira se os dados estão corretos na `connectionString` em `Infrastructure/MyFinanceDbContext.cs`:

```c#
protected  override  void  OnConfiguring(DbContextOptionsBuilder  optionsBuilder)

{

var  connectionString  =  @"Server=LOCALHOST,1433\\Catalog=myfinanceweb;Database=myfinanceweb;User=sa;Password=MyPass@word;TrustServerCertificate=True;"; ;

optionsBuilder.UseSqlServer(connectionString);

}
```
5. Rode o projeto

Agora abra o terminal, confira se está na mesma pasta do arquivo `Program.cs` e execute o comando **`dotnet run`** ou `dotnet watch` para que o projeto seja 'buildado'. 
Após o termino do build, abra o browser no endereço: `http://localhost:5261/`.

6. Ovweview:

No menu, clique em 'Plano Conta' e aparecerá a lista de itens já criado inicialmente (essa lista foi inserida no passo 4).

Nessa página você pode criar, editar e excluir itens de 'Plano Conta'.

Em 'Transações' é possível cadastrar Receitas ou despesas, identificadas com o relacionamento de 'Plano Conta' associado

![exemplo conexão](/docs/img/overview.png)