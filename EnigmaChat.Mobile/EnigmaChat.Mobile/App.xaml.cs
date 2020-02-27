using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnigmaChat.Mobile.Views;
using EnigmaChat.SignalR.Client;

namespace EnigmaChat.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<ChatService>();
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
