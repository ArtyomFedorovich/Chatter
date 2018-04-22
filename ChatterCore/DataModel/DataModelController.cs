using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatterCore
{
  public class DataModelController
  {
    public Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo>
      GetConnectedToNetworkUsersMap()
    {
      throw new NotImplementedException();
    }

    public Dictionary<ChatterUser.UserAuthInfoItem, string> ProvideUserAuthInfo()
    {
      throw new NotImplementedException();
    }
    public ChatterUser.ChatterUserChatterInfo ProvideUserChatterInfo()
    {
      throw new NotImplementedException();
    }
    public ChatterUser.ChatterUserPersonalInfo ProvideUserPersonalInfo()
    {
      throw new NotImplementedException();
    }
  }
}
