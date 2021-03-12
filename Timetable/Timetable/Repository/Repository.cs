using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Athletes;
using Timetable.Models.LearningGroups;
using Timetable.Models.Trainers;

namespace Timetable.Repository
{
    public static class Repository
    {
        public static List<Athlete> GetAthletes()
        {
            return new List<Athlete>
            {
                new Athlete { Id = 1,  LName = "Попов", FName = "Петр" },
                new Athlete { Id = 2,  LName = "Иванов", FName = "Петр" },
                new Athlete { Id = 3,  LName = "Сидоров", FName = "Евгений" },
                new Athlete { Id = 4,  LName = "Петров", FName = "Петр" },
                new Athlete { Id = 5,  LName = "Иванов", FName = "Иван" },
                new Athlete { Id = 6,  LName = "Глазунов", FName = "Валерий" },
                new Athlete { Id = 7,  LName = "Иванова", FName = "Анна" },
                new Athlete { Id = 8,  LName = "Тригубов", FName = "Кирилл" },
                new Athlete { Id = 9,  LName = "Хасенов", FName = "Даурен" },
                new Athlete { Id = 10, LName = "Гребешков", FName = "Дмитрий" },
                new Athlete { Id = 11, LName = "Бородулин", FName = "Роман" },
                new Athlete { Id = 12, LName = "Игнатова", FName = "Дарья" },
                new Athlete { Id = 13, LName = "Алибаева", FName = "Гульнара" },
                new Athlete { Id = 14, LName = "Плеханов", FName = "Павел" }
            };
        }
        public static List<Trainer> GetTrainers()
        {
            return new List<Trainer>
            {
                new Trainer{Id=1,LName="Заичков",  FName="Дмитрий"},
                new Trainer{Id=2,LName="Петров",   FName="Павел"},
                new Trainer{Id=3,LName="Жайлыбаев",FName="Жарас"},
                new Trainer{Id=4,LName="Тунгышбай",FName="Омиртай"},
                new Trainer{Id=5,LName="Карпенко", FName="Михаил"},
                new Trainer{Id=6,LName="Гребешков",FName="Дмитрий"},
                new Trainer{Id=7,LName="Иванов",   FName="Иван"},
                new Trainer{Id=8,LName="Глазунов", FName="Валерий"},
                new Trainer{Id=9,LName="Андреева",FName="Елизаветта"},
                new Trainer{Id=10,LName="Иванов",FName="Иван"},
                new Trainer{Id=11,LName="Борадулин",FName="Роман"},
                new Trainer{Id=12,LName="Плеханов",FName="Павел"},
                new Trainer{Id=13,LName="Смаилов",FName="Арман"},
                new Trainer{Id=14,LName="Исин",FName="Айдар"}
            };
        }
        public static List<LearningGroup> GetLearningGroups()
        {
            var athletes = GetAthletes();
            var trainers = GetTrainers();
            var learningGroups =  new List<LearningGroup>
            {
                new LearningGroup{Id=1,  Name="ДЮСШ-1", AthletesId = new List<int>{1,2,3,4}, TrainersId = new List<int>{1,2 } },
                new LearningGroup{Id=2,  Name="ДЮСШ-2", AthletesId = new List<int>{2,3}, TrainersId = new List<int>{3} },
                new LearningGroup{Id=3,  Name="ДЮСШ-3", AthletesId = new List<int>{4,5,6}, TrainersId = new List<int>{ 4} },
                new LearningGroup{Id=4,  Name="ДЮСШ-4", AthletesId = new List<int>{7,8,9}, TrainersId = new List<int>{ 5,7} },
                new LearningGroup{Id=5,  Name="ДЮСШ-5", AthletesId = new List<int>{10,11}, TrainersId = new List<int>{ 6} },
                new LearningGroup{Id=6,  Name="ДЮСШ-6", AthletesId = new List<int>{12,13,14}, TrainersId = new List<int>{8,9 } },
                new LearningGroup{Id=7,  Name="НП-1",AthletesId=new List<int>{4,5},TrainersId = new List<int>{5}},
                new LearningGroup{Id=8,  Name="НП-2",AthletesId=new List<int>{8},TrainersId = new List<int>{7}},
                new LearningGroup{Id=9,  Name="НП-3",AthletesId=new List<int>{9},TrainersId = new List<int>{6}},
                new LearningGroup{Id=10, Name="УТГ1",AthletesId=new List<int>{10},TrainersId = new List<int>{7}},
                new LearningGroup{Id=11, Name="УТГ2",AthletesId=new List<int>{11},TrainersId = new List<int>{8}},
                new LearningGroup{Id=12, Name="УТГ3",AthletesId=new List<int>{12},TrainersId = new List<int>{9}},
                new LearningGroup{Id=13, Name="УТГ4",AthletesId=new List<int>{13},TrainersId = new List<int>{10}},
                new LearningGroup{Id=14, Name="УТГ5",AthletesId=new List<int>{14},TrainersId = new List<int>{11} }
            };

            learningGroups.ForEach(l => l.Athletes = athletes.Where(x => l.AthletesId.Any(p => p == x.Id)).ToList());
            learningGroups.ForEach(l => l.Trainers = trainers.Where(x => l.TrainersId.Any(p => p == x.Id)).ToList());

            return learningGroups;
        }
    }
}
