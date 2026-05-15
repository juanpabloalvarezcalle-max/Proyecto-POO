using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Barras de Vida")]
    [SerializeField] private Slider sliderJugador;
    [SerializeField] private Slider sliderEnemigo;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegistrarJugador(Player jugador)
    {
        sliderJugador.minValue = 0f;
        sliderJugador.maxValue = 1f;
        sliderJugador.value = 1f;
        jugador.OnVidaCambiada += ActualizarBarraJugador;
    }

    public void RegistrarEnemigo(Enemigo enemigo)
    {
        sliderEnemigo.minValue = 0f;
        sliderEnemigo.maxValue = 1f;
        sliderEnemigo.value = 1f;
        enemigo.OnVidaCambiada += ActualizarBarraEnemigo;
    }

    private void ActualizarBarraJugador(int vidaActual, int vidaMaxima)
    {
        sliderJugador.value = (float)vidaActual / vidaMaxima;
    }

    private void ActualizarBarraEnemigo(int vidaActual, int vidaMaxima)
    {
        sliderEnemigo.value = (float)vidaActual / vidaMaxima;
    }
}
