CREATE TABLE [dbo].[TBQUESTAO] (
    [id]                    INT           IDENTITY (1, 1) NOT NULL,
    [disciplina_id]         INT           NOT NULL,
    [materia_id]            INT           NOT NULL,
    [alternativaCorreta_Id] VARCHAR (50)  NOT NULL,
    [enunciado]             VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_TBQuestao] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TBQuestao_TBDisciplina] FOREIGN KEY ([disciplina_id]) REFERENCES [dbo].[TBDISCIPLINA] ([id]),
    CONSTRAINT [FK_TBQuestao_TBMateria] FOREIGN KEY ([materia_id]) REFERENCES [dbo].[TBMATERIA] ([id])
);









