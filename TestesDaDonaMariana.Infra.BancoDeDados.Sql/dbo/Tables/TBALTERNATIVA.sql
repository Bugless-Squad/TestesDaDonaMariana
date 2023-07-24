CREATE TABLE [dbo].[TBALTERNATIVA] (
    [id]                 INT          IDENTITY (1, 1) NOT NULL,
    [idLetra]            CHAR NOT NULL,
    [texto]              VARCHAR (50) NOT NULL,
    [alternativaCorreta] VARCHAR (50) NOT NULL,
    [questao_id]         INT          NOT NULL,
    CONSTRAINT [PK_TBAlternativa] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TBAlternativa_TBQuestao] FOREIGN KEY ([questao_id]) REFERENCES [dbo].[TBQUESTAO] ([id])
);







