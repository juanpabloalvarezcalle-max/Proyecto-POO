using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{


    [SerializeField] private bool cargarEscenaAlTerminar = false;
    [SerializeField] private string nombreEscena;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject interactuableObj;
    private IInteractuable interactuable;

    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialoguesLines;

    private float typingTime = 0.05f;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    public bool textoTerminado;

    // Update is called once per frames
    void Awake()
    {
        interactuable = interactuableObj.GetComponent<IInteractuable>();
    }   
    
    void Update()
    {
    if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
    {
        if (!didDialogueStart)
        {
            interactuable.Interactuar();
        }
        else if (textoTerminado)
        {
            NextDialogueLine();
        }
    }
}

   public void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        //dialogueMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(Showline());
    }

    private void NextDialogueLine()
{
    lineIndex++;
    if (lineIndex < dialoguesLines.Length)
    {
        StartCoroutine(Showline());
    }
    else
    {
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
        if (cargarEscenaAlTerminar)
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}

private IEnumerator Showline()
{
    textoTerminado = false;
    dialogueText.text = string.Empty;

    foreach (char ch in dialoguesLines[lineIndex])
    {
        dialogueText.text += ch;
        yield return new WaitForSeconds(typingTime);
    }

    textoTerminado = true;
}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            // dialogueMark.SetActive(true);

        }


    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            //dialogueMark.SetActive(false);

        }


    }

    public void TextoTerminado()
    {

    }

}
