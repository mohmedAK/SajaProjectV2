USE [EmployeePro]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllEmployee]    Script Date: 5/30/2021 9:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[SP_GetAllEmployee]

as

begin

SELECT [EmpId]
      ,[FName]
      ,[LName]
      ,[Address]
      ,[Image]
      ,[FinalTotal]
  FROM [dbo].[Employee]
end

