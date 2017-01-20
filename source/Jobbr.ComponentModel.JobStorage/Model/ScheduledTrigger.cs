using System;

namespace Jobbr.ComponentModel.JobStorage.Model
{
    [Serializable]
    public class ScheduledTrigger : JobTriggerBase
    {
        public DateTime StartDateTimeUtc { get; set; }

        public string Comment { get; set; }

        public string Parameters { get; set; }
    }
}