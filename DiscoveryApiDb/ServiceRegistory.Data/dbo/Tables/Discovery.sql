CREATE TABLE [dbo].[Discovery]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY, 
    [CreationDate] DATETIME NOT NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [UpdateDate] DATETIME NULL, 
    [UpdatedBy] BIGINT NULL, 
    [DeletedDate] DATETIME NULL, 
    [DeletedBy] BIGINT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    [ServiceName] NVARCHAR(50) NOT NULL,
    [GlobalAddress] NVARCHAR(MAX) NOT NULL,
    [LocalAddress] NVARCHAR(MAX) NOT NULL,
)
