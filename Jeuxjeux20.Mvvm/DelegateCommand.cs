using System;
using System.Windows;
using System.Windows.Input;

namespace Jeuxjeux20.Mvvm
{
    public class DelegateCommand<T> : ICommand
    {
        public DelegateCommand(Action<T> action, Func<T, bool> canExecute = null)
        {
            ActionToExecute = action;
            if (canExecute != null) CanExecuteAction = canExecute;
        }

        public DelegateCommand(Action act, Func<T, bool> canExecute = null) : this(_ => act(), canExecute)
        {
        }

        public DelegateCommand(Action act, Func<bool> canExecute) : this(act, _ => canExecute())
        {
        }

        public Action<T> ActionToExecute { get; set; }
        public Func<T, bool> CanExecuteAction { get; set; } = o => true;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (parameter is T p)
            {
                return CanExecuteAction(p);
            }

            return CanExecuteAction(default);
        }

        public void Execute(object parameter)
        {
            if (parameter is T p)
            {
                ActionToExecute(p);
            }
            else
            {
                ActionToExecute(default);
            }
        }

        public virtual void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

    }

    public class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(Action<object> action, Func<object, bool> canExecute = null) : base(action, canExecute)
        {
        }

        public DelegateCommand(Action act, Func<object, bool> canExecute = null) : base(act, canExecute)
        {
        }

        public DelegateCommand(Action act, Func<bool> canExecute) : base(act, canExecute)
        {
        }
    }
}