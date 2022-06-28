CREATE TABLE [dbo].[TBTaxa] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Descricao] VARCHAR (150) NULL,
    [Valor]     FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

