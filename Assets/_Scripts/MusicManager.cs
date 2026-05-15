using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [Header("Música por escena")]
    [SerializeField] private AudioClip musicaEscenaPrincipal;
    [SerializeField] private AudioClip musicaCombate;

    private AudioSource audioSource;

    void Awake()
    {
        // Singleton: que solo exista uno y no se destruya al cambiar de escena
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.loop = true;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip clipDeseado = null;

        if (scene.name == "EscenaPrincipal")
        {
            clipDeseado = musicaEscenaPrincipal;
        }
        else if (scene.name == "Escena de Combate 1")
        {
            clipDeseado = musicaCombate;
        }

        // Solo cambiar si es una canción diferente
        if (clipDeseado != null && audioSource.clip != clipDeseado)
        {
            audioSource.clip = clipDeseado;
            audioSource.Play();
        }
    }
}
