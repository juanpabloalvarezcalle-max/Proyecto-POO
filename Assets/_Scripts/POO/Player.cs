using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character, IDaniable
{
    void Awake()
    {
        SetVida(100);
        SetDefensa(20);
        SetDanio(10);
        AgregarHabilidad(new Habilidad(50, "Espadazo", 1));
        AgregarHabilidad(new Habilidad(30, "Puñetazo", 1));
    }

    public override void Morir()
    {
        SceneManager.LoadScene("Pantalla Muerte");
    }
}