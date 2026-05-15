using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : Character, IDaniable, IInteractuable
{

    [SerializeField] private NewMonoBehaviourScript scriptDialogo;

    public void Interactuar()
    {
        scriptDialogo.StartDialogue();
    }

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null) animator = GetComponentInChildren<Animator>();

        SetVida(150);
        SetDefensa(8);
        SetDanio(12);
        SetVidaMaxima(150);
        AgregarHabilidad(new Habilidad(25, "Golpetazo", 1));
        AgregarHabilidad(new Habilidad(40, "Ultra Golpe", 2));
    }

    public void AnimarAtaque()
    {
        if (animator != null)
        {
            animator.SetTrigger("Ataque");
        }
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

