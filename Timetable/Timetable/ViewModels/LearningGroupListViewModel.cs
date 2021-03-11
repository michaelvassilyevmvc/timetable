using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.LearningGroups;

namespace Timetable.ViewModels
{
    public class LearningGroupListViewModel : INotifyPropertyChanged
    {
        private List<LearningGroup> _learningGroups;

        public List<LearningGroup> LearningGroups { get { return this._learningGroups; } set {
                _learningGroups = value;
                this.OnPropertyChanged("LearningGroups");
            } }

        public LearningGroupListViewModel()
        {
            this.LearningGroups = GetLearningGroups();
        }

        public List<LearningGroup> GetLearningGroups()
        {
            return new List<LearningGroup>
            {
                new LearningGroup{Id=1,Name="ДЮСШ-1"},
                new LearningGroup{Id=2,Name="ДЮСШ-2"},
                new LearningGroup{Id=3,Name="ДЮСШ-3"},
                new LearningGroup{Id=4,Name="ДЮСШ-4"},
                new LearningGroup{Id=5,Name="ДЮСШ-5"},
                new LearningGroup{Id=6,Name="ДЮСШ-6"},
                new LearningGroup{Id=7,Name="НП-1"},
                new LearningGroup{Id=8,Name="НП-2"},
                new LearningGroup{Id=9,Name="НП-3"},
                new LearningGroup{Id=10,Name="УТГ1"},
                new LearningGroup{Id=11,Name="УТГ2"},
                new LearningGroup{Id=12,Name="УТГ3"},
                new LearningGroup{Id=13,Name="УТГ4"},
                new LearningGroup{Id=14,Name="УТГ5"} 
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
