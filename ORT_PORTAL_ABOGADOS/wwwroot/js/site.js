// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function mostrarLogin() {
    let formulario = document.getElementById('formularioLogin');
    let icono = document.getElementById('iconoUsuario');
    let cerrar = document.getElementById('cancelar');

    icono.addEventListener('click', function () {
        formulario.style.display = "block";
    });

    cerrar.addEventListener('click', function () {
        formulario.style.display = "none";
    });
}
window.onload = mostrarLogin;


