CREATE TABLE [dbo].[TBTaxa] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Descricao] VARCHAR (150) NOT NULL,
    [Valor]     FLOAT (53)    NOT NULL,
    [TipoCalculo]		  INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

