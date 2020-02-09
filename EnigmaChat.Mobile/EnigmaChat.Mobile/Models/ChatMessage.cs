using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EnigmaChat.Mobile.Models
{
    public class ChatMessage : INotifyPropertyChanged
    {
        static Random Random = new Random();

        private string user;
        public string User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        string firstLetter;
        public string FirstLetter
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(firstLetter))
                    return firstLetter;

                firstLetter = User?.Length > 0 ? User[0].ToString() : "?";
                return firstLetter;
            }
            set => firstLetter = value;
        }

        Color color;
        public Color Color
        {
            get
            {
                if (color != null && color.A != 0)
                    return color;

                color = Color.FromRgb(Random.Next(0, 255), Random.Next(0, 255), Random.Next(0, 255)).MultiplyAlpha(.9);
                return color;
            }
            set => color = value;
        }

        Color backgroundColor;
        public Color BackgroundColor
        {
            get
            {
                if (backgroundColor != null && backgroundColor.A != 0)
                    return backgroundColor;

                backgroundColor = Color.MultiplyAlpha(.6);
                return backgroundColor;
            }
            set => backgroundColor = value;
        }

        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
    [CallerMemberName]string propertyName = "",
    Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
