using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatterCore
{
  public class ChatController
  {
    private P2PNetworkController networkController;
    public ChatController()
    {
      networkController = new P2PNetworkController();
      networkController.ConnectToNetwork();
    }

    public Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo> GetConnectedUsersMap()
    {
      return networkController.GetConnectedUsersMap();
    }
    public void SaveConnectedUsersToFile()
    {

    }
  }
}
