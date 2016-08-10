using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pleer.Models
{
    public partial class Frame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String OpenVideo()
        {
            //Camera ProCamera = new Camera(Request.Form[0], DateTime.Parse(Request.Form[1] + " " + Request.Form[2]), DateTime.Parse(Request.Form[3] + " " + Request.Form[4]));
            String ProCamera = "#";

            SqlConnection connection = new SqlConnection(Global.connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            connection.Open();
            cmd.CommandText = @"SELECT file_name FROM Archive 
WHERE date_beg = '" + DateTime.Parse(Request.Form[0]).ToString("dd-MM-yyyy") + " " + Request.Form[1].Trim() + "' and date_end = '" + DateTime.Parse(Request.Form[2]).ToString("dd-MM-yyyy") + " " + Request.Form[3].Trim() + "' and id_cam = '192.168.110." + Request.Form[4].Substring(Request.Form[4].Length - 1) + "' ";


            var Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                ProCamera = (String)Reader["file_name"];
            }

            Reader.Close();
            connection.Close();

            //найти файл по номеру, дате и времени
                        
            return ProCamera.Substring(2);
        }
    }
}