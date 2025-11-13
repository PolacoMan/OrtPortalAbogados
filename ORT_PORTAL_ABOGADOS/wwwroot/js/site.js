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
//function setPrecio() {
//    let btnsSetPrecio = document.getElementsByClassName('btn-precio');
//    let precios = document.getElementsByName('precio');
//    let aceptarBtns = document.getElementsByClassName('btn-aceptar');

//    for (let i = 0; i < btnsSetPrecio.length; i++) {
//        btnsSetPrecio[i].addEventListener('click', function (e) {
//            e.preventDefault();
//            let precio = precios[i].value;
//            if (precio && parseInt(precio) > 0) {
//                aceptarBtns[i].style.display = "inline-block";
//            }
//        });
//    }
//}

document.addEventListener("DOMContentLoaded", function () {
    let formsPrecio = document.querySelectorAll('.form-precio');

    formsPrecio.forEach(form => {
        form.addEventListener('submit', function (e) {
            e.preventDefault();

            let precioInput = form.querySelector('input[name="precio"]');
            let precio = precioInput.value;

            if (!precio || parseFloat(precio) <= 0) {
                alert("Debe ingresar un precio válido");
                return;
            }

            // Encontramos el form de aceptar en la misma fila
            let aceptarForm = form.closest('tr').querySelector('.form-aceptar');
            if (aceptarForm) {
                aceptarForm.querySelector('.input-precio-hidden').value = precio;
                aceptarForm.style.display = "inline-block";
            }
        });
    });
});

window.onload = function () {
    mostrarLogin();
};