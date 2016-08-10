using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.SqlClient;


namespace Pleer
{
    public partial class _Default : System.Web.UI.Page
    {
        protected List<String> SelectCamera()
        {
            List<String> SelCamera = new List<String>();
            SqlConnection connection = new SqlConnection(Global.connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            connection.Open();
            cmd.CommandText = @"SELECT DISTINCT [id_cam] FROM [Archive]";

            var Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {
                SelCamera.Add("Камера-" + ((string)Reader["id_cam"]).Trim().Substring(((string)Reader["id_cam"]).Trim().Length-1));
            }

            Reader.Close();
            connection.Close();

            return SelCamera;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public class Camera
    {
        public string CameraId { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }

        public Camera(string _CameraId, DateTime _TimeBegin, DateTime _TimeEnd) {
            CameraId = _CameraId;
            TimeBegin = _TimeBegin;
            TimeEnd = _TimeEnd;
        }
    }


}