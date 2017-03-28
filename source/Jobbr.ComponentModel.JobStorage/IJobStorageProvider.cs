using System;
using System.Collections.Generic;
using Jobbr.ComponentModel.JobStorage.Model;

namespace Jobbr.ComponentModel.JobStorage
{
    /// <summary>
    /// Interface that specifies how the store can be accessed.
    /// </summary>
    public interface IJobStorageProvider
    {
        #region Jobs

        /// <summary>
        /// Add a job. The Id property of the job instance will be set by the implementation.
        /// </summary>
        void AddJob(Job job);

        List<Job> GetJobs(int page = 0, int pageSize = 50);

        Job GetJobById(long id);

        Job GetJobByUniqueName(string identifier);

        void Update(Job job);

        #endregion

        #region Triggers

        /// <summary>
        /// Add a RecurringTrigger. The Id and JobId property of the trigger instance will be set after calling this method.
        /// </summary>
        void AddTrigger(long jobId, RecurringTrigger trigger);

        /// <summary>
        /// Add an InstantTrigger. The Id and JobId property of the trigger instance will be set after calling this method.
        /// </summary>
        void AddTrigger(long jobId, InstantTrigger trigger);

        /// <summary>
        /// Add a ScheduledTrigger. The Id and JobId property of the trigger instance will be set after calling this method.
        /// </summary>
        void AddTrigger(long jobId, ScheduledTrigger trigger);

        JobTriggerBase GetTriggerById(long jobId, long triggerId);

        List<JobTriggerBase> GetTriggersByJobId(long jobId);

        List<JobTriggerBase> GetActiveTriggers();

        bool DisableTrigger(long jobId, long triggerId);

        bool EnableTrigger(long jobId, long triggerId);

        bool Update(long jobId, InstantTrigger trigger);

        bool Update(long jobId, ScheduledTrigger trigger);

        bool Update(long jobId, RecurringTrigger trigger);

        #endregion

        #region Jobruns

        int AddJobRun(JobRun jobRun);

        /// <summary>
        /// Get JobRuns ordered by PlannedStartDateTimeUtc descending
        /// </summary>
        List<JobRun> GetJobRuns(long page = 0, long pageSize = 50);

        JobRun GetJobRunById(long id);

        JobRun GetLastJobRunByTriggerId(long jobId, long triggerId, DateTime utcNow);

        JobRun GetNextJobRunByTriggerId(long jobId, long triggerId, DateTime utcNow);

        /// <summary>
        /// Triggers are orderd by date descending
        /// </summary>
        List<JobRun> GetJobRunsByTriggerId(long jobId, long triggerId, long page = 0, long pageSize = 50);

        /// <summary>
        /// Get JobRuns by state, ordered by PlannedStartDateTimeUtc ascending
        /// </summary>
        List<JobRun> GetJobRunsByState(JobRunStates state);

        /// <summary>
        /// Get JobRuns by user id, ordered by PlannedStartDateTimeUtc ascending
        /// </summary>
        List<JobRun> GetJobRunsByUserId(long userId);

        /// <summary>
        /// Get JobRuns by user name, ordered by PlannedStartDateTimeUtc ascending
        /// </summary>
        List<JobRun> GetJobRunsByUserName(string userName);

        void Update(JobRun jobRun);

        void UpdateProgress(long jobRunId, double? progress);

        bool IsAvailable();

        #endregion
    }
}