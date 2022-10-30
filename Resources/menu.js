// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function (event) {

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
    const toggle = document.getElementById('header-toggle')
    toggle.addEventListener('click', toggleAll)

    const otoggle = document.getElementById('debug-menu')
    otoggle.addEventListener('click', openAll)
}

function toggleAll() {
    toggle = document.getElementById('header-toggle')
    nav = document.getElementById('nav-bar')
    bodypd = document.getElementById('{{BODY_ID}}')

    if (toggle.classList.contains('fa-angles-right')) {
        toggle.classList.add('bx-x')
        bodypd.classList.add('{{BODY_ID}}')
        toggle.classList.remove('fa-angles-right')
        toggle.classList.add('fa-angles-left')
        nav.classList.add('show')
    } else {
        toggle.classList.remove('bx-x')
        bodypd.classList.remove('{{BODY_ID}}')
        toggle.classList.add('fa-angles-right')
        toggle.classList.remove('fa-angles-left')
        nav.classList.remove('show')
    }
}

function openAll() {
    toggle = document.getElementById('header-toggle')
    nav = document.getElementById('nav-bar')
    bodypd = document.getElementById('{{BODY_ID}}')

    if (toggle.classList.contains('fa-angles-right')) {
        toggle.classList.add('bx-x')
        bodypd.classList.add('{{BODY_ID}}')
        toggle.classList.remove('fa-angles-right')
        toggle.classList.add('fa-angles-left')
        nav.classList.add('show')
    }
}