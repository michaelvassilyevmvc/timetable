using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Trainers;
using Timetable.Repository;
using Xamarin.Forms;


namespace Timetable.ViewModels
{
    public class TrainerListViewModel : INotifyPropertyChanged
    {
        public IRepository _repository { get; set; }
        private List<Trainer> _trainers;
        private List<Trainer> _searchTrainers;

        public List<Trainer> Trainers { get { return this._trainers; } set {
                _trainers = value;
                this.OnPropertyChanged("Trainers");
            } }

        public List<Trainer> SearchTrainers
        {
            get { return this._searchTrainers; }
            set { this._searchTrainers = value; this.OnPropertyChanged("SearchTrainers"); }
        }


        public TrainerListViewModel()
        {
            this._repository = new RepositoryContext();
            this.Trainers = this._repository.GetTrainers();
        }

        public void elSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.SearchTrainers = this.Trainers.Where(a => a.FullName.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
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
