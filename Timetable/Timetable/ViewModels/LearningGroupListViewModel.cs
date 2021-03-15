using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.LearningGroups;
using Timetable.Models.Athletes;
using Timetable.Models.Trainers;
using Xamarin.Forms;
using Timetable.Repository;

namespace Timetable.ViewModels
{
    public class LearningGroupListViewModel : INotifyPropertyChanged
    {
        public IRepository _repository { get; set; }
        private List<LearningGroup> _learningGroups;
        private List<LearningGroup> _searchTrainers;

        public List<LearningGroup> LearningGroups { 
            get { 
                return this._learningGroups; 
            } 
            set {
                _learningGroups = value;
                this.OnPropertyChanged("LearningGroups");
            }
        }
        public List<LearningGroup> SearchLearningGroups
        {
            get { return this._searchTrainers; }
            set { this._searchTrainers = value; this.OnPropertyChanged("SearchLearningGroups"); }
        }

        public LearningGroupListViewModel()
        {
            this._repository = new RepositoryContext();
            this.LearningGroups = this._repository.GetLearningGroups();
            var trainers = this._repository.GetTrainers();
            var athletes = this._repository.GetAthletes();
        }

        public void elSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.SearchLearningGroups = this.LearningGroups.Where(a => a.Name.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
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
