"use strict";
// TODO: Put menu state into cookie , and retrieve on re-entry

$(document).ready(function () {

    var hamburger = document.getElementById("hamburger");

    hamburger.addEventListener("click", function () {
        document.querySelector("body").classList.toggle("active");
    });

});
