var httpRequestStatus;
var timestep = 1000;
const debug = false;
var clicked = false;
var selected;
const consoleVersion = "v1.4";

function init() {
    "use strict";
    document.body.onmousedown = mouseDown;
    document.body.onmouseup = mouseUp;
    document.getElementById("consoleVersion").innerHTML += " " + consoleVersion;
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
    if (!clicked) {
        if (!httpRequestStatus || httpRequestStatus.readyState === 0) {
            httpRequestStatus = getRequest();
            try {
                httpRequestStatus.open("GET", "http://" + self.location.hostname + ":12369/log.html", true);
                httpRequestStatus.onreadystatechange = done;
                httpRequestStatus.send(null);
            } catch (e) {
                alert(e);
            }
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

function mouseDown() {
    clicked = true;
    onClickHandler();
}

function mouseUp() {
    if (document.getSelection().toString().length > 0 && !selected)
    {
        selected = true;
    }
    else {
        selected = false;
        clicked = false;
    }
    onClickHandler();
}

function onClickHandler() {
    if (debug) {
        var logo = document.getElementsByClassName("logo")[0];
        if (logo) {
            logo.style.color = (clicked ? "red" : "yellow");
        }
    }
}