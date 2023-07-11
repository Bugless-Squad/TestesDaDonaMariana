CREATE TABLE [dbo].[TBMATERIA] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [nome]          VARCHAR (100) NOT NULL,
    [serie]         VARCHAR (100) NOT NULL,
    [disciplina_id] INT           NOT NULL,
    CONSTRAINT [PK_TBMateria] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TBMateria_TBDisciplina] FOREIGN KEY ([disciplina_id]) REFERENCES [dbo].[TBDISCIPLINA] ([id])
);

