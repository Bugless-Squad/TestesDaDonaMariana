CREATE TABLE [dbo].[TBQUESTAO_ALTERNATIVA] (
    [questao_id]     INT NOT NULL,
    [alternativa_id] INT NOT NULL,
    CONSTRAINT [PK_TBQuestaoAlternativa] PRIMARY KEY CLUSTERED ([questao_id] ASC, [alternativa_id] ASC),
    CONSTRAINT [FK_TBQuestaoAlternativa_TBALTERNATIVA] FOREIGN KEY ([alternativa_id]) REFERENCES [dbo].[TBALTERNATIVA] ([id]),
    CONSTRAINT [FK_TBQuestaoAlternativa_TBQUESTAO] FOREIGN KEY ([questao_id]) REFERENCES [dbo].[TBQUESTAO] ([id])
);

