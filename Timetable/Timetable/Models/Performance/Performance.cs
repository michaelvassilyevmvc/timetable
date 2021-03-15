using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Athletes;
using Timetable.Models.LearningGroups;
using Timetable.Models.Trainers;

namespace Timetable.Models.Performance
{
    public class Performance
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int? TrainerId { get; set; }
        public int? AthleteId { get; set; }

        public List<LearningGroup> LearningGroups { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Athlete> Athletes { get; set; }
        public PerformanceType Type { get; set; } = PerformanceType.Group;
        public PerformanceState State { get; set; } = PerformanceState.Planned;

        public Performance()
        {
            this.Trainers = new List<Trainer>();
            this.Athletes = new List<Athlete>();
            this.LearningGroups = new List<LearningGroup>();
        }

    }
}
