using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobbr.ComponentModel.JobStorage.Model
{
    [Serializable]
    public class JobTriggerBase
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public long JobId { get; set; }
        public string UserDisplayName { get; set; }
        public long? UserId { get; set; }
        public string UserName { get; set; }
        public string Parameters { get; set; }
    }
}
