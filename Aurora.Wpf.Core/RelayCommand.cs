using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Aurora.Wpf.Core
{
    public class RelayCommand : ICommand
    {
        #region Fields
        private readonly Action<object>? m_Execute;
        private readonly Predicate<object>? m_CanExecute;
        #endregion // Fields 
        #region Constructors

        public RelayCommand(Action<object> execute, Predicate<object>? canExecute = null)
        {
            m_Execute = execute ?? throw new ArgumentNullException(nameof(execute)); m_CanExecute = canExecute;
        }
        #endregion // Constructors 
        #region ICommand Members 
        [DebuggerStepThrough]
        public bool CanExecute(object? parameter)
        {
            return parameter != null && (m_CanExecute?.Invoke(parameter) ?? true);
        }
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public void Execute(object? parameter)
        {
            if (parameter != null) m_Execute?.Invoke(parameter);
        }
        #endregion 
    }
}
