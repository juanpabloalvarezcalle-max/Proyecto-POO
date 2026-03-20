using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody2D rb;
    private Vector2 movement;

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