<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frame.aspx.cs" Inherits="Pleer.Models.Frame" %>
<%      
    String camera = OpenVideo();
    Response.Write(String.Format(@"
            <video id='videoarea' src={0} type='video/x-matroska' controls autoplay width='100%' height='100%'>
            </video>",
            camera));
%>
