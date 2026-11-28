using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace EndPoint.Site.Extensions
{
    public static class WebControlExtensions
    {
        public static void ShowError(this System.Web.UI.WebControls.Label lbl, string message)
        {
            lbl.Text = message;
            lbl.ForeColor = Color.Red;
        }
    }
}