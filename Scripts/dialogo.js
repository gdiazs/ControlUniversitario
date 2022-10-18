function dialogo(dialogoId, llamado) {
    var este = this;

    var dialogo = document.getElementById(dialogoId);
    dialogo.addEventListener('show.bs.modal', evento => {
        dialogo.getElementsByClassName("modal-title")[0].textContent = evento.relatedTarget.getAttribute("dialogo-titulo");
        dialogo.getElementsByClassName("dialogo-mensaje")[0].textContent = evento.relatedTarget.getAttribute("dialogo-mensaje");
        este.relatedTarget = evento.relatedTarget;
    });

    dialogo.getElementsByClassName("btn-action")[0].addEventListener("click", (e) => {
        llamado(este.relatedTarget.getAttribute("dialogo-datos"));
    })

}