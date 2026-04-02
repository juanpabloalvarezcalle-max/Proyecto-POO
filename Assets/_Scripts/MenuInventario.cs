using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class MenuInventario : MonoBehaviour {
    [Header("Referencias")]
    [SerializeField] private RectTransform itemContainer;

    [Header("Tama�os")]
    [SerializeField] private Vector2 collapsedSize;
    [SerializeField] private Vector2 expandedSize = new Vector2(360f, 420f);

    [Header("Animacion")]
    [SerializeField] private float animationDuration = 0.2f;

    private RectTransform rectTransform;
    private Button button;
    private bool isOpen;
    private Coroutine animRoutine;

    public Player jugador;

    private void Awake() {
        collapsedSize = GetComponent<RectTransform>().sizeDelta;

        rectTransform = GetComponent<RectTransform>();
        button = GetComponent<Button>();

        if (itemContainer != null) {
            itemContainer.gameObject.SetActive(false);
        }

        rectTransform.sizeDelta = collapsedSize;
        isOpen = false;
    }

    [SerializeField] GameObject botonesDeAtaque, botonInvTexto;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {

            if (isOpen) {
                botonesDeAtaque.SetActive(true);
                botonInvTexto.SetActive(true);
            } else {
                botonesDeAtaque.SetActive(false);
                botonInvTexto.SetActive(false);
            }
            CuadrarEstado(!isOpen);
        }
    }


    const bool ABRIR = true, CERRAR = false;
    public void BotonMenuEnSi() {
        button.enabled = false;
        CuadrarEstado(ABRIR);
    }
    public void BotonItemMenu() {
        button.enabled = true;
        CuadrarEstado(CERRAR);
    }

    public void CuadrarEstado(bool open) {
        isOpen = open;

        if (animRoutine != null) {
            StopCoroutine(animRoutine);
        }

        animRoutine = StartCoroutine(Animateeee(open));
        Debug.Log("Check");
    }

    private IEnumerator Animateeee(bool abiertocerrado) {
        if (!abiertocerrado && itemContainer != null) {
            itemContainer.gameObject.SetActive(false);
        }

        Vector2 startSize = rectTransform.sizeDelta;
        Vector2 targetSize = abiertocerrado ? expandedSize : collapsedSize;

        float elapsed = 0f;

        while (elapsed < animationDuration) {
            elapsed += Time.unscaledDeltaTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);

            rectTransform.sizeDelta = Vector2.Lerp(startSize, targetSize, t);

            yield return null;
        }

        rectTransform.sizeDelta = targetSize;

        if (abiertocerrado && itemContainer != null) {
            itemContainer.gameObject.SetActive(true);
        }

        animRoutine = null;
    }


    /// Funciones de las posiones individuales
    /// 

    public void item1() {
        jugador.SetVida(jugador.GetVida() + 30);
    }
    public void item2() {
        jugador.SetVida(jugador.GetVida() + 50);
    }
    public void item3() {
        jugador.SetDanio(jugador.GetDanio() + 10);
    }
    public void item4() {
        jugador.SetDanio(jugador.GetDanio() + 15);
    }
    public void item5() {
        jugador.SetDanio(jugador.GetDanio() + 20);
    }

}