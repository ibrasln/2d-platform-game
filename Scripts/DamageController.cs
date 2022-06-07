using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    PlayerHealthController playerHealthController;
    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>(); // Unity'nin icerisindeki PlayerHealthController scriptine sahip olan objeye ulasmis oluyoruz.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealthController.TakeDamage();
        }
    }
}
