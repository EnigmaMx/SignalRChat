using EnigmaChat.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnigmaChat.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LobbyPage : ContentPage
    {
        LobbyViewModel vm;
        LobbyViewModel VM
        {
            get => vm ?? (vm = (LobbyViewModel)BindingContext);
        }
        public LobbyPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.OnAppearing();
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await VM.GoToGroupChat(Navigation, e.SelectedItem as string);
            ((ListView)sender).SelectedItem = null;
        }
    }
}