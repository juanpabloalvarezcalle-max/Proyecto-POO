using System;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Assuming the player has a method called "Die" to handle death
            Debug.Log("Player has entered the lava and will die.");
        }
    }
}
