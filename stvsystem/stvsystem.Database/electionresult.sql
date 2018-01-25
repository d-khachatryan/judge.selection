--delete from dbo.credential
--delete from dbo.result

----insert initial result into the temporary table
update dbo.Candidate set CandidateStatus = 0
if exists (select * from sys.tables where name = 'TmpResult')
drop table TmpResult
select *, 1.00 as ResultVal into TmpResult from Result

SET NOCOUNT ON

declare @numofcycles int
set @numofcycles = 0

declare @candidatesToBeSelected int
select @candidatesToBeSelected = SelectionCount from dbo.Setting

WHILE  (select count(*) from dbo.Candidate where CandidateStatus = 1) < @candidatesToBeSelected
BEGIN
set @numofcycles = @numofcycles + 1
print CHAR(10) + 'Cycle ' + LTRIM(STR(@numofcycles)) + CHAR(10);
print '--------------------------------------------------------------' + CHAR(10);


--calculate the quota

declare @selectedcandidatecount int
select @selectedcandidatecount = count(*) from candidate where candidateStatus = 1

declare @participantcount int
select @participantcount = T.ParticipantCount from
(select Count(distinct CredentialID) as ParticipantCount from dbo.TmpResult
) AS T

declare @quota int
SET @quota = @participantcount/(@candidatesToBeSelected-@selectedcandidatecount)

print 'count of participants in the cycle = ' + LTRIM(STR(@participantcount))
print 'remaming seets = ' + LTRIM(STR(@candidatesToBeSelected-@selectedcandidatecount))
print 'quota = ' + LTRIM(STR(@quota)) + CHAR(10);

declare @maxsum int
declare @winnercandidate int
select @winnercandidate = CandidateID, @maxsum = maxsum from
(select top 1 CandidateID, max(N1) as maxsum from vwTmpResult group by CandidateID order by max(N1) desc) AS T

declare @minsum int
declare @loosercandidate int
select @loosercandidate = CandidateID, @minsum = minsum from
(select top 1 CandidateID, min(N1) as minsum from vwTmpResult group by CandidateID order by min(N1)) AS T

SELECT * FROM [stvsystemDB].[dbo].[vwTmpResult] ORDER BY [N1] DESC

IF @maxsum > @quota
	BEGIN

		--processing max
		print 'at this step we will process max because there is a candidate with vote count bigger than the quota'
		print 'candidate with maximum votes = ' + LTRIM(STR(@winnercandidate))
		print 'maximum vote count = ' + LTRIM(STR(@maxsum)) + CHAR(10);
		
		
		print 'sub-step 1: update first indexes of the TOP (not identified) candidate to 0'
		update TmpResult set CandidateIndex = CandidateIndex - 1, ResultVal = ResultVal*(@maxsum-@quota)/@maxsum from TmpResult where CredentialID in
		(select credentialID from TmpResult where candidateId = @winnercandidate and candidateindex = 1) 

		print 'sub-step 2: create temporary table and keep the TOP list of records to remove beacuse already used during the selection'
		if exists (select * from sys.tables where name = 'TmpCredential')
		drop table TmpCredential
		select distinct TOP (@quota) CredentialID into TmpCredential from
		(select CredentialID from TmpResult where CredentialID in
		(select credentialID from TmpResult where candidateId = @winnercandidate and candidateindex = 0)) AS T order by credentialID
		
		print 'sub-step 3: insert the results of candiadte part of which shall be removed and part of  which shall be switched'
		if exists (select * from sys.tables where name = 'TmpPartialResult')
		drop table TmpPartialResult
		select resultID into TmpPartialResult from TmpResult where CredentialID in
		(select credentialID from TmpResult where candidateId = @winnercandidate and candidateindex = 0) order by credentialID, CandidateIndex
		
		print 'sub-step 4: delete the records used by the winner candidate to keep the track of the calculation'
		delete from TmpResult from TmpResult 
		inner join TmpCredential on TmpResult.credentialID = TmpCredential.CredentialID
		inner join TmpPartialResult on TmpResult.ResultID = TmpPartialResult.ResultID

		print 'sub-step 4: delete the first records of the candidate to switch the other candidates to the first index'
		delete from TmpResult where candidateindex = 0

		print 'sub-step 4: make the ' + LTRIM(STR(@winnercandidate)) + ' candidate as a winner'		
		update Candidate set CandidateStatus = 1 where CandidateID = @winnercandidate
		delete from TmpResult where candidateID = @winnercandidate

	END
ELSE
	BEGIN

		--processing min
		print 'at this step we will process min because there is no candidate with vote count bigger than the quota'
		print 'candidate with min votes = ' + LTRIM(STR(@loosercandidate))
		print 'minimum vote count = ' + LTRIM(STR(@minsum)) + CHAR(10);

		print 'sub-step 1: change the indexes accordingly. 0 is the looser candidate'
		update TmpResult set CandidateIndex = CandidateIndex - 1 from TmpResult where CredentialID in
		(select credentialID from TmpResult where candidateId = @loosercandidate and candidateindex = 1		) 
		
		print 'sub-step 2: delete switched records with 0'
		delete from TmpResult where candidateindex = 0

		print 'sub-step 2: delete candidate'
		delete from TmpResult where candidateID = @loosercandidate

	END

IF (SELECT count(*) FROM [stvsystemDB].[dbo].[vwTmpResult]) = 0
	BREAK  
ELSE  
   CONTINUE 

END