using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Athletes;

namespace Timetable.ViewModels
{
    public class AthletesListViewModel : INotifyPropertyChanged
    {
        private List<Athlete> _athletes;

        public List<Athlete> Athletes { get { return this._athletes; } set {
                _athletes = value;
                this.OnPropertyChanged("Athletes");
            } }

        public AthletesListViewModel()
        {
            this.Athletes = GetAthletes();
        }

        public List<Athlete> GetAthletes()
        {
            return new List<Athlete>
            {
                new Athlete{Id=1,LName="Попов",       FName="Петр"},
                new Athlete{Id=2,LName="Иванов",        FName="Петр"},
                new Athlete{Id=3,LName="Сидоров",     FName="Евгений"},
                new Athlete{Id=4,LName="Петров",     FName="Петр"},
                new Athlete{Id=5,LName="Иванов",      FName="Иван"},
                new Athlete{Id=6,LName="Глазунов",     FName="Валерий"},
                new Athlete{Id=7,LName="Иванова",        FName="Анна"},
                new Athlete{Id=8,LName="Тригубов",      FName="Кирилл"},
                new Athlete{Id=9,LName="Хасенов",      FName="Даурен"},
                new Athlete{Id=10,LName="Гребешков",       FName="Дмитрий"},
                new Athlete{Id=11,LName="Бородулин",    FName="Роман"},
                new Athlete{Id=12,LName="Игнатова",     FName="Дарья"},
                new Athlete{Id=13,LName="Алибаева",      FName="Гульнара"},
                new Athlete{Id=14,LName="Плеханов",         FName="Павел"}
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
