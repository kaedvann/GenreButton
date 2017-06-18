using System;
using System.Windows.Input;

namespace GenreButton
{
	public class DelegateCommand : ICommand
	{
		private readonly Predicate<object> _canExecute;
		private readonly Action<object> _execute;

		public event EventHandler CanExecuteChanged;

		public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public DelegateCommand(Action execute, Predicate<object> canExecute = null) 
			: this(o => execute(), canExecute)
		{
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}

}