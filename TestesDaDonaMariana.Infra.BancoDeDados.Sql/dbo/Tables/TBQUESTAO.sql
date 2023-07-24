CREATE TABLE [dbo].[TBQUESTAO] (
    [id]                    INT           IDENTITY (1, 1) NOT NULL,
    [materia_id]            INT           NOT NULL,
    [enunciado]             VARCHAR (MAX) NOT NULL,
    [jaUtilizada] BIT NULL, 
    CONSTRAINT [PK_TBQuestao] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TBQuestao_TBMateria] FOREIGN KEY ([materia_id]) REFERENCES [dbo].[TBMATERIA] ([id])
);









