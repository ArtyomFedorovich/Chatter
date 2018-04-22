using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Net;


namespace ChatterCore
{
  public class XmlPacketFormatter
  {
    private XmlDocument document;
    private const string bodyElementName = "LocalPeersChatter";
    private const string connectionElementName = "connection";
    private const string statusElementName = "status";
    private const string detailsElementName = "details";
    private const string contentElementName = "content";
    private const string usersListElementName = "users";
    private const string userInfoElementName = "userinfo";
    private const string enumToStringFormatter = "d";


    public XmlPacketFormatter()
    {
      FormTemplate();
    }

    private void FormTemplate()
    {
      // Create header
      XmlDocument doc = new XmlDocument();
      XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
      XmlElement root = doc.DocumentElement;
      doc.InsertBefore(xmlDeclaration, root);

      // Body attachment
      XmlElement bodyElement = doc.CreateElement(string.Empty, bodyElementName, string.Empty);
      doc.AppendChild(bodyElement);

      // Append connetion, status, details elements
      XmlElement connectionElement = doc.CreateElement(string.Empty, connectionElementName, string.Empty);
      XmlElement statusElement = doc.CreateElement(string.Empty, statusElementName, string.Empty);
      XmlElement detailsElement = doc.CreateElement(string.Empty, detailsElementName, string.Empty);
      bodyElement.AppendChild(connectionElement);
      bodyElement.AppendChild(statusElement);
      bodyElement.AppendChild(detailsElement);

      // Append content element
      XmlElement contentElement = doc.CreateElement(string.Empty, contentElementName, string.Empty);
      bodyElement.AppendChild(contentElement);

      document = doc;
    }

    public XmlDocument AddStatusValue(ConnectionStatus statusValue)
    {
      XmlElement status = document.GetElementsByTagName(statusElementName)[0] as XmlElement;
      status.SetAttribute("value", statusValue.ToString(enumToStringFormatter));
      return document;
    }
    public XmlDocument AddUserInfo(ChatterUser.ChatterUserChatterInfo.ID senderId, IPAddress senderIp)
    {
      XmlDocument doc = document.Clone() as XmlDocument;
      XmlElement details = document.GetElementsByTagName(detailsElementName)[0] as XmlElement;
      details.SetAttribute("id", senderId.ToString());
      details.SetAttribute("ipaddress", senderIp.ToString());
      return document;
    }
    public XmlDocument AddContentUsersList(List<ChatterUser> users)
    {
      XmlElement content = document.GetElementsByTagName(contentElementName)[0] as XmlElement;
      XmlElement usersList = document.CreateElement(string.Empty, usersListElementName, string.Empty);
      foreach (var user in users)
      {
        XmlElement userInfo = document.CreateElement(string.Empty, userInfoElementName, string.Empty);
        // Create elements for provided user info
        userInfo.SetAttribute("id", user.UserChatterInfo.Id.ToString());
        userInfo.SetAttribute("ipaddress", user.UserChatterInfo.UserSocket.Address.ToString());
        /////////////////////////////////////////
        usersList.AppendChild(userInfo);
      }
      content.AppendChild(usersList);
      return document;
    }
  }
}
