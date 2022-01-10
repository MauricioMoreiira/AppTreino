function OpenMenu(action) {
    if (action.toLowerCase() === "AddTopico") {
        RedirectAction("/AddTopico");
    }

    if (action.toLowerCase() === "ConsultaTreino") {
        RedirectAction("/ConsultaTreino");
    }

    if (action.toLowerCase() === "ConsultaTreinoAtleta") {
        RedirectAction("/ConsultaTreinoAtleta");
    }

    if (action.toLowerCase() === "Index") {
        RedirectAction("/Index");
    }
}

