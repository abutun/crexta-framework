using System;
using System.Linq;
using System.Web;

namespace Crexta.Live.en
{
    public partial class Inner_en : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.copyrightLabel.Text = "Copyright © 2011-" + DateTime.Now.Year.ToString() + " Crexta Framework - Version " + Utilities.Version.LiveVersion;

            if (HttpContext.Current.Request.Url != null)
            {
                String url = HttpContext.Current.Request.Url.AbsoluteUri;
                if (url.Contains("/en/"))
                    this.languageLink.NavigateUrl = url.Replace("/en", "");
                else
                {
                    int k = url.LastIndexOf("/");
                    if (k > 0)
                        this.languageLink.NavigateUrl = url.Substring(0, k) + "/en" + url.Substring(k);
                }
            }
        }
    }
}