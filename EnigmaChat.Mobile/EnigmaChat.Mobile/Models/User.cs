using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EnigmaChat.Mobile.Models
{
    public class User
    {
        static Random Random = new Random();
        string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        string firstLetter;
        public string FirstLetter
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(firstLetter))
                    return firstLetter;

                firstLetter = Name?.Length > 0 ? Name[0].ToString() : "?";
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
