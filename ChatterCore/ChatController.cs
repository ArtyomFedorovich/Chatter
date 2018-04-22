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
    private Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser> connectedUsers;
    public ChatController()
    {
      networkController = new P2PNetworkController();
      connectedUsers = networkController.ConnectToNetwork();
    }

    public Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo> GetConnectedUsersMap()
    {
      throw new NotImplementedException();
    }
    public void SaveConnectedUsersToFile()
    {

    }
  }
}
