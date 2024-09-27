SELECT TOP (1000) sd.[Id] as ScheduleDetailID
      ,sd.[ScheduleId]
      ,sd.[SessionId]
	  ,s.ClassroomId
	  ,cl.ClassName
	  ,se.[DayOfWeek]
	  ,p.PeriodName
	  ,p.StartTime
  FROM [VEMS].[dbo].[ScheduleDetails] sd
  JOIN [VEMS].[dbo].[Schedules] s
  ON sd.[ScheduleId] = s.[Id]
  JOIN [VEMS].[dbo].Classrooms cl
  ON s.ClassroomId = cl.[Id]
  join [VEMS].[dbo].[Sessions] se 
  on sd.SessionId = se.Id  
  join [VEMS].[dbo].[Periods] p
  on se.PeriodID = p.Id
  ;

 
 -- Bước 1: Lấy tất cả các sessionId từ bảng ScheduleDetails dựa trên scheduleID
SELECT [SessionId]
INTO #TempSessionIds
FROM [VEMS].[dbo].[ScheduleDetails]
WHERE [ScheduleId] = '4C226136-BF65-4221-0B29-08DCDDC5B781';

-- Bước 2: Lấy tất cả các slotDetail từ bảng SlotDetails dựa trên các sessionId đã lấy được
SELECT 
sld.Id as SlotDetailID,
t.Id,
t.FullName,
s.Id,
s.SubjectName,
sl.SlotIndex,
sl.StartTime,
sl.EndTime,
p.PeriodName,
se.[DayOfWeek]
FROM [VEMS].[dbo].[SlotDetails] sld
join [VEMS].[dbo].[Teacher] t on  sld.TeacherID = t.Id 
join [VEMS].[dbo].Subjects s on  sld.SubjectID = s.Id 
join [VEMS].[dbo].Slots sl on  sld.SlotID = sl.Id 
join [VEMS].[dbo].[Sessions] se on  sld.SessionID = se.Id 
join [VEMS].[dbo].[Periods] p on  se.PeriodID = p.Id 
WHERE [SessionId] IN (SELECT [SessionId] FROM #TempSessionIds) order by  [DayOfWeek], SlotIndex
;
-- Xóa bảng tạm sau khi sử dụng
DROP TABLE #TempSessionIds;
