using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        // Restaurar posición si venimos de una pelea (antes de que corra cualquier otra cosa)
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            transform.position = new Vector3(x, y, transform.position.z);
            Debug.Log("Posición restaurada a: " + x + ", " + y);

            // Limpiar para no reaplicar en reinicios normales
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.Save();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // El input se sigue leyendo en Update (es donde debe leerse)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        movement = new Vector2(moveX, moveY);
    }

    void FixedUpdate()
    {
        // El movimiento físico va aquí, sincronizado con la física de Unity
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}