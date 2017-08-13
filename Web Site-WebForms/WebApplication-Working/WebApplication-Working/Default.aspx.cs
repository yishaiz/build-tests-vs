using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_Working
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            label1.Text = GetConfigSettings("Environment");
        }

        public static string GetConfigSettings(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key].ToString();
                if (value.Length == 0)
                {
                    throw new ApplicationException("key is not exists in config file");
                }
                return (value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while trying to get value from config file - " + key + ". " + ex.Message);
            }
        }
    }
}