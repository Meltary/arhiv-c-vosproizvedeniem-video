<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Pleer.Models.WebForm1" %>

<%      
    foreach (Pleer.Camera camera in SQL2())
    {
        Response.Write(String.Format(@"
            <tr onclick='SelectVideo(this)'>
                <td>{0}</td>
                <td>{1}</td>
                <td>{2}</td>
            </tr>",
            camera.CameraId, camera.TimeBegin + "." + camera.TimeBegin.Millisecond, camera.TimeEnd + "." + camera.TimeEnd.Millisecond));
    }
%>
