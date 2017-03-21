using System;

namespace Jobbr.ComponentModel.JobStorage.Model
{
    [Serializable]
    public enum JobRunStates
    {
        /// <summary>
        /// The null :)
        /// </summary>
        Null,

        /// <summary>
        /// The JoBRun is queued unless a JobStarter starts a new executable
        /// </summary>
        Scheduled,

        /// <summary>
        /// The JobStarter has created a enviornment for the Job and copies a related files/data to the working directory
        /// </summary>
        Preparing,

        /// <summary>
        /// The JobStarted has started a new executable 
        /// </summary>
        Starting,

        /// <summary>
        /// The JobStarted has created a new environment and the executable has been started
        /// </summary>
        Started,

        /// <summary>
        /// The Executable itself has connected to the jobServer
        /// </summary>
        Connected,

        /// <summary>
        /// The Executable is running and connected to the jobserver
        /// </summary>
        Initializing,

        /// <summary>
        /// The logic has started to run
        /// </summary>
        Processing,

        /// <summary>
        /// The external code was run
        /// </summary>
        Finishing,

        /// <summary>
        /// Collecting the files
        /// </summary>
        Collecting,

        /// <summary>
        /// The job as executed sucessfully and the executer has cleaned up and terminated
        /// </summary>
        Completed,

        /// <summary>
        /// The job failed.
        /// </summary>
        Failed,

        /// <summary>
        /// The JobRun has ben deleted in advance
        /// </summary>
        Deleted,

        /// <summary>
        /// The JobRun has been omitted. Eg job has been scheduled, Jobserver stopped (before the jobrun is executed) and After PlannedStartDateTime started again -> JobRun won't be started in that case but set to Omitted.
        /// </summary>
        Omitted
    }

    [Serializable]
    public class JobRun
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public long TriggerId { get; set; }
        public Guid UniqueId { get; set; }
        public JobRunStates State { get; set; }
        public double? Progress { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public DateTime PlannedStartDateTimeUtc { get; set; }
        public DateTime? ActualStartDateTimeUtc { get; set; }
        public DateTime? ActualEndDateTimeUtc { get; set; }
        public DateTime? EstimatedEndDateTimeUtc { get; set; }

        public string JobParameters { get; set; }

        public string InstanceParameters { get; set; }

        public int Pid { get; set; }
    }
}
