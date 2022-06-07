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
        if (collision.CompareTag("Player") && playerController.transform.position.y > transform.position.y) // �arpt��� obje Player ise ve player'�n y'si tank'�n y'sinden b�y�kse (A�a��dan �arp�nca kabul etmemesi i�in)
        {
            playerController.JumpJump();
            tankController.Damage();
            gameObject.SetActive(false);
        }
    }
}
