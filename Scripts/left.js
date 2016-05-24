function showdiv_item(sid) {
    whichEl = eval("div_item" + sid);
    if (whichEl.style.display == "none") {
        eval("div_item" + sid + ".style.display=\"\";");
    }
    else {
        eval("div_item" + sid + ".style.display=\"none\";");
    }
}
