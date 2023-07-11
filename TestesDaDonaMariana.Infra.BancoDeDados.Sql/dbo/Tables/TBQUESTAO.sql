CREATE TABLE [dbo].[TBQUESTAO] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [Enunciado]  VARCHAR (MAX) NOT NULL,
    [Materia_Id] INT           NOT NULL,
    [Resposta]   VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Questao] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Questao_TBMateria] FOREIGN KEY ([Materia_Id]) REFERENCES [dbo].[TBMATERIA] ([id])
);

