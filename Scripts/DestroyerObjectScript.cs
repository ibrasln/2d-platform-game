using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerObjectScript : MonoBehaviour
{

    [SerializeField]
    GameObject deathEffect;

    PlayerController playerController;

    public float spawnChance; // Kirazin cikma sansi
    public GameObject cherry;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frog"))
        {
            collision.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, transform.position, transform.rotation);
            playerController.JumpJump();

            SoundController.instance.SoundEffect(0); // Direkt olarak bu scriptin fonksiyonuna ulaþtýk.

            float spawnRange = Random.Range(0, 100f);

            if(spawnRange <= spawnChance)
            {
                Instantiate(cherry, collision.transform.position, collision.transform.rotation);
            }
        }
    }

}
