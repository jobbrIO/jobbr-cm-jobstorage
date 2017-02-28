using System;

namespace Jobbr.ComponentModel.JobStorage.Model
{
    [Serializable]
    public class JobArtefact
    {
        public string Filename { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
    }
}