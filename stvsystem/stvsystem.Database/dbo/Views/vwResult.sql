CREATE VIEW [dbo].[vwResult]
	AS SELECT CandidateID, 
[1] AS N1, [2] AS N2, [3] AS N3, [4] AS N4, [5] AS N5, [6] AS N6, [7] AS N7, [8]AS N8, [9] AS N9, [10] AS N10, [11] AS N11, [12] AS N12, [13] AS N13, [14] AS N14, [15] AS N15
FROM
(SELECT CredentialID, CandidateID, CandidateIndex 
    FROM [dbo].[Result]) AS SourceTable
PIVOT
(
Count(CredentialID)
FOR CandidateIndex IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15])
) AS PivotTable
