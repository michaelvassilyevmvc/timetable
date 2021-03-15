using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AthleteDetailPage : ContentPage
    {
        public AthleteDetailPage(AthleteViewModel athleteViewModel)
        {
            InitializeComponent();
            BindingContext = athleteViewModel;
            this.Title = athleteViewModel.Athlete.FullName;
        }
    }
}