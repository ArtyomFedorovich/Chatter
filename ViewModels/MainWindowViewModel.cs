using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPeersChatter
{
  public class MainWindowViewModel : BaseViewModel
  {
    public ObservableCollection<string> ConnectedUsers { get; set; }

    public MainWindowViewModel()
    {
      // Get connected users.
      // Instantiate listview.
      ConnectedUsers = new ObservableCollection<string>();
      ConnectedUsers.Add("Hello");
      ConnectedUsers.Add("World");
      // Commands.
    }
  }
}
