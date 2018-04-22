using System.ComponentModel;

namespace LocalPeersChatter
{
  /// <summary>
  /// Base class for view models.
  /// </summary>
  public class BaseViewModel : INotifyPropertyChanged
  {
    /// <summary>
    /// Event, invoked when custom properties are changed.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Helper method for view model's properties that invokes PropertyChanged.
    /// </summary>
    public void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
