

CREATE TABLE [dbo].[FinanciamentoTipo](
	[IdTipoFinanciamento] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
	[Sigla] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TipoFinanciamento] PRIMARY KEY CLUSTERED 
(
	[IdTipoFinanciamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](250) NOT NULL,
	[Uf] [varchar](2) NOT NULL,
	[Celular] [varchar](9) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Financiamento](
	[IdFinanciamento] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdTipoFinanciamento] [int] NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
	[DataVencimento] [datetime] NOT NULL,
 CONSTRAINT [PK_Financiamento] PRIMARY KEY CLUSTERED 
(
	[IdFinanciamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Financiamento]  WITH CHECK ADD  CONSTRAINT [FK_Financiamento_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO

ALTER TABLE [dbo].[Financiamento] CHECK CONSTRAINT [FK_Financiamento_Cliente]
GO

ALTER TABLE [dbo].[Financiamento]  WITH CHECK ADD  CONSTRAINT [FK_Financiamento_TipoFinanciamento] FOREIGN KEY([IdTipoFinanciamento])
REFERENCES [dbo].[FinanciamentoTipo] ([IdTipoFinanciamento])
GO

ALTER TABLE [dbo].[Financiamento] CHECK CONSTRAINT [FK_Financiamento_TipoFinanciamento]
GO




CREATE TABLE [dbo].[FinanciamentoParcela](
	[IdFinanciamentoParcela] [int] IDENTITY(1,1) NOT NULL,
	[IdFinanciamento] [int] NOT NULL,
	[Numero] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Vencimento] [datetime] NOT NULL,
	[Pagamento] [datetime] NULL,
 CONSTRAINT [PK_FinanciamentoParcela] PRIMARY KEY CLUSTERED 
(
	[IdFinanciamentoParcela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FinanciamentoParcela]  WITH CHECK ADD  CONSTRAINT [FK_FinanciamentoParcela_Financiamento] FOREIGN KEY([IdFinanciamento])
REFERENCES [dbo].[Financiamento] ([IdFinanciamento])
GO

ALTER TABLE [dbo].[FinanciamentoParcela] CHECK CONSTRAINT [FK_FinanciamentoParcela_Financiamento]
GO
