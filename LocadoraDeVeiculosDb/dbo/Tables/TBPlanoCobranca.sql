CREATE TABLE [dbo].[TBPlanoCobranca] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [GrupoVeiculos_Id]        UNIQUEIDENTIFIER NOT NULL,
    [ModalidadePlanoCobranca] INT              NOT NULL,
    [ValorDiaria]             DECIMAL (8, 2)   NOT NULL,
    [LimiteKm]                DECIMAL (8, 2)   NOT NULL,
    [ValorKm]                 DECIMAL (8, 2)   NOT NULL,
    CONSTRAINT [PK_TBPlanoCobranca] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBGrupoVeiculos_TBPlanoCobranca] FOREIGN KEY ([GrupoVeiculos_Id]) REFERENCES [dbo].[TBGrupoVeiculos] ([Id])
);

