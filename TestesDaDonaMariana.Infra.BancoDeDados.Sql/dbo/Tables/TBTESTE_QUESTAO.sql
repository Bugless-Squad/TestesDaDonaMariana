CREATE TABLE [dbo].[TBTESTE_QUESTAO] (
    [teste_id]   INT NOT NULL,
    [questao_id] INT NOT NULL,
    CONSTRAINT [FK_TBTeste_Questao_TBTeste] FOREIGN KEY ([teste_id]) REFERENCES [dbo].[TBTESTE] ([id]),
    CONSTRAINT [FK_TBTeste_Questao_TBQuestao] FOREIGN KEY ([questao_id]) REFERENCES [dbo].[TBQUESTAO] ([id])
);

