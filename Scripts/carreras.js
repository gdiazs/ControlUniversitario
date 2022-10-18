
document.addEventListener('DOMContentLoaded', () => {
    document.getElementsByName("Carrera")[0]
        .addEventListener("change", () => {
            document.forms.formularioCarrera.submit();
        })
}, false);