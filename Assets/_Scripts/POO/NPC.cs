using UnityEngine;

public class NPC : Character, IInteractuable
{
    [SerializeField] private NewMonoBehaviourScript scriptDialogo;

    public void Interactuar()
    {
        scriptDialogo.StartDialogue();
    }
    
    void Awake()
    {
        SetVida(50);
        SetDefensa(0);
        SetDanio(0);
    }

    public override void Morir()
    {
        Destroy(gameObject);
    }

   
}
