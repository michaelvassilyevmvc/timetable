using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Athletes;
using Timetable.Models.LearningGroups;
using Xamarin.Forms;

namespace Timetable.ViewModels
{
    public class AthletesListViewModel : INotifyPropertyChanged
    {
        private List<Athlete> _athletes;
        private List<Athlete> _searchAthletes;
        private List<LearningGroup> _learningGroups;

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

        public AthletesListViewModel()
        {
            this.Athletes = Repository.Repository.GetAthletes();
            this.LearningGroups = Repository.Repository.GetLearningGroups();
        }

        public void elSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.SearchAthletes = this.Athletes.Where(a => a.FullName.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
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
