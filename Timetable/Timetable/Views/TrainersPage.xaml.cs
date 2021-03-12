using Timetable.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainersPage : ContentPage
    {
        public TrainersPage()
        {
            InitializeComponent();
            BindingContext = new TrainerListViewModel();
        }

        private void elSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var trainersListViewModel = (BindingContext as TrainerListViewModel);

            trainersListViewModel.elSearch_TextChanged(sender, e);
            lstTrainers.ItemsSource = trainersListViewModel.SearchTrainers;
        }
    }
}