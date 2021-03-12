using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Athletes;
using Timetable.Models.Trainers;

namespace Timetable.Models.LearningGroups
{
    public class LearningGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<int> AthletesId { get; set; }
        public List<int> TrainersId { get; set; }


        public List<Athlete> Athletes { get; set; }
        public List<Trainer> Trainers { get; set; }

        public LearningGroup()
        {
            AthletesId = new List<int>();
            TrainersId = new List<int>();
            Athletes = new List<Athlete>();
            Trainers = new List<Trainer>();
        }
    }
}
