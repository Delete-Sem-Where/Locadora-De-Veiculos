CREATE TABLE [dbo].[TBPessoaFisica] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (70) NOT NULL,
    [Email]    VARCHAR (70) NOT NULL,
    [Telefone] VARCHAR (70) NOT NULL,
    [Endereco] VARCHAR (70) NOT NULL,
    [CPF]      VARCHAR (20) NOT NULL,
    [CNH]      VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_TBPessoaFisica] PRIMARY KEY CLUSTERED ([Id] ASC)
);

