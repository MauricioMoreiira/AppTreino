function OpenMenu(action) {

    if (action.toLowerCase() === "Index") {
        window.location = "./Index";
    }

    if (action.toLowerCase() === "ConsultaAtleta") {
        window.location = "./ConsultaAtleta";
    }

    if (action.toLowerCase() === "AddTopico") {
        window.location = "./AddTopico";
    }

    if (action.toLowerCase() === "ConsultaTreinoAtleta") {
        window.location = "./ConsultaTreinoAtleta";
    }
}
