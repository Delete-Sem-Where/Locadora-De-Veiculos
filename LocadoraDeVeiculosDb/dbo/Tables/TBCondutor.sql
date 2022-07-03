CREATE TABLE [dbo].[TBCondutor] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (70) NOT NULL,
    [Email]       VARCHAR (70) NOT NULL,
    [Telefone]    VARCHAR (20) NOT NULL,
    [Endereco]    VARCHAR (70) NOT NULL,
    [CPF]         VARCHAR (20) NOT NULL,
    [CNH]         VARCHAR (20) NOT NULL,
    [ValidadeCNH] DATE         NOT NULL,
    [Cliente_Id]  INT          NOT NULL,
    CONSTRAINT [PK_TBCondutor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCondutor_TBCliente] FOREIGN KEY ([Cliente_Id]) REFERENCES [dbo].[TBCliente] ([Id])
);