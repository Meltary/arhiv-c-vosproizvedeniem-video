var nextVideo;

function getXmlHttp() {
    var xmlhttp;
    try {
        xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
    } catch (e) {
        try {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        } catch (E) {
            xmlhttp = false;
        }
    }
    if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
        xmlhttp = new XMLHttpRequest();
    }
    return xmlhttp;
}

//запрос серверу
function Get(element, adress, zapros) {
    // (1) создать объект для запроса к серверу
    var req = getXmlHttp();

    // (2)
    // span рядом с кнопкой
    // в нем будем отображать ход выполнения
    var statusElem = document.getElementById(element);

    req.onreadystatechange = function () {
        // onreadystatechange активируется при получении ответа сервера

        if (req.readyState == 4) {
            // если запрос закончил выполняться

            statusElem.innerHTML = req.statusText; // показать статус (Not Found, ОК..)

            if (req.status == 200) {
                // если статус 200 (ОК) - выдать ответ пользователю

                statusElem.innerHTML = req.responseText;
                if (element == 'frame') {
                    NextVideoFun();
                }
            }
            // тут можно добавить else с обработкой ошибок запроса
        }

    }

    // (3) задать адрес подключения
    req.open('POST', adress, true);
    req.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    // объект запроса подготовлен: указан адрес и создана функция onreadystatechange
    // для обработки ответа сервера

    // (4)// отослать запрос
    req.send(zapros);

    // (5)
    if (element != 'frame') {
        statusElem.innerHTML = 'Ожидаю ответа сервера...';
    }

}

// фильтр
function Filtr() {

    Get('vote_status', '/Models/WebForm1.aspx', 'dateBegin=' + document.getElementById('dateBegin').value + ' \
        &timeBegin=' + document.getElementById('timeBegin').value + ' \
        &dateEnd=' + document.getElementById('dateEnd').value + ' \
        &timeEnd=' + document.getElementById('timeEnd').value + ' \
        &Camera=' + document.getElementById('Camera').value);
}

//очищение
function Clear() {

    var now = new Date();

    document.getElementById('dateBegin').value = (now.getDate()-1) +"-" + (now.getMonth()+1) + "-" + now.getFullYear();
    document.getElementById('timeBegin').value = now.getHours() + ":" + now.getMinutes();
    document.getElementById('dateEnd').value = now.getDate() + "-" + (now.getMonth()+1) + "-" + now.getFullYear();
    document.getElementById('timeEnd').value = now.getHours() + ":" + now.getMinutes();;
    document.getElementById('Camera').value = "";

    Get('vote_status', '/Models/WebForm1.aspx', 'dateBegin=' + document.getElementById('dateBegin').value + ' \
        &timeBegin=' + document.getElementById('timeBegin').value + ' \
        &dateEnd=' + document.getElementById('dateEnd').value + ' \
        &timeEnd=' + document.getElementById('timeEnd').value + ' \
        &Camera=' + document.getElementById('Camera').value);
}

//выбор видео для просмотра
function SelectVideo(video) {
    var str = video.textContent.replace(/\s+/g, "|");
    var arr = str.split('|');

    Get('frame', '/Models/Frame.aspx', 'dateBegin=' + arr[2] + ' \
        &timeBegin=' + arr[3] + ' \
        &dateEnd=' + arr[4] + ' \
        &timeEnd=' + arr[5] + ' \
        &Camera=' + arr[1]);

    for (i = 0; i < video.parentElement.childElementCount; i++) {
        video.parentElement.children[i].style.background = '#fff';
    }
    video.style.background = '#f7f7f7 linear-gradient(#f7f7f7, #f1f1f1)';
    nextVideo = video.nextElementSibling;
}

//следующее видео
function NextVideoFun() {
    var videoPlayer = document.getElementById('videoarea');
    videoPlayer.onended = function () {
        SelectVideo(nextVideo);
        //videoPlayer.src = nextVideo;
    }
}








