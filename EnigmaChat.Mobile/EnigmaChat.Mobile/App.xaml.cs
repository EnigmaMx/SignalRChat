using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnigmaChat.Mobile.Services;
using EnigmaChat.Mobile.Views;

namespace EnigmaChat.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
