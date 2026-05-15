using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Objetivo")]
    [SerializeField] private Transform jugador;

    [Header("Límites del mapa")]
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float minY = -10f;
    [SerializeField] private float maxY = 10f;

    private float zOffset;

    private void Start()
    {
        zOffset = transform.position.z;

        // Si no se asignó jugador, buscar por tag
        if (jugador == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                jugador = player.transform;
        }
    }

    private void LateUpdate()
    {
        if (jugador == null) return;

        // Calcular posición deseada siguiendo al jugador
        float clampedX = Mathf.Clamp(jugador.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(jugador.position.y, minY, maxY);

        // Sobrescribir posición en mundo (funciona aunque sea hija del Player)
        transform.position = new Vector3(clampedX, clampedY, zOffset);
    }
}
