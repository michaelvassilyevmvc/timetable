using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Athletes;
using Timetable.Models.LearningGroups;
using Timetable.Utils;
using Xamarin.Forms;

namespace Timetable.ViewModels
{
    public class AthletesListViewModel : INotifyPropertyChanged
    {
        private List<Athlete> _athletes;
        private List<Athlete> _searchAthletes;

        private List<LearningGroup> _learningGroups;
        private List<LearningGroup> _searchLearningGroups;
        private ObservableCollection<Grouping<string, Athlete>> _athleteGroups;

        public ObservableCollection<Grouping<string, Athlete>> AthleteGroups
        {
            get { return _athleteGroups;}
            set { this._athleteGroups = value; this.OnPropertyChanged("AthleteGroups"); }
        }

        public List<Athlete> Athletes { 
            get { 
                return this._athletes; 
            } 
            set {
                this._athletes = value;
                this.OnPropertyChanged("Athletes");
            } 
        }
        public List<LearningGroup> LearningGroups
        {
            get { return this._learningGroups; }
            set
            {
                this._learningGroups = value;
                this.OnPropertyChanged("LearningGroups");
            }
        }
        public List<Athlete> SearchAthletes { 
            get { return this._searchAthletes; } 
            set { this._searchAthletes = value; this.OnPropertyChanged("SearchAthletes"); } 
        }

        public List<LearningGroup> SearchLearningGroups
        {
            get { return this._searchLearningGroups; }
            set
            {
                this._searchLearningGroups = value;
                this.OnPropertyChanged("SearchLearningGroups");
            }
        }

        public AthletesListViewModel()
        {
            this.Athletes = Repository.Repository.GetAthletes();
            this.LearningGroups = Repository.Repository.GetLearningGroups();

            InitAthleteGroups();

            this.LearningGroups.Insert(0,new LearningGroup("Все группы") );


        }

        public void Filtered(string searchText, LearningGroup filterGroup)
        {
            var athletes = Repository.Repository.GetAthletes();

            this.SearchLearningGroups = (filterGroup != null && filterGroup.Id != 0) 
                ? new List<LearningGroup>{ filterGroup }
                : this.LearningGroups;

            this.SearchLearningGroups.ForEach(l => l.Athletes = athletes.Where(x => l.AthletesId.Any(p => p == x.Id)).ToList());

            this.SearchLearningGroups = this.SearchLearningGroups
                .Where(x => x.Athletes.Any(a => a.FullName.ToLower().Contains(searchText.ToLower()))).ToList();

            this.SearchLearningGroups.ForEach(x =>
                x.Athletes = x.Athletes.Where(a => a.FullName.ToLower().Contains(searchText.ToLower())).ToList());

            InitAthleteGroups();

        }

        private void InitAthleteGroups()
        {
            this.AthleteGroups = new ObservableCollection<Grouping<string, Athlete>>();
            foreach (var item in this.SearchLearningGroups)
            {
                if (item.Id == 0) continue;
                this.AthleteGroups.Add(new Grouping<string, Athlete>(item.Name, item.Athletes));
            }
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
