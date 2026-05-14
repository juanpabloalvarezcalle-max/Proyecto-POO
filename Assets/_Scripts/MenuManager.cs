using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelOpciones;

    public void Jugar()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }

    public void Opciones()
    {
        panelOpciones.SetActive(true);
    }

    public void Volver()
    {
        panelOpciones.SetActive(false);
    }
}