
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Player jugador;
    [SerializeField] private Enemigo enemigo;

    public enum EstadoCombate
    {
        TurnoJugador,
        TurnoEnemigo,
        FinDelCombate
    }

    private EstadoCombate estadoActual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        estadoActual = EstadoCombate.TurnoJugador;
    }

    public void AtaqueNormal()
    {
        jugador.AcerDanio(enemigo);
        Debug.Log("Jugador atacó. Vida enemigo: " + enemigo.GetVida());
        estadoActual = EstadoCombate.TurnoEnemigo;
        ataqueEnemigo();

    }
    public void usarEspadazo()
    {
        ReducirCoolDownsJugador();
        Habilidad espadazo = jugador.GetHabilidad(0);
        Debug.Log("Vida enemigo tras espadazo: " + enemigo.GetVida());

        if (espadazo.EstaDisponible())
        {
            enemigo.RecibirDanio(espadazo.GetDanio());
            espadazo.UsarHabilidad();
        }
        estadoActual = EstadoCombate.TurnoEnemigo;
        ataqueEnemigo();
    }

    public void usarPuñetazo()
    {
        ReducirCoolDownsJugador();
        Habilidad puñetazo = jugador.GetHabilidad(1);
        Debug.Log("Vida enemigo tras puñetazo: " + enemigo.GetVida());
        if (puñetazo.EstaDisponible())
        {
            enemigo.RecibirDanio(puñetazo.GetDanio());
            puñetazo.UsarHabilidad();
        }
        estadoActual = EstadoCombate.TurnoEnemigo;
        ataqueEnemigo();
    }


    public void ataqueEnemigo()
    {
        enemigo.GenerarHabilidadAleatoria(jugador);
        Debug.Log("Enemigo atacó. Vida jugador: " + jugador.GetVida());
        estadoActual = EstadoCombate.TurnoJugador;
    }

    void ReducirCoolDownsJugador()
    {
        for (int i = 0; i < 2; i++)
        {
            jugador.GetHabilidad(i).ReducirCoolDown();
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
