using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public int maxHealth, availableHealth;

    UIController uIController;
    PlayerController playerController;

    public float invincibilityTime = 1.5f;
    float invincibilityCounter;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameObject deathEffect;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        uIController = Object.FindObjectOfType<UIController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        availableHealth = maxHealth;
    }

    private void Update()
    {
        invincibilityCounter -= Time.deltaTime; // Yenilmezlik suresini azalttik.
        if(invincibilityCounter < 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        }
    }

    public void TakeDamage()
    {
        if(invincibilityCounter <= 0)
        {

            availableHealth--;

            if (availableHealth <= 0)
            {
                availableHealth = 0;
                gameObject.SetActive(false); // Objenin aktifligini kaldirir.
                Instantiate(deathEffect, transform.position, transform.rotation);
                SoundController.instance.SoundEffect(2);
                
            }
            else
            {
                invincibilityCounter = invincibilityTime;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

                playerController.Recoil();
                SoundController.instance.SoundEffect(1);
            }

            uIController.UpdateHealth();

        }
    }

    public void IncreaseHealth()
    {
        availableHealth++;

        if (availableHealth >= maxHealth)
        {
            availableHealth = maxHealth;
        }
        uIController.UpdateHealth();
    }

}
