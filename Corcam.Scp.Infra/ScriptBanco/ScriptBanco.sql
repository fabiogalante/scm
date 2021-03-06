USE [Scp]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 09/05/2017 11:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[Id] [uniqueidentifier] NOT NULL,
	[Cpf] [nchar](11) NOT NULL,
	[Nome] [nvarchar](60) NOT NULL,
	[Sobrenome] [nvarchar](60) NOT NULL,
	[Sexo] [int] NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Peso] [decimal](6, 2) NOT NULL,
	[Altura] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Paciente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ObterPacientesView]    Script Date: 09/05/2017 11:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW[dbo].[ObterPacientesView]
AS
SELECT        Id, Cpf, Nome + ' ' + Sobrenome as NomeCompleto, 

CASE WHEN Sexo = 1 THEN 'Masculino' WHEN Sexo = 2 THEN 'Feminino' END AS Sexo, DataNascimento, Peso, Altura
FROM            dbo.Paciente


GO
