using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private int vida = 0;
    private int defensa = 0;
    private int danio = 0;
    private int vidaMaxima = 100;
    private List<Habilidad> habilidades = new List<Habilidad>();

    public int GetVida() { return vida; }

    public void SetVida(int nuevaVida)
    {
        if (nuevaVida > vidaMaxima) vida = vidaMaxima;
        else if (nuevaVida < 0) vida = 0;
        else vida = nuevaVida;

        if (vida <= 0) Morir();
    }

    public int GetDefensa() { return defensa; }
    public void SetDefensa(int nuevaDefensa) { defensa = math.clamp(nuevaDefensa, 0, 100); }
    public int GetDanio() { return danio; }
    public void SetDanio(int nuevoDanio) { danio = nuevoDanio; }
    public void SetVidaMaxima(int nuevaVidaMaxima) { vidaMaxima = nuevaVidaMaxima; }

    public void AcerDanio(Character enemigo) { enemigo.RecibirDanio(danio); }

    public void RecibirDanio(int danioEntrante)
    {
        int danioReal = math.clamp(danioEntrante - defensa, 0, 100);
        SetVida(vida - danioReal);
    }

    public void AgregarHabilidad(Habilidad habilidad) { habilidades.Add(habilidad); }
    public Habilidad GetHabilidad(int index) { return habilidades[index]; }

    public abstract void Morir();
}
