$(document).ready(function () {

    $("#btnRegistrar").click(function () {

        let nombre1 = $("#txtJugador1").val();
        let nombre2 = $("#txtJugador2").val();

        if (!nombre1 || !nombre2) {
            Swal.fire("Error", "Debe ingresar ambos jugadores", "error");

            return;
        }

        $.ajax({
            url: "/Juego/RegistrarJugadores",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({
                jugador1: nombre1,
                jugador2: nombre2
            }),
            success: function (resp) {

                if (resp.success) {
                    window.location.href = resp.redirectUrl;
                } else {
                    Swal.fire("Error", "No se pudieron registrar los jugadores", "error");
                }
            },
            error: function (xhr) {
                alert("Error registrando jugadores");
            }
        });
    });

});
