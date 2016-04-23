using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace MMI
{
    public class ActiveTrainingViewModel : INotifyPropertyChanged
    {
        public ActiveTrainingViewModel(TrainingViewModel training)
        {
            Training = training;
        }

        public TrainingViewModel Training { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}