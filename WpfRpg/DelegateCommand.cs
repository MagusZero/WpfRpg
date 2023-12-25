namespace BlackOmen.WpfRpg;

using System;
using System.Windows.Input;

/// <summary>
/// A simple command implementation using a delegate.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DelegateCommand"/> class.
/// </remarks>
/// <param name="execute">
/// The action to execute when the command is executed.
/// </param>
/// <param name="canExecute">
/// Determines whether the command can be executed.
/// </param>
public class DelegateCommand(Action execute, Func<bool>? canExecute = null)
	: ICommand
{
	private readonly Action execute = execute;
	private readonly Func<bool>? canExecute = canExecute;

	/// <inheritdoc/>
	public event EventHandler? CanExecuteChanged;

	/// <inheritdoc/>
	public bool CanExecute(object? parameter) => this.canExecute?.Invoke() ?? true;

	/// <inheritdoc/>
	public void Execute(object? parameter) => this.execute?.Invoke();
}

/// <summary>
/// A simple command implementation using a delegate.
/// </summary>
/// <typeparam name="T">
/// The type of parameter this command acts on.
/// </typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
/// </remarks>
/// <param name="execute">
/// The action to execute when the command is executed.
/// </param>
/// <param name="canExecute">
/// Determines whether the command can be executed.
/// </param>
public class DelegateCommand<T>(Action<T?> execute, Func<T?, bool>? canExecute = null)
	: ICommand
{
	private readonly Action<T?> execute = execute;
	private readonly Func<T?, bool>? canExecute = canExecute;

	/// <inheritdoc/>
	public event EventHandler? CanExecuteChanged;

	/// <inheritdoc/>
	public bool CanExecute(object? parameter) => this.canExecute?.Invoke((T?)parameter) ?? true;

	/// <inheritdoc/>
	public void Execute(object? parameter) => this.execute?.Invoke((T?)parameter);
}
