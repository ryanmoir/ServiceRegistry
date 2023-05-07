CREATE TABLE [dbo].[HeartBeat]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY, 
    [CreationDate] DATE NOT NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [UpdateDate] DATE NULL, 
    [UpdatedBy] BIGINT NULL, 
    [DeletedDate] DATE NULL, 
    [DeletedBy] BIGINT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    [ServiceId] BIGINT NOT NULL
)