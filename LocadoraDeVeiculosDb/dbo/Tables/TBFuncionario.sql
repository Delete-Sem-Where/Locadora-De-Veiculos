CREATE TABLE [dbo].[TBFuncionario] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Nome]           VARCHAR (70)   NOT NULL,
    [Email]          VARCHAR (70)   NOT NULL,
    [Telefone]       VARCHAR (20)   NOT NULL,
    [Endereco]       VARCHAR (70)   NOT NULL,
    [Login]          VARCHAR (50)   NOT NULL,
    [Senha]          VARCHAR (50)   NOT NULL,
    [Salario]        DECIMAL (8, 2) NOT NULL,
    [DataDeAdmissao] DATE           NOT NULL,
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

