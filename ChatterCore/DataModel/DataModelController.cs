using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatterCore
{
  public class DataModelController
  {
    private ResourceManager resourceManager = new ResourceManager("ChatterCore.Properties.Resources", 
      Assembly.GetExecutingAssembly());;
    
    public Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo>
      GetConnectedToNetworkUsersMap()
    {
      string connectedUsersInfo = resourceManager.GetString(AssemblyInfo.CONNECTED_USERS_FILE_NAME);
      List<ChatterUser> connectedUsers = ParseConnectedUsersInfoFromString(connectedUsersInfo);
      var usersMap = new Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo>();
      foreach (var user in connectedUsers)
      {
        usersMap.Add(user.UserChatterInfo.Id, user.UserChatterInfo);
      }
      return usersMap;
    }
    public void SetConnectedToNetworkUsers(Dictionary<ChatterUser.ChatterUserChatterInfo.ID, 
      ChatterUser.ChatterUserChatterInfo> connectedUsers)
    {
      string connectedUsersInfo = resourceManager.GetString(AssemblyInfo.CONNECTED_USERS_FILE_NAME);
      connectedUsersInfo += "\r\n";
      connectedUsersInfo += 
    }

    private List<ChatterUser> ParseConnectedUsersInfoFromString(string connectedUsersInfo)
    {
      List<ChatterUser> connectedUsers = new List<ChatterUser>();

      // Parse lines
      string[] usersInfo = connectedUsersInfo.Split(new char[]{ '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (var user in usersInfo)
      {
        // Parse info items
        string[] infoItems = user.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        
        // Hardcode info
        string idKey = infoItems[0].Substring(0, infoItems[0].IndexOf(':'));
        string idValue = infoItems[0].Substring(infoItems[0].IndexOf(':') + 1, infoItems[0].Length - idKey.Length - 1);

        string ipKey = infoItems[1].Substring(0, infoItems[1].IndexOf(':'));
        string ipValue = infoItems[1].Substring(infoItems[1].IndexOf(':') + 1, infoItems[1].Length - idKey.Length - 1);

        string portKey = infoItems[2].Substring(0, infoItems[2].IndexOf(':'));
        string portValue = infoItems[2].Substring(infoItems[2].IndexOf(':') + 1, infoItems[2].Length - idKey.Length - 1);

        string statusKey = infoItems[3].Substring(0, infoItems[3].IndexOf(':'));
        string statusValue = infoItems[3].Substring(infoItems[3].IndexOf(':') + 1, infoItems[3].Length - idKey.Length - 1);
        // Set users
        ChatterUser newUser = new ChatterUser();
        try
        {
          // Set id
          if (idKey == "userid")
          {
            newUser.UserChatterInfo.Id.FromString(idValue);
          }
          else
          {
            throw new Exception();
          }
          // Set ip
          if (ipKey == "userip")
          {
            newUser.UserChatterInfo.UserSocket.Address = IPAddress.Parse(ipValue);
          }
          else
          {
            throw new Exception();
          }
          // Set port
          if (portKey == "userport")
          {
            newUser.UserChatterInfo.UserSocket.Port = int.Parse(portValue);
          }
          else
          {
            throw new Exception();
          }
          // Set status
          if (statusKey == "userstatus")
          {
            newUser.UserChatterInfo.Status = (ConnectionStatus)Enum.Parse(typeof(ConnectionStatus), statusValue);
          }
          else
          {
            throw new Exception();
          }
        } catch(Exception ex)
        {
          throw new Exception();
        }
        connectedUsers.Add(newUser);
      }
      return connectedUsers;
    }
    private string ParseConnectedUsersInfoFromMap(Dictionary<ChatterUser.ChatterUserChatterInfo.ID, 
      ChatterUser.ChatterUserChatterInfo> connectedUsers)
    {
      string info = string.Empty;
      foreach (var user in connectedUsers)
      {
        info += "userid:" + user.Key + ",userip:" + user.Value.UserSocket.Address + ",userport:" + user.Value.UserSocket.Port
          + ",userstatus:" + user.Value.Status.ToString();
        info += "\r\n";
      }
      return info;
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
