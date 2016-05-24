function LoadCSS(url) {
    var s = document.createElement("LINK");
    s.rel = "stylesheet";
    s.type = "text/css";
    s.href = url;
    document.getElementsByTagName("HEAD")[0].appendChild(s);
}
function compWidth(width1) {
    if (width1 > 1366) {
        LoadCSS('../css/energy1366.css');
    }
}