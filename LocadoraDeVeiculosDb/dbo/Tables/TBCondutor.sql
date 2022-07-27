CREATE TABLE [dbo].[TBCondutor] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Nome]        VARCHAR (70)     NOT NULL,
    [Email]       VARCHAR (70)     NOT NULL,
    [Telefone]    VARCHAR (20)     NOT NULL,
    [Endereco]    VARCHAR (70)     NOT NULL,
    [CPF]         VARCHAR (20)     NOT NULL,
    [CNH]         VARCHAR (20)     NOT NULL,
    [ValidadeCNH] DATE             NOT NULL,
    [Cliente_Id]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TBCondutor_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCliente_TBCondutor] FOREIGN KEY ([Cliente_Id]) REFERENCES [dbo].[TBCliente] ([Id])
);

