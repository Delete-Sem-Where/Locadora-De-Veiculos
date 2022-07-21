﻿CREATE TABLE [dbo].[TBVeiculos]
(
	[Id]                    UNIQUEIDENTIFIER NOT NULL,
    [Modelo]                VARCHAR(65)      NOT NULL, 
    [Marca]                 VARCHAR(20)      NOT NULL, 
    [Ano]                   VARCHAR(4)       NOT NULL, 
    [Cor]                   VARCHAR(40)      NOT NULL, 
    [Placa]                 VARCHAR(7)       NOT NULL, 
    [Quilometro_Percorrido] VARCHAR(8)       NOT NULL, 
    [Capacidade_Tanque]     VARCHAR(8)       NOT NULL, 
    [GrupoVeiculos_Id]      UNIQUEIDENTIFIER NOT NULL, 
    [Foto]                  VARBINARY(MAX)   NULL,
    [Tipo_Combustivel]      VARCHAR(30) NOT NULL, 
    CONSTRAINT [PK_TBVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVeiculo_TBGrupoVeiculos] 
    FOREIGN KEY ([GrupoVeiculos_Id]) 
    REFERENCES [dbo].[TBGrupoVeiculos] ([Id])

)
