using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{

    [SerializeField]
    bool isGem, isCherry;

    [SerializeField]
    GameObject collectEffect;

    bool isCollected;

    LevelManager levelManager;
    UIController uIController;
    PlayerHealthController playerHealthController;

    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uIController = Object.FindObjectOfType<UIController>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {


            if (isGem)
            {
                levelManager.collectedGem++;
                isCollected = true;
                Destroy(gameObject);

                uIController.UpdateGemCount();

                Instantiate(collectEffect, transform.position, transform.rotation);
                SoundController.instance.RandomSoundEffect(7);
            }

            if (isCherry)
            {
                if(playerHealthController.availableHealth != playerHealthController.maxHealth)
                {
                    isCollected = true;
                    Destroy(gameObject);
                    playerHealthController.IncreaseHealth();
                    Instantiate(collectEffect, transform.position, transform.rotation);
                    SoundController.instance.RandomSoundEffect(4);
                }
            }
        }
    }

    

}
