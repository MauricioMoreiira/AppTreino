function OpenMenu(action) {

    if (action === "Treino") {
        window.location = "./Treino?idTreino=".concat("0").concat("&idInstrutor=").concat("3");
    }

    if (action == "ConsultaAtleta") {
        window.location = "./ConsultaAtleta?idAtleta=".concat("0").concat("&idInstrutor=").concat("3");
    }

    if (action.toLowerCase() == "index") {
        window.location = "./index";
    }

    if (action.toLowerCase() === "ConsultaTreinoAtleta") {
        window.location = "./ConsultaTreinoAtleta";
    }
}
