using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatterCore
{
  public class P2PNetworkController
  {
    public Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo> connectedUsersMap;

    private ChatterUser currentUser;
    public P2PNetworkController(Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo> connectedUsersMap)
    {
      this.connectedUsersMap = connectedUsersMap;
    }
    public Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser> ConnectToNetwork()
    {
      return new Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser>();
    }
  }
}
