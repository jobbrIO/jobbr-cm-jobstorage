﻿using System;using Jobbr.ComponentModel.JobStorage.Model;namespace Jobbr.ComponentModel.JobStorage{    /// <summary>    /// Interface that specifies how the store can be accessed.    /// </summary>    public interface IJobStorageProvider    {        #region Jobs        /// <summary>        /// Add a job. The Id property of the job instance will be set by the implementation.        /// </summary>        void AddJob(Job job);        void DeleteJob(long jobId);        long GetJobsCount();        PagedResult<Job> GetJobs(int page = 1, int pageSize = 50, string jobTypeFilter = null, string jobUniqueNameFilter = null, string query = null, params string[] sort);        Job GetJobById(long id);        Job GetJobByUniqueName(string identifier);        void Update(Job job);        #endregion        #region Triggers        /// <summary>        /// Add a RecurringTrigger. The Id and JobId property of the trigger instance will be set after calling this method.        /// </summary>        void AddTrigger(long jobId, RecurringTrigger trigger);        /// <summary>        /// Add an InstantTrigger. The Id and JobId property of the trigger instance will be set after calling this method.        /// </summary>        void AddTrigger(long jobId, InstantTrigger trigger);        /// <summary>        /// Add a ScheduledTrigger. The Id and JobId property of the trigger instance will be set after calling this method.        /// </summary>        void AddTrigger(long jobId, ScheduledTrigger trigger);        JobTriggerBase GetTriggerById(long jobId, long triggerId);        PagedResult<JobTriggerBase> GetTriggersByJobId(long jobId, int page = 1, int pageSize = 50);        PagedResult<JobTriggerBase> GetActiveTriggers(int page = 1, int pageSize = 50, string jobTypeFilter = null, string jobUniqueNameFilter = null, string query = null, params string[] sort);        void DisableTrigger(long jobId, long triggerId);        void EnableTrigger(long jobId, long triggerId);        void DeleteTrigger(long jobId, long triggerId);        void Update(long jobId, InstantTrigger trigger);        void Update(long jobId, ScheduledTrigger trigger);        void Update(long jobId, RecurringTrigger trigger);        #endregion        #region Jobruns        /// <summary>        /// Add a JobRun. JobRun.Id will be set after calling this method.        /// </summary>        void AddJobRun(JobRun jobRun);        JobRun GetJobRunById(long id);        JobRun GetLastJobRunByTriggerId(long jobId, long triggerId, DateTime utcNow);        JobRun GetNextJobRunByTriggerId(long jobId, long triggerId, DateTime utcNow);        PagedResult<JobRun> GetJobRuns(int page = 1, int pageSize = 50, string jobTypeFilter = null, string jobUniqueNameFilter = null, string query = null, params string[] sort);        PagedResult<JobRun> GetJobRunsByJobId(int jobId, int page = 1, int pageSize = 50, params string[] sort);        PagedResult<JobRun> GetJobRunsByUserId(string userId, int page = 1, int pageSize = 50, string jobTypeFilter = null, string jobUniqueNameFilter = null, params string[] sort);        PagedResult<JobRun> GetJobRunsByTriggerId(long jobId, long triggerId, int page = 1, int pageSize = 50, params string[] sort);        PagedResult<JobRun> GetJobRunsByUserDisplayName(string userDisplayName, int page = 1, int pageSize = 50, string jobTypeFilter = null, string jobUniqueNameFilter = null, params string[] sort);        PagedResult<JobRun> GetJobRunsByState(JobRunStates state, int page = 1, int pageSize = 50, string jobTypeFilter = null, string jobUniqueNameFilter = null, string query = null, params string[] sort);        PagedResult<JobRun> GetJobRunsByStates(JobRunStates[] states, int page = 1, int pageSize = 50, string jobTypeFilter = null, string jobUniqueNameFilter = null, string query = null, params string[] sort);        void Update(JobRun jobRun);        void UpdateProgress(long jobRunId, double? progress);        bool IsAvailable();        #endregion    }}