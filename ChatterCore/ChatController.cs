using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ChatterCore
{
  public class ChatController
  {
    private DataModelController dataModelController;
    private P2PNetworkController networkController;
    private Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser> connectedUsers;
    public ChatController()
    {
      dataModelController = new DataModelController();
      networkController = new P2PNetworkController(dataModelController.GetConnectedToNetworkUsersMap());
      connectedUsers = networkController.ConnectToNetwork();
    }

    public Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo> ConnectToNetwork()
    {
      // Get Connected Users Map from P2PNetwork controller
      // Save to file
      throw new NotImplementedException();
    }
  }
}
