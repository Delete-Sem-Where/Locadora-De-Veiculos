CREATE TABLE [dbo].[TBCliente] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (70)  NOT NULL,
    [Documento]    VARCHAR (30)  NOT NULL,
    [Email]        VARCHAR (70)  NOT NULL,
    [Telefone]     VARCHAR (30)  NOT NULL,
    [Endereco]     VARCHAR (100) NOT NULL,
    [Tipo_Cliente] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);