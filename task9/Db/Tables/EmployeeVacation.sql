CREATE TABLE [dbo].[EmployeeVacation]
(
	[EmployeeId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_EmployeeVacation_dbo_Employee] FOREIGN KEY REFERENCES [dbo].[Employee]([Id]) ON DELETE CASCADE NOT NULL, 
    [VacationId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_EmployeeVacation_dbo_Vacation] FOREIGN KEY REFERENCES [dbo].[Vacation]([Id]) ON DELETE CASCADE NOT NULL, 
	CONSTRAINT [PK_dbo_EmployeeVacation] PRIMARY KEY ([EmployeeId], [VacationId]),
);
GO

CREATE INDEX [IX_dbo_EmployeeVacation_EmployeeId] ON [dbo].[EmployeeVacation]([EmployeeId]);
GO

CREATE INDEX [IX_dbo_EmployeeVacation_VacationId] ON [dbo].[EmployeeVacation]([VacationId]);
GO
