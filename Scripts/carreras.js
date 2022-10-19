
document.addEventListener('DOMContentLoaded', () => {
    document.getElementsByName("CarreraSeleccionada")[0]
        .addEventListener("change", () => {
            document.forms.formularioCarrera.submit();
        })
}, false);