CREATE TABLE [dbo].[Registory]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY, 
    [CreationDate] DATETIME NOT NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [ServiceName] NVARCHAR(50) NOT NULL,
    [GlobalAddress] NVARCHAR(MAX) NOT NULL,
    [LocalAddress] NVARCHAR(MAX) NOT NULL,
    [Port] INT NOT NULL,
    [ServiceStatus] NVARCHAR(50) NOT NULL
)