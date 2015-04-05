using System;
using System.Linq;

namespace Crexta.Live.masterpages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.copyrightLabel.Text = "Copyright © 2011-" + DateTime.Now.Year.ToString() + " Crexta Framework - Version " + Utilities.Version.LiveVersion;
        }
    }
}