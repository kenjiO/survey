use [CS6232-G1];
GO
IF OBJECT_ID('dbo.EvaluationScheduleView', 'V') IS NOT NULL
    DROP VIEW dbo.EvaluationScheduleView;
GO
CREATE VIEW dbo.EvaluationScheduleView
AS
SELECT  es.scheduleId,
        es.cohortId,
        es.typeId,
        ty.typeName,
        ty.answerRange,
        es.stageId,
        st.stageName,
        startDate,
        endDate
  FROM dbo.evaluation_schedule es
  LEFT JOIN dbo.type ty ON (ty.typeId = es.typeId)
  LEFT JOIN dbo.stage st ON (st.stageId = es.stageId)
