using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : Character, IDaniable
{
    void Awake()
    {
        SetVida(200);
        SetDefensa(5);
        SetDanio(10);
        SetVidaMaxima(200);
        AgregarHabilidad(new Habilidad(40, "Golpetazo", 1));
        AgregarHabilidad(new Habilidad(60, "Ultra Golpe", 1));
    }

    public override void Morir()
    {
        SceneManager.LoadScene("EscenaPrincipal");
        Destroy(gameObject);
    }

    public void GenerarHabilidadAleatoria(Player jugador)
    {
        int numeroRandom = UnityEngine.Random.Range(0, 2);
        Habilidad habilidadElegida = GetHabilidad(numeroRandom);
        if (habilidadElegida.EstaDisponible())
        {
            habilidadElegida.UsarHabilidad();
            jugador.RecibirDanio(habilidadElegida.GetDanio());
        }
    }
}
