CREATE TABLE [dbo].[TBTESTE] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]             VARCHAR (500) NOT NULL,
    [Disciplina_Id]      INT           NOT NULL,
    [Materia_Id]         INT           NOT NULL,
    [QuantidadeQuestoes] INT           NOT NULL,
    CONSTRAINT [PK_TBTeste] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBTeste_TBDisciplina] FOREIGN KEY ([Disciplina_Id]) REFERENCES [dbo].[TBDISCIPLINA] ([id]),
    CONSTRAINT [FK_TBTeste_TBMateria] FOREIGN KEY ([Materia_Id]) REFERENCES [dbo].[TBMATERIA] ([id])
);

