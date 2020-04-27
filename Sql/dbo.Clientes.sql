CREATE TABLE [dbo].[Clientes] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     NVARCHAR (50) NULL,
    [Endereco] NVARCHAR (50) NULL,
    [Bairro]   NVARCHAR (50) NULL,
    [CEP]      NVARCHAR (10) NULL,
    [Cidade]   NVARCHAR (50) NULL,
    [Estado]   NVARCHAR (50) NULL,
    [Email]    NVARCHAR(50)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

