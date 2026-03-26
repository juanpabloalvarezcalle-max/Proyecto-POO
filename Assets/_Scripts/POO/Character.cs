using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Character : MonoBehaviour
{
    private int vida = 0;
    private int defensa = 0;
    private int danio = 0;

    private int vidaMaxima = 100;

    private List<Habilidad> habilidades = new List<Habilidad>();






    public int GetVida()
    {
        return vida;
    }

    public void SetVida(int nuevaVida)
    {
        if (nuevaVida > vidaMaxima)
            vida = vidaMaxima;
        else if (nuevaVida < 0)
            vida = 0;
        else
            vida = nuevaVida;

        if (vida <= 0)
            Morir();
    }

    public int GetDefensa()
    {
        return defensa;
    }



    public void SetDefensa(int nuevaDefensa)
    {
        defensa = math.clamp(nuevaDefensa, 0, 100);
    }

    public int GetDAnio()
    {
        return danio;
    }

    public void SetDanio(int nuevoDanio)
    {
        danio = nuevoDanio;
    }



    public void AcerDanio(Character enemigo)
    {

        enemigo.RecibirDanio(danio);
    }
    public void RecibirDanio(int danioEntrante)
    {
        int danioReal = math.clamp(danioEntrante - defensa, 0, 100);
        SetVida(vida - danioReal);

    }



    public virtual void Morir()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AgregarHabilidad(Habilidad habilidad)
    {
        habilidades.Add(habilidad);
    }



    public Habilidad GetHabilidad(int index)
    {
        return habilidades[index];
    }


    public void SetVidaMaxima(int nuevaVidaMaxima)
    {
        vidaMaxima = nuevaVidaMaxima;
    }
}
