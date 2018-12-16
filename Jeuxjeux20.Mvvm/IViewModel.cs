using System.ComponentModel;

namespace Jeuxjeux20.Mvvm
{
    public interface IViewModel<out T> : INotifyPropertyChanged
    {
        T Model { get; }
    }
}