function OpenMenu(action) {

    if (action.toLowerCase() === "Index") {
        RedirectAction("/Index");
    }

    if (action.toLowerCase() === "Login") {
        RedirectAction("/Login");
    }
}
