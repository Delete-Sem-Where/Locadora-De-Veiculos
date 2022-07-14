CREATE TABLE [dbo].[TBTaxa] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Descricao]   VARCHAR (150)    NOT NULL,
    [Valor]       FLOAT (53)       NOT NULL,
    [TipoCalculo] INT              NOT NULL,
    CONSTRAINT [PK_TBTaxa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

