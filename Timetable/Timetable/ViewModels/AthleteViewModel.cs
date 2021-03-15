using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Timetable.Models.Athletes;
using Timetable.Models.Performance;
using Timetable.Repository;
using Timetable.Utils;
using Xamarin.Forms;

namespace Timetable.ViewModels
{
    public class AthleteViewModel : BaseViewModel
    {
        public ObservableCollection<Grouping<DateTime, Performance>> PerformancesGroupingValues { get; set; }

        public RepositoryContext _repository { get; set; }
        public Athlete Athlete { get; set; }
        public List<Performance> Performances { get; set; }
        public Page CurrentPage { get; set; }

        public DateTime CurentMonthDate { get; set; }
        public DateTime FirstDateCurrentMonth{
            get
            {
                return new DateTime(this.CurentMonthDate.Year, this.CurentMonthDate.Month, 1);
            }
        }

        public DateTime LastDateCurrentMonth
        {
            get
            {
                return FirstDateCurrentMonth.AddMonths(1).AddTicks(-1);
            }
        }

        public string CurentMonthTitle
        {
            get
            {
                string result = null;
                result = this.CurentMonthDate.ToString("MM-yyyy");
                return result;
            }
        }

        public ICommand doAdd { get; }
        public ICommand doRefresh { get; }
        public ICommand doDelete { get; }
        public ICommand doFilter { get; }
        public ICommand doNextMonth { get; }
        public ICommand doPreviousMonth { get; }

        public AthleteViewModel( Athlete athlete)
        {
            this._repository = new RepositoryContext();
            this.Athlete = athlete;
            this.Performances = this._repository
                .GetPerformances()
                .Where(x => (x.AthleteId == athlete.Id) || x.Athletes.Any(a => a.Id == athlete.Id))
                .ToList(); 

            this.CurentMonthDate = DateTime.Today;
            GetPerformancesGroupingValues();

            this.CurentMonthDate = DateTime.Now;
            this.doNextMonth = new Command(this.onNextMonth);
            this.doPreviousMonth = new Command(this.onPreviousMonth);
        }

        public void GetPerformancesGroupingValues()
        {

            var groups = this.Performances
                .Where(x=> x.StartDate >= FirstDateCurrentMonth && x.StartDate < LastDateCurrentMonth)
                .GroupBy(x => x.StartDate.Date)
                .Select(g => new Grouping<DateTime, Performance>(g.Key, g))
                .OrderBy(g => g.Name);

            this.PerformancesGroupingValues = new ObservableCollection<Grouping<DateTime, Performance>>(groups);
            this.OnPropertyChanged("PerformancesGroupingValues");
        }

        public  void SetToolBars(Page currentPage)
        {
            this.CurrentPage = currentPage;
            this.CurrentPage.ToolbarItems.Clear();
            this.CurrentPage.ToolbarItems.Add(new ToolbarItem { IconImageSource = "toolbar_add.png", Command = this.doAdd });
            this.CurrentPage.ToolbarItems.Add(new ToolbarItem { IconImageSource = "toolbar_filter.png", Command = this.doFilter });
            this.CurrentPage.ToolbarItems.Add(new ToolbarItem { IconImageSource = "toolbar_refresh.png", Command = this.doRefresh });
            this.OnPropertyChanged("CurentPage");
        }

        private void onPreviousMonth()
        {
            this.CurentMonthDate = this.CurentMonthDate.AddMonths(-1);
            //this.OnPropertyChanged("CurentMonth");
            this.OnPropertyChanged("CurentMonthTitle");
            GetPerformancesGroupingValues();
        }

        private void onNextMonth()
        {
            this.CurentMonthDate = this.CurentMonthDate.AddMonths(1);
            //this.OnPropertyChanged("CurentMonth");
            this.OnPropertyChanged("CurentMonthTitle");
            GetPerformancesGroupingValues();
        }

       


        


    }
}
