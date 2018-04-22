using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatterCore
{
  public class P2PNetworkController
  {
    private DataModelController dataModelController;
    public Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo> ConnectedUsersMap { get; }

    private ChatterUser currentUser;
    public P2PNetworkController()
    {
      dataModelController = new DataModelController();
      ConnectedUsersMap = dataModelController.GetConnectedToNetworkUsersMap();

    }
    public void ConnectToNetwork()
    {
      throw new NotImplementedException();
    }

    public Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo> GetConnectedUsersMap()
    {
      return ConnectedUsersMap;
    }
  }
}
