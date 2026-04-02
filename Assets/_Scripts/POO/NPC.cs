using UnityEngine;

public class NPC : Character, IInteractuable
{
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

    public void Interactuar()
    {
        Debug.Log("El NPC está interactuando con el jugador.");
    }
}
