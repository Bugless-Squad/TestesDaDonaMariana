CREATE TABLE [dbo].[TBALTERNATIVA] (
    [id]                 INT          IDENTITY (1, 1) NOT NULL,
    [idLetra]            VARCHAR (10) NOT NULL,
    [texto]              VARCHAR (50) NOT NULL,
    [alternativaCorreta] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TBAlternativa] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TbAlternativa_Questao] FOREIGN KEY ([id]) REFERENCES [dbo].[TBQUESTAO] ([id])
);





