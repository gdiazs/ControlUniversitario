function esVacio(texto) {
    return !(texto !== null && texto.length > 0);
}


function validarCampoNoVacio(control, mensajeDeError) {
    var seccionDeError = control.name;
    var validationSpan = document.querySelector(`[data-valmsg-for="${seccionDeError}"]`);

    if (esVacio(control.value)) {
        validationSpan.classList.replace("field-validation-valid", "field-validation-error");
        validationSpan.textContent = mensajeDeError;
        return false;
    } else {
        validationSpan.textContent = "";
        validationSpan.classList.replace("field-validation-error", "field-validation-valid");
        return true;
    }
}
