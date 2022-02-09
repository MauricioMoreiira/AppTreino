function OpenMenu(action) {

    if (action === "Treino") {
        window.location = "./Treino?idTreino=".concat("0").concat("&idInstrutor=").concat("3");
    }

    if (action.toLowerCase() === "ConsultaAtleta") {
        window.location = "./ConsultaAtleta";
    }

    if (action.toLowerCase() == "index") {
        window.location = "./index";
    }

    if (action.toLowerCase() === "ConsultaTreinoAtleta") {
        window.location = "./ConsultaTreinoAtleta";
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

function RedirectAction(action) {
    window.location.href = action;
}

