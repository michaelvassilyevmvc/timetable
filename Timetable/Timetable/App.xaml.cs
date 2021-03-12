using System;
using Timetable.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InfoTabbedPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
