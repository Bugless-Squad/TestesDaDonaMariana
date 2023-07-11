CREATE TABLE [dbo].[TBTESTE_MATERIA] (
    [teste_id]   INT NOT NULL,
    [materia_id] INT NOT NULL,
    CONSTRAINT [PK_TBTeste_Materia] PRIMARY KEY CLUSTERED ([teste_id] ASC, [materia_id] ASC),
    CONSTRAINT [FK_TBTeste_Materia_TBMateria] FOREIGN KEY ([materia_id]) REFERENCES [dbo].[TBMATERIA] ([id]),
    CONSTRAINT [FK_TBTeste_Materia_TBTeste] FOREIGN KEY ([teste_id]) REFERENCES [dbo].[TBTESTE] ([id])
);

