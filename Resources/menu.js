// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function (event) {
    if (getCookie("MenuState") == ""  )  setCookie("MenuState", "CLOSED", 365)
    
    if (getCookie("MenuState") == "OPEN") openMenu();

    showNavbar()

    const linkColor = document.querySelectorAll('.nav_link')

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'))
            this.classList.add('active')
        }
    }
    linkColor.forEach(l => l.addEventListener('click', colorLink))

});

function showNavbar() {
    const toggle = document.getElementById('icon-toggle')
    toggle.addEventListener('click', toggleAll)

    const otoggle = document.getElementById('debug-menu')
    otoggle.addEventListener('click', openMenu)
}

function toggleAll() {
    if (getCookie("MenuState") == "CLOSED") {
        openMenu();
    } else {
        closeMenu();
    }
}

function openMenu() {
    toggle = document.getElementById('header-toggle')
    nav = document.getElementById('nav-bar')
    bodypd = document.getElementById('{BODY_ID}')

    bodypd.classList.add('{BODY_ID}')
    toggle.classList.remove('{ICONRIGHT}')
    toggle.classList.add('{ICONLEFT}')
    nav.classList.add('show')
    setCookie("MenuState", "OPEN", 365)
}

function closeMenu() {
    toggle = document.getElementById('header-toggle')
    nav = document.getElementById('nav-bar')
    bodypd = document.getElementById('{BODY_ID}')

    bodypd.classList.remove('{BODY_ID}')
    toggle.classList.add('{ICONRIGHT}')
    toggle.classList.remove('{ICONLEFT}')
    nav.classList.remove('show')
    setCookie("MenuState", "CLOSED", 365)
}