using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckCookieSupport();

    }

    //This method checks support for cookies
    private void CheckCookieSupport()
    {
        // Cookie detection.
        // Is our cookie not yet set and the url parameter empty? If so, lets set the cookie.
        if (HttpContext.Current.Session["CookieCheck"] == null && HttpContext.Current.Request.QueryString["c"] == null)
        {
            // Set the cookie and redirect so we can try to detect it.
            HttpContext.Current.Session["CookieCheck"] = "1";
            HttpContext.Current.Response.Redirect("~/default.aspx?c=1", true);

            return;
        }
        else
        {
            // Detect the cookie.
            if (Session["CookieCheck"] == null || Session["CookieCheck"].ToString() != "1")
            {
                // Cookies are disabled
                HttpContext.Current.Response.Redirect("~/NoCookies.aspx", true);
                return;
            }
            else
            {
                HttpContext.Current.Response.Write("Ok, your browser supports cookies.");
            }
        }
    }
}
