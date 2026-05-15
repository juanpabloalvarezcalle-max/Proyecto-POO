using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelOpciones;
    public GameObject panelControles;

    public void Jugar()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }

    public void Opciones()
    {
        panelOpciones.SetActive(true);
        panelControles.SetActive(false);
    }

    public void Controles()
    {
        panelControles.SetActive(true);
        panelOpciones.SetActive(false);
    }

    public void Volver()
    {
        panelOpciones.SetActive(false);
        panelControles.SetActive(false);
    }
}