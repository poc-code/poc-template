CREATE TABLE [Acesso] (
  [Id] int NOT NULL IDENTITY(1, 1),
  [Username] varchar(50) NOT NULL,
  [Password] varchar(50) NOT NULL,
  [UsuarioId] int NOT NULL,
  [PerfilId] int NOT NULL,
  [Ativo] bit NOT NULL,
  [Hit] int,
  [UltimoAcesso] datetime NOT NULL,
  [CriadoEm] datetime NOT NULL,
  [ModificadoEm] datetime,
  PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Cliente] (
  [Id] int NOT NULL IDENTITY(1, 1),
  [Nome] varchar(150) NOT NULL,
  [EnderecoId] int NOT NULL,
  [UsuarioId] int NOT NULL,
  [Ativo] bit NOT NULL,
  [CriadoEm] datetime NOT NULL,
  [ModificadoEm] datetime,
  PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Endereco] (
  [Id] int NOT NULL IDENTITY(1, 1),
  [CEP] varchar(8) NOT NULL,
  [Logradouro] varchar(200),
  [Complemento] varchar(200),
  [Bairro] varchar(200),
  [Localidade] varchar(200),
  [UF] varchar(2),
  [UsuarioId] int NOT NULL,
  [Ativo] bit NOT NULL,
  [CriadoEm] datetime NOT NULL,
  [ModificadoEm] datetime,
  PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Perfil] (
  [Id] int NOT NULL IDENTITY(1, 1),
  [Nome] varchar(250) NOT NULL,
  [Ativo] bit NOT NULL,
  [CriadoEm] datetime NOT NULL,
  [ModificadoEm] datetime,
  PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Usuario] (
  [Id] int NOT NULL IDENTITY(1, 1),
  [Nome] varchar(250) NOT NULL,
  [Email] varchar(150) NOT NULL,
  [PessoaId] int NOT NULL,
  [Ativo] bit NOT NULL,
  [CriadoEm] datetime NOT NULL,
  [ModificadoEm] datetime,
  PRIMARY KEY ([Id])
)
GO

ALTER TABLE [Acesso] ADD FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id])
GO

ALTER TABLE [Endereco] ADD FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id])
GO

ALTER TABLE [Acesso] ADD FOREIGN KEY ([PerfilId]) REFERENCES [Perfil] ([Id])
GO

ALTER TABLE [Cliente] ADD FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id])
GO

