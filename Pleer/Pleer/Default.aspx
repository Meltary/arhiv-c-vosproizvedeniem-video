<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pleer._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/Style.css" />
    <link rel="stylesheet" type="text/css" href="/css/tcal.css" />
	<script type="text/javascript" src="/Scripts/tcal.js"></script> 
    <script type="text/javascript" src="/Scripts/JavaScript1.js"></script> 
</head>
<body onload="Clear()">
    <form id="form1" runat="server">
        <a class='exit' href='Services.aspx'>Выход</a>
        <div class="wrapper">
            <div class="btn">
                <p>
                    Камера:
                </p>
                <p>
                    <select size="1" name="camera" class="cam" id="Camera">
                    <option disabled selected></option>
                    <%
                        foreach (String cam in SelectCamera())
                        {
                            Response.Write(String.Format(@"
                                <option value='{0}'>{0}</option>",
                                cam));
                        }
                    %>
                   </select>
                </p>
                <p>
                    Дата и время начала:
                </p>
                <p>
                    <input type="text" name="date" class="tcal" id="dateBegin" 
                    value="" />
                    <input type="text" class="time" id="timeBegin"
                    value="" />
                </p>
                <p>
                    Дата и время окончания:
                </p>
                <p>
                    <input type="text" name="date" class="tcal" id="dateEnd" value="" />
                    <input type="text" class="time" id="timeEnd" value="" />
                </p>
                <span></span>
                <div>
                    <a href="#" class="button fill" title="Добавить файл" onclick="Filtr()">Фильтр</a>
                    <a href="#" class="button fill" title="Добавить файл" onclick="Clear()">Очистить</a>
                </div>
            </div>

			<div class="table-wrapper">
				<table class="table-overflow">
					<thead>
						<tr>
							<th>Камера</th>
							<th>Время начала</th>
							<th>Время окончания</th>
						</tr>
					</thead>
					<tbody id="vote_status">                         
					</tbody>
				</table>
			</div>

			<div class="another-wrapper" id="frame">
                <video id='videoarea' width='100%' height='100%'>
                </video>
			</div>
		</div>

    </form>
</body>
</html>
