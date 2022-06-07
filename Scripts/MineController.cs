using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    public GameObject explosionEffect;

    PlayerHealthController playerHealthController;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Explosion();
            playerHealthController.TakeDamage();
        }
    }

    public void Explosion()
    {
        Destroy(this.gameObject);
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}
