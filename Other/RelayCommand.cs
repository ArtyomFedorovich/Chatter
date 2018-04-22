using System;
using System.Windows.Input;

namespace LocalPeersChatter
{
  /// <summary>
  /// A basic command that runs an Action
  /// </summary>
  public class RelayCommand : ICommand
  {
    #region Private Members

    /// <summary>
    /// The action to run
    /// </summary>
    private Action action;
    private Action<object> actionWithParam;
    #endregion

    #region Public Events

    /// <summary>
    /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
    /// </summary>
    public event EventHandler CanExecuteChanged = (sender, e) => { };

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    public RelayCommand(Action action)
    {
      this.action = action;
    }
    public RelayCommand(Action<object> actionWithParam)
    {
      this.actionWithParam = actionWithParam;
    }

    #endregion

    #region Command Methods

    /// <summary>
    /// A relay command can always execute
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public bool CanExecute(object parameter)
    {
      return true;
    }

    /// <summary>
    /// Executes the commands Action
    /// </summary>
    /// <param name="parameter"></param>
    public void Execute(object parameter)
    {
      if (parameter != null)
      {
        actionWithParam(parameter);
      }
      else
      {
        action();
      }
    }
    public void Execute()
    {
      action();
    }

    #endregion
  }
}