using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Jeuxjeux20.Mvvm
{
    public abstract class PropertyChangedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(
#if !NO_CALLER_ATTRIBUTE
            [CallerMemberName]
#endif
        string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}