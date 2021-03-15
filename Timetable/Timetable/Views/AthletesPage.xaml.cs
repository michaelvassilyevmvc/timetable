using Timetable.Models.Athletes;
using Timetable.Models.LearningGroups;
using Timetable.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AthletesPage : ContentPage
    {
        public AthletesListViewModel AthletesListViewModel { get; set; }

        public AthletesPage()
        {
            InitializeComponent();

            AthletesListViewModel = new AthletesListViewModel();
            BindingContext = AthletesListViewModel;
        }

        private void elSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterApply();
        }

        private void pckLearningGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            FilterApply();
        }

        private void FilterApply()
        {
            var searchText = this.elSearch.Text ?? string.Empty;
            var selectGroup = (pckLearningGroup.SelectedItem as LearningGroup);
            this.AthletesListViewModel.Filtered(searchText, selectGroup);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            pckLearningGroup.SelectedIndex = 0;
            elSearch.Text = string.Empty;
        }

        private void LstAthletes_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var athlete = e.Item as Athlete;
            var athleteViewModel = new AthleteViewModel(athlete);
            this.Navigation.PushAsync(new AthleteDetailPage(athleteViewModel));
    }
    }
}