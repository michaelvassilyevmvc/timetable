using System;
using System.Collections.Generic;
using Timetable.Models.Athletes;
using Timetable.Models.LearningGroups;

namespace Timetable.Models.Trainers
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ScheduleType ScheduleType { get; set; } 
        public StateSchedule State { get; set; } = StateSchedule.Active;
        public List<LearningGroup> LearningGroups { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Athlete> Athletes { get; set; }

        public Schedule()
        {
            this.LearningGroups = new List<LearningGroup>();
            this.Trainers = new List<Trainer>();
            this.Athletes = new List<Athlete>();
        }
    }
}

