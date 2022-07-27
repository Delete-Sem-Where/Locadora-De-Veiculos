CREATE TABLE [dbo].[TBCliente] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         VARCHAR (70)     NOT NULL,
    [Documento]    VARCHAR (30)     NOT NULL,
    [Email]        VARCHAR (70)     NOT NULL,
    [Telefone]     VARCHAR (30)     NOT NULL,
    [Endereco]     VARCHAR (100)    NOT NULL,
    [Tipo_Cliente] INT              NOT NULL,
    CONSTRAINT [PK_TBCliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

