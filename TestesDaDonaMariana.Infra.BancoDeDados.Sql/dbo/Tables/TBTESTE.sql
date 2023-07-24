CREATE TABLE [dbo].[TBTESTE] (
    [id]                 INT           IDENTITY (1, 1) NOT NULL,
    [titulo]             VARCHAR (100) NOT NULL,
    [quantidadeQuestoes] INT           NOT NULL,
    [dataCriacao]        DATETIME      NOT NULL,
    [disciplina_id]      INT           NOT NULL,
    [materia_id] INT NULL, 
    CONSTRAINT [PK_TBTeste] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TBTeste_TBDisciplina] FOREIGN KEY ([disciplina_id]) REFERENCES [dbo].[TBDISCIPLINA] ([id]),
    CONSTRAINT [FK_TBTeste_TBMateria] FOREIGN KEY ([materia_id]) REFERENCES [dbo].[TBMATERIA] ([id])
);





