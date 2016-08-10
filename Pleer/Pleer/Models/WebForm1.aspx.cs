using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pleer.Models
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<Camera> ProCamera = new List<Camera>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected List<Camera> SQL2()
        {
            String dateBegin = "";
            String dateEnd = "";
            try
            {
                dateBegin = DateTime.Parse(Request.Form[0]).ToString("dd-MM-yyyy");
            }
            catch (Exception e) {
                dateBegin = DateTime.Today.ToString("dd-MM-yyyy");
            }

            try
            {
                dateEnd = DateTime.Parse(Request.Form[2]).ToString("dd-MM-yyyy");
            }
            catch (Exception e)
            {
                dateEnd = DateTime.Today.ToString("dd-MM-yyyy");
            }


            String timeBegin = Request.Form[1].Trim();
            String timeEnd = Request.Form[3].Trim();
            String Camera = Request.Form[4].Trim();

            SqlConnection connection = new SqlConnection(Global.connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            connection.Open();
            cmd.CommandText = @"SELECT Archive.date_beg, Archive.date_end, Archive.id_cam
                    FROM Archive WHERE date_beg > '" + dateBegin + " " + timeBegin + "' and date_end < '" + dateEnd + " " + timeEnd + "' ";

            if (Camera != "")
            {
                cmd.CommandText += " and Archive.id_cam = '192.168.110." + Camera.Substring(Camera.Length-1) + "' ";
            }

            cmd.CommandText += " ORDER BY date_beg DESC";

            var Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {
                string id_camera = "Камера-" + ((string)Reader["id_cam"]).Trim().Substring(((string)Reader["id_cam"]).Trim().Length - 1);
                DateTime TimeBegin = (DateTime)Reader["date_beg"];
                DateTime TimeEnd = (DateTime)Reader["date_end"];

                ProCamera.Add(new Camera(id_camera, TimeBegin, TimeEnd));
            }

            Reader.Close();
            connection.Close();

            return ProCamera;
        }
    }
}