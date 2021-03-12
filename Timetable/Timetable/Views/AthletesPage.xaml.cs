using Timetable.Models.LearningGroups;
using Timetable.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AthletesPage : ContentPage
    {
        public AthletesPage()
        {
            InitializeComponent();
            BindingContext = new AthletesListViewModel();
        }

        private void elSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var athletesListViewModel = (BindingContext as AthletesListViewModel);

            athletesListViewModel.elSearch_TextChanged(sender, e);
            lstAthletes.ItemsSource = athletesListViewModel.SearchAthletes;
        }

        private void pckLearningGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var athletesListViewModel = (BindingContext as AthletesListViewModel);

            athletesListViewModel.SearchAthletes = (pckLearningGroup.SelectedItem as LearningGroup).Athletes;
            lstAthletes.ItemsSource = athletesListViewModel.SearchAthletes;
        }
    }
}