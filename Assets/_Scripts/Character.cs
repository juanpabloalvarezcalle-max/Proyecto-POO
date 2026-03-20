using Unity.Mathematics;

using UnityEngine;


public class Character : MonoBehaviour
{
    private int vida;
    private int defensa;
    private int danio;
    private string habilidad;


    public Character(int vida, int defensa, int danio, string habilidad)
    {
        this.vida = vida;
        this.defensa = defensa;
        this.danio = danio;
        this.habilidad = habilidad;
    }

    public int GetVida()
    {
        return vida;
    }

    public void SetVida(int nuevaVida)
    {
        math.clamp(nuevaVida, 0, 100);
        Morir();
    }

    public int GetDefensa()
    {
        return defensa;
    }



    public void SetDefensa(int nuevaDefensa)
    {
        vida = math.clamp(nuevaDefensa, 0, 100);
    }




    public void AcerDanio()
    {

        danio = danio - defensa;
    }
    public void RecibirDanio(int danioEntrante)
    {
        int danioReal = math.clamp(danioEntrante - defensa, 0, 100);
        SetVida(vida - danioReal);

    }



    public void Morir()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

}
