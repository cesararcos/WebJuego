let jugador1 = window.juegoConfig.jugador1;
let jugador2 = window.juegoConfig.jugador2;

let turno = 1; // 1 = jugador1, 2 = jugador2
let ronda = 1;

let movimientoJugador1 = null;
let movimientoJugador2 = null;

$(document).ready(function () {

    actualizarTurnoVisual();

    $("#btnMovimiento").click(registrarMovimiento);
});

function registrarMovimiento() {

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

        // Pasamos turno al jugador 2
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

        // Ambos jugadores ya eligieron → cerrar ronda
        cerrarRonda();

        $("#selectMovimiento").val("");
    }
}

function cerrarRonda() {

    let ganador = determinarGanador(movimientoJugador1, movimientoJugador2);

    let li = document.createElement("li");
    li.classList.add("list-group-item");

    li.innerHTML = `
        <strong>Ronda ${ronda}:</strong>  
        ${jugador1}: <em>${movimientoJugador1}</em> | 
        ${jugador2}: <em>${movimientoJugador2}</em>  
        → <strong>${ganador}</strong>
    `;

    $("#listaResultados").append(li);

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
