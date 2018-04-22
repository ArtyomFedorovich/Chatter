using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ChatterCore
{
  public class ChatterUser
  {
    #region UserInfo Declaration
    #region Auth Info Declaration
    public enum UserAuthInfoItem
    {
      Login,
      Password
    }
    private class ChatterUserAuthInfo
    {
      private string login;
      private string password;
      public ChatterUserAuthInfo(Dictionary<UserAuthInfoItem, string> userAuthInfo)
      {
        userAuthInfo[UserAuthInfoItem.Login] = login;
        userAuthInfo[UserAuthInfoItem.Password] = password;
      }
    }
    #endregion
    #region Personal Info Declaration
    public class ChatterUserPersonalInfo
    {

    }
    #endregion
    #region Chatter Info Declaration
    public class ChatterUserChatterInfo
    {
      public class ID
      {
        private int length = 10;
        private string value;
        public ID()
        {
          value = GenerateUserId();
        }
        private string GenerateUserId()
        {
          throw new NotImplementedException();
        }
        public override string ToString()
        {
          return value;
        }
      }

      public ID Id { get; private set; } = new ID();
      public IPEndPoint UserSocket { get; private set; }
    }
    #endregion
    #endregion

    #region Private Info
    private ChatterUserAuthInfo userAuthInfo;
    #endregion

    #region Public Info
    public ChatterUserChatterInfo UserChatterInfo { get; private set; }
    public ChatterUserPersonalInfo UserPersonalInfo { get; private set; }
    #endregion

    #region Controller
    private DataModelController dataModelController;
    #endregion

    #region ChatterUser Constructor
    public ChatterUser()
    {
      dataModelController = new DataModelController();

      userAuthInfo = new ChatterUserAuthInfo(dataModelController.ProvideUserAuthInfo());
      UserChatterInfo = dataModelController.ProvideUserChatterInfo();
      UserPersonalInfo = dataModelController.ProvideUserPersonalInfo();
    }
    #endregion
  }
}
