// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function mostrarLogin() {
    let formulario = document.getElementById('formularioLogin');
    let cerrar = document.getElementById('cancelar');

    document.getElementById('iconoUsuario').onclick = function () {
        if (!window.usuarioLogueado) {
            formulario.style.display = "block";
        } else {
            alert("Ya iniciaste sesión.");
        }
    };

    cerrar.onclick = function () {
        formulario.style.display = "none";
    };
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

            let aceptarForm = form.closest('tr').querySelector('.form-aceptar');
            if (aceptarForm) {
                aceptarForm.querySelector('.input-precio-hidden').value = precio;
                aceptarForm.style.display = "inline-block";
            }
        });
    });
});

document.addEventListener('DOMContentLoaded', function () {

    document.querySelectorAll('.ocultar').forEach(boton => {

        boton.addEventListener('click', function () {

            let fila = this.closest('.solicitud');
            fila.style.display = 'none';

        });

    });

});



window.onload = function () {
    mostrarLogin();
};

const formularioLogin = document.getElementById("formularioLogin");
const btnCancelar = document.getElementById("cancelar");

if (btnAbrirLogin) {
    btnAbrirLogin.addEventListener("click", function (e) {

        if (window.usuarioLogueado) {
            e.preventDefault();
            alert("Ya iniciaste sesión.");
            return;
        }

        formularioLogin.style.display = "block";
    });
}

if (btnCancelar) {
    btnCancelar.addEventListener("click", function () {
        formularioLogin.style.display = "none";
    });
}

if (window.usuarioLogueado) {
    if (formularioLogin) {
        formularioLogin.style.display = "none";
    }
}

document.addEventListener("DOMContentLoaded", function () {

    const formLogin = document.getElementById("formularioLogin");

    formLogin.addEventListener("submit", function (e) {
        formLogin.submit();
    });
});
