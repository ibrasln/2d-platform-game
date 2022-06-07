using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image heart1, heart2, heart3;

    [SerializeField]
    Sprite filledHeart, halfHeart, emptyHeart;

    PlayerHealthController playerHealthController;

    [SerializeField]
    TMP_Text gemText;

    LevelManager levelManager;

    public GameObject fadeScreen;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }

    public void UpdateHealth()
    {
        switch (playerHealthController.availableHealth)
        {
            case 6:
                heart1.sprite = filledHeart;
                heart2.sprite = filledHeart;
                heart3.sprite = filledHeart;
                break;
            case 5:
                heart1.sprite = filledHeart;
                heart2.sprite = filledHeart;
                heart3.sprite = halfHeart;
                break;
            case 4:
                heart1.sprite = filledHeart;
                heart2.sprite = filledHeart;
                heart3.sprite = emptyHeart;
                break;
            case 3:
                heart1.sprite = filledHeart;
                heart2.sprite = halfHeart;
                heart3.sprite = emptyHeart;
                break;
            case 2:
                heart1.sprite = filledHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            case 1:
                heart1.sprite = halfHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;



        }
    }

    public void UpdateGemCount()
    {
        gemText.text = levelManager.collectedGem.ToString();
    }

    public void OpenFadeScreen()
    {
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, .5f);
    }

}
