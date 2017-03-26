using System;
using System.Collections.Generic;
using Jobbr.ComponentModel.JobStorage.Model;

namespace Jobbr.ComponentModel.JobStorage
{
    /// <summary>
    /// Interface that specifies how the store can be accessed.
    /// 
    /// Note: The different entities are grouped by entity.
    /// The methods are ordered by the CRUD-principle.
    /// </summary>
    public interface IJobStorageProvider
    {
        #region Jobs

        long AddJob(Job job);

        List<Job> GetJobs();

        Job GetJobById(long id);

        Job GetJobByUniqueName(string identifier);

        bool Update(Job job);

        #endregion

        #region Triggers

        long AddTrigger(RecurringTrigger trigger);

        long AddTrigger(InstantTrigger trigger);

        long AddTrigger(ScheduledTrigger trigger);

        JobTriggerBase GetTriggerById(long triggerId);

        List<JobTriggerBase> GetTriggersByJobId(long jobId);

        List<JobTriggerBase> GetActiveTriggers();

        bool DisableTrigger(long triggerId);

        bool EnableTrigger(long triggerId);

        bool Update(InstantTrigger trigger);

        bool Update(ScheduledTrigger trigger);

        bool Update(RecurringTrigger trigger);

        #endregion

        #region Jobruns

        int AddJobRun(JobRun jobRun);

        List<JobRun> GetJobRuns();

        JobRun GetJobRunById(long id);

        JobRun GetLastJobRunByTriggerId(long triggerId, DateTime utcNow);

        JobRun GetNextJobRunByTriggerId(long triggerId, DateTime utcNow);

        List<JobRun> GetJobRunsByTriggerId(long triggerId);

        List<JobRun> GetJobRunsByState(JobRunStates state);

        List<JobRun> GetJobRunsByUserId(long userId);

        List<JobRun> GetJobRunsByUserName(string userName);

        bool Update(JobRun jobRun);

        bool UpdateProgress(long jobRunId, double? progress);

        #endregion

        bool CheckParallelExecution(long triggerId);
    }
}