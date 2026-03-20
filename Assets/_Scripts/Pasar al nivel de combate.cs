using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarAlNivelDeCombate : MonoBehaviour
{
    private bool jugadorEnRango = false;

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
            SceneManager.LoadScene("Escena de Combate 1");
        }
    }
}
