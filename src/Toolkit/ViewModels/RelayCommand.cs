using System;
using System.Windows.Input;

namespace Toolkit.ViewModels
{
    /// <summary>
    /// Class implementing ICommand interface for simplified implementation of commands
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged = delegate
        {
            // IT'S DOESN'T WORK FOR UWP PROJECT!!!

            //add => CommandManager.RequerySuggested += value;
            //remove => CommandManager.RequerySuggested -= value;
        };

        /// <summary>
        /// The constructor of the command accepts the delegate of the execution method and the delegate of the condition for the execution of the command
        /// </summary>
        /// <param name="execute">One-argument execution method delegate</param>
        /// <param name="canExecute">The delegate of the command execution condition that returns the Boolean value of the command execution ability</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }

    /// <summary>
    /// Generic class implementing ICommand interface for simplified implementation of commands
    /// </summary>
    /// <typeparam name="T">The type of object for which the command is executed</typeparam>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public event EventHandler CanExecuteChanged = delegate
        {
            // IT'S DOESN'T WORK FOR UWP PROJECT!!!

            //add => CommandManager.RequerySuggested += value;
            //remove => CommandManager.RequerySuggested -= value;
        };

        /// <summary>
        /// The constructor of the command accepts the delegate of the execution method and the delegate of the condition for the execution of the command
        /// </summary>
        /// <param name="execute">One-argument execution method delegate</param>
        /// <param name="canExecute">The delegate of the command execution condition that returns the Boolean value of the command execution ability</param>
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            execute((T)parameter);
        }
    }
}