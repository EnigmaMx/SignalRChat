using EnigmaChat.Mobile.Helpers;
using EnigmaChat.Mobile.Views;
using EnigmaChat.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EnigmaChat.Mobile.ViewModels
{
    public class LobbyViewModel : BaseViewModel
    {
        List<string> _rooms;
        public List<string> Rooms
        {
            get => _rooms;
            set => SetProperty(ref _rooms, value);
        }
        public LobbyViewModel()
        {
        }

        public string UserName
        {
            get => Settings.UserName;
            set
            {
                if (value == UserName)
                    return;
                Settings.UserName = value;
                OnPropertyChanged();
            }
        }

        public void OnAppearing()
        {
            Rooms = new List<string>();
            Rooms = ChatService.GetRooms();
        }

        public async Task GoToGroupChat(INavigation navigation, string group)
        {
            if (string.IsNullOrWhiteSpace(group))
                return;

            if (string.IsNullOrWhiteSpace(UserName))
                return;

            Settings.Group = group;
            await navigation.PushModalAsync(new GroupChatPage());
        }

    }
}
