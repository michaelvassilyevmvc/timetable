using Timetable.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LearningGroupsPage : ContentPage
    {
        public LearningGroupsPage()
        {
            InitializeComponent();
            BindingContext = new LearningGroupListViewModel();
        }

        private void elSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var learningGroupListViewModel = (BindingContext as LearningGroupListViewModel);

            learningGroupListViewModel.elSearch_TextChanged(sender, e);
            lstLearningGroups.ItemsSource = learningGroupListViewModel.SearchLearningGroups;
        }
    }
}