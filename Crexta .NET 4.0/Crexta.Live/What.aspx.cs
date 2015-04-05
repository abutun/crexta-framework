using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Crexta.Live
{
    public partial class WhatIs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control control = this.Master.FindControl("topLinkWhat");
            if (control != null)
            {
                HtmlGenericControl topLink = (HtmlGenericControl)control;
                topLink.Attributes.Add("class", "menu_active");
            }
        }
    }
}