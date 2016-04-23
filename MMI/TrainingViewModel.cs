using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace MMI
{
    public class TrainingViewModel : INotifyPropertyChanged
    {
        private bool _isSelected;

        public TrainingViewModel(string name, string level, double distance, DateTime startDate, DateTime endDate, string startLocation, string endLocation)
        {
            Name = name;
            Level = level;
            Distance = distance;
            StartDate = startDate;
            EndDate = endDate;
            StartLocation = startLocation;
            EndLocation = endLocation;
        }

        public string Name { get; }
        public string StartLocation { get; }
        public string EndLocation { get; }
        public string Level { get; }
        public double Distance { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected) return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}