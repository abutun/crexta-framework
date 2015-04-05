using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

using Crexta.DataBase;
using Crexta.Utilities;
using Crexta.Common.XML;

namespace Crexta.Live.ws
{
    /// <summary>
    /// Summary description for Api
    /// </summary>
    [WebService(Namespace = "http://crexta.com/ws/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Api : System.Web.Services.WebService
    {
        private static readonly int DEFAULT_HOUR_RANGE = 24;
        private static readonly int MAXIMUM_HOUR_RANGE = 48;

        /// <summary>
        /// Belirtilen bir şirketin erişim iznine sahip olduğu Crextor sonuçlarına erişim sağlar
        /// </summary>
        /// <param name="companyId">Şirket ID</param>
        /// <param name="key">Şirkete ait gizli anahtar</param>
        /// <param name="hour">Şu andan itibaren kaç saat öncesine ait sonuçlara ulaşmak istiyorsunuz? 0 değeri son 24 saate ait sonuçları döndürür</param>
        /// <returns>Belirli bir formata ait XML dökümanı</returns>
        [WebMethod]
        public XmlDocument GetAllResults(int companyId, string key, int hour)
        {
            String remoteIP = HttpContext.Current.Request.UserHostAddress;
            if (remoteIP.Equals("::1"))
                remoteIP = "127.0.0.1";

            // Create XML Document and send it to user
            XmlDocument resultXmlDoc = new XmlDocument();

            XmlElement rootElement = resultXmlDoc.CreateElement("rules");
            XmlElement resultElement = resultXmlDoc.CreateElement("result");

            XmlNode resultCode = resultXmlDoc.CreateNode(XmlNodeType.Element, "code", "");
            resultCode.InnerText = "0";
            XmlNode resultMessage = resultXmlDoc.CreateNode(XmlNodeType.Element, "message", "");
            resultMessage.InnerText = "No errors.";

            if (companyId > 0)
            {
                if (hour <= 0 || hour > MAXIMUM_HOUR_RANGE)
                    hour = DEFAULT_HOUR_RANGE;

                try
                {
                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        // check secret key
                        var acc = (from ca in db.Companies
                                   where ca.Id == companyId && ca.SecretKey == key
                                   select ca).SingleOrDefault();

                        if (acc != null)
                        {
                            // key ok, get the results
                            DateTime filterDate = DateTime.Now.AddHours(hour * -1);

                            var crextors = from ra in db.ResultAccesses
                                           where ra.CompanyId == companyId && ra.Ip == remoteIP
                                           select new { ra.CrextorId };

                            if (crextors.Count()>0)
                            {
                                int i = 0;
                                foreach (var crextor in crextors)
                                {
                                    var results = from res in db.Results
                                                  where res.CrextorId == crextor.CrextorId && (res.Date.CompareTo(filterDate) > 0 || res.LastUpdate.CompareTo(filterDate) > 0)
                                                  select new { res.Result1 };

                                    if (results != null)
                                    {
                                        foreach (var result in results)
                                        {
                                            XmlNode currentNode = result.Result1.GetXmlNode();

                                            if (currentNode.HasChildNodes)
                                                rootElement.AppendChild(resultXmlDoc.ImportNode(currentNode.FirstChild, true));

                                            i++;
                                        }
                                    }
                                }

                                if (i == 0)
                                {
                                    resultCode.InnerText = "1";
                                    resultMessage.InnerText = "No results!";
                                }
                            }
                            else
                            {
                                resultCode.InnerText = "2";
                                resultMessage.InnerText = "Could not find any matching access result Crextors!";
                            }
                        }
                        else
                        {
                            resultCode.InnerText = "3";
                            resultMessage.InnerText = "Secret key is invalid or company not found!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    resultCode.InnerText = "4";
                    resultMessage.InnerText = ex.Message;
                }
            }
            else
            {
                resultCode.InnerText = "5";
                resultMessage.InnerText = "Company not found!";
            }

            resultElement.AppendChild(resultCode);
            resultElement.AppendChild(resultMessage);

            rootElement.AppendChild(resultElement);
            resultXmlDoc.AppendChild(rootElement);

            return resultXmlDoc;
        }

        [WebMethod]
        public XmlDocument GetCrextorResults(int companyId, int crextorId, string key, int hour)
        {
            String remoteIP = HttpContext.Current.Request.UserHostAddress;
            if (remoteIP.Equals("::1"))
                remoteIP = "127.0.0.1";

            // Create XML Document and send it to user
            XmlDocument resultXmlDoc = new XmlDocument();

            XmlElement rootElement = resultXmlDoc.CreateElement("rules");
            XmlElement resultElement = resultXmlDoc.CreateElement("result");

            XmlNode resultCode = resultXmlDoc.CreateNode(XmlNodeType.Element, "code", "");
            resultCode.InnerText = "0";
            XmlNode resultMessage = resultXmlDoc.CreateNode(XmlNodeType.Element, "message", "");
            resultMessage.InnerText = "No errors.";

            if (companyId > 0)
            {
                if (hour <= 0 || hour > MAXIMUM_HOUR_RANGE)
                    hour = DEFAULT_HOUR_RANGE;

                try
                {
                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        // check secret key
                        var acc = (from ca in db.Companies
                                   where ca.Id == companyId && ca.SecretKey == key
                                   select ca).SingleOrDefault();

                        if (acc != null)
                        {
                            // key ok, get the results
                            DateTime filterDate = DateTime.Now.AddHours(hour * -1);

                            var crextors = from ra in db.ResultAccesses
                                           where ra.CompanyId == companyId && ra.Ip == remoteIP
                                           && ra.CrextorId == crextorId
                                           select new { ra.CrextorId };

                            if (crextors.Count() > 0)
                            {
                                var results = from res in db.Results
                                              where res.CrextorId == crextorId && (res.Date.CompareTo(filterDate) > 0 || res.LastUpdate.CompareTo(filterDate) > 0)
                                              select new { res.Result1 };

                                int i = 0;
                                if (results != null)
                                {
                                    foreach (var result in results)
                                    {
                                        XmlNode currentNode = result.Result1.GetXmlNode();

                                        if (currentNode.HasChildNodes)
                                            rootElement.AppendChild(resultXmlDoc.ImportNode(currentNode.FirstChild, true));

                                        i++;
                                    }
                                }

                                if (i == 0)
                                {
                                    resultCode.InnerText = "1";
                                    resultMessage.InnerText = "No results!";
                                }
                            }
                            else
                            {
                                resultCode.InnerText = "2";
                                resultMessage.InnerText = "Could not find any matching access result Crextors!";
                            }
                        }
                        else
                        {
                            resultCode.InnerText = "3";
                            resultMessage.InnerText = "Secret key is invalid or company not found!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    resultCode.InnerText = "4";
                    resultMessage.InnerText = ex.Message;
                }
            }
            else
            {
                resultCode.InnerText = "4";
                resultMessage.InnerText = "Company not found!";
            }

            resultElement.AppendChild(resultCode);
            resultElement.AppendChild(resultMessage);

            rootElement.AppendChild(resultElement);
            resultXmlDoc.AppendChild(rootElement);

            return resultXmlDoc;
        }

        [WebMethod]
        public XmlDocument GetGroupResults(int companyId, int groupid, string key, int hour)
        {
            String remoteIP = HttpContext.Current.Request.UserHostAddress;
            if (remoteIP.Equals("::1"))
                remoteIP = "127.0.0.1";

            // Create XML Document and send it to user
            XmlDocument resultXmlDoc = new XmlDocument();

            XmlElement rootElement = resultXmlDoc.CreateElement("rules");
            XmlElement resultElement = resultXmlDoc.CreateElement("result");

            XmlNode resultCode = resultXmlDoc.CreateNode(XmlNodeType.Element, "code", "");
            resultCode.InnerText = "0";
            XmlNode resultMessage = resultXmlDoc.CreateNode(XmlNodeType.Element, "message", "");
            resultMessage.InnerText = "No errors.";

            if (companyId > 0)
            {
                if (hour <= 0 || hour > MAXIMUM_HOUR_RANGE)
                    hour = DEFAULT_HOUR_RANGE;

                try
                {
                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        // check secret key
                        var acc = (from ca in db.Companies
                                   where ca.Id == companyId && ca.SecretKey == key
                                   select ca).SingleOrDefault();

                        if (acc != null)
                        {
                            // key ok, get the results
                            DateTime filterDate = DateTime.Now.AddHours(hour * -1);

                            var crextors = from ra in db.ResultAccesses
                                           where ra.CompanyId == companyId && ra.Ip == remoteIP
                                           && ra.Crextor.GroupId == groupid
                                           select new { ra.CrextorId };

                            if (crextors.Count() > 0)
                            {
                                int i = 0;
                                foreach (var crextor in crextors)
                                {
                                    var results = from res in db.Results
                                                  where res.CrextorId == crextor.CrextorId && (res.Date.CompareTo(filterDate) > 0 || res.LastUpdate.CompareTo(filterDate) > 0)
                                                  select new { res.Result1 };

                                    if (results != null)
                                    {
                                        foreach (var result in results)
                                        {
                                            XmlNode currentNode = result.Result1.GetXmlNode();

                                            if (currentNode.HasChildNodes)
                                                rootElement.AppendChild(resultXmlDoc.ImportNode(currentNode.FirstChild, true));

                                            i++;
                                        }
                                    }
                                }

                                if (i == 0)
                                {
                                    resultCode.InnerText = "1";
                                    resultMessage.InnerText = "No results!";
                                }
                            }
                            else
                            {
                                resultCode.InnerText = "2";
                                resultMessage.InnerText = "Could not find any matching access result Crextors!";
                            }
                        }
                        else
                        {
                            resultCode.InnerText = "3";
                            resultMessage.InnerText = "Secret key is invalid or company not found!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    resultCode.InnerText = "4";
                    resultMessage.InnerText = ex.Message;
                }
            }
            else
            {
                resultCode.InnerText = "5";
                resultMessage.InnerText = "Company not found!";
            }

            resultElement.AppendChild(resultCode);
            resultElement.AppendChild(resultMessage);

            rootElement.AppendChild(resultElement);
            resultXmlDoc.AppendChild(rootElement);

            return resultXmlDoc;
        }
    }
}
