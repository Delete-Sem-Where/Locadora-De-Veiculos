CREATE TABLE [dbo].[TBPlanoCobranca] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [GrupoVeiculos_Id]        INT            NOT NULL,
    [ModalidadePlanoCobranca] INT            NOT NULL,
    [ValorDiaria]             DECIMAL (8, 2) NOT NULL,
    [LimiteKm]                DECIMAL (8, 2) NOT NULL,
    [ValorKm]                 DECIMAL (8, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPlanoCobranca_TBGrupoVeiculos] FOREIGN KEY ([GrupoVeiculos_Id]) REFERENCES [dbo].[TBGrupoVeiculos] ([Id])
);