CREATE VIEW [dbo].[vwResult]
	AS SELECT CandidateID, 
[1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15]
FROM
(SELECT CredentialID, CandidateID, CandidateIndex 
    FROM [dbo].[Result]) AS SourceTable
PIVOT
(
Count(CredentialID)
FOR CandidateIndex IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15])
) AS PivotTable
