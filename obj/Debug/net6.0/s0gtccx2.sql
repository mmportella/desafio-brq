IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Candidatos] (
    [IdCandidato] int NOT NULL IDENTITY,
    [Cpf] int NOT NULL,
    [Nome] nvarchar(50) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [Telefone] int NOT NULL,
    [Genero] nvarchar(1) NOT NULL,
    [Nascimento] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_Candidatos] PRIMARY KEY ([IdCandidato])
);
GO

CREATE TABLE [Skills] (
    [IdSkill] int NOT NULL IDENTITY,
    [NomeSkill] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY ([IdSkill])
);
GO

CREATE TABLE [Certificacoes] (
    [IdCertificacao] int NOT NULL IDENTITY,
    [Instituicao] nvarchar(50) NOT NULL,
    [NomeCertificacao] nvarchar(100) NOT NULL,
    [SkillId] int NOT NULL,
    CONSTRAINT [PK_Certificacoes] PRIMARY KEY ([IdCertificacao]),
    CONSTRAINT [FK_Certificacoes_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skills] ([IdSkill]) ON DELETE CASCADE
);
GO

CREATE TABLE [SkillCandidatos] (
    [IdSkillCandidato] int NOT NULL IDENTITY,
    [CandidatoId] int NOT NULL,
    [SkillId] int NOT NULL,
    CONSTRAINT [PK_SkillCandidatos] PRIMARY KEY ([IdSkillCandidato]),
    CONSTRAINT [FK_SkillCandidatos_Candidatos_CandidatoId] FOREIGN KEY ([CandidatoId]) REFERENCES [Candidatos] ([IdCandidato]) ON DELETE CASCADE,
    CONSTRAINT [FK_SkillCandidatos_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skills] ([IdSkill]) ON DELETE CASCADE
);
GO

CREATE TABLE [CertificacoesCandidatos] (
    [IdCertificacaoCandidato] int NOT NULL IDENTITY,
    [CandidatoId] int NOT NULL,
    [CertificacaoId] int NOT NULL,
    CONSTRAINT [PK_CertificacoesCandidatos] PRIMARY KEY ([IdCertificacaoCandidato]),
    CONSTRAINT [FK_CertificacoesCandidatos_Candidatos_CandidatoId] FOREIGN KEY ([CandidatoId]) REFERENCES [Candidatos] ([IdCandidato]) ON DELETE CASCADE,
    CONSTRAINT [FK_CertificacoesCandidatos_Certificacoes_CertificacaoId] FOREIGN KEY ([CertificacaoId]) REFERENCES [Certificacoes] ([IdCertificacao]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Certificacoes_SkillId] ON [Certificacoes] ([SkillId]);
GO

CREATE INDEX [IX_CertificacoesCandidatos_CandidatoId] ON [CertificacoesCandidatos] ([CandidatoId]);
GO

CREATE INDEX [IX_CertificacoesCandidatos_CertificacaoId] ON [CertificacoesCandidatos] ([CertificacaoId]);
GO

CREATE INDEX [IX_SkillCandidatos_CandidatoId] ON [SkillCandidatos] ([CandidatoId]);
GO

CREATE INDEX [IX_SkillCandidatos_SkillId] ON [SkillCandidatos] ([SkillId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220427033445_Migracao1', N'6.0.4');
GO

COMMIT;
GO

