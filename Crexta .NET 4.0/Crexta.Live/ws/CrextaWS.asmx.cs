using System;
using System.Linq;
using System.Web;
using System.Web.Services;

using Crexta.DataBase;
using Crexta.Utilities;
using Crexta.Common.Server;

namespace Crexta.Live.ws
{
    /// <summary>
    /// Summary description for CrextaWS
    /// </summary>
    [WebService(Namespace = "http://crexta.com/ws/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CrextaWS : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetExternalIPAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        [WebMethod]
        public bool UpdateClientSoftware(string current)
        {
            bool result = false;

            //Business.Versions version = DataRepository.VersionsProvider.GetById((int)Common.Enums.VERSIONTYPES.CLIENT);
            CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
            if (db != null)
            {
                var version = (from ver in db.Versions
                               where ver.Id == 2
                               select ver).SingleOrDefault();

                if (version != null)
                {
                    if (current != version.Version1)
                        result = true;
                }
            }

            return result;
        }

        [WebMethod]
        public bool AddClientLog(long uniqueHash, string guid, string mac, short instance, string message, string exception)
        {
            bool result = false;

            CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
            if (db != null)
            {
                // Check client
                var client = (from c in db.Clients
                             where c.UniqueHash == uniqueHash && c.Guid == guid && c.Mac == mac && c.Instance == instance
                             select c).FirstOrDefault();

                if(client!=null)
                {
                    // Client is OK and connected
                    AppLog appLog = new AppLog();
                    appLog.Exception = exception;
                    appLog.Level = "INFO";
                    appLog.Thread = "CLIENT";
                    appLog.Logger = "[HASH="+ uniqueHash.ToString() +", INSTANCE:"+ instance.ToString() +", GUID:"+ guid +", MAC:"+ mac +"]";
                    appLog.Message = message;
                    appLog.Date = DateTime.Now;

                    db.AppLogs.InsertOnSubmit(appLog);
                }
                else
                {
                    // Client is not all right! Log it!
                    AppLog appLog = new AppLog();
                    appLog.Exception = "";
                    appLog.Level = "INFO";
                    appLog.Thread = "CLIENT";
                    appLog.Logger = "[HASH="+ uniqueHash.ToString() +", GUID:"+ guid +", MAC:"+ mac +"]";
                    appLog.Message = "Client wants to store some logs about itself but client is not found!";
                    appLog.Date = DateTime.Now;

                    db.AppLogs.InsertOnSubmit(appLog);
                }

                db.SubmitChanges();
            }

            return result;
        }

        [WebMethod]
        public ServerIpPort GetServerInformation(string securitykey)
        {
            ServerIpPort result = null;

            if (securitykey == Common.Constants.GeneralConstants.securityKey)
            {
                CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                if (db != null)
                {
                    var availableServers = from ser in db.Servers
                                           where ser.Active == true
                                           select ser;

                    if (availableServers != null)
                    {
                        //Get the least connected server
                        Server server = availableServers.First();

                        foreach (Server s in availableServers)
                        {
                            if (s.ClientCount < server.ClientCount)
                                server = s;
                        }

                        result = new ServerIpPort(server.ExternalIp, server.LocalIp, server.Socket);
                    }
                }
            }

            return result;
        }

        [WebMethod]
        public bool UpdateMainList(string current)
        {
            bool result = false;

            //Business.Versions version = DataRepository.VersionsProvider.GetById((int)Common.Enums.VERSIONTYPES.MAINLIST);
            CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
            if (db != null)
            {
                var version = (from ver in db.Versions
                               where ver.Id == 1
                               select ver).SingleOrDefault();

                if (version != null)
                {
                    if (current != version.Version1)
                        result = true;
                }
            }

            return result;
        }
    }
}
