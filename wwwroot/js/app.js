function OpenMenu(action) {

    if (action === "Treino") {
        window.location = "./Treino?idTreino=".concat("0").concat("&idInstrutor=").concat(getCookie('idInstrutor'));
    }

    if (action == "ConsultaAtleta") {
        window.location = "./ConsultaAtleta?idAtleta=".concat("0").concat("&idInstrutor=").concat(getCookie('idInstrutor'));
    }

    if (action == "Topico") {
        window.location = "./Topico?idInstrutor=".concat(getCookie('idInstrutor'));
    }

    if (action == "ConsultaTreinoAtleta") {
        window.location = "./ConsultaTreinoAtleta";
    }

    if (action.toLowerCase() == "index") {
        window.location = "./index";
    }

    if (action === "ConsultaTreinoAtleta") {
        window.location = "./ConsultaTreinoAtleta";
    }

    if (action === "Login") {
        deleteCookie('idInstrutor')
        window.location = "./index";
    }
}

function ShowMessage(mensagem) {
    const obj = JSON.parse(mensagem);
    switch (obj.MessageType) {
        case 0:
            window.Notiflix.Report.success(
                obj.Title,
                obj.Message,
                "Ok"
            );
            break;
        case 1:
            window.Notiflix.Report.failure(
                obj.Title,
                obj.Message,
                "Ok"
            );
            break;
        case 2:
            window.Notiflix.Report.warning(
                obj.Title,
                obj.Message,
                "Ok"
            );
            break;
        case 3:
            window.Notiflix.Report.info(
                obj.Title,
                obj.Message,
                "Ok"
            );
    }
}

function ShowError(error) {
    const obj = JSON.parse(error);
    window.Notiflix.Report.warning(
        obj.Title,
        obj.Message,
        "Ok"
    );
}

function ShowErrorGen(error) {
    window.Notiflix.Report.warning(
        'Erro',
        error,
        "Ok"
    );
}

function RedirectAction(action) {
    window.location.href = action;
}

function setCookie(cName, cValue) {

    document.cookie = cName + "=" + cValue + ";" ;
}

function getCookie(cName) {
    const name = cName + "=";
    const cDecoded = decodeURIComponent(document.cookie); //to be careful
    const cArr = cDecoded.split('; ');
    let res;
    cArr.forEach(val => {
        if (val.indexOf(name) === 0) res = val.substring(name.length);
    })
    return res
}


function deleteAllCookies() {
    var cookies = document.cookie.split(";");

    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];
        var eqPos = cookie.indexOf("=");
        var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
        document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
}

function deleteCookie(cName) {
    const name = cName + "=";
    const cDecoded = decodeURIComponent(document.cookie); //to be careful
    const cArr = cDecoded.split('; ');
    let res;
    cArr.forEach(val => {
        if (val.indexOf(name) === 0) {
            document.cookie = name + ";expires=Thu, 01 Jan 1970 00:00:00 GMT";
        }
    })
}

function AgoraSimples() {
    var dt = new Date();
    var mm = dt.getMonth();
    var yy = dt.getFullYear();
    var dd = dt.getDate();

    return [yy,
        (mm > 9 ? '' : '0') + mm,
        (dd > 9 ? '' : '0') + dd
    ].join('-');
}

function Agora() {
    var dt = new Date();
    return dt.toISOString();
}

function date_PTtoEN(cDate) {
    var dd = cDate.substring(0, 1);
    var mm = cDate.substring(3, 4);
    var yy = cDate.substring(6, 9);
    return [yy,
        (mm > 9 ? '' : '0') + mm,
        (dd > 9 ? '' : '0') + dd
    ].join('-');
}

function validalogin() {
    var id = getCookie("idInstrutor");
    if (id == "" || id == "undefined" || id == null) {
        //location.href = "http://appplano.com.br";
        location.href = "/";

    }    
}