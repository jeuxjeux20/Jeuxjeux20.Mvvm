using System;
using System.Windows;

namespace Jeuxjeux20.Mvvm
{
    public class WpfDelegateCommand<T> : DelegateCommand<T>
    {
        public WpfDelegateCommand(Action<T> action, Func<T, bool> canExecute = null) : base(action, canExecute)
        {
        }

        public WpfDelegateCommand(Action act, Func<T, bool> canExecute = null) : base(act, canExecute)
        {
        }

        public WpfDelegateCommand(Action act, Func<bool> canExecute) : base(act, canExecute)
        {
        }

        public sealed override void RaiseCanExecuteChanged()
        {
            if (Application.Current.Dispatcher.CheckAccess())
            {
                base.RaiseCanExecuteChanged();
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() => base.RaiseCanExecuteChanged()));
            }
        }
    }
    public class WpfDelegateCommand : DelegateCommand<object>
    {
        public WpfDelegateCommand(Action<object> action, Func<object, bool> canExecute = null) : base(action, canExecute)
        {
        }

        public WpfDelegateCommand(Action act, Func<object, bool> canExecute = null) : base(act, canExecute)
        {
        }

        public WpfDelegateCommand(Action act, Func<bool> canExecute) : base(act, canExecute)
        {
        }
    }
}