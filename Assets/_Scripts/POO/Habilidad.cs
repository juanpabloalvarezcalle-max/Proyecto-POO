using UnityEngine;

public class Habilidad
{
    private int danio;
    private string efecto;

    private int coolDownActual = 0;
    private int coolDownMax;



    public Habilidad(int danio, string efecto, int coolDownMax)
    {
        this.danio = danio;
        this.efecto = efecto;

        this.coolDownMax = coolDownMax;

    }

    public int GetDanio()
    {
        return danio;
    }

    public string GetEfecto()
    {
        return efecto;
    }

    public int GetCoolDownActual()
    {
        return coolDownActual;
    }

    public int GetCoolDownMax()
    {
        return coolDownMax;
    }

    public void UsarHabilidad()
    {
        coolDownActual = coolDownMax;
    }

    public void ReducirCoolDown()
    {
        if (coolDownActual > 0)
        {
            coolDownActual--;
        }
    }

    public bool EstaDisponible()
    {
        return coolDownActual == 0;
    }


}

