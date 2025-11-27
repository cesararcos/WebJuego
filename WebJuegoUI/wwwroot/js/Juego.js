let jugador1 = window.juegoConfig.jugador1;
let jugador2 = window.juegoConfig.jugador2;

let turno = 1;
let ronda = 1;

let movimientoJugador1 = null;
let movimientoJugador2 = null;

let victoriasJ1 = 0;
let victoriasJ2 = 0;

$(document).ready(function () {
    actualizarTurnoVisual();

    $("#btnMovimiento").click(registrarMovimiento);

    $("#btnRevancha").hide();
    $("#btnNuevoJuego").hide();
});

function registrarMovimiento() {

    if (victoriasJ1 >= 3 || victoriasJ2 >= 3) return;

    let movimiento = $("#selectMovimiento").val();

    if (!movimiento) {
        Swal.fire("Atención", "Debes elegir una opción", "warning");
        return;
    }

    if (turno === 1) {

        movimientoJugador1 = movimiento;

        Swal.fire(
            "Movimiento registrado",
            `${jugador1} eligió: ${movimientoJugador1}`,
            "success"
        );

        turno = 2;
        actualizarTurnoVisual();

        $("#selectMovimiento").val("");

    } else {

        movimientoJugador2 = movimiento;

        Swal.fire(
            "Movimiento registrado",
            `${jugador2} eligió: ${movimientoJugador2}`,
            "success"
        );

        cerrarRonda();
        $("#selectMovimiento").val("");
    }
}

function cerrarRonda() {

    let ganador = determinarGanador(movimientoJugador1, movimientoJugador2);

    if (ganador === jugador1) victoriasJ1++;
    if (ganador === jugador2) victoriasJ2++;

    let li = document.createElement("li");
    li.classList.add("list-group-item");

    li.innerHTML = `
        <strong>Ronda ${ronda}:</strong>  
        ${jugador1}: <em>${movimientoJugador1}</em> | 
        ${jugador2}: <em>${movimientoJugador2}</em>  
        → <strong>${ganador}</strong>
        <br>
        <small>${jugador1}: ${victoriasJ1} victorias | ${jugador2}: ${victoriasJ2} victorias</small>
    `;

    $("#listaResultados").append(li);

    if (victoriasJ1 === 3 || victoriasJ2 === 3) {
        finalizarJuego();
        return;
    }

    // Reset para siguiente ronda
    ronda++;
    movimientoJugador1 = null;
    movimientoJugador2 = null;

    turno = 1;
    actualizarTurnoVisual();
}

function determinarGanador(m1, m2) {

    if (m1 === m2) return "Empate";

    if (
        (m1 === "piedra" && m2 === "tijera") ||
        (m1 === "papel" && m2 === "piedra") ||
        (m1 === "tijera" && m2 === "papel")
    ) {
        return jugador1;
    }

    return jugador2;
}

function actualizarTurnoVisual() {
    let nombreTurno = (turno === 1 ? jugador1 : jugador2);
    $("#lblTurno").html(`Turno de <strong>${nombreTurno}</strong>`);
}

function finalizarJuego() {

    let ganadorFinal = victoriasJ1 === 3 ? jugador1 : jugador2;

    Swal.fire({
        icon: "success",
        title: "¡Juego terminado!",
        html: `El ganador es <strong>${ganadorFinal}</strong>`,
        confirmButtonText: "Aceptar"
    });

    $("#btnMovimiento").prop("disabled", true);

    // Mostrar botones finales
    $("#btnRevancha").show();
    $("#btnNuevoJuego").show();
}

function revancha() {

    turno = 1;
    ronda = 1;

    victoriasJ1 = 0;
    victoriasJ2 = 0;

    movimientoJugador1 = null;
    movimientoJugador2 = null;

    $("#listaResultados").html("");
    $("#btnMovimiento").prop("disabled", false);

    $("#btnRevancha").hide();
    $("#btnNuevoJuego").hide();

    actualizarTurnoVisual();
}

function nuevoJuego() {
    window.location.href = "/Juego/Index";
}
