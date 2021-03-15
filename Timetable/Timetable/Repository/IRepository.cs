using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Athletes;
using Timetable.Models.LearningGroups;
using Timetable.Models.Performance;
using Timetable.Models.Trainers;

namespace Timetable.Repository
{
    public interface IRepository
    {
        List<Athlete> GetAthletes();
        List<Trainer> GetTrainers();
        List<LearningGroup> GetLearningGroups();

        List<Performance> GetPerformances();
        bool AddPerformance(Performance performance);
        bool DeletePerformance(int id);
    }
}
