using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using JetBrains.Annotations;

namespace MMI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Items.Add(new ItemViewModel("Trondheim maraton"));
            Items.Add(new ItemViewModel("NTNU-løpet"));
        }

        public bool ShowItem1 { get; private set; }
        public bool ShowItem2 { get; private set; }
        public bool ShowItem3 { get; private set; }

        public ICommand AddStepsCommand => new RelayCommand(AddSteps);

        private async void AddSteps()
        {
            var dialog = new ContentDialog
            {
                Content = new RegisterStepsControl()
            };

            var result = await dialog.ShowAsync();
        }

        public ObservableCollection<ItemViewModel> Items { get; } = new ObservableCollection<ItemViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}