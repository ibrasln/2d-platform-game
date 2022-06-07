using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDestroyerController : MonoBehaviour
{

    PlayerController playerController;
    TankController tankController;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        tankController = Object.FindObjectOfType<TankController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerController.transform.position.y > transform.position.y) // Çarptýðý obje Player ise ve player'ýn y'si tank'ýn y'sinden büyükse (Aþaðýdan çarpýnca kabul etmemesi için)
        {
            playerController.JumpJump();
            tankController.Damage();
            gameObject.SetActive(false);
        }
    }
}
