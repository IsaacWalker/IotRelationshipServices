using System;
using System.Collections.Generic;
using System.Text;

namespace FYPDataGenerator.ClusterGraph
{
    public sealed class ClusterGraphSettings
    {
        public IList<Cluster> Clusters { get; set; }


        public IList<Tuple<DateTime, TimeSpan>> ActivePeriods { get; set; }


        public TimeSpan ScanningDuration { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }
    }

    public sealed class Cluster
    {
        public TimeSpan ClusterTimeStandardDeviation { get; set; }


        public DateTime ClusterTimeMean { get; set; }
    }

}
