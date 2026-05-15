using UnityEngine;
using System.Collections;

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


        estadoActual = EstadoCombate.TurnoJugador;
        UIManager.Instance.RegistrarJugador(jugador);
        UIManager.Instance.RegistrarEnemigo(enemigo);

        if (UIManager.Instance == null)
            Debug.LogError("UIManager.Instance es NULL");
        else
            Debug.Log("UIManager encontrado OK");

        UIManager.Instance.RegistrarJugador(jugador);
        estadoActual = EstadoCombate.TurnoJugador;
    }

    public void AtaqueNormal()
    {
        if (estadoActual != EstadoCombate.TurnoJugador) return;

        jugador.AcerDanio(enemigo);
        jugador.AnimarAtaque();
        Debug.Log("Jugador atacó. Vida enemigo: " + enemigo.GetVida());
        estadoActual = EstadoCombate.TurnoEnemigo;
        StartCoroutine(RutinaAtaqueEnemigo());
    }
    public void usarEspadazo()
    {
        if (estadoActual != EstadoCombate.TurnoJugador) return;

        ReducirCoolDownsJugador();
        Habilidad espadazo = jugador.GetHabilidad(0);
        Debug.Log("Vida enemigo tras espadazo: " + enemigo.GetVida());

        if (espadazo.EstaDisponible())
        {
            enemigo.RecibirDanio(espadazo.GetDanio());
            espadazo.UsarHabilidad();
            jugador.AnimarAtaque();
        }
        estadoActual = EstadoCombate.TurnoEnemigo;
        StartCoroutine(RutinaAtaqueEnemigo());
    }

    public void usarPuñetazo()
    {
        if (estadoActual != EstadoCombate.TurnoJugador) return;

        ReducirCoolDownsJugador();
        Habilidad puñetazo = jugador.GetHabilidad(1);
        Debug.Log("Vida enemigo tras puñetazo: " + enemigo.GetVida());
        if (puñetazo.EstaDisponible())
        {
            enemigo.RecibirDanio(puñetazo.GetDanio());
            puñetazo.UsarHabilidad();
            jugador.AnimarAtaque();
        }
        estadoActual = EstadoCombate.TurnoEnemigo;
        StartCoroutine(RutinaAtaqueEnemigo());
    }


    private IEnumerator RutinaAtaqueEnemigo()
    {
        yield return new WaitForSeconds(1.5f);
        ataqueEnemigo();
    }

    public void ataqueEnemigo()
    {
        enemigo.GenerarHabilidadAleatoria(jugador);
        enemigo.AnimarAtaque();
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
