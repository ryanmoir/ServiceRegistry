CREATE TABLE [dbo].[HeartBeat]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY, 
    [CreationDate] DATETIME NOT NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [ServiceId] BIGINT NOT NULL
)