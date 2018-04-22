using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Window
{
  Auth,
  Chatter,
  OpenFile
}

namespace LocalPeersChatter
{
  public class WindowService
  {
    #region Window Threads
    public BaseViewModel MainWindowViewModel { get; set; }
    #endregion

    public void OpenWindow(Window type)
    {
      if (type == Window.Auth)
      {
        throw new NotImplementedException();
      }
      else if (type == Window.Chatter)
      {
        throw new NotImplementedException();
      }
      else if (type == Window.OpenFile)
      {
        throw new NotImplementedException();
      }
    }
    #region Open Specified Window
    private void OpenAuthWindow()
    {
      throw new NotImplementedException();
    }
    private void OpenChatterWindow()
    {
      throw new NotImplementedException();
    }
    private void OpenOpenFileWindow()
    {
      throw new NotImplementedException();
    }
    #endregion
  }
}
