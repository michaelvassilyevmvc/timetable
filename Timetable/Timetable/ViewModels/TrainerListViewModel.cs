using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Trainers;

namespace Timetable.ViewModels
{
    public class TrainerListViewModel : INotifyPropertyChanged
    {
        private List<Trainer> _trainers;

        public List<Trainer> Trainers { get { return this._trainers; } set {
                _trainers = value;
                this.OnPropertyChanged("Trainers");
            } }

        public TrainerListViewModel()
        {
            this.Trainers = GetTrainers();
        }

        public List<Trainer> GetTrainers()
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
