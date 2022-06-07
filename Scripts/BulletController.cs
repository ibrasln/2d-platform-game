using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;

    PlayerHealthController playerHealthController;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void Update()
    {
        transform.position += new Vector3(-bulletSpeed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealthController.TakeDamage();
        }
        Destroy(gameObject);
    }

}
