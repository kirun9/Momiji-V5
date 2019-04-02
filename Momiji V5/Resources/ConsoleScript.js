var httpRequestStatus;
var timestep = 5000;

function init() {
    "use strict";
    startLoop();
}

function getRequest() {
    "use strict";
    try {
        return new ActiveXObject("Msxml2.XMLHTTP");
    } catch (e) {
        try {
            return new ActiveXObject("Microsoft.XMLHTTP");
        } catch (err) { }
    }
    if (typeof XMLHttpRequest !== "undefined") {
        return new XMLHttpRequest();
    }
    return null;
}

function startLoop() {
    "use strict";

    if (!httpRequestStatus || httpRequestStatus.readyState === 0) {
        httpRequestStatus = getRequest();
        try {
            httpRequestStatus.open("GET", "http://localhost:12369/log.html", true);
            httpRequestStatus.onreadystatechange = done;
            httpRequestStatus.send(null);
        } catch (e) {
            alert(e);
        }
    }
    setTimeout(startLoop, timestep);
}

function done() {
    if (httpRequestStatus && httpRequestStatus.readyState === 4) {
        var element = document.getElementById("LogTable");
        if (element) {
            element.innerHTML = httpRequestStatus.responseText;
        }
        httpRequestStatus = null;
    }
}