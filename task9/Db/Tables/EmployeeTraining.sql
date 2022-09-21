CREATE TABLE [dbo].[EmployeeTraining]
(
	[EmployeeId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_EmployeeTraining_dbo_Employee] FOREIGN KEY REFERENCES [dbo].[Employee]([Id]) ON DELETE CASCADE NOT NULL, 
    [TrainingId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_EmployeeTraining_dbo_Training] FOREIGN KEY REFERENCES [dbo].[Training]([Id]) ON DELETE CASCADE NOT NULL,
	CONSTRAINT [PK_dbo_EmployeeTrainingr] PRIMARY KEY ([EmployeeId], [TrainingId]),
);
GO

CREATE INDEX [IX_dbo_EmployeeTraining_EmployeeId] ON [dbo].[EmployeeTraining]([EmployeeId]);
GO

CREATE INDEX [IX_dbo_EmployeeTraining_TrainingId] ON [dbo].[EmployeeTraining]([TrainingId]);
GO
