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

function validarDatos() {
    return validarMail() && validarPassword();
}

function validarMail() {
    const emailInput = document.getElementById("mailCliente");
    const email = emailInput.value;
    if (!email.includes("@") || (!email.endsWith(".com") && !email.endsWith(".ar")) || email.length > 74 || email.length < 16) {
        alert("Por favor, ingrese un correo electrónico válido.");
        return false;
    }
    return true;
}

function validarPassword() {
    const passwordInput = document.getElementById("passwordCliente");
    const password = passwordInput.value;
    if (password.length < 6 || password.length > 18 || !/[A-Z]/.test(password) || !/[0-9]/.test(password)) {
        alert("La contraseña debe tener entre 6 y 18 caracteres, contener al menos un número y una mayúscula.");
        return false;
    }
    return true;
}

document.addEventListener("DOMContentLoaded", function () {
    function activarTogglePassword(checkboxId, inputId) {
        const checkbox = document.getElementById(checkboxId);
        const input = document.getElementById(inputId);

        if (!checkbox || !input) return;

        checkbox.addEventListener("change", function () {
            input.type = checkbox.checked ? "text" : "password";
        });
    }
    activarTogglePassword("mostrarPass", "contrasena");
    activarTogglePassword("mostrarPassCliente", "passwordCliente");
});

