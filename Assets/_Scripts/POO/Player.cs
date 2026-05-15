using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character, IDaniable
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null) animator = GetComponentInChildren<Animator>();

        SetVida(100);
        SetDefensa(15);
        SetDanio(15);
        AgregarHabilidad(new Habilidad(35, "Golpe de mandoble", 2));
        AgregarHabilidad(new Habilidad(20, "Golpe de pomo", 1));
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
        SceneManager.LoadScene("Pantalla Muerte");
    }
}