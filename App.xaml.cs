using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ChatterCore;

namespace LocalPeersChatter
{
  /// <summary>
  /// Логика взаимодействия для App.xaml
  /// </summary>
  public partial class App : Application
  {
    private Dictionary<ChatterUser.ChatterUserChatterInfo.ID, ChatterUser.ChatterUserChatterInfo> connectedUsersMap;
    private ChatController chatController;
    private WindowService windowService;
    public App()
    {
      windowService = new WindowService();
      chatController = new ChatController();

      connectedUsersMap = chatController.GetConnectedUsersMap();
    }
  }
}
