using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using JetBrains.Annotations;

namespace MMI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TrainingViewModel _selectedTraining;
        private ActiveTrainingViewModel _activeTraining;

        public MainViewModel()
        {
            Items.Add(new TrainingViewModel("Trondheim maraton", "viderekommen", 42.195, new DateTime(2016, 4, 8), new DateTime(16, 4, 10), "byen", "landet"));
            Items.Add(new TrainingViewModel("NTNU-løpet", "viderekommen", 15.0, new DateTime(2016, 5, 2), new DateTime(16, 5, 5), "Gløshaugen", "Brattsberg"));
        }

        public TrainingViewModel SelectedTraining
        {
            get { return _selectedTraining; }
            set
            {
                if (Equals(value, _selectedTraining)) return;
                _selectedTraining = value;
                OnPropertyChanged();
            }
        }

        public ActiveTrainingViewModel ActiveTraining
        {
            get { return _activeTraining; }
            set
            {
                if (Equals(value, _activeTraining)) return;
                _activeTraining = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand => new RelayCommand<Pivot>(Register);

        public void Register(Pivot pivot)
        {
            ActiveTraining = new ActiveTrainingViewModel(SelectedTraining);
            pivot.SelectedItem = pivot.Items[0];
        }

        public ICommand AddStepsCommand => new RelayCommand(AddSteps);

        private async void AddSteps()
        {
            var stackpanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            stackpanel.Children.Add(new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 14,
                Text = "antall:"
            });
            stackpanel.Children.Add(new TextBox
            {
                Margin = new Thickness(7, 0, 0, 0)
            });

            var dialog = new ContentDialog
            {
                Content = stackpanel,
                Title = "Registrer skritt",
                IsPrimaryButtonEnabled = true,
                IsSecondaryButtonEnabled = true,
                PrimaryButtonText = "Registrer",
                SecondaryButtonText = "Avbryt"
            };

            var result = await dialog.ShowAsync();
        }

        public ObservableCollection<TrainingViewModel> Items { get; } = new ObservableCollection<TrainingViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}