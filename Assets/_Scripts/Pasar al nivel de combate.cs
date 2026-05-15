using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PasarAlNivelDeCombate : MonoBehaviour
{
    

    
    private bool jugadorEnRango = false;

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorEnRango = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorEnRango = false;
        }
    }

    void Update()
    {
        if (jugadorEnRango && Input.GetKeyDown(KeyCode.E))
        {
            // Guardar la posición del jugador antes de ir al combate
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
            {
                PlayerPrefs.SetFloat("PlayerPosX", jugador.transform.position.x);
                PlayerPrefs.SetFloat("PlayerPosY", jugador.transform.position.y);
                PlayerPrefs.Save();
                Debug.Log("POSICIÓN GUARDADA: " + jugador.transform.position.x + ", " + jugador.transform.position.y);
            }
            else
            {
                Debug.LogError("NO SE ENCONTRÓ JUGADOR CON TAG 'Player'");
            }

            SceneManager.LoadScene("Escena de Combate 1");
        }
    }
}
