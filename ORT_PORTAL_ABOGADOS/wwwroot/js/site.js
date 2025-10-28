// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function mostrarLogin() {
    let formulario = document.getElementById('formularioLogin');
    let icono = document.getElementById('iconoUsuario');

    icono.addEventListener('click', function () {
        formulario.style.display = "block";
    });

}
window.onload = mostrarLogin;

function validarLogin() {
    let formulario = document.getElementById('formularioLogin');

    formulario.addEventListener('submit', function () {
    });

}